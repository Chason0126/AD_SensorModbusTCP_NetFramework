using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO.Ports;

namespace AD_SensorModbusTCP_NetFramework
{
    public partial class UCModBusRTU : UserControl
    {
        public UCModBusRTU()
        {
            try
            {
                InitializeComponent();
                string[] portNames = GetPortNames();
                cbxPortName.Items.Clear();
                foreach(string name in portNames)
                {
                    cbxPortName.Items.Add(name);
                }
                cbxBaudRate.Text = GetBaudRate().ToString();
                cbxPortName.Text = GetPortName();
            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg(ex.Message + ex.StackTrace);
            }
         
        }

        private int GetBaudRate()
        {
            int type = 0;
            try
            {
                type = Convert.ToInt32(ConfigurationManager.AppSettings["baudRate"].ToString());
            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg("读取配置文件出错！" + ex.Message + ex.StackTrace);
            }
            return type;
        }

        private string GetPortName()
        {
            string portNames = null;
            try
            {
                portNames = ConfigurationManager.AppSettings["portName"].ToString();
            }
            catch (Win32Exception ex)
            {
                DataClass.ShowErrMsg("读取配置文件出错！" + ex.Message + ex.StackTrace);
            }
            return portNames;
        }

        private string[] GetPortNames()
        {
            string[] portNames = null;
            try
            {
                portNames = SerialPort.GetPortNames();
            }
            catch (Win32Exception ex)
            {
                DataClass.ShowErrMsg("未能查询串行端口名称！" + ex.Message + ex.StackTrace);
            }
            return portNames;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["portName"].Value = cbxPortName.Text;
                configuration.AppSettings.Settings["baudRate"].Value = cbxBaudRate.Text;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("AppSettings");
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg("保存配置文件出错！" + ex.Message + ex.StackTrace);
            }
            finally
            {
                cbxBaudRate.Text = GetBaudRate().ToString();
                cbxPortName.Text = GetPortName();
            }
        }
    }
}
