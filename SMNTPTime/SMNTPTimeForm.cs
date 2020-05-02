using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace StateManager
{
    public partial class SMNTPTimeForm : Form,IState
    {
        public SMNTPTimeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            SYSTEMTIME st = new SYSTEMTIME();
            if (checkBox1.Checked)
            {
                st.FromLocalTime();
                Print(st.ToDateTime().ToString("系统时间：yyyy-MM-dd HH:mm:ss:fff"));
            }
            if (checkBox2.Checked)
            {
                st.FromNTPServer(textBox1.Text);
                Print(st.ToDateTime().ToString("NTP 时间：yyyy-MM-dd HH:mm:ss:fff"));
            }
            dateTimePicker1.Value = st.ToDateTime();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SYSTEMTIME st = new SYSTEMTIME();
            st.FromDateTime(dateTimePicker1.Value);
            st.SetLocalTime();
            Print(st.ToDateTime().ToString("设置为时间：yyyy-MM-dd HH:mm:ss:fff"));
        }

        public object Form
        {
            get { return this; }
        }

        public void StateFInit(SObject so)
        {
        }

        int Interval = 86400000;
        public void StateHandle(ref SObject so)
        {
            switch (so.State)
            {
                case "":
                    so.SetNextState("从NTP服务器同步时间",Interval);
                    break;
                case "从NTP服务器同步时间":
                    button1_Click(null, null);
                    button2_Click(null, null);
                    break;
            }
        }

        public void StateInit(SObject so)
        {
            if (so.JObject.ContainsKey("Interval"))
            {
                Interval = (int)so.JObject["Interval"];
            }
        }

        private void buttonNTPServer_Click(object sender, EventArgs e)
        {
            Print("开启NTP服务器...");
            SYSTEMTIME.StartNTPServer(Str =>
            {
                Print(Str);
            });
            Print("开启NTP服务器完成");
        }

        private void buttonNTPServerStop_Click(object sender, EventArgs e)
        {
            Print("关闭NTP服务器...");
            SYSTEMTIME.StopNTPServer(Str =>
            {
                Print(Str);
            });
            Print("关闭NTP服务器完成");
        }

        void Print(string Str)
        {
            SManager.TextBoxAutoScrollPrintLine(richTextBox1, Str);
        }



    }

    public class SMNTPTime : SMNTPTimeForm
    {
    }

}
