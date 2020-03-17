namespace AD_Sensor_SM9001A
{
    partial class UCNodePic
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
            this.pbx = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx
            // 
            this.pbx.BackgroundImage = global::AD_Sensor_SM9001A.Properties.Resources.LedNormal;
            this.pbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbx.Location = new System.Drawing.Point(3, 3);
            this.pbx.Margin = new System.Windows.Forms.Padding(0);
            this.pbx.Name = "pbx";
            this.pbx.Size = new System.Drawing.Size(19, 14);
            this.pbx.TabIndex = 0;
            this.pbx.TabStop = false;
            this.pbx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbx_MouseDown);
            this.pbx.MouseHover += new System.EventHandler(this.pbx_MouseHover);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UCNodePic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbx);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCNodePic";
            this.Size = new System.Drawing.Size(25, 20);
            this.MouseHover += new System.EventHandler(this.UCNodePic_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx;
        private System.Windows.Forms.Timer timer1;
    }
}
