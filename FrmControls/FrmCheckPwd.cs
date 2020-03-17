using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_Sensor_SM9001A
{
    public partial class FrmCheckPwd : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void Frm_Move()
        {
            int WM_SYSCOMMAND = 0x0112;
            int SC_MOVE = 0xF010;
            int HTCAPTION = 0x0002;
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        public FrmCheckPwd()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            Frm_Move();
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            Frm_Move();
        }

        private void FrmCheckPwd_MouseDown(object sender, MouseEventArgs e)
        {
            Frm_Move();
        }

        private void btnChangeOperatorPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxPwd.Text))
                {
                    MessageBox.Show("密码不能为空！");
                    return;
                }
                if (new SQLSelect().Select_Pwd(1) == Encryption.GetMD5Hash(tbxPwd.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    HomeParam.userLevel = 0;
                    this.Close();
                }
                if (new SQLSelect().Select_Pwd(2) == Encryption.GetMD5Hash(tbxPwd.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    HomeParam.userLevel = 0;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码错误！");
                    tbxPwd.SelectAll();
                }
            }
            catch (Exception ex)
            {
                Log.log.Error("修改密码异常！", ex);
            }
        }
    }
}
