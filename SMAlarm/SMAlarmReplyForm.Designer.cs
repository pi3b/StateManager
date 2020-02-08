namespace StateManager
{
    partial class SMAlarmReplyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSONAME = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.richTextBoxMSG = new System.Windows.Forms.RichTextBox();
            this.labelAlarmTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 153);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(514, 178);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择处理方式：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "报警信息:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "报警工位:";
            // 
            // labelSONAME
            // 
            this.labelSONAME.AutoSize = true;
            this.labelSONAME.BackColor = System.Drawing.Color.Lime;
            this.labelSONAME.Location = new System.Drawing.Point(89, 5);
            this.labelSONAME.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSONAME.Name = "labelSONAME";
            this.labelSONAME.Size = new System.Drawing.Size(32, 16);
            this.labelSONAME.TabIndex = 5;
            this.labelSONAME.Text = "XXX";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(419, 339);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(98, 43);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.TabStop = false;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // richTextBoxMSG
            // 
            this.richTextBoxMSG.Location = new System.Drawing.Point(4, 49);
            this.richTextBoxMSG.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxMSG.Name = "richTextBoxMSG";
            this.richTextBoxMSG.Size = new System.Drawing.Size(513, 91);
            this.richTextBoxMSG.TabIndex = 7;
            this.richTextBoxMSG.TabStop = false;
            this.richTextBoxMSG.Text = "";
            // 
            // labelAlarmTime
            // 
            this.labelAlarmTime.AutoSize = true;
            this.labelAlarmTime.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelAlarmTime.Location = new System.Drawing.Point(299, 27);
            this.labelAlarmTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAlarmTime.Name = "labelAlarmTime";
            this.labelAlarmTime.Size = new System.Drawing.Size(32, 16);
            this.labelAlarmTime.TabIndex = 9;
            this.labelAlarmTime.Text = "XXX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "报警时间:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(9, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(498, 148);
            this.listBox1.TabIndex = 3;
            // 
            // SMAlarmReplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(523, 395);
            this.Controls.Add(this.labelAlarmTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBoxMSG);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelSONAME);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SMAlarmReplyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报警处理";
            this.Load += new System.EventHandler(this.AlarmReplyForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SMAlarmReplyForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSONAME;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.RichTextBox richTextBoxMSG;
        private System.Windows.Forms.Label labelAlarmTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
    }
}