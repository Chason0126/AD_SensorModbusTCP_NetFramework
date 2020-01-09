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
using System.Net;

namespace AD_SensorModbusTCP_NetFramework
{
    public partial class UCModBusTCP : UserControl
    {
        public UCModBusTCP()
        {
            try
            {
                InitializeComponent();
                tbxIpAddress.Text = GetIP();
                tbxPort.Text = GetPort();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private string GetPort()
        {
            string type = string.Empty;
            try
            {
                type = ConfigurationManager.AppSettings["port"].ToString();
            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg("读取配置文件出错！" + ex.Message + ex.StackTrace);
            }
            return type;
        }

        private string GetIP()
        {
            string portNames = null;
            try
            {
                portNames = ConfigurationManager.AppSettings["IP"].ToString();
            }
            catch (Win32Exception ex)
            {
                DataClass.ShowErrMsg("读取配置文件出错！" + ex.Message + ex.StackTrace);
            }
            return portNames;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                IPAddress ip;
                IPAddress.TryParse(tbxIpAddress.Text, out ip);
                configuration.AppSettings.Settings["portName"].Value = ip.ToString();
                configuration.AppSettings.Settings["baudRate"].Value = tbxPort.Text.ToString();
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
                tbxIpAddress.Text = GetIP();
                tbxPort.Text = GetPort();
            }
        }
    }
}
