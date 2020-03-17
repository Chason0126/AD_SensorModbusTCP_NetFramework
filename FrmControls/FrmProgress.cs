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
    public partial class FrmProgress : Form
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

        public FrmProgress()
        {
            InitializeComponent();
        }

        public void SetPercent(int process)
        {
            progressBar1.Value = process;
            lblPercent.Text = "请稍等。。。" + progressBar1.Value.ToString() + "%";
        }

       

        private void FrmInitDB_MouseDown(object sender, MouseEventArgs e)
        {
            Frm_Move();
        }
    }
}
