using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_SensorModbusTCP_NetFramework
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            timerMain.Start();//主时钟事件

        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            try
            {
                lblTime.Text = DateTime.Now.ToString();
                switch (DataClass.userLevel)
                {
                    case 1:
                        lblWelcome.Text = "欢迎！普通用户";
                        break;
                    case 2:
                        lblWelcome.Text = "你好！系统操作员";
                        break;
                    case 3:
                        lblWelcome.Text = "您好！系统管理员";
                        break;
                }
            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg("主时钟事件错误！" + ex.Message + ex.StackTrace);
            }
        }

        private void btnSySConfig_Click(object sender, EventArgs e)
        {
            UCSysConfig uCSysConfig = new UCSysConfig();
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uCSysConfig);
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (DataClass.userLevel == 1)
            {
                FrmCheckPwd frmCheckPwd = new FrmCheckPwd();
                if (frmCheckPwd.ShowDialog() == DialogResult.OK)
                {

                }
                else
                {
                    return;
                }
            }
            this.Close();
            Environment.Exit(0);
        }

        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }
    }
}
