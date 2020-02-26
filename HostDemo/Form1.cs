using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]//使脚本中可以使用本窗体对象，即：SManager.Owner
    public partial class Form1 : Form
    {
        SManager SManager; //声明一个状态机
        public Form1()
        {
            InitializeComponent();

            try
            {
                //程序启动时，创建状态机对象
                SManager = new SManager(
                        Application.StartupPath + "\\project.json"//指定so配置文件
                        );
                SManager.Start(false); //运行状态机，参数表示是否挂起实例
                SManager.Owner = this; //使脚本系统或实例成员可以访问到本窗体
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
                throw;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //程序关闭时，停止状态机，可保证正在执行的状态任务正常结束
            SManager.Stop();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            SManager.GetSOObjectForm("执行控制").Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SManager.GetSOObjectForm("连接管理").Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SManager.GetSOObjectForm("Alarm").Show();
        }

    }
}
