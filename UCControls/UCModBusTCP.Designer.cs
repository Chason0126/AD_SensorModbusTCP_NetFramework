namespace AD_SensorModbusTCP_NetFramework
{
    partial class UCModBusTCP
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
            this.grpTCP = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxIpAddress = new System.Windows.Forms.TextBox();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.grpTCP.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTCP
            // 
            this.grpTCP.Controls.Add(this.tbxPort);
            this.grpTCP.Controls.Add(this.tbxIpAddress);
            this.grpTCP.Controls.Add(this.btnConfirm);
            this.grpTCP.Controls.Add(this.label2);
            this.grpTCP.Controls.Add(this.label1);
            this.grpTCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTCP.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpTCP.Location = new System.Drawing.Point(0, 0);
            this.grpTCP.Margin = new System.Windows.Forms.Padding(0);
            this.grpTCP.Name = "grpTCP";
            this.grpTCP.Size = new System.Drawing.Size(300, 250);
            this.grpTCP.TabIndex = 2;
            this.grpTCP.TabStop = false;
            this.grpTCP.Text = "ModBusTCP";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(119, 181);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(85, 25);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(57, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(52, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址";
            // 
            // tbxIpAddress
            // 
            this.tbxIpAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxIpAddress.Location = new System.Drawing.Point(107, 60);
            this.tbxIpAddress.Name = "tbxIpAddress";
            this.tbxIpAddress.Size = new System.Drawing.Size(127, 23);
            this.tbxIpAddress.TabIndex = 6;
            this.tbxIpAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxPort
            // 
            this.tbxPort.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPort.Location = new System.Drawing.Point(107, 111);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.ReadOnly = true;
            this.tbxPort.Size = new System.Drawing.Size(127, 23);
            this.tbxPort.TabIndex = 6;
            this.tbxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UCModBusTCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpTCP);
            this.Name = "UCModBusTCP";
            this.Size = new System.Drawing.Size(300, 250);
            this.grpTCP.ResumeLayout(false);
            this.grpTCP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTCP;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.TextBox tbxIpAddress;
    }
}
