namespace AD_Sensor_SM9001A
{
    partial class UCProjConfig
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
            this.spc1 = new System.Windows.Forms.SplitContainer();
            this.spc2 = new System.Windows.Forms.SplitContainer();
            this.grpSensor = new System.Windows.Forms.GroupBox();
            this.btnSaveSensorNode = new System.Windows.Forms.Button();
            this.btnDelNode = new System.Windows.Forms.Button();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.btnDelSensor = new System.Windows.Forms.Button();
            this.btnAddSensor = new System.Windows.Forms.Button();
            this.tbxNodeName = new System.Windows.Forms.TextBox();
            this.cbxNodeNo = new System.Windows.Forms.ComboBox();
            this.tbxSensorName = new System.Windows.Forms.TextBox();
            this.cbxSensorNo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpAreaName = new System.Windows.Forms.GroupBox();
            this.btnChangePic = new System.Windows.Forms.Button();
            this.btnAreaSave = new System.Windows.Forms.Button();
            this.rdbDisable = new System.Windows.Forms.RadioButton();
            this.rdbEnable = new System.Windows.Forms.RadioButton();
            this.tbxAreaId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxAreaName = new System.Windows.Forms.TextBox();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.grpProjName = new System.Windows.Forms.GroupBox();
            this.btnChangePrjName = new System.Windows.Forms.Button();
            this.tbxProjName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdateSensor = new System.Windows.Forms.Button();
            this.btnUpdateNode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spc1)).BeginInit();
            this.spc1.Panel1.SuspendLayout();
            this.spc1.Panel2.SuspendLayout();
            this.spc1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spc2)).BeginInit();
            this.spc2.SuspendLayout();
            this.grpSensor.SuspendLayout();
            this.grpAreaName.SuspendLayout();
            this.grpProjName.SuspendLayout();
            this.SuspendLayout();
            // 
            // spc1
            // 
            this.spc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spc1.Location = new System.Drawing.Point(0, 0);
            this.spc1.Margin = new System.Windows.Forms.Padding(0);
            this.spc1.Name = "spc1";
            // 
            // spc1.Panel1
            // 
            this.spc1.Panel1.Controls.Add(this.spc2);
            // 
            // spc1.Panel2
            // 
            this.spc1.Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.spc1.Panel2.Controls.Add(this.grpSensor);
            this.spc1.Panel2.Controls.Add(this.grpAreaName);
            this.spc1.Panel2.Controls.Add(this.grpProjName);
            this.spc1.Size = new System.Drawing.Size(1920, 930);
            this.spc1.SplitterDistance = 1650;
            this.spc1.SplitterWidth = 1;
            this.spc1.TabIndex = 0;
            // 
            // spc2
            // 
            this.spc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spc2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spc2.IsSplitterFixed = true;
            this.spc2.Location = new System.Drawing.Point(0, 0);
            this.spc2.Margin = new System.Windows.Forms.Padding(0);
            this.spc2.Name = "spc2";
            // 
            // spc2.Panel1
            // 
            this.spc2.Panel1.AutoScroll = true;
            this.spc2.Size = new System.Drawing.Size(1650, 930);
            this.spc2.SplitterDistance = 217;
            this.spc2.SplitterWidth = 1;
            this.spc2.TabIndex = 0;
            // 
            // grpSensor
            // 
            this.grpSensor.Controls.Add(this.btnSaveSensorNode);
            this.grpSensor.Controls.Add(this.btnDelNode);
            this.grpSensor.Controls.Add(this.btnUpdateNode);
            this.grpSensor.Controls.Add(this.btnAddNode);
            this.grpSensor.Controls.Add(this.btnDelSensor);
            this.grpSensor.Controls.Add(this.btnUpdateSensor);
            this.grpSensor.Controls.Add(this.btnAddSensor);
            this.grpSensor.Controls.Add(this.tbxNodeName);
            this.grpSensor.Controls.Add(this.cbxNodeNo);
            this.grpSensor.Controls.Add(this.tbxSensorName);
            this.grpSensor.Controls.Add(this.cbxSensorNo);
            this.grpSensor.Controls.Add(this.label6);
            this.grpSensor.Controls.Add(this.label5);
            this.grpSensor.Controls.Add(this.label4);
            this.grpSensor.Controls.Add(this.label3);
            this.grpSensor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpSensor.Location = new System.Drawing.Point(14, 425);
            this.grpSensor.Name = "grpSensor";
            this.grpSensor.Size = new System.Drawing.Size(245, 428);
            this.grpSensor.TabIndex = 2;
            this.grpSensor.TabStop = false;
            this.grpSensor.Text = "探测器设置";
            // 
            // btnSaveSensorNode
            // 
            this.btnSaveSensorNode.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSaveSensorNode.FlatAppearance.BorderSize = 2;
            this.btnSaveSensorNode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnSaveSensorNode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnSaveSensorNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSensorNode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveSensorNode.Location = new System.Drawing.Point(59, 357);
            this.btnSaveSensorNode.Name = "btnSaveSensorNode";
            this.btnSaveSensorNode.Size = new System.Drawing.Size(162, 40);
            this.btnSaveSensorNode.TabIndex = 4;
            this.btnSaveSensorNode.Text = "保存";
            this.btnSaveSensorNode.UseVisualStyleBackColor = false;
            this.btnSaveSensorNode.Click += new System.EventHandler(this.btnSaveSensorNode_Click);
            // 
            // btnDelNode
            // 
            this.btnDelNode.BackColor = System.Drawing.Color.Green;
            this.btnDelNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelNode.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelNode.Location = new System.Drawing.Point(169, 310);
            this.btnDelNode.Name = "btnDelNode";
            this.btnDelNode.Size = new System.Drawing.Size(60, 30);
            this.btnDelNode.TabIndex = 3;
            this.btnDelNode.Text = "删除";
            this.btnDelNode.UseVisualStyleBackColor = false;
            this.btnDelNode.Click += new System.EventHandler(this.btnDelNode_Click);
            // 
            // btnAddNode
            // 
            this.btnAddNode.BackColor = System.Drawing.Color.Green;
            this.btnAddNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNode.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddNode.Location = new System.Drawing.Point(17, 310);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(60, 30);
            this.btnAddNode.TabIndex = 3;
            this.btnAddNode.Text = "添加";
            this.btnAddNode.UseVisualStyleBackColor = false;
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // btnDelSensor
            // 
            this.btnDelSensor.BackColor = System.Drawing.Color.Green;
            this.btnDelSensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelSensor.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelSensor.Location = new System.Drawing.Point(169, 149);
            this.btnDelSensor.Name = "btnDelSensor";
            this.btnDelSensor.Size = new System.Drawing.Size(60, 30);
            this.btnDelSensor.TabIndex = 3;
            this.btnDelSensor.Text = "删除";
            this.btnDelSensor.UseVisualStyleBackColor = false;
            this.btnDelSensor.Click += new System.EventHandler(this.btnDelSensor_Click);
            // 
            // btnAddSensor
            // 
            this.btnAddSensor.BackColor = System.Drawing.Color.Green;
            this.btnAddSensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSensor.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddSensor.Location = new System.Drawing.Point(17, 149);
            this.btnAddSensor.Name = "btnAddSensor";
            this.btnAddSensor.Size = new System.Drawing.Size(60, 30);
            this.btnAddSensor.TabIndex = 3;
            this.btnAddSensor.Text = "添加";
            this.btnAddSensor.UseVisualStyleBackColor = false;
            this.btnAddSensor.Click += new System.EventHandler(this.btnAddSensor_Click);
            // 
            // tbxNodeName
            // 
            this.tbxNodeName.Location = new System.Drawing.Point(106, 236);
            this.tbxNodeName.Multiline = true;
            this.tbxNodeName.Name = "tbxNodeName";
            this.tbxNodeName.Size = new System.Drawing.Size(126, 53);
            this.tbxNodeName.TabIndex = 2;
            // 
            // cbxNodeNo
            // 
            this.cbxNodeNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNodeNo.FormattingEnabled = true;
            this.cbxNodeNo.Location = new System.Drawing.Point(106, 198);
            this.cbxNodeNo.Name = "cbxNodeNo";
            this.cbxNodeNo.Size = new System.Drawing.Size(92, 24);
            this.cbxNodeNo.TabIndex = 1;
            this.cbxNodeNo.SelectedIndexChanged += new System.EventHandler(this.cbxNodeNo_SelectedIndexChanged);
            // 
            // tbxSensorName
            // 
            this.tbxSensorName.Location = new System.Drawing.Point(111, 76);
            this.tbxSensorName.Multiline = true;
            this.tbxSensorName.Name = "tbxSensorName";
            this.tbxSensorName.Size = new System.Drawing.Size(126, 53);
            this.tbxSensorName.TabIndex = 2;
            // 
            // cbxSensorNo
            // 
            this.cbxSensorNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSensorNo.FormattingEnabled = true;
            this.cbxSensorNo.Location = new System.Drawing.Point(111, 38);
            this.cbxSensorNo.Name = "cbxSensorNo";
            this.cbxSensorNo.Size = new System.Drawing.Size(92, 24);
            this.cbxSensorNo.TabIndex = 1;
            this.cbxSensorNo.SelectedIndexChanged += new System.EventHandler(this.cbxSensorNo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "节点名称：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "节点编号：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "探测器名称：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "探测器编号：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpAreaName
            // 
            this.grpAreaName.Controls.Add(this.btnChangePic);
            this.grpAreaName.Controls.Add(this.btnAreaSave);
            this.grpAreaName.Controls.Add(this.rdbDisable);
            this.grpAreaName.Controls.Add(this.rdbEnable);
            this.grpAreaName.Controls.Add(this.tbxAreaId);
            this.grpAreaName.Controls.Add(this.label1);
            this.grpAreaName.Controls.Add(this.tbxAreaName);
            this.grpAreaName.Controls.Add(this.lblAreaName);
            this.grpAreaName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpAreaName.Location = new System.Drawing.Point(40, 182);
            this.grpAreaName.Name = "grpAreaName";
            this.grpAreaName.Padding = new System.Windows.Forms.Padding(0);
            this.grpAreaName.Size = new System.Drawing.Size(201, 231);
            this.grpAreaName.TabIndex = 1;
            this.grpAreaName.TabStop = false;
            this.grpAreaName.Text = "分区设置";
            // 
            // btnChangePic
            // 
            this.btnChangePic.Location = new System.Drawing.Point(57, 145);
            this.btnChangePic.Name = "btnChangePic";
            this.btnChangePic.Size = new System.Drawing.Size(114, 25);
            this.btnChangePic.TabIndex = 7;
            this.btnChangePic.Text = "更换图片";
            this.btnChangePic.UseVisualStyleBackColor = true;
            this.btnChangePic.Click += new System.EventHandler(this.btnChangePic_Click);
            // 
            // btnAreaSave
            // 
            this.btnAreaSave.Location = new System.Drawing.Point(77, 189);
            this.btnAreaSave.Name = "btnAreaSave";
            this.btnAreaSave.Size = new System.Drawing.Size(75, 25);
            this.btnAreaSave.TabIndex = 6;
            this.btnAreaSave.Text = "确定";
            this.btnAreaSave.UseVisualStyleBackColor = true;
            this.btnAreaSave.Click += new System.EventHandler(this.btnAreaSave_Click);
            // 
            // rdbDisable
            // 
            this.rdbDisable.AutoSize = true;
            this.rdbDisable.Location = new System.Drawing.Point(118, 66);
            this.rdbDisable.Name = "rdbDisable";
            this.rdbDisable.Size = new System.Drawing.Size(58, 20);
            this.rdbDisable.TabIndex = 5;
            this.rdbDisable.TabStop = true;
            this.rdbDisable.Text = "关闭";
            this.rdbDisable.UseVisualStyleBackColor = true;
            // 
            // rdbEnable
            // 
            this.rdbEnable.AutoSize = true;
            this.rdbEnable.Location = new System.Drawing.Point(42, 66);
            this.rdbEnable.Name = "rdbEnable";
            this.rdbEnable.Size = new System.Drawing.Size(58, 20);
            this.rdbEnable.TabIndex = 4;
            this.rdbEnable.TabStop = true;
            this.rdbEnable.Text = "启用";
            this.rdbEnable.UseVisualStyleBackColor = true;
            // 
            // tbxAreaId
            // 
            this.tbxAreaId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxAreaId.Location = new System.Drawing.Point(76, 24);
            this.tbxAreaId.Name = "tbxAreaId";
            this.tbxAreaId.ReadOnly = true;
            this.tbxAreaId.Size = new System.Drawing.Size(100, 23);
            this.tbxAreaId.TabIndex = 3;
            this.tbxAreaId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "编号：";
            // 
            // tbxAreaName
            // 
            this.tbxAreaName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxAreaName.Location = new System.Drawing.Point(76, 102);
            this.tbxAreaName.Name = "tbxAreaName";
            this.tbxAreaName.Size = new System.Drawing.Size(100, 23);
            this.tbxAreaName.TabIndex = 1;
            this.tbxAreaName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAreaName
            // 
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAreaName.Location = new System.Drawing.Point(15, 106);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(56, 16);
            this.lblAreaName.TabIndex = 0;
            this.lblAreaName.Text = "名称：";
            // 
            // grpProjName
            // 
            this.grpProjName.Controls.Add(this.btnChangePrjName);
            this.grpProjName.Controls.Add(this.tbxProjName);
            this.grpProjName.Controls.Add(this.label2);
            this.grpProjName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpProjName.Location = new System.Drawing.Point(3, 27);
            this.grpProjName.Name = "grpProjName";
            this.grpProjName.Padding = new System.Windows.Forms.Padding(0);
            this.grpProjName.Size = new System.Drawing.Size(256, 130);
            this.grpProjName.TabIndex = 0;
            this.grpProjName.TabStop = false;
            this.grpProjName.Text = "工程名称";
            // 
            // btnChangePrjName
            // 
            this.btnChangePrjName.Location = new System.Drawing.Point(107, 93);
            this.btnChangePrjName.Name = "btnChangePrjName";
            this.btnChangePrjName.Size = new System.Drawing.Size(75, 25);
            this.btnChangePrjName.TabIndex = 2;
            this.btnChangePrjName.Text = "保存";
            this.btnChangePrjName.UseVisualStyleBackColor = true;
            this.btnChangePrjName.Click += new System.EventHandler(this.btnChangePrjName_Click);
            // 
            // tbxProjName
            // 
            this.tbxProjName.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxProjName.Location = new System.Drawing.Point(65, 33);
            this.tbxProjName.Multiline = true;
            this.tbxProjName.Name = "tbxProjName";
            this.tbxProjName.Size = new System.Drawing.Size(178, 54);
            this.tbxProjName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "名称：";
            // 
            // btnUpdateSensor
            // 
            this.btnUpdateSensor.BackColor = System.Drawing.Color.Green;
            this.btnUpdateSensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSensor.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdateSensor.Location = new System.Drawing.Point(93, 149);
            this.btnUpdateSensor.Name = "btnUpdateSensor";
            this.btnUpdateSensor.Size = new System.Drawing.Size(60, 30);
            this.btnUpdateSensor.TabIndex = 3;
            this.btnUpdateSensor.Text = "修改";
            this.btnUpdateSensor.UseVisualStyleBackColor = false;
            this.btnUpdateSensor.Click += new System.EventHandler(this.btnUpdateSensor_Click);
            // 
            // btnUpdateNode
            // 
            this.btnUpdateNode.BackColor = System.Drawing.Color.Green;
            this.btnUpdateNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateNode.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdateNode.Location = new System.Drawing.Point(93, 310);
            this.btnUpdateNode.Name = "btnUpdateNode";
            this.btnUpdateNode.Size = new System.Drawing.Size(60, 30);
            this.btnUpdateNode.TabIndex = 3;
            this.btnUpdateNode.Text = "修改";
            this.btnUpdateNode.UseVisualStyleBackColor = false;
            this.btnUpdateNode.Click += new System.EventHandler(this.btnUpdateNode_Click);
            // 
            // UCProjConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spc1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCProjConfig";
            this.Size = new System.Drawing.Size(1920, 930);
            this.spc1.Panel1.ResumeLayout(false);
            this.spc1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spc1)).EndInit();
            this.spc1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spc2)).EndInit();
            this.spc2.ResumeLayout(false);
            this.grpSensor.ResumeLayout(false);
            this.grpSensor.PerformLayout();
            this.grpAreaName.ResumeLayout(false);
            this.grpAreaName.PerformLayout();
            this.grpProjName.ResumeLayout(false);
            this.grpProjName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spc1;
        private System.Windows.Forms.SplitContainer spc2;
        private System.Windows.Forms.GroupBox grpAreaName;
        private System.Windows.Forms.TextBox tbxAreaId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxAreaName;
        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.GroupBox grpProjName;
        private System.Windows.Forms.Button btnChangePic;
        private System.Windows.Forms.Button btnAreaSave;
        private System.Windows.Forms.RadioButton rdbDisable;
        private System.Windows.Forms.RadioButton rdbEnable;
        private System.Windows.Forms.Button btnChangePrjName;
        private System.Windows.Forms.TextBox tbxProjName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpSensor;
        private System.Windows.Forms.Button btnDelNode;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.Button btnDelSensor;
        private System.Windows.Forms.Button btnAddSensor;
        private System.Windows.Forms.TextBox tbxNodeName;
        private System.Windows.Forms.ComboBox cbxNodeNo;
        private System.Windows.Forms.TextBox tbxSensorName;
        private System.Windows.Forms.ComboBox cbxSensorNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveSensorNode;
        private System.Windows.Forms.Button btnUpdateNode;
        private System.Windows.Forms.Button btnUpdateSensor;
    }
}
