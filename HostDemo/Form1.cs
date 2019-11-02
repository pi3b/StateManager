using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StateManager;
using System.Threading;

namespace Demo
{
    public partial class Form1 : Form
    {
        SManager SManager; //声明一个状态机
        public Form1()
        {
            InitializeComponent();

            //程序启动时，创建状态机对象
            SManager = new SManager(
                    Application.StartupPath + "\\project.so"//指定so配置文件
                    ,System.Reflection.Assembly.GetExecutingAssembly()
                    );                 
            SManager.Start(false);                                 //运行状态机，参数表示是否暂停实例
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //程序关闭时，停止状态机，可保证正在执行的状态任务正常结束
            SManager.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //不暂停实例
            SManager.wPaused = false;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            //暂停实例
            SManager.wPaused = true;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            //状态机自带的 实例列表管理界面
            (SManager.SPlugIn.GetPlugIn("执行控制") as IPlugIn).PlugInForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //状态机自带的网络连接管理界面
            (SManager.SPlugIn.GetPlugIn("连接管理") as IPlugIn).PlugInForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
