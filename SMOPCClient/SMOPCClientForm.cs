using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPCAutomation;
using Newtonsoft.Json.Linq;
//using System.Runtime.InteropServices;

namespace StateManager
{
    public partial class SMOPCClientForm : Form,IState
    {
        public SMOPCClientForm()
        {
            InitializeComponent();
            string json = @"
		        {
			        ""Name"":""OPCClientTest"",
			        ""TypeName"":""SMOPCClient"",
			        ""OPCServerName"":""SMOPC.DA2"",
			        ""Groups"":{
				        ""G1"":{
					        ""别名1"":""PLC_S7.DB1.0:D:此示例为long(32位)类型"",//格式为：连接名称.地址:类型:注释
					        ""别名2"":""Simulate.Complete"",//服务器自带的Simulate测试项，固定格式，只有22个
				        },
			        },
		        }";
            jo = JObject.Parse(SManager.ClearJsonComment(json));
        }

        JObject jo;

        OPCServer OPCServer;
        Dictionary<string, OPCItem> LocalOPCItems = new Dictionary<string, OPCItem>();//key=GroupName+ItemName
        
        object Read(string GroupName, string ItemName)
        {
            object V, Q, T;
            LocalOPCItems[GroupName + "_" + ItemName].Read(0, out V, out Q, out T);
            
            return V;
        }

        void Write(string GroupName, string ItemName,object V)
        {
            LocalOPCItems[GroupName + "_" + ItemName].Write(V);
        }


        public object Form
        {
            get { return null; }
        }

        public void StateFInit(SObject so)
        {
            buttonDisconnect_Click(null,null);
        }

        public void StateHandle(ref SObject so)
        {
            switch (so.State)
            {
                case "":
                    buttonConnect_Click(null, null);
                    so.SetNextState("", 10000, "");
                    break;
            }
        }

        public void StateInit(SObject so)
        {
            this.jo = so.JObject;
        }

        //连接
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            lock (lockobj)
            {
                if (OPCServer == null)
                    OPCServer = new OPCServer();
                if (OPCServer.ServerState == (int)OPCServerState.OPCRunning)
                    return;
                OPCServer.Connect((string)jo["OPCServerName"]);
                int i = 1;
                foreach (KeyValuePair<string, JToken> kvp in (JObject)jo["Groups"])
                {
                    OPCGroup G = OPCServer.OPCGroups.Add(kvp.Key);
                    G.UpdateRate = 10000;
                    G.IsActive = false;
                    G.IsSubscribed = false;
                    foreach (KeyValuePair<string, JToken> kvpp in (JObject)kvp.Value)
                    {
                        //OPCItem oItem = G.OPCItems.AddItem((string)kvpp.Value, i);
                        i++;
                        //LocalOPCItems.Add(kvp.Key + "_" + kvpp.Key, oItem);
                    }
                }
                string[] items = LocalOPCItems.Keys.ToArray<string>();
                listBox1.Items.AddRange(items);
            }
        }
        object lockobj=new object();
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            lock (lockobj)
            {
                if (OPCServer == null)
                    return;
                if (OPCServer.ServerState != (int)OPCServerState.OPCRunning) 
                    return;
                foreach(OPCGroup G in OPCServer.OPCGroups)
                {
                    foreach (OPCItem I in G.OPCItems)
                    {
                    }
                    OPCServer.OPCGroups.Remove(G.Name);
                }
                OPCServer.OPCGroups.RemoveAll();
                LocalOPCItems.Clear();
                GC.Collect();
                OPCServer.Disconnect();
                GC.Collect();
                OPCServer = null;
                GC.Collect();//如果有多个group，断开后，服务器会有一个group不会释放，本程序关掉后，服务器有个连接没有释放，为什么呢？使用kep客户端不存在这情况
            }
        }
    }

    public class SMOPCClient : SMOPCClientForm
    {

    }
}
