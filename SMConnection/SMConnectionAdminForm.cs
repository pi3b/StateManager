using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
//using HslCommunication;
//using HslCommunication.Profinet;
//using HslCommunication.Profinet.Siemens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using System.Diagnostics;
using System.Collections;
using System.Threading;
//using System.Runtime.InteropServices;

namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class SMConnectionAdminForm : Form, IState
    {
        public Dictionary<string, SObject> conSOs = new Dictionary<string, SObject>();
        SObject so;
        public object GetConSO(string name) //Com不支持字典方式访问，所以要用这个
        {
            return conSOs[name];
        }

        public SMConnectionAdminForm()
        {
            InitializeComponent();
        }

        public void ReLoadList()
        {
            dataGridView1.Rows.Clear();

            foreach (SObject soo in conSOs.Values)
            {
                int r = dataGridView1.Rows.Add(new DataGridViewRow());
                DataGridViewRow dr = dataGridView1.Rows[r];
                dr.Cells[0].Value = soo.Name;
                dr.Cells[1].Value = soo.Tip;
                dr.Cells[2].Value = soo.TypeName;
                if (!(soo.Manager.GetSOObject(soo.Name) is SMConnection)) continue;
                SMConnection Con = soo.Manager.GetSOObject(soo.Name) as SMConnection;
                dr.Cells[3].Value = Con.Simulate ? Con.ConnectionStringSimu : Con.ConnectionString;
                dr.Cells[4].Value = soo.Auto;
                dr.Cells[5].Value = Con.Simulate;
                dr.Cells[6].Value = soo.Status ;
                dr.Tag = soo;
            }
            dataGridView1.ClearSelection();

            foreach (SObject conSO in conSOs.Values)
            {
                //绑定更新事件
                conSO.OnUpdate += DoUpdateOne;
            }
        }
        public void DoUpdateOne(object obj,EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((EventHandler)delegate
                {
                    DoUpdateOne(obj, e);
                });
            }
            else
            {
                if (!Visible) return;
                try
                {
                    SObject soo = obj as SObject;
                    SMConnection Con = so.Manager.GetSOObject(soo.Name) as SMConnection;
                    if (Con != null)
                    {
                        foreach (DataGridViewRow dr in dataGridView1.Rows)
                        {
                            if (dr.Tag.Equals(soo))
                            {
                                dr.Cells[3].Value = Con.Simulate ? Con.ConnectionStringSimu : Con.ConnectionString;
                                dr.Cells[4].Value = soo.Auto;
                                dr.Cells[5].Value = Con.Simulate;
                                dr.Cells[6].Value = soo.Status;
                                if (soo.Status !=null && soo.Status.Contains(".."))
                                {
                                    dr.Cells[6].Style.BackColor = Color.LightBlue;
                                }
                                else
                                {
                                    dr.Cells[6].Style.BackColor = Color.Empty;
                                }
                                dataGridView1.Refresh();
                                break;
                            }
                        }
                    }
                }
                catch (Exception E)
                {

                }
            }
        }
        private void 连接_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                SObject soo = dr.Tag as SObject;
                if (soo != null)
                {
                    try
                    {
                        (so.Manager.GetSOObject(soo.Name) as SMConnection).Connect();
                    }
                    catch
                    {
                    }
                }
            }
        }
        private void 断开_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                SObject soo = dr.Tag as SObject;
                if (soo != null)
                {
                    try
                    {
                        (so.Manager.GetSOObject(soo.Name) as SMConnection).DisConnect();
                    }
                    catch
                    {
                    }
                }
            }
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                dataGridView1.EndEdit();
                DataGridViewRow dr = dataGridView1.Rows[e.RowIndex];
                SObject soo = dr.Tag as SObject;
                if (soo != null)
                {
                    soo.Auto = (bool)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                    (so.Manager.GetSOObject(soo.Name) as SMConnection).Simulate = (bool)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
                    soo.JObject["Auto"] = soo.Auto;
                    soo.JObject["Simulate"] = (so.Manager.GetSOObject(soo.Name) as SMConnection).Simulate;
                    soo.Update();
                }
            }
            else
                dataGridView1.ClearSelection();
        }
        private void 重新加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReLoadList();
        }

        public void StateInit(SObject so)
        {
            this.so = so;
            foreach (JToken jO in so.JObject["Connections"])
            {
                SObject conso = so.Manager.SOs[(string)jO] as SObject;
                if (conso == null)
                    throw new Exception(string.Format("连接管理中的[{0}]没有定义!", (string)jO));

                conSOs.Add((string)jO, conso);
            }

            Name = (string)so.JObject["Tip"];
        }

        public void StateFInit(SObject so)
        {
            conSOs.Clear();
        }

        public object Form
        {
            get
            {
                return this;
            }
        }

        public void StateHandle(ref SObject so)
        {
            //自动重连功能写在连接基类中了，由各连接实例来实现多连接的同时进行，实现线程层面的面向对象）
            //return so;
        }

        private void SMConnectionAdminForm_Shown(object sender, EventArgs e)
        {
            ReLoadList();
        }

    }
}
