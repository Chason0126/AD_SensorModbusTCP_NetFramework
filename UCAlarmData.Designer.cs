namespace AD_Sensor_SM9001A
{
    partial class UCAlarmData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAlarmData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spc = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spc)).BeginInit();
            this.spc.Panel2.SuspendLayout();
            this.spc.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAlarmData
            // 
            this.dgvAlarmData.AllowUserToAddRows = false;
            this.dgvAlarmData.AllowUserToDeleteRows = false;
            this.dgvAlarmData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlarmData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlarmData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarmData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvAlarmData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlarmData.Location = new System.Drawing.Point(0, 0);
            this.dgvAlarmData.Name = "dgvAlarmData";
            this.dgvAlarmData.RowTemplate.Height = 23;
            this.dgvAlarmData.Size = new System.Drawing.Size(1102, 626);
            this.dgvAlarmData.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "时间";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "探测器编号";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "节点编号";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "报警类型";
            this.Column4.Name = "Column4";
            // 
            // spc
            // 
            this.spc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spc.Location = new System.Drawing.Point(0, 0);
            this.spc.Margin = new System.Windows.Forms.Padding(0);
            this.spc.Name = "spc";
            this.spc.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spc.Panel2
            // 
            this.spc.Panel2.Controls.Add(this.dgvAlarmData);
            this.spc.Size = new System.Drawing.Size(1102, 710);
            this.spc.SplitterDistance = 80;
            this.spc.TabIndex = 1;
            // 
            // UCAlarmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spc);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCAlarmData";
            this.Size = new System.Drawing.Size(1102, 710);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmData)).EndInit();
            this.spc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spc)).EndInit();
            this.spc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlarmData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.SplitContainer spc;
    }
}
