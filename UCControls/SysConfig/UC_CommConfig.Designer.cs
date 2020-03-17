namespace AD_Sensor_SM9001A
{
    partial class UC_CommConfig
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
            this.cbxCommType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grpSerialPort = new System.Windows.Forms.GroupBox();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.cbxSerialPortName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpIP = new System.Windows.Forms.GroupBox();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.tbxIPAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpCommParam = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxWriteTimeout = new System.Windows.Forms.TextBox();
            this.tbxReadTimeout = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxInspectionTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grpSerialPort.SuspendLayout();
            this.grpIP.SuspendLayout();
            this.grpCommParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxCommType
            // 
            this.cbxCommType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCommType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxCommType.FormattingEnabled = true;
            this.cbxCommType.Items.AddRange(new object[] {
            "ModBus_RTU",
            "ModBus_TCP"});
            this.cbxCommType.Location = new System.Drawing.Point(171, 27);
            this.cbxCommType.Name = "cbxCommType";
            this.cbxCommType.Size = new System.Drawing.Size(121, 24);
            this.cbxCommType.TabIndex = 0;
            this.cbxCommType.SelectedIndexChanged += new System.EventHandler(this.cbxCommType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(56, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "通讯协议：";
            // 
            // grpSerialPort
            // 
            this.grpSerialPort.Controls.Add(this.cbxBaudRate);
            this.grpSerialPort.Controls.Add(this.cbxSerialPortName);
            this.grpSerialPort.Controls.Add(this.label3);
            this.grpSerialPort.Controls.Add(this.label2);
            this.grpSerialPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpSerialPort.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpSerialPort.Location = new System.Drawing.Point(23, 79);
            this.grpSerialPort.Name = "grpSerialPort";
            this.grpSerialPort.Size = new System.Drawing.Size(282, 185);
            this.grpSerialPort.TabIndex = 6;
            this.grpSerialPort.TabStop = false;
            this.grpSerialPort.Text = "串口设置";
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBaudRate.FormattingEnabled = true;
            this.cbxBaudRate.Location = new System.Drawing.Point(150, 131);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(121, 27);
            this.cbxBaudRate.TabIndex = 2;
            // 
            // cbxSerialPortName
            // 
            this.cbxSerialPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSerialPortName.FormattingEnabled = true;
            this.cbxSerialPortName.Location = new System.Drawing.Point(150, 59);
            this.cbxSerialPortName.Name = "cbxSerialPortName";
            this.cbxSerialPortName.Size = new System.Drawing.Size(121, 27);
            this.cbxSerialPortName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "波特率：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "串口名称：";
            // 
            // grpIP
            // 
            this.grpIP.Controls.Add(this.tbxPort);
            this.grpIP.Controls.Add(this.tbxIPAddress);
            this.grpIP.Controls.Add(this.label5);
            this.grpIP.Controls.Add(this.label4);
            this.grpIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpIP.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpIP.Location = new System.Drawing.Point(23, 283);
            this.grpIP.Name = "grpIP";
            this.grpIP.Size = new System.Drawing.Size(282, 164);
            this.grpIP.TabIndex = 7;
            this.grpIP.TabStop = false;
            this.grpIP.Text = "网络设置";
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(122, 116);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(135, 29);
            this.tbxPort.TabIndex = 4;
            this.tbxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxIPAddress
            // 
            this.tbxIPAddress.Location = new System.Drawing.Point(122, 44);
            this.tbxIPAddress.Name = "tbxIPAddress";
            this.tbxIPAddress.Size = new System.Drawing.Size(135, 29);
            this.tbxIPAddress.TabIndex = 3;
            this.tbxIPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "端口号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "IP地址：";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.Location = new System.Drawing.Point(100, 748);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 49);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存修改";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpCommParam
            // 
            this.grpCommParam.Controls.Add(this.label11);
            this.grpCommParam.Controls.Add(this.label10);
            this.grpCommParam.Controls.Add(this.label9);
            this.grpCommParam.Controls.Add(this.tbxWriteTimeout);
            this.grpCommParam.Controls.Add(this.tbxReadTimeout);
            this.grpCommParam.Controls.Add(this.label8);
            this.grpCommParam.Controls.Add(this.tbxInspectionTime);
            this.grpCommParam.Controls.Add(this.label1);
            this.grpCommParam.Controls.Add(this.label7);
            this.grpCommParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpCommParam.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpCommParam.Location = new System.Drawing.Point(23, 492);
            this.grpCommParam.Name = "grpCommParam";
            this.grpCommParam.Size = new System.Drawing.Size(282, 209);
            this.grpCommParam.TabIndex = 8;
            this.grpCommParam.TabStop = false;
            this.grpCommParam.Text = "通讯参数";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(232, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "ms";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(232, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "ms";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(232, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "ms";
            // 
            // tbxWriteTimeout
            // 
            this.tbxWriteTimeout.Location = new System.Drawing.Point(142, 165);
            this.tbxWriteTimeout.Name = "tbxWriteTimeout";
            this.tbxWriteTimeout.ReadOnly = true;
            this.tbxWriteTimeout.Size = new System.Drawing.Size(84, 29);
            this.tbxWriteTimeout.TabIndex = 7;
            this.tbxWriteTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxReadTimeout
            // 
            this.tbxReadTimeout.Location = new System.Drawing.Point(142, 106);
            this.tbxReadTimeout.Name = "tbxReadTimeout";
            this.tbxReadTimeout.ReadOnly = true;
            this.tbxReadTimeout.Size = new System.Drawing.Size(84, 29);
            this.tbxReadTimeout.TabIndex = 6;
            this.tbxReadTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "写超时：";
            // 
            // tbxInspectionTime
            // 
            this.tbxInspectionTime.Location = new System.Drawing.Point(142, 44);
            this.tbxInspectionTime.Name = "tbxInspectionTime";
            this.tbxInspectionTime.Size = new System.Drawing.Size(84, 29);
            this.tbxInspectionTime.TabIndex = 5;
            this.tbxInspectionTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "读超时：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "巡检时间：";
            // 
            // UC_CommConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.grpCommParam);
            this.Controls.Add(this.grpIP);
            this.Controls.Add(this.grpSerialPort);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxCommType);
            this.Controls.Add(this.label6);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_CommConfig";
            this.Size = new System.Drawing.Size(319, 850);
            this.grpSerialPort.ResumeLayout(false);
            this.grpSerialPort.PerformLayout();
            this.grpIP.ResumeLayout(false);
            this.grpIP.PerformLayout();
            this.grpCommParam.ResumeLayout(false);
            this.grpCommParam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCommType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpSerialPort;
        private System.Windows.Forms.ComboBox cbxBaudRate;
        private System.Windows.Forms.ComboBox cbxSerialPortName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpIP;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.TextBox tbxIPAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpCommParam;
        private System.Windows.Forms.TextBox tbxWriteTimeout;
        private System.Windows.Forms.TextBox tbxReadTimeout;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxInspectionTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}
