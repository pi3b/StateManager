using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StateManager;

namespace Demo.Logics
{
    public partial class type1 : Form,ILogic
    {
        public type1()
        {
            InitializeComponent();
        }

        public void HandleState(SObject so)  
        {
            switch (so.State)
            {
                case "检测网络":
                    foreach (SMConnection Con in (so.PlugIn.GetPlugIn("连接管理") as SMConnections).Cons.Values)
                    {
                        if (!so.SManager.wPaused && so.Auto && !Con.Connected && Con.AutoReConnect)
                        {
                            so.Status = string.Format("断线重连：{0}", Con.Tip);
                            try
                            {
                                if(!Con.Connected)
                                    Con.Connect();
                            }
                            catch (Exception E)
                            {
                                Log.SO(so, string.Format("{0}\t{1}", Con.Tip, E.Message));
                            }
                        }
                        if (Con.Connected)
                        {
                            //if (Con.ID == "2")
                            //{
                            //    bool b = (Con as dynamic).ReadBool("M100");
                            //    MessageBox.Show(b.ToString());
                            //    (Con as dynamic).MC.Write("M100", !b);

                            //    b = (Con as dynamic).HslContent((Con as dynamic).MC.ReadBool("M100"));
                            //    MessageBox.Show(b.ToString());

                            //}
                        }
                    }
                    so.SetNextState("检测网络", 5000, "");
                    break;
                case "":
                    so.SetNextState("检测网络", 0, "");
                    break;
            }
        }

        public void Init(SObject so)
        {

        }

        public void FInit(SObject so)
        {

        }
    }
}
