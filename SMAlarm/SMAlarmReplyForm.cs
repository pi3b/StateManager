using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StateManager
{
    public partial class SMAlarmReplyForm : Form
    {
        public string Result;
        public SMAlarmReplyForm()
        {
            InitializeComponent();
        }
        public void SetData(string SONAME, string MSG, string ASK, string ASKTIME, string REPLY)
        {
            string[] Asks = ASK.Split(new char[] { ',' });
            labelSONAME.Text = SONAME;
            labelAlarmTime.Text = ASKTIME;
            richTextBoxMSG.Text = MSG;
            listBox1.Items.Clear();
            listBox1.Items.Add("");
            listBox1.Items.AddRange(Asks);
            listBox1.SelectedIndex = listBox1.Items.IndexOf(REPLY);

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Result = listBox1.Text;
        }

        private void AlarmReplyForm_Load(object sender, EventArgs e)
        {
            Result = "";
        }

        private void SMAlarmReplyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
