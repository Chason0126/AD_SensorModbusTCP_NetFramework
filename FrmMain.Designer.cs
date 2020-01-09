namespace AD_SensorModbusTCP_NetFramework
{
    partial class FrmMain
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblProjName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.tlpButtom = new System.Windows.Forms.TableLayoutPanel();
            this.btnDataAnalyse = new System.Windows.Forms.Button();
            this.btnProjConfig = new System.Windows.Forms.Button();
            this.btnMainPage = new System.Windows.Forms.Button();
            this.btnSySConfig = new System.Windows.Forms.Button();
            this.btnFireData = new System.Windows.Forms.Button();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.tlpButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(116)))), ((int)(((byte)(170)))));
            this.pnlHeader.Controls.Add(this.btnSignOut);
            this.pnlHeader.Controls.Add(this.btnLogin);
            this.pnlHeader.Controls.Add(this.lblTime);
            this.pnlHeader.Controls.Add(this.lblProjName);
            this.pnlHeader.Controls.Add(this.lblName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1920, 80);
            this.pnlHeader.TabIndex = 1;
            // 
            // btnSignOut
            // 
            this.btnSignOut.FlatAppearance.BorderColor = System.Drawing.Color.LightCyan;
            this.btnSignOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnSignOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOut.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSignOut.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSignOut.Location = new System.Drawing.Point(1828, 28);
            this.btnSignOut.Margin = new System.Windows.Forms.Padding(0);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(80, 30);
            this.btnSignOut.TabIndex = 5;
            this.btnSignOut.Text = "退出";
            this.btnSignOut.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.LightCyan;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLogin.Location = new System.Drawing.Point(1714, 28);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(80, 30);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("黑体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.Location = new System.Drawing.Point(1381, 31);
            this.lblTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(131, 21);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "DateTimeNow";
            // 
            // lblProjName
            // 
            this.lblProjName.AutoSize = true;
            this.lblProjName.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProjName.ForeColor = System.Drawing.Color.White;
            this.lblProjName.Location = new System.Drawing.Point(10, 28);
            this.lblProjName.Margin = new System.Windows.Forms.Padding(0);
            this.lblProjName.Name = "lblProjName";
            this.lblProjName.Size = new System.Drawing.Size(178, 24);
            this.lblProjName.TabIndex = 2;
            this.lblProjName.Text = "圣敏火灾实验室";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("黑体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(724, 12);
            this.lblName.Margin = new System.Windows.Forms.Padding(0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(472, 56);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "火灾监控预警平台";
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // tlpButtom
            // 
            this.tlpButtom.BackColor = System.Drawing.Color.Transparent;
            this.tlpButtom.ColumnCount = 5;
            this.tlpButtom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtom.Controls.Add(this.btnDataAnalyse, 0, 0);
            this.tlpButtom.Controls.Add(this.btnProjConfig, 0, 0);
            this.tlpButtom.Controls.Add(this.btnMainPage, 0, 0);
            this.tlpButtom.Controls.Add(this.btnSySConfig, 1, 0);
            this.tlpButtom.Controls.Add(this.btnFireData, 0, 0);
            this.tlpButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpButtom.Location = new System.Drawing.Point(0, 1010);
            this.tlpButtom.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtom.Name = "tlpButtom";
            this.tlpButtom.RowCount = 1;
            this.tlpButtom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtom.Size = new System.Drawing.Size(1920, 70);
            this.tlpButtom.TabIndex = 5;
            // 
            // btnDataAnalyse
            // 
            this.btnDataAnalyse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDataAnalyse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnDataAnalyse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataAnalyse.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDataAnalyse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.btnDataAnalyse.Location = new System.Drawing.Point(771, 3);
            this.btnDataAnalyse.Name = "btnDataAnalyse";
            this.btnDataAnalyse.Size = new System.Drawing.Size(378, 64);
            this.btnDataAnalyse.TabIndex = 7;
            this.btnDataAnalyse.Text = "数据分析";
            this.btnDataAnalyse.UseVisualStyleBackColor = true;
            // 
            // btnProjConfig
            // 
            this.btnProjConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProjConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnProjConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjConfig.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnProjConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.btnProjConfig.Location = new System.Drawing.Point(1155, 3);
            this.btnProjConfig.Name = "btnProjConfig";
            this.btnProjConfig.Size = new System.Drawing.Size(378, 64);
            this.btnProjConfig.TabIndex = 6;
            this.btnProjConfig.Text = "工程设置";
            this.btnProjConfig.UseVisualStyleBackColor = true;
            // 
            // btnMainPage
            // 
            this.btnMainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMainPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnMainPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainPage.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMainPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.btnMainPage.Location = new System.Drawing.Point(3, 3);
            this.btnMainPage.Name = "btnMainPage";
            this.btnMainPage.Size = new System.Drawing.Size(378, 64);
            this.btnMainPage.TabIndex = 5;
            this.btnMainPage.Text = "主页";
            this.btnMainPage.UseVisualStyleBackColor = true;
            // 
            // btnSySConfig
            // 
            this.btnSySConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSySConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnSySConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSySConfig.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSySConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.btnSySConfig.Location = new System.Drawing.Point(1539, 3);
            this.btnSySConfig.Name = "btnSySConfig";
            this.btnSySConfig.Size = new System.Drawing.Size(378, 64);
            this.btnSySConfig.TabIndex = 1;
            this.btnSySConfig.Text = "系统设置";
            this.btnSySConfig.UseVisualStyleBackColor = true;
            this.btnSySConfig.Click += new System.EventHandler(this.btnSySConfig_Click);
            // 
            // btnFireData
            // 
            this.btnFireData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFireData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnFireData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFireData.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFireData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.btnFireData.Location = new System.Drawing.Point(387, 3);
            this.btnFireData.Name = "btnFireData";
            this.btnFireData.Size = new System.Drawing.Size(378, 64);
            this.btnFireData.TabIndex = 0;
            this.btnFireData.Text = "火警数据";
            this.btnFireData.UseVisualStyleBackColor = true;
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcMain.IsSplitterFixed = true;
            this.spcMain.Location = new System.Drawing.Point(0, 80);
            this.spcMain.Margin = new System.Windows.Forms.Padding(0);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.pnlMain);
            this.spcMain.Size = new System.Drawing.Size(1920, 930);
            this.spcMain.SplitterDistance = 1700;
            this.spcMain.SplitterWidth = 1;
            this.spcMain.TabIndex = 6;
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1700, 930);
            this.pnlMain.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.tlpButtom);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpButtom.ResumeLayout(false);
            this.spcMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblProjName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.TableLayoutPanel tlpButtom;
        private System.Windows.Forms.Button btnDataAnalyse;
        private System.Windows.Forms.Button btnProjConfig;
        private System.Windows.Forms.Button btnMainPage;
        private System.Windows.Forms.Button btnSySConfig;
        private System.Windows.Forms.Button btnFireData;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Panel pnlMain;
    }
}