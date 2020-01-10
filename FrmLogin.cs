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

namespace AD_SensorModbusTCP_NetFramework
{
    public partial class FrmLogin : Form
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
        public FrmLogin()
        {
            InitializeComponent();
            cbxUser.SelectedIndex = 0;
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            Frm_Move();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxPwd.Text))
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            switch (cbxUser.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("请选择用户名！");
                    break;
                case 0:
                    if(Encryption.GetMD5Hash(tbxPwd.Text)==new SQLSelect().Select_Pwd(1))
                    {
                        DialogResult = DialogResult.OK;
                        DataClass.userLevel = 1;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("密码错误！");
                        tbxPwd.SelectAll();
                    }
                    break;
                case 1:
                    if (Encryption.GetMD5Hash(tbxPwd.Text) == new SQLSelect().Select_Pwd(2))
                    {
                        DialogResult = DialogResult.OK;
                        DataClass.userLevel = 2;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("密码错误！");
                        tbxPwd.SelectAll();

                    }
                    break;
                case 2:
                    if (Encryption.GetMD5Hash(tbxPwd.Text) == new SQLSelect().Select_Pwd(3))
                    {
                        DialogResult = DialogResult.OK;
                        DataClass.userLevel = 3;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("密码错误！");
                        tbxPwd.SelectAll();
                    }
                    break;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
    }
}
