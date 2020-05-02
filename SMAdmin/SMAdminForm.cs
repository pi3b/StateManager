using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StateManager
{
    public partial class SMAdminForm : Form, IState
    {
        public SManager Manager;
        SObject so;

        public SMAdminForm()
        {
            InitializeComponent();
            延时toolStripComboBoxDelay.SelectedIndex = 0;
        }

        [DllImport("user32.dll")]
        public static extern int GetTopWindow(int hWnd);

        void DoUpdateAllSO(object obj, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((EventHandler)delegate
                {
                    DoUpdateAllSO(obj, e);
                });
            }
            else
            {
                try
                {
                    if (!Visible) return;
                    //if (this.components == null || this.IsDisposed || !this.IsHandleCreated) return;
                    string Info = so.SManager.GetThreadsInfo();

                    if (label1.Text != Info) label1.Text = Info;
                    if (启动ToolStripMenuItem.Enabled != so.SManager.Paused)
                        启动ToolStripMenuItem.Enabled = so.SManager.Paused;
                    if (停止ToolStripMenuItem.Enabled != !so.SManager.Paused)
                        停止ToolStripMenuItem.Enabled = !so.SManager.Paused;
                    //如果是初次加载，载入名称、描述
                    if (dataGridView1.RowCount == 0)
                    {
                        JArray hides = so.JObject["Hides"] as JArray;
                        foreach (SObject s in so.SManager.SOs.Values)
                        {
                            var tmp = hides.Where(o =>
                            {
                                return o.Type == JTokenType.String && (string)o == s.Name;
                            });

                            if (tmp.Count() > 0) continue;
                            int i = dataGridView1.Rows.Add();
                            DataGridViewRow dr = dataGridView1.Rows[i];
                            dr.Tag = s;
                            dr.Cells[0].Value = s.Name;
                            dr.Cells[0].ToolTipText = s.Tip;
                            //绑定单行更新事件
                            s.OnUpdate += DoUpdateOne;
                        }
                    }
                    //更新表格所有行
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        SObject s = dr.Tag as SObject;
                        DoUpdateOne(s,null);
                    }
                }
                catch { }
            }
        }

        void DoUpdateOne(object obj, EventArgs e)
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
                try
                {
                    if (!Visible) return;
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Tag.Equals(obj))
                        {
                            SObject s = dr.Tag as SObject;
                            dr.Cells[1].Value = s.Auto ? "是" : "";
                            dr.Cells[2].Value = s.State;
                            dr.Cells[3].Value = s.Status;
                            dr.Cells[4].Value = s.EngineStep;
                            dr.Cells[5].Value = s.NextState;
                            double lefttime = (s.NextCheckTime - DateTime.Now).TotalSeconds;
                            if (lefttime > 0 && s.State != "执行")
                            {
                                dr.Cells[6].Value = lefttime.ToString("0.0秒");
                            }
                            else
                            {
                                dr.Cells[6].Value = "";
                            }
                            break;
                        }
                    }
                }
                catch { }
            }
        }

        private void 激活ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                SObject so = dr.Tag as SObject;
                so.Auto = true;
                so.JObject["Auto"] = so.Auto;
                so.Update();
            }
        }

        private void 取消激活ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                SObject so = dr.Tag as SObject;
                so.Auto = false;
                so.JObject["Auto"] = so.Auto;
                so.Update();
            }
        }

        private void 复位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                SObject so = dr.Tag as SObject;
                so.ResetState("");
                so.Update();
            }       
        }

        private void 立即执行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                SObject so = dr.Tag as SObject;
                so.RepeatState(0);
                so.Update();
            }       
        }

        private void 重置脚本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                SObject so = dr.Tag as SObject;
                if (so.ScriptFile == "")
                    continue;
                so.ResetScript = true;
                so.RepeatState(0);
                so.Update();
            }       
        }

        private void 维护组件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                SObject so = dr.Tag as SObject;
                if (!so.Isolate)
                    continue;
                so.UnloadDoman = !维护组件ToolStripMenuItem.Checked;
                so.RepeatState(0);
                so.Update();
            }       
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                SObject so = dr.Tag as SObject;
                重置脚本ToolStripMenuItem.Visible = so.ScriptFile != "";
                维护组件ToolStripMenuItem.Visible = so.Isolate;
                toolStripSeparator1.Visible = so.ScriptFile != "" || so.Isolate;
                维护组件ToolStripMenuItem.Checked = so.UnloadDoman && Manager.GetDomain(so.Name) == null;
                break;
            }       
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dr = dataGridView1.Rows[e.RowIndex];
                    SObject so = dr.Tag as SObject;
                    Form Form = so.SManager.GetSOObject(so.Name) as Form;
                    if (!(Form is Form))
                    {
                        MessageBox.Show("没有界面");
                        return;
                    }
                    Action action = new Action(()=>{
                        Form.StartPosition = FormStartPosition.CenterParent;
                        Form.Show();
                        Form.BringToFront();
                        Form.WindowState = FormWindowState.Normal;                        
                    });
                    if (Form.InvokeRequired)
                    {
                        Form.Invoke(action,new object[]{});
                    }
                    else
                    {
                        action();
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void 启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            so.SManager.Paused = false;
            启动ToolStripMenuItem.Enabled = so.SManager.Paused;
            停止ToolStripMenuItem.Enabled = !so.SManager.Paused;
        }

        private void 停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            so.SManager.Paused = true;
            启动ToolStripMenuItem.Enabled = so.SManager.Paused;
            停止ToolStripMenuItem.Enabled = !so.SManager.Paused;
        }

        private void 延时toolStripComboBoxDelay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (so == null) 
                return;
            switch (延时toolStripComboBoxDelay.SelectedIndex)
            {
                case 0:
                    so.SManager.StateChangeDelay = 0;
                    break;
                case 1:
                    so.SManager.StateChangeDelay = 300;
                    break;
                case 2:
                    so.SManager.StateChangeDelay = 1000;
                    break;
            }
        }

        private void 日志ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer",Application.StartupPath+ "\\Log");

        }

        private void 脚本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer", Application.StartupPath + "\\Script");
        }

        public object Form
        {
            get {
                return this;
            }
        }

        public void StateFInit(SObject so)
        {
        }

        public void StateHandle(ref SObject so)
        {
            //return so;
        }

        public void StateInit(SObject so)
        {
            this.so = so;
            Manager = so.SManager;
            dataGridView1.Rows.Clear();
            //这里通过事件回调更新界面，也可以在StateHandle中状态处理中更新界面
            so.SManager.OnStateHandleAll += DoUpdateAllSO;
        }

    }
}
