namespace StateManager
{
    partial class SMAlarmForm
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
                DB.DidyDB();
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试报警ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.颜色说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新报警ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.已处理的报警ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史报警ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1118, 564);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.清空ToolStripMenuItem,
            this.测试报警ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // 测试报警ToolStripMenuItem
            // 
            this.测试报警ToolStripMenuItem.Name = "测试报警ToolStripMenuItem";
            this.测试报警ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.测试报警ToolStripMenuItem.Text = "测试报警";
            this.测试报警ToolStripMenuItem.Click += new System.EventHandler(this.测试报警ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.处理ToolStripMenuItem,
            this.toolStripComboBox1,
            this.颜色说明ToolStripMenuItem,
            this.新报警ToolStripMenuItem,
            this.已处理的报警ToolStripMenuItem,
            this.历史报警ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1118, 29);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(68, 25);
            this.刷新ToolStripMenuItem.Text = "刷新列表";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 处理ToolStripMenuItem
            // 
            this.处理ToolStripMenuItem.Name = "处理ToolStripMenuItem";
            this.处理ToolStripMenuItem.Size = new System.Drawing.Size(44, 25);
            this.处理ToolStripMenuItem.Text = "处理";
            this.处理ToolStripMenuItem.Click += new System.EventHandler(this.处理ToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "当前报警",
            "所有"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // 颜色说明ToolStripMenuItem
            // 
            this.颜色说明ToolStripMenuItem.AutoToolTip = true;
            this.颜色说明ToolStripMenuItem.CheckOnClick = true;
            this.颜色说明ToolStripMenuItem.Name = "颜色说明ToolStripMenuItem";
            this.颜色说明ToolStripMenuItem.Size = new System.Drawing.Size(96, 25);
            this.颜色说明ToolStripMenuItem.Text = "    颜色说明：";
            // 
            // 新报警ToolStripMenuItem
            // 
            this.新报警ToolStripMenuItem.AutoToolTip = true;
            this.新报警ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.新报警ToolStripMenuItem.CheckOnClick = true;
            this.新报警ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.新报警ToolStripMenuItem.Name = "新报警ToolStripMenuItem";
            this.新报警ToolStripMenuItem.Size = new System.Drawing.Size(92, 25);
            this.新报警ToolStripMenuItem.Text = "未处理的报警";
            // 
            // 已处理的报警ToolStripMenuItem
            // 
            this.已处理的报警ToolStripMenuItem.AutoToolTip = true;
            this.已处理的报警ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.已处理的报警ToolStripMenuItem.CheckOnClick = true;
            this.已处理的报警ToolStripMenuItem.Name = "已处理的报警ToolStripMenuItem";
            this.已处理的报警ToolStripMenuItem.Size = new System.Drawing.Size(92, 25);
            this.已处理的报警ToolStripMenuItem.Text = "已处理的报警";
            // 
            // 历史报警ToolStripMenuItem
            // 
            this.历史报警ToolStripMenuItem.AutoToolTip = true;
            this.历史报警ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.历史报警ToolStripMenuItem.CheckOnClick = true;
            this.历史报警ToolStripMenuItem.Name = "历史报警ToolStripMenuItem";
            this.历史报警ToolStripMenuItem.Size = new System.Drawing.Size(68, 25);
            this.历史报警ToolStripMenuItem.Text = "历史报警";
            // 
            // SMAlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 593);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "SMAlarmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "报警信息";
            this.Load += new System.EventHandler(this.SMAlarmForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem 新报警ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 已处理的报警ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史报警ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 颜色说明ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试报警ToolStripMenuItem;


    }
}