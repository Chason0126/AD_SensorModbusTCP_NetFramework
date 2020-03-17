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
    public partial class UCNodePic : UserControl
    {
        private int sensorId;
        private int nodeId;
        private string nodeName;
        private bool addState;

        public int SensorId { get => sensorId; set => sensorId = value; }
        public int NodeId { get => nodeId; set => nodeId = value; }

        public UCNodePic(int sensorId, int nodeId, string nodeName,bool addState)
        {
            this.SensorId = sensorId;
            this.NodeId = nodeId;
            this.nodeName = nodeName;
            this.addState = addState;
            InitializeComponent();
            if (HomeParam.runState == 1)
            {
                timer1.Start();
                this.BackColor = Color.Green;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Data.sensorDatas[SensorId].faultStatus[NodeId] == 1)
            {
                this.BackColor = Color.Yellow;
            }
            if (Data.sensorDatas[SensorId].alarmStatus[NodeId] == 1)
            {
                this.BackColor = Color.Red;
            }
        }

        private void pbx_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            if (HomeParam.runState == 1)
            {
                toolTip.SetToolTip(pbx, nodeName + "\r\n" + Data.sensorDatas[SensorId].tempers[NodeId] + "℃");
            }
            else
            {
                toolTip.SetToolTip(pbx, sensorId.ToString() + "-" + nodeId.ToString() + "\r\n" + nodeName);

            }
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

        private void UCNodePic_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            if (HomeParam.runState == 1)
            {
                toolTip.SetToolTip(pbx, nodeName + "\r\n" + Data.sensorDatas[SensorId].tempers[NodeId] + "℃");
            }
            else
            {
                toolTip.SetToolTip(pbx, nodeName);

            }
        }
    }
}
