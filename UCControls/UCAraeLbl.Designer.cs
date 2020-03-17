namespace AD_Sensor_SM9001A
{
    partial class UCAraeLbl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlArea = new System.Windows.Forms.Panel();
            this.lblAreaMaxTemp = new System.Windows.Forms.Label();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.cmsPnlLbl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.启用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.pnlArea.SuspendLayout();
            this.cmsPnlLbl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlArea
            // 
            this.pnlArea.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlArea.Controls.Add(this.lblAreaMaxTemp);
            this.pnlArea.Controls.Add(this.lblAreaName);
            this.pnlArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlArea.Location = new System.Drawing.Point(0, 0);
            this.pnlArea.Margin = new System.Windows.Forms.Padding(0);
            this.pnlArea.Name = "pnlArea";
            this.pnlArea.Padding = new System.Windows.Forms.Padding(1);
            this.pnlArea.Size = new System.Drawing.Size(217, 80);
            this.pnlArea.TabIndex = 0;
            this.pnlArea.Click += new System.EventHandler(this.pnlArea_Click);
            this.pnlArea.MouseEnter += new System.EventHandler(this.pnlArea_MouseEnter);
            this.pnlArea.MouseLeave += new System.EventHandler(this.pnlArea_MouseLeave);
            // 
            // lblAreaMaxTemp
            // 
            this.lblAreaMaxTemp.AutoSize = true;
            this.lblAreaMaxTemp.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAreaMaxTemp.Location = new System.Drawing.Point(31, 53);
            this.lblAreaMaxTemp.Name = "lblAreaMaxTemp";
            this.lblAreaMaxTemp.Size = new System.Drawing.Size(109, 19);
            this.lblAreaMaxTemp.TabIndex = 0;
            this.lblAreaMaxTemp.Text = "最高温度：";
            this.lblAreaMaxTemp.Click += new System.EventHandler(this.lblAreaMaxTemp_Click);
            this.lblAreaMaxTemp.MouseEnter += new System.EventHandler(this.lblAreaMaxTemp_MouseEnter);
            this.lblAreaMaxTemp.MouseLeave += new System.EventHandler(this.lblAreaMaxTemp_MouseLeave);
            // 
            // lblAreaName
            // 
            this.lblAreaName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAreaName.ForeColor = System.Drawing.Color.Black;
            this.lblAreaName.Location = new System.Drawing.Point(36, 20);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(89, 19);
            this.lblAreaName.TabIndex = 0;
            this.lblAreaName.Text = "分区名称";
            this.lblAreaName.Click += new System.EventHandler(this.lblAreaName_Click);
            this.lblAreaName.MouseEnter += new System.EventHandler(this.lblAreaName_MouseEnter);
            this.lblAreaName.MouseLeave += new System.EventHandler(this.lblAreaName_MouseLeave);
            // 
            // cmsPnlLbl
            // 
            this.cmsPnlLbl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启用ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.cmsPnlLbl.Name = "cmsPnlLbl";
            this.cmsPnlLbl.Size = new System.Drawing.Size(101, 48);
            // 
            // 启用ToolStripMenuItem
            // 
            this.启用ToolStripMenuItem.Name = "启用ToolStripMenuItem";
            this.启用ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.启用ToolStripMenuItem.Text = "启用";
            this.启用ToolStripMenuItem.Click += new System.EventHandler(this.启用ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // UCAraeLbl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlArea);
            this.DoubleBuffered = true;
            this.Name = "UCAraeLbl";
            this.Size = new System.Drawing.Size(217, 80);
            this.Load += new System.EventHandler(this.UCAraeLbl_Load);
            this.pnlArea.ResumeLayout(false);
            this.pnlArea.PerformLayout();
            this.cmsPnlLbl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblAreaMaxTemp;
        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.Timer timerMain;
        public System.Windows.Forms.Panel pnlArea;
        private System.Windows.Forms.ContextMenuStrip cmsPnlLbl;
        private System.Windows.Forms.ToolStripMenuItem 启用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}
