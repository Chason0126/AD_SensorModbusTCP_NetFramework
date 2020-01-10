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
                Init_DgvSensor();
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
        private void Init_DgvSensor()
        {
            try
            {
                dgvSensor.Rows.Clear();
                List<SSensor> list = new SQLSelect().Select_Sensor();
                foreach(SSensor sSensor in list)
                {
                    dgvSensor.Rows.Add(sSensor.sensorId, sSensor.sensorName, sSensor.startNo, sSensor.quantity, sSensor.length, sSensor.enable);
                }
            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg("获取探测器信息失败！" + ex.Message + ex.StackTrace);
            }
        }

        private void InitDgvNode(int sensorId)
        {
            try
            {
                dgvNode.Rows.Clear();

            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg("获取节点信息失败！" + ex.Message + ex.StackTrace);
            }
        }

        private void dgvDevice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >=0)
                {
                    if (e.ColumnIndex == 6)
                    {
                        if (MessageBox.Show("确定要修改设备信息吗？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            try
                            {
                                SSensor sSensor = new SSensor();
                                sSensor.sensorId = Convert.ToInt32(dgvSensor.CurrentRow.Cells[0].Value);
                                sSensor.sensorName = Convert.ToString(dgvSensor.CurrentRow.Cells[1].Value);
                                sSensor.startNo = Convert.ToInt32(dgvSensor.CurrentRow.Cells[2].Value);
                                sSensor.quantity = Convert.ToInt32(dgvSensor.CurrentRow.Cells[3].Value);
                                sSensor.length = Convert.ToInt32(dgvSensor.CurrentRow.Cells[4].Value);
                                sSensor.enable = Convert.ToInt32(dgvSensor.CurrentRow.Cells[5].Value);
                                if (sSensor.sensorName.Length > 32)
                                {
                                    throw new OverflowException("名称过长！");
                                }
                                if (sSensor.startNo <= 0 || sSensor.startNo > 255)
                                {
                                    throw new OverflowException("请填入合适的起始编号！");
                                }
                                if (sSensor.quantity <= 0 || sSensor.quantity > 255)
                                {
                                    throw new OverflowException("数量超出范围！");
                                }
                                if (sSensor.startNo + sSensor.quantity > 255)
                                {
                                    throw new OverflowException("数值超出范围！");
                                }
                                new SQLUpdate().Update("update sensor set sensorName='" + sSensor.sensorName + "',startNo='" + sSensor.startNo + "',quantity='" + sSensor.quantity + "',length='" + sSensor.length + "',enable='" + sSensor.enable + "' where sensorId='" + sSensor.sensorId + "' ");
                            }
                            catch(FormatException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            catch(OverflowException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                Init_DgvSensor();
                            }
                        }
                        else if (e.ColumnIndex == 0)
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
