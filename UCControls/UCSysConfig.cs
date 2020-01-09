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

namespace AD_SensorModbusTCP_NetFramework
{
    public partial class UCSysConfig : UserControl
    {
        public UCSysConfig()
        {
            try
            {
                InitializeComponent();
                string type = GetCommType();
                pnlComm.Controls.Clear();
                if (type == "TCP")
                {
                    UCModBusTCP uCModBusTCP = new UCModBusTCP();
                    pnlComm.Controls.Add(uCModBusTCP);
                }
                else if (type == "RTU")
                {
                    UCModBusRTU uCModBusRTU = new UCModBusRTU();
                    pnlComm.Controls.Add(uCModBusRTU);
                }
                else
                {
                    throw new Exception("通讯协议配置文件异常");
                }
            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg(ex.Message + ex.StackTrace);
            }
          
        }

        private string GetCommType()
        {
            string type = string.Empty;
            try
            {
                type = ConfigurationManager.AppSettings["type"].ToString();
            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg("获取通讯协议类型配置文件异常！" + ex.Message + ex.StackTrace);
            }
            return type;
        }

        private void dgvDevice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > 1)
                {
                    if (e.RowIndex == 5)
                    {
                        if (MessageBox.Show("确定要修改设备信息吗？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg("设备信息更细异常！" + ex.Message + ex.StackTrace);
            }
        }
    }
}
