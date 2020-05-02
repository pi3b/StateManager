﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Newtonsoft.Json;

namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class SMAlarmForm : Form, IState
    {
        public SqliteFileDB DB;
        object sda; DataTable dt;
        public SMAlarmForm()
        {
            InitializeComponent();
            DB = new SqliteFileDB();
            string DllPath = Application.ExecutablePath;
            string DBFileName = System.IO.Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().Location, ".db");
            if (!System.IO.File.Exists(DBFileName))
                throw new Exception("找不到文件："+DBFileName);
            DB.Connect(DBFileName);
        }

        public void ReLoadList()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((EventHandler)delegate
                {
                    ReLoadList();
                });
            }
            else
            {
                if (toolStripComboBox1.SelectedIndex != 1)
                {
                    string FileterActive = "AND ACTIVE=1";
                    DB.GetDataTableStatic(ref sda, ref dt, string.Format("SELECT ID 序号,SONAME 工位,MSG 描述,ASKTIME 发生时间,REPLY 处理方式,REPLYTIME 处理时间,(CASE ACTIVE WHEN 1 THEN '是' ELSE ' ' END) 有效 FROM ALARM WHERE 1=1 {0} ORDER BY ID", FileterActive));
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["描述"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridView1.Columns["处理方式"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        //string ID = dr.Cells[0].Value.ToString();
                        if (dr.Cells[4].Value.ToString() == "") //REPLY 处理方式
                        {
                            dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192, 192);
                        }
                        else
                        {
                            dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 255, 192);
                        }
                    }
                }
                else
                {
                    string FileterActive = "";
                    DB.GetDataTableStatic(ref sda, ref dt, string.Format("SELECT ID 序号,SONAME 工位,MSG 描述,ASKTIME 发生时间,REPLY 处理方式,REPLYTIME 处理时间,(CASE ACTIVE WHEN 1 THEN '是' ELSE ' ' END) 有效 FROM ALARM WHERE 1=1 {0} ORDER BY ID", FileterActive));
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["描述"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridView1.Columns["处理方式"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[6].Value.ToString() == "是")
                        {
                            if (dr.Cells[4].Value.ToString() == "") //REPLY 处理方式
                            {
                                dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192, 192);
                            }
                            else
                            {
                                dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 255, 192);
                            }
                        }
                        else
                        {
                            dr.DefaultCellStyle.BackColor = SystemColors.Control;
                        }
                    }
                }
                dataGridView1.Refresh();
                dataGridView1.ClearSelection();
                //dataGridView1.Invalidate();
            }
        }

        private void SMAlarmForm_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReLoadList();
        }

        private void 测试报警ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAlarm("SONAME", "State","TEST MSG", "选择项1,选择项2");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            处理ToolStripMenuItem_Click(null,null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                int ID = Convert.ToInt32( r.Cells[0].Value.ToString());

                if (toolStripComboBox1.SelectedIndex == 1 && r.Cells[6].Value.ToString() != "是") return;

                ShowReSolveFrom(ID);

                break;
            }
            ReLoadList();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReLoadList();
        }
        
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                int ID = Convert.ToInt32(r.Cells[0].Value.ToString());
                DeleteAlarm(ID);
            }
            ReLoadList();
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB.Excute("DELETE FROM ALARM;");
            ReLoadList();
        }

        public string ReadAlarmAsk(int ID)
        {
            return (string)DB.ReadFirstValue(string.Format("SELECT ASK FROM ALARM WHERE ID='{0}';", ID));
        }
        public void SetAlarmReply(int ID, string REPLY)
        {
            DB.Excute(string.Format("UPDATE ALARM SET REPLY='{0}',REPLYTIME=DATETIME('now','localtime') WHERE ID={1};", REPLY, ID));
        }
        public void DeleteAlarm(int ID)
        {
            DB.Excute(string.Format("DELETE FROM ALARM WHERE ID={0};", ID));
        }
        public void ShowReSolveFrom(int ID)
        {
            string SONAME = "",SOSTATE = "", MSG = "", ASK = "", ASKTIME = "", REPLY = "";
            SQLiteDataReader Reader = DB.ReadReader(string.Format("SELECT SONAME,SOSTATE,MSG,ASK,ASKTIME,REPLY,REPLYTIME FROM ALARM WHERE ID={0};", ID));
            if (Reader.Read())
            {
                SONAME = Reader["SONAME"].ToString();
                SOSTATE = Reader["SOSTATE"].ToString();
                MSG = Reader["MSG"].ToString();
                ASK = Reader["ASK"].ToString();
                ASKTIME = Reader["ASKTIME"].ToString();
                REPLY = Reader["REPLY"].ToString();
            }
            Reader.Close();
            SMAlarmReplyForm AlarmReplyForm = new SMAlarmReplyForm();
            AlarmReplyForm.SetData(SONAME,SOSTATE, MSG, ASK, ASKTIME, REPLY);
            if (AlarmReplyForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                REPLY = AlarmReplyForm.Result;
                SetAlarmReply(ID, REPLY);
            }
            AlarmReplyForm.Close();
        }

        bool IsAutoPopUp = false;
        object LockObj = new object();
        /// <summary>
        /// 添加报警信息
        /// </summary>
        /// <param name="SONAME">工位名称</param>
        /// <param name="SOSTATE">工位状态</param>
        /// <param name="Msg">提示信息</param>
        /// <param name="Ask">逗号间隔的选项供用户选择</param>
        public void AddAlarm(string SONAME, string SOSTATE, string Msg, string Ask)
        {
            DeActiveAlarm(SONAME);
            DB.Excute(string.Format("INSERT INTO ALARM(SONAME,SOSTATE,MSG,ASK,ASKTIME) VALUES('{0}','{1}','{2}','{3}',DATETIME('now','localtime'));", SONAME, SOSTATE, Msg, Ask));
            ReLoadList();
            int ID = (int)DB.ReadFirstValue(string.Format("SELECT ID FROM ALARM WHERE SONAME='{0}' AND ACTIVE=1 ORDER BY ID DESC;", SONAME));
            if (IsAutoPopUp)
                lock (LockObj)
                {
                    ShowReSolveFrom(ID);
                }
            ReLoadList();
        }
        /// <summary>
        /// 添加报警信息
        /// </summary>
        /// <param name="so">状态机实例</param>
        /// <param name="Msg">提示信息</param>
        /// <param name="Ask">逗号间隔的选项供用户选择</param>
        public void AddSOAlarm(SObject so, string Msg, string Ask)
        {
            AddAlarm(so.Name, so.State, Msg, Ask);
        }
        public string ReadAlarmReply(string SONAME)
        {
            return DB.ReadFirstValue(string.Format("SELECT REPLY FROM ALARM WHERE SONAME='{0}' AND ACTIVE=1 ORDER BY ID DESC;", SONAME)).ToString();
        }
        public void DeActiveAlarm(string SONAME)
        {
            DB.Excute(string.Format("UPDATE ALARM SET ACTIVE=0 WHERE SONAME='{0}';", SONAME));
        }

        public void StateFInit(SObject so)
        {
            DB.Con.Close();
        }
        public void StateHandle(ref SObject so)
        {
        }
        public void StateInit(SObject so)
        {
            if (so.JObject.ContainsKey("IsAutoPopUp"))
                IsAutoPopUp = (bool)so.JObject["IsAutoPopUp"];
        }
        public object Form
        {
            get { return this; }
        }

    }
}
