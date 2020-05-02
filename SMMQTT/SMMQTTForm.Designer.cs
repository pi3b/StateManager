namespace StateManager
{
    partial class SMMQTTForm
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
            this.txtReceiveMessage = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPubTopic = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.断开 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSubTopic = new System.Windows.Forms.RichTextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtSendMessage = new System.Windows.Forms.RichTextBox();
            this.连接 = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPsw = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开本地服务端";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtReceiveMessage
            // 
            this.txtReceiveMessage.Location = new System.Drawing.Point(378, 33);
            this.txtReceiveMessage.Name = "txtReceiveMessage";
            this.txtReceiveMessage.Size = new System.Drawing.Size(443, 373);
            this.txtReceiveMessage.TabIndex = 3;
            this.txtReceiveMessage.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPubTopic);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.断开);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtSubTopic);
            this.groupBox1.Controls.Add(this.txtIp);
            this.groupBox1.Controls.Add(this.txtSendMessage);
            this.groupBox1.Controls.Add(this.连接);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.txtPsw);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtClientId);
            this.groupBox1.Location = new System.Drawing.Point(24, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 356);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户端";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 204);
            this.label1.TabIndex = 6;
            this.label1.Text = "目标IP\r\n\r\n目标端口\r\n\r\n账号\r\n\r\n密码\r\n\r\n客户端ID\r\n\r\n订阅主题\r\n\r\n\r\n\r\n发布主题\r\n\r\n发布内容";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPubTopic
            // 
            this.txtPubTopic.Location = new System.Drawing.Point(72, 146);
            this.txtPubTopic.Name = "txtPubTopic";
            this.txtPubTopic.Size = new System.Drawing.Size(195, 35);
            this.txtPubTopic.TabIndex = 4;
            this.txtPubTopic.Text = "testTopic";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(273, 146);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "订阅";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // 断开
            // 
            this.断开.Location = new System.Drawing.Point(273, 104);
            this.断开.Name = "断开";
            this.断开.Size = new System.Drawing.Size(58, 36);
            this.断开.TabIndex = 6;
            this.断开.Text = "断开";
            this.断开.UseVisualStyleBackColor = true;
            this.断开.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(246, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "发布";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSubTopic
            // 
            this.txtSubTopic.Location = new System.Drawing.Point(72, 192);
            this.txtSubTopic.Name = "txtSubTopic";
            this.txtSubTopic.Size = new System.Drawing.Size(262, 22);
            this.txtSubTopic.TabIndex = 4;
            this.txtSubTopic.Text = "testTopic";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(72, 21);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(88, 21);
            this.txtIp.TabIndex = 5;
            this.txtIp.Text = "127.0.0.1";
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(72, 220);
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(262, 85);
            this.txtSendMessage.TabIndex = 4;
            this.txtSendMessage.Text = "test";
            // 
            // 连接
            // 
            this.连接.Location = new System.Drawing.Point(209, 104);
            this.连接.Name = "连接";
            this.连接.Size = new System.Drawing.Size(58, 36);
            this.连接.TabIndex = 6;
            this.连接.Text = "连接";
            this.连接.UseVisualStyleBackColor = true;
            this.连接.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(72, 70);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(88, 21);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.Text = "test";
            // 
            // txtPsw
            // 
            this.txtPsw.Location = new System.Drawing.Point(72, 94);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.Size = new System.Drawing.Size(88, 21);
            this.txtPsw.TabIndex = 5;
            this.txtPsw.Text = "test";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(72, 46);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(62, 21);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "1883";
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(72, 118);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(47, 21);
            this.txtClientId.TabIndex = 5;
            this.txtClientId.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "日志";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 422);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtReceiveMessage);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox txtReceiveMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox txtSendMessage;
        private System.Windows.Forms.RichTextBox txtSubTopic;
        private System.Windows.Forms.RichTextBox txtPubTopic;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPsw;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button 连接;
        private System.Windows.Forms.Button 断开;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

