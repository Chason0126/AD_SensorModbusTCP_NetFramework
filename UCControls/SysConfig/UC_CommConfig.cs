using System;
using System.Drawing;
using System.IO.Ports;
using System.Net;
using System.Windows.Forms;

namespace AD_Sensor_SM9001A
{
    public partial class UC_CommConfig : UserControl
    {


        public UC_CommConfig()
        {
            InitializeComponent();
            UpdateTbx_SerialPort();
            UpdateTbx_IPEndPoint();
            Update_CommType();
            Update_CommParam();
        }

        private void Update_CommType()
        {
            try
            {
                if (ConfigClass.Get_commType().Equals("AD_Sensor_SM9001A.ModBus_RTU"))
                {
                    cbxCommType.SelectedIndex = 0;
                }
                else if (ConfigClass.Get_commType().Equals("AD_Sensor_SM9001A.ModBus_TCP"))
                {
                    cbxCommType.SelectedIndex = 1;
                }
                else
                {
                    throw new Exception("未知的通讯类型参数，请检查配置文件！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("通讯类型获取失败" + ex.Message);
            }
        }

        /// <summary>
        /// 获取 串口配置信息
        /// </summary>
        private void UpdateTbx_SerialPort()
        {
            try
            {
                SSpParam spParam = ConfigClass.Get_PortParam();//获取配置文件串口 参数
                string[] portNames = SerialPort.GetPortNames();
                cbxSerialPortName.Items.Clear();
                foreach (string portname in portNames)
                {
                    cbxSerialPortName.Items.Add(portname);
                }
                string[] strBaudRate = { "300", "1200", "2400", "9600", "19200", "38400", "115200" };
                foreach (string baudRate in strBaudRate)
                {
                    cbxBaudRate.Items.Add(baudRate);
                }
                cbxSerialPortName.Text = spParam.portName;
                cbxBaudRate.Text = spParam.baudRate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("串口参数获取失败" + ex.Message);
            }
        }
        /// <summary>
        /// 获取 网络配置信息
        /// </summary>
        private void UpdateTbx_IPEndPoint()
        {
            try
            {
                IPEndPoint ipEndPoint = ConfigClass.Get_TCPParam();
                tbxIPAddress.Text = ipEndPoint.Address.ToString();
                tbxPort.Text = ipEndPoint.Port.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("IP参数获取失败" + ex.Message);
            }
        }

        private void Update_CommParam()
        {
            try
            {
                int inspectionTime;
                int readTimeout;
                int writeTimeout;
                ConfigClass.Get_commParam(out inspectionTime, out readTimeout, out writeTimeout);
                tbxInspectionTime.Text = inspectionTime.ToString();
                tbxReadTimeout.Text = readTimeout.ToString();
                tbxWriteTimeout.Text = writeTimeout.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("通讯参数获取失败" + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxCommType.SelectedIndex == 0)//修改通讯类型
                {
                    ConfigClass.Set_commType("AD_Sensor_SM9001A.ModBus_RTU");
                }
                else if (cbxCommType.SelectedIndex == 1)
                {
                    ConfigClass.Set_commType("AD_Sensor_SM9001A.ModBus_TCP");
                }

                if (cbxBaudRate.SelectedIndex == -1 || cbxSerialPortName.SelectedIndex == -1)//修改串口参数
                {
                    MessageBox.Show("请选择合适串口参数！");
                    return;
                }
                else
                {
                    ConfigClass.Set_PortParam(cbxSerialPortName.Text, Convert.ToInt32(cbxBaudRate.Text));
                }

                try//修改网络参数
                {
                    ConfigClass.Set_TCPParam(new IPEndPoint(IPAddress.Parse(tbxIPAddress.Text), Convert.ToInt32(tbxPort.Text)));
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("ip为 null。");
                    return;
                }
                catch (FormatException)
                {
                    MessageBox.Show("不是有效的 IP 地址");
                    return;
                }
                try
                {
                    ConfigClass.Set_commParam(Convert.ToInt32(tbxInspectionTime.Text));
                }
                catch (FormatException)
                {
                    MessageBox.Show("巡检时间不由一个可选符号后跟一系列数字 (0-9) 组成");
                    return;
                }
                catch (OverflowException)
                {
                    MessageBox.Show("巡检时间超出int32的范围");
                    return;
                }
                MessageBox.Show("修改成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message);
            }
            finally
            {
                UpdateTbx_SerialPort();
                UpdateTbx_IPEndPoint();
                Update_CommType();
                Update_CommParam();
            }
        }

        private void cbxCommType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCommType.SelectedIndex == 0)
            {
                grpIP.Enabled = false;
                grpIP.BackColor = Color.Gray;
                grpSerialPort.Enabled = true;
                grpSerialPort.BackColor = Color.LightSteelBlue;
            }
            else if(cbxCommType.SelectedIndex==1)
            {
                grpSerialPort.Enabled = false;
                grpSerialPort.BackColor = Color.Gray;
                grpIP.Enabled = true;
                grpIP.BackColor = Color.LightSteelBlue;
            }
        }
      
    }


}
