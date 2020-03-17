using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace AD_Sensor_SM9001A
{
    public partial class UCSysConfig : UserControl
    {
        SQLUpdate sqlUpdate = new SQLUpdate();
        List<SSensor> listSensor;
        List<SNode> listNode;
        Dictionary<int, SSensor> lastSensors = new Dictionary<int, SSensor>();
        Dictionary<int, SNode> lastNodes = new Dictionary<int, SNode>();

        public UCSysConfig()
        {
            try
            {
                InitializeComponent();

                UC_CommConfig uC_CommConfig = new UC_CommConfig();
                uC_CommConfig.Dock = DockStyle.Fill;
                pnlComm.Controls.Clear();
                pnlComm.Controls.Add(uC_CommConfig);

                Init_DgvSensor();
                //InitDgvNode(Convert.ToInt32(dgvSensor.CurrentRow.Cells[0].Value));
            }
            catch (Exception ex)
            {
                Log.log.Error("系统设置异常!", ex);
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
                Log.log.Error("获取通讯协议类型配置文件异常!", ex);
            }
            return type;
        }
        private void Init_DgvSensor()
        {
            try
            {
                dgvSensor.Rows.Clear();
                lastSensors.Clear();
                listSensor = new SQLSelect().Select_Sensor();
                foreach (SSensor sSensor in listSensor)
                {
                    lastSensors.Add(sSensor.sensorId, sSensor);
                    if (ckbShowAll.Checked)
                    {
                        dgvSensor.Rows.Add(sSensor.sensorId, sSensor.sensorName, sSensor.startNo, sSensor.quantity, sSensor.length, sSensor.enable);
                    }
                    else
                    {
                        if (sSensor.enable == 1)
                        {
                            dgvSensor.Rows.Add(sSensor.sensorId, sSensor.sensorName, sSensor.startNo, sSensor.quantity, sSensor.length, sSensor.enable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.log.Error("获取探测器信息失败!", ex);
            }
        }

        private void InitDgvNode(int sensorId)
        {
            try
            {
                dgvNode.Rows.Clear();
                lastNodes.Clear();
                listNode = new SQLSelect().Select_Node(sensorId);
                foreach (SNode sNode in listNode)
                {
                    lastNodes.Add(sNode.nodeId, sNode);
                    if (sNode.enable == 1)
                    {
                        dgvNode.Rows.Add(sNode.sensorId, sNode.nodeId, sNode.nodeName);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.log.Error("获取节点信息失败！", ex);
            }
        }
        private void dgvSensor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                InitDgvNode(Convert.ToInt32(dgvSensor.CurrentRow.Cells[0].Value));
            }
        }
        private void dgvDevice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 6)
                    {
                        if (MessageBox.Show("确定要修改探测器信息吗？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
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
                                if (sSensor.sensorName.Length > 20)
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
                                sqlUpdate.Update_Sensor(sSensor.sensorId, sSensor.sensorName, sSensor.startNo, sSensor.quantity, sSensor.length, sSensor.enable);
                            }
                            catch (FormatException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            catch (OverflowException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                Init_DgvSensor();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.log.Error("设备信息更新异常！", ex);
            }
        }

        private void ckbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Init_DgvSensor();
            }
            catch (Exception ex)
            {
                Log.log.Error("设备信息更新异常！", ex);
            }
        }

        private void btnSensorSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要修改设备信息吗？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    for (int i = 0; i < dgvSensor.Rows.Count; i++)
                    {
                        SSensor sSensor = new SSensor();
                        SSensor tempSensor = new SSensor();
                        sSensor.sensorId = Convert.ToInt32(dgvSensor.Rows[i].Cells[0].Value);
                        sSensor.sensorName = Convert.ToString(dgvSensor.Rows[i].Cells[1].Value);
                        sSensor.startNo = Convert.ToInt32(dgvSensor.Rows[i].Cells[2].Value);
                        sSensor.quantity = Convert.ToInt32(dgvSensor.Rows[i].Cells[3].Value);
                        sSensor.length = Convert.ToInt32(dgvSensor.Rows[i].Cells[4].Value);
                        sSensor.enable = Convert.ToInt32(dgvSensor.Rows[i].Cells[5].Value);
                        lastSensors.TryGetValue(sSensor.sensorId, out tempSensor);
                        try
                        {
                            if (sSensor.sensorName.Length > 20 || sSensor.sensorName.Length == 0)
                            {
                                throw new OverflowException("名称过长或者名称不能为空！");
                            }
                            if (sSensor.startNo <= 0 || sSensor.startNo > 255)
                            {
                                throw new OverflowException("请填入合适的起始编号！");
                            }
                            if (sSensor.quantity <= 0 || sSensor.quantity > 255)
                            {
                                throw new OverflowException("数量超出范围！");
                            }
                            if (sSensor.startNo + sSensor.quantity - 1 > 255)
                            {
                                throw new OverflowException("数值超出范围！");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        sqlUpdate.Update_Sensor(sSensor.sensorId, sSensor.sensorName, sSensor.startNo, sSensor.quantity, sSensor.length, sSensor.enable);
                        if (sSensor.enable == 1)
                        {
                            if (tempSensor.startNo != sSensor.startNo || tempSensor.quantity != sSensor.quantity || tempSensor.length != sSensor.length)
                            {
                                //if (MessageBox.Show("是否要修改节设置点表，这将覆盖所有节点的备注信息？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                                //{
                                //    sqlUpdate.Update_Node(sSensor.sensorId, sSensor.startNo, sSensor.quantity, sSensor.length);
                                //}
                                sqlUpdate.Update_Node(sSensor.sensorId, sSensor.startNo, sSensor.quantity);
                            }
                        }

                    }
                }
                MessageBox.Show("修改成功！");
            }
            catch (Exception ex)
            {
                Log.log.Error("设备信息更新异常", ex);
            }
            finally
            {
                InitDgvNode(Convert.ToInt32(dgvSensor.CurrentRow.Cells[0].Value));
            }
        }

        private void btnNodeSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要修改节点信息表吗？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    for (int i = 0; i < dgvNode.Rows.Count; i++)
                    {
                        SNode sNode = new SNode();
                        SNode temp = new SNode();
                        try
                        {
                            sNode.sensorId = Convert.ToInt32(dgvNode.Rows[i].Cells[0].Value);
                            sNode.nodeId = Convert.ToInt32(dgvNode.Rows[i].Cells[1].Value);
                            sNode.nodeName = Convert.ToString(dgvNode.Rows[i].Cells[2].Value);
                            lastNodes.TryGetValue(sNode.nodeId, out temp);
                            if (temp.nodeName != sNode.nodeName)
                            {
                                if (sNode.nodeName.Length > 20 || sNode.nodeName.Length == 0)
                                {
                                    throw new Exception("名称过长或者名称不能为空！");
                                }
                                sqlUpdate.Update_Node(sNode.sensorId, sNode.nodeId, sNode.nodeName);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    MessageBox.Show("修改成功！");
                }
            }
            catch (Exception ex)
            {
                Log.log.Error("节点信息更新异常", ex);
            }
            finally
            {
                InitDgvNode(Convert.ToInt32(dgvNode.CurrentRow.Cells[0].Value));
            }
        }


    }
}
