using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MQTTnet;
using MQTTnet.Client;　　　　　//客户端需要用到
using MQTTnet.Client.Options;  //具体连接时需要用到的属性,ID的名称,要连接Server的名称,接入时用到的账号和密码,掉线时是否重新清除原有名称,还有许多...
using MQTTnet.Server.Status;
using MQTTnet.Protocol;
using MQTTnet.Client.Receiving;　　　　//接收
using MQTTnet.Client.Disconnecting;　　//断线
using MQTTnet.Client.Connecting;　　　　//连接
using MQTTnet.Server;
using System.Threading;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class SMMQTTForm : Form,IState
    {
        public SMMQTTForm()
        {
            InitializeComponent();
        }


        #region 服务端

        private IMqttServer mqttServer = new MqttFactory().CreateMqttServer();
        public delegate string deleHandleMessage(string topic, string msg);
        public deleHandleMessage ServerOnHandleMessage;
        public bool ServerActive = false;
        public int ServerPort = 1883;
        public void ServerStart()
        {
            mqttServer.StopAsync().Wait();
            MqttServerOptionsBuilder optionBuilder = new MqttServerOptionsBuilder()
                .WithConnectionBacklog(1000)
                .WithDefaultEndpointPort(ServerPort);
            MqttServerOptions option = optionBuilder.Build() as MqttServerOptions;
            option.EnablePersistentSessions = true;
            option.MaxPendingMessagesPerClient = 1000;
            option.ConnectionValidator = new MqttServerConnectionValidatorDelegate((MqttConnectionValidatorContext c) =>
                {
                    if (c.Username == "test")
                    {
                        c.ReasonCode = MqttConnectReasonCode.Success;
                    }
                    else
                        c.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                }
            );
            mqttServer.StartAsync(option).Wait();
            ServerActive = true;
            //SManager.TextBoxAutoScrollPrintLine(txtReceiveMessage, "服务端已打开！");
            mqttServer.UseApplicationMessageReceivedHandler((MqttApplicationMessageReceivedEventArgs ee) =>
            {
                Invoke(new Action(() =>
                {
                    if (ServerOnHandleMessage != null)
                        ServerOnHandleMessage.Invoke(ee.ApplicationMessage.Topic, ee.ApplicationMessage.ConvertPayloadToString());
                    SManager.TextBoxAutoScrollPrintLine(txtReceiveMessage, "服务端收到消息:" + Encoding.UTF8.GetString(ee.ApplicationMessage.Payload));
                }));

            }
            );
        }
        public void ServerStop()
        {
            ServerActive = false;
            mqttServer.StopAsync().Wait();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServerStart();
        }
        
        #endregion

        
        #region 客户端

        private IMqttClient mqttClient = new MqttFactory().CreateMqttClient();
        //发布内容
        public void Publish(string topic, string inputString)
        {
            mqttClient.PublishAsync(new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(inputString)
                .WithExactlyOnceQoS()
                .WithRetainFlag()
                .Build()
                ).Wait();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string topic = txtPubTopic.Text.Trim();
            string inputString = txtSendMessage.Text.Trim();
            if (string.IsNullOrEmpty(topic))
            {
                MessageBox.Show("发布主题不能为空！");
                return;
            }
            try
            {
                Publish(topic, inputString);
            }
            catch (Exception ex)
            {
                SManager.TextBoxAutoScrollPrintLine(txtReceiveMessage, "发布主题失败！" + Environment.NewLine + ex.Message + Environment.NewLine);
            }
        }
        //订阅
        public void Subscribe(string topic)
        {
            mqttClient.SubscribeAsync(new TopicFilterBuilder()
              .WithTopic(topic)
              .WithAtMostOnceQoS()
              .Build()
              ).Wait();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string topic = txtSubTopic.Text.Trim();
            if (string.IsNullOrEmpty(topic))
            {
                MessageBox.Show("订阅主题不能为空！");
                return;
            }
            if (!mqttClient.IsConnected)
            {
                MessageBox.Show("MQTT客户端尚未连接！");
                return;
            }
            Subscribe(topic);
            SManager.TextBoxAutoScrollPrintLine(txtReceiveMessage, string.Format("已订阅[{0}]主题.", topic));
        }
        //连接
        public void Connect(string IP="127.0.0.1", int Port=1883, string Username="test", string Password="", string ClientID="")
        {
            mqttClient.ConnectAsync(new MqttClientOptionsBuilder()
                .WithTcpServer(txtIp.Text, Convert.ToInt32(txtPort.Text))
                .WithCredentials(txtUsername.Text, txtPsw.Text)
                .WithClientId(txtClientId.Text)
                .Build()
                ).Wait();
        }
        public deleHandleMessage ClientOnHandleMessage;
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (!mqttClient.IsConnected)
            {
                try
                {
                    Connect(txtIp.Text, Convert.ToInt32(txtPort.Text), txtUsername.Text, txtPsw.Text, txtClientId.Text);

                    if (mqttClient.IsConnected)
                    {
                        SManager.TextBoxAutoScrollPrintLine(txtReceiveMessage,"连接成功！");
                    }
                    else
                    {
                        SManager.TextBoxAutoScrollPrintLine(txtReceiveMessage, "连接失败！");
                    }
                    mqttClient.UseApplicationMessageReceivedHandler(ee =>
                    {
                        Invoke(new Action(() =>
                        {
                            if (ClientOnHandleMessage != null)
                                ClientOnHandleMessage(ee.ApplicationMessage.Topic, ee.ApplicationMessage.ConvertPayloadToString());

                            SManager.TextBoxAutoScrollPrintLine(txtReceiveMessage, "收到订阅消息:" + Encoding.UTF8.GetString(ee.ApplicationMessage.Payload));
                        }));

                    });
                }
                catch (Exception ex)
                {
                    Invoke((new Action(() =>
                    {
                        SManager.TextBoxAutoScrollPrintLine(txtReceiveMessage, "连接失败！" + ex.Message);
                    })));
                }
            }
        }
        //断开
        public void Disconnect()
        {
            mqttClient.DisconnectAsync().Wait();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Disconnect();
            SManager.TextBoxAutoScrollPrintLine(txtReceiveMessage, "已断开MQTT连接！");
        }
        
        #endregion

        public object Form
        {
            get { return this; }
        }

        public void StateFInit(SObject so)
        {
        }

        public void StateHandle(ref SObject so)
        {
            switch (so.State)
            {
                case "":
                    so.SetNextState("开启MQTT服务");
                    break;
                case "开启MQTT服务":
                    if (!ServerActive)
                    {
                        if(so.JObject.ContainsKey("ServerPort"))
                            ServerPort = (int)so.JObject["ServerPort"];
                        ServerStart();
                    }
                    so.RepeatState(10000);
                    break;
            }
        }

        public void StateInit(SObject so)
        {
        }
    }
    public class SMMQTT : SMMQTTForm
    {
    }
}
