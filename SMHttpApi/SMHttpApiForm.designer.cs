namespace StateManager
{
    partial class SMHTTPApiForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxClientSendData = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBoxClientReceivedData = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxClientViewMode = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxServerForceResponce = new System.Windows.Forms.CheckBox();
            this.buttonServerStop = new System.Windows.Forms.Button();
            this.textBoxServerRequest = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxServerResponse = new System.Windows.Forms.TextBox();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonServerStart = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(832, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUrl.Location = new System.Drawing.Point(45, 11);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(781, 21);
            this.textBoxUrl.TabIndex = 1;
            this.textBoxUrl.Text = "http://localhost:666";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "参数：";
            // 
            // textBoxClientSendData
            // 
            this.textBoxClientSendData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClientSendData.Location = new System.Drawing.Point(45, 38);
            this.textBoxClientSendData.Multiline = true;
            this.textBoxClientSendData.Name = "textBoxClientSendData";
            this.textBoxClientSendData.Size = new System.Drawing.Size(781, 123);
            this.textBoxClientSendData.TabIndex = 4;
            this.textBoxClientSendData.Text = "{\"action\":\"jk_lsccartout\",\"pos\":1}";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(944, 581);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(936, 555);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "客户端";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBoxClientReceivedData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 182);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(45, 0, 100, 20);
            this.panel2.Size = new System.Drawing.Size(930, 370);
            this.panel2.TabIndex = 4;
            // 
            // richTextBoxClientReceivedData
            // 
            this.richTextBoxClientReceivedData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxClientReceivedData.Location = new System.Drawing.Point(45, 0);
            this.richTextBoxClientReceivedData.Name = "richTextBoxClientReceivedData";
            this.richTextBoxClientReceivedData.ReadOnly = true;
            this.richTextBoxClientReceivedData.Size = new System.Drawing.Size(785, 350);
            this.richTextBoxClientReceivedData.TabIndex = 2;
            this.richTextBoxClientReceivedData.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxClientViewMode);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxClientSendData);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxUrl);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 179);
            this.panel1.TabIndex = 3;
            // 
            // checkBoxClientViewMode
            // 
            this.checkBoxClientViewMode.AutoSize = true;
            this.checkBoxClientViewMode.Location = new System.Drawing.Point(838, 104);
            this.checkBoxClientViewMode.Name = "checkBoxClientViewMode";
            this.checkBoxClientViewMode.Size = new System.Drawing.Size(72, 16);
            this.checkBoxClientViewMode.TabIndex = 16;
            this.checkBoxClientViewMode.Text = "监听模式";
            this.checkBoxClientViewMode.UseVisualStyleBackColor = true;
            this.checkBoxClientViewMode.CheckedChanged += new System.EventHandler(this.checkBoxClientViewMode_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE"});
            this.comboBox1.Location = new System.Drawing.Point(832, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(78, 20);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "POST";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "返回：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBoxServerForceResponce);
            this.tabPage2.Controls.Add(this.buttonServerStop);
            this.tabPage2.Controls.Add(this.textBoxServerRequest);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBoxServerResponse);
            this.tabPage2.Controls.Add(this.textBoxServerPort);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.buttonServerStart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(936, 555);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "服务端";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBoxServerForceResponce
            // 
            this.checkBoxServerForceResponce.AutoSize = true;
            this.checkBoxServerForceResponce.Location = new System.Drawing.Point(55, 224);
            this.checkBoxServerForceResponce.Name = "checkBoxServerForceResponce";
            this.checkBoxServerForceResponce.Size = new System.Drawing.Size(72, 16);
            this.checkBoxServerForceResponce.TabIndex = 15;
            this.checkBoxServerForceResponce.Text = "强制内容";
            this.checkBoxServerForceResponce.UseVisualStyleBackColor = true;
            this.checkBoxServerForceResponce.CheckedChanged += new System.EventHandler(this.checkBoxServerForceResponce_CheckedChanged);
            // 
            // buttonServerStop
            // 
            this.buttonServerStop.Enabled = false;
            this.buttonServerStop.Location = new System.Drawing.Point(209, 6);
            this.buttonServerStop.Name = "buttonServerStop";
            this.buttonServerStop.Size = new System.Drawing.Size(78, 31);
            this.buttonServerStop.TabIndex = 14;
            this.buttonServerStop.Text = "关闭";
            this.buttonServerStop.UseVisualStyleBackColor = true;
            this.buttonServerStop.Click += new System.EventHandler(this.buttonServerStop_Click);
            // 
            // textBoxServerRequest
            // 
            this.textBoxServerRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerRequest.Location = new System.Drawing.Point(55, 56);
            this.textBoxServerRequest.Multiline = true;
            this.textBoxServerRequest.Name = "textBoxServerRequest";
            this.textBoxServerRequest.ReadOnly = true;
            this.textBoxServerRequest.Size = new System.Drawing.Size(781, 159);
            this.textBoxServerRequest.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "回复：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "请求：";
            // 
            // textBoxServerResponse
            // 
            this.textBoxServerResponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerResponse.Location = new System.Drawing.Point(55, 250);
            this.textBoxServerResponse.Multiline = true;
            this.textBoxServerResponse.Name = "textBoxServerResponse";
            this.textBoxServerResponse.Size = new System.Drawing.Size(781, 264);
            this.textBoxServerResponse.TabIndex = 8;
            this.textBoxServerResponse.TextChanged += new System.EventHandler(this.textBoxServerResponse_TextChanged);
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(55, 12);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(55, 21);
            this.textBoxServerPort.TabIndex = 7;
            this.textBoxServerPort.Text = "666";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "端口：";
            // 
            // buttonServerStart
            // 
            this.buttonServerStart.Location = new System.Drawing.Point(125, 6);
            this.buttonServerStart.Name = "buttonServerStart";
            this.buttonServerStart.Size = new System.Drawing.Size(78, 31);
            this.buttonServerStart.TabIndex = 5;
            this.buttonServerStart.Text = "开启";
            this.buttonServerStart.UseVisualStyleBackColor = true;
            this.buttonServerStart.Click += new System.EventHandler(this.buttonServerStart_Click);
            // 
            // SMHTTPApiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 581);
            this.Controls.Add(this.tabControl1);
            this.Name = "SMHTTPApiForm";
            this.Text = "HttpApi测试工具";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxClientSendData;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxServerRequest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxServerResponse;
        private System.Windows.Forms.TextBox textBoxServerPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonServerStart;
        private System.Windows.Forms.Button buttonServerStop;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBoxServerForceResponce;
        private System.Windows.Forms.CheckBox checkBoxClientViewMode;
        private System.Windows.Forms.RichTextBox richTextBoxClientReceivedData;

    }
}

