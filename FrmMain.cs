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
    }
}
