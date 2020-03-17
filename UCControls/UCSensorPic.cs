using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AD_Sensor_SM9001A
{
    public partial class UCSensorPic : UserControl
    {
        private int sensorId;
        private string sensorName;
        private bool addState;

        public int SensorId { get => sensorId; set => sensorId = value; }

        public UCSensorPic(int sensorId, string sensorName, bool addState)
        {
            InitializeComponent();
            this.SensorId = sensorId;
            this.sensorName = sensorName;
            if (HomeParam.runState == 1)
            {
                timer1.Start();
                this.BackColor = Color.Green;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Data.commFaultCount[SensorId] >= 10)
            {
                this.BackColor = Color.Yellow;
            }
            if (Data.queryFaultCount[SensorId] > 0)
            {
                this.BackColor = Color.Yellow;
            }
            if (Data.queryAlarmCount[SensorId] > 0)
            {
                this.BackColor = Color.Red;
            }
        }

        private void pbx_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(pbx, sensorName);
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void Frm_Move()
        {
            if (HomeParam.runState == 1)
            {
                return;
            }
            int WM_SYSCOMMAND = 0x0112;
            int SC_MOVE = 0xF010;
            int HTCAPTION = 0x0002;
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void pbx_MouseDown(object sender, MouseEventArgs e)
        {
            if (addState)
            {
                Frm_Move();
            }
        }

        private void UCSensorPic_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(pbx, sensorName);
        }
    }
}
