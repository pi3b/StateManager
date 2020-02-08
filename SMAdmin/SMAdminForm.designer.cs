namespace StateManager
{
    partial class SMAdminForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.激活ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消激活ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复位ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.立即执行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.重置脚本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.维护组件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.延时toolStripComboBoxDelay = new System.Windows.Forms.ToolStripComboBox();
            this.启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.脚本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column6,
            this.Column7,
            this.Column2,
            this.Column5,
            this.Column9});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1064, 314);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 54;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column3.HeaderText = "自动";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 54;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "当前";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "状态描述";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 200;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column2.HeaderText = "执行状态";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 78;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "下一步";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column9.HeaderText = "执行倒计时";
            this.Column9.MinimumWidth = 90;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 90;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.激活ToolStripMenuItem,
            this.取消激活ToolStripMenuItem,
            this.复位ToolStripMenuItem,
            this.立即执行ToolStripMenuItem,
            this.toolStripSeparator1,
            this.重置脚本ToolStripMenuItem,
            this.维护组件ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 164);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 激活ToolStripMenuItem
            // 
            this.激活ToolStripMenuItem.Name = "激活ToolStripMenuItem";
            this.激活ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.激活ToolStripMenuItem.Text = "自动";
            this.激活ToolStripMenuItem.ToolTipText = "切换为自动状态";
            this.激活ToolStripMenuItem.Click += new System.EventHandler(this.激活ToolStripMenuItem_Click);
            // 
            // 取消激活ToolStripMenuItem
            // 
            this.取消激活ToolStripMenuItem.Name = "取消激活ToolStripMenuItem";
            this.取消激活ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.取消激活ToolStripMenuItem.Text = "取消自动";
            this.取消激活ToolStripMenuItem.ToolTipText = "切换为手动状态";
            this.取消激活ToolStripMenuItem.Click += new System.EventHandler(this.取消激活ToolStripMenuItem_Click);
            // 
            // 复位ToolStripMenuItem
            // 
            this.复位ToolStripMenuItem.Name = "复位ToolStripMenuItem";
            this.复位ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.复位ToolStripMenuItem.Text = "复位";
            this.复位ToolStripMenuItem.ToolTipText = "将状态修改为初始状态";
            this.复位ToolStripMenuItem.Click += new System.EventHandler(this.复位ToolStripMenuItem_Click);
            // 
            // 立即执行ToolStripMenuItem
            // 
            this.立即执行ToolStripMenuItem.Name = "立即执行ToolStripMenuItem";
            this.立即执行ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.立即执行ToolStripMenuItem.Text = "立即执行";
            this.立即执行ToolStripMenuItem.ToolTipText = "取消倒计时的等待时间";
            this.立即执行ToolStripMenuItem.Click += new System.EventHandler(this.立即执行ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 重置脚本ToolStripMenuItem
            // 
            this.重置脚本ToolStripMenuItem.Name = "重置脚本ToolStripMenuItem";
            this.重置脚本ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.重置脚本ToolStripMenuItem.Text = "重置脚本系统";
            this.重置脚本ToolStripMenuItem.ToolTipText = "修改脚本文件后可以立即重新载入";
            this.重置脚本ToolStripMenuItem.Click += new System.EventHandler(this.重置脚本ToolStripMenuItem_Click);
            // 
            // 维护组件ToolStripMenuItem
            // 
            this.维护组件ToolStripMenuItem.Name = "维护组件ToolStripMenuItem";
            this.维护组件ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.维护组件ToolStripMenuItem.Text = "维护组件";
            this.维护组件ToolStripMenuItem.Click += new System.EventHandler(this.维护组件ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.延时toolStripComboBoxDelay,
            this.启动ToolStripMenuItem,
            this.停止ToolStripMenuItem,
            this.日志ToolStripMenuItem1,
            this.脚本ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 29);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 延时toolStripComboBoxDelay
            // 
            this.延时toolStripComboBoxDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.延时toolStripComboBoxDelay.Items.AddRange(new object[] {
            "无延时",
            "延时300ms",
            "延时1000ms"});
            this.延时toolStripComboBoxDelay.Name = "延时toolStripComboBoxDelay";
            this.延时toolStripComboBoxDelay.Size = new System.Drawing.Size(121, 25);
            this.延时toolStripComboBoxDelay.SelectedIndexChanged += new System.EventHandler(this.延时toolStripComboBoxDelay_SelectedIndexChanged);
            // 
            // 启动ToolStripMenuItem
            // 
            this.启动ToolStripMenuItem.Name = "启动ToolStripMenuItem";
            this.启动ToolStripMenuItem.Size = new System.Drawing.Size(44, 25);
            this.启动ToolStripMenuItem.Text = "启动";
            this.启动ToolStripMenuItem.Click += new System.EventHandler(this.启动ToolStripMenuItem_Click);
            // 
            // 停止ToolStripMenuItem
            // 
            this.停止ToolStripMenuItem.Name = "停止ToolStripMenuItem";
            this.停止ToolStripMenuItem.Size = new System.Drawing.Size(44, 25);
            this.停止ToolStripMenuItem.Text = "停止";
            this.停止ToolStripMenuItem.Click += new System.EventHandler(this.停止ToolStripMenuItem_Click);
            // 
            // 日志ToolStripMenuItem1
            // 
            this.日志ToolStripMenuItem1.Name = "日志ToolStripMenuItem1";
            this.日志ToolStripMenuItem1.Size = new System.Drawing.Size(44, 25);
            this.日志ToolStripMenuItem1.Text = "日志";
            this.日志ToolStripMenuItem1.Click += new System.EventHandler(this.日志ToolStripMenuItem1_Click);
            // 
            // 脚本ToolStripMenuItem
            // 
            this.脚本ToolStripMenuItem.Name = "脚本ToolStripMenuItem";
            this.脚本ToolStripMenuItem.Size = new System.Drawing.Size(44, 25);
            this.脚本ToolStripMenuItem.Text = "脚本";
            this.脚本ToolStripMenuItem.Click += new System.EventHandler(this.脚本ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "label1";
            // 
            // SMAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 343);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SMAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "执行控制";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 激活ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消激活ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复位ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox 延时toolStripComboBoxDelay;
        private System.Windows.Forms.ToolStripMenuItem 启动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日志ToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 脚本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重置脚本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 维护组件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 立即执行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}