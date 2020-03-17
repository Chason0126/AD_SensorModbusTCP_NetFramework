using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AD_Sensor_SM9001A
{
    public partial class UCProjConfig : UserControl
    {
        SQLUpdate sqlUpdate = new SQLUpdate();
        SQLSelect sqlSelect = new SQLSelect();
        SArea tempSArea;
        UCPage page;
        private Dictionary<int, string> sensorEnables = new Dictionary<int, string>();
        private Dictionary<SNode_id, string> nodeEnables = new Dictionary<SNode_id, string>();

        private Dictionary<int, SSensorDisplay> sensorDisplays = new Dictionary<int, SSensorDisplay>();
        private Dictionary<SNode_id, SNodeDisplay> nodeDiplays = new Dictionary<SNode_id, SNodeDisplay>();
        public UCProjConfig()
        {
            InitializeComponent();
            InitProjName();
            InitPnlArea();
            GetEnables();
            Update_cbxSensorNo();
        }

        private void InitProjName()
        {
            try
            {
                HomeParam.projName = sqlSelect.GetProjName();
                tbxProjName.Text = HomeParam.projName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 加载全部的分区信息  并展示在左边
        /// </summary>
        private void InitPnlArea()
        {
            try
            {
                spc2.Panel1.Controls.Clear();
                List<SArea> sAreas = sqlSelect.Select_Area();
                foreach (SArea sArea in sAreas)
                {
                    UCAraeLbl areaLbl = new UCAraeLbl(sArea);
                    areaLbl.getMsg += AreaLbl_getMsg;
                    if (HomeParam.runState == 1)
                    {
                        if (sArea.enable == 1)//分区启用
                        {
                            areaLbl.Dock = DockStyle.Top;
                            spc2.Panel1.Controls.Add(areaLbl);
                        }
                    }
                    else
                    {
                        if (sArea.enable != 1)
                        {
                            areaLbl.pnlArea.BackColor = Color.Gray;
                            areaLbl.Able = 0;
                        }
                        else
                        {
                            areaLbl.Able = 1;
                        }
                        areaLbl.Dock = DockStyle.Top;
                        spc2.Panel1.Controls.Add(areaLbl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("分区异常", ex.Message);
            }
        }

        private void InitPnlPic(SArea sArea)
        {
            tbxAreaId.Text = sArea.areaId.ToString();
            tbxAreaName.Text = sArea.areaName;
            if (sArea.enable == 1)
            {
                rdbEnable.Checked = true;
            }
            if (sArea.enable == 0)
            {
                rdbDisable.Checked = true;
            }
        }

        private void AreaLbl_getMsg(SArea sArea)
        {
            try
            {
                tempSArea = sArea;
                InitPnlPic(tempSArea);
                UpdatePage();
            }
            catch (Exception ex)
            {
                Log.log.Error("分区信息异常！", ex);
                MessageBox.Show("分区信息异常！");
            }
        }

        private void UpdatePage()
        {
            try
            {
                StaticMethod.GetDisplays(out sensorDisplays, out nodeDiplays);
                page = new UCPage(tempSArea.areaId, sensorDisplays, nodeDiplays, true);
                page.Dock = DockStyle.Fill;
                page.GetMouseDownPosition += Page_GetMouseDownPosition;
                spc2.Panel2.Controls.Clear();
                spc2.Panel2.Controls.Add(page);
            }
            catch (Exception ex)
            {
                MessageBox.Show("page页加载异常！" + ex.Message);
            }
        }

        private void Page_GetMouseDownPosition(Point point)
        {
            try
            {
                if (IsNotAddSensorState)
                {
                    page.AddSensor(Convert.ToInt32(cbxSensorNo.Text), tbxSensorName.Text, point.X - 17, point.Y - 15);
                }
                else if (IsNotAddNodeState)
                {
                    page.AddNode(Convert.ToInt32(cbxSensorNo.Text), Convert.ToInt32(cbxNodeNo.Text), tbxNodeName.Text, point.X - 12, point.Y - 10);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChangePic_Click(object sender, EventArgs e)
        {
            try
            {
                if (page == null)
                {
                    throw new Exception("请选择需要操作的分区！");
                }
                if (this.Cursor == Cursors.Cross)
                {
                    throw new Exception("请先退出添加状态！");
                }
                string path;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPG图片(*.jpg)|*.jpg|PNG图片（*.png）|*.png|BMP图片(*.bmp)|*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    if (string.IsNullOrEmpty(path))
                    {
                        MessageBox.Show("请选择正确的图片路径！");
                        return;
                    }
                    StaticMethod.CopyAreaPic(path, tempSArea.areaId);
                    MessageBox.Show("更换成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更换失败！" + ex.Message);
            }
            finally
            {
                InitPnlPic(tempSArea);
                UpdatePage();
            }
        }

        private void btnAreaSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (page == null)
                {
                    throw new Exception("请选择需要操作的分区！");
                }
                if (this.Cursor == Cursors.Cross)
                {
                    throw new Exception("请先退出添加状态！");
                }
                if (tbxAreaName.Text.Length > 20)
                {
                    throw new Exception("名称过长！");
                }
                if (rdbEnable.Checked)
                {
                    sqlUpdate.Update_Area(tempSArea.areaId, 1, tbxAreaName.Text);
                }
                if (!rdbEnable.Checked)
                {
                    sqlUpdate.Update_Area(tempSArea.areaId, 0, tbxAreaName.Text);
                }

            }
            catch (Exception ex)
            {
                Log.log.Error("保存失败！", ex);
            }
            finally
            {
                InitPnlArea();
            }
        }

        private void btnChangePrjName_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Cursor == Cursors.Cross)
                {
                    throw new Exception("请先退出添加状态！");
                }
                if (string.IsNullOrEmpty(tbxProjName.Text))
                {
                    MessageBox.Show("工程名称不能为空！请检查后重试。");
                    return;
                }
                if (tbxProjName.Text.Length >= 25)//太长了会遮挡 数据库字段长度为32
                {
                    MessageBox.Show("名称过长，不得大于32个字符！，请检查后重试。");
                    return;
                }
                if (new SQLUpdate().SetProjName(tbxProjName.Text.Trim().ToString()))
                {
                    MessageBox.Show("保存成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                InitProjName();
            }
        }

        private void GetEnables()
        {
            try
            {
                sensorEnables.Clear();
                nodeEnables.Clear();
                foreach (SSensor sensor in sqlSelect.Select_SensorEnable())
                {
                    sensorEnables.Add(sensor.sensorId, sensor.sensorName);
                    foreach (SNode node in sqlSelect.Select_NodeEnable(sensor.sensorId))
                    {
                        nodeEnables.Add(new SNode_id { sensorId = node.sensorId, nodeId = node.nodeId }, node.nodeName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_cbxSensorNo()
        {
            try
            {
                cbxSensorNo.Items.Clear();
                foreach (int sensorNo in sensorEnables.Keys)
                {
                    cbxSensorNo.Items.Add(sensorNo);
                }
                if (cbxSensorNo.Items.Count > 0)
                {
                    cbxSensorNo.SelectedIndex = 0;
                }
                Update_cbxNodeNo(Convert.ToInt32(cbxSensorNo.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Update_cbxNodeNo(int sensorNo)
        {
            try
            {
                cbxNodeNo.Items.Clear();
                foreach (SNode_id nodeid in nodeEnables.Keys)
                {
                    if (nodeid.sensorId == sensorNo)
                    {
                        cbxNodeNo.Items.Add(nodeid.nodeId);
                    }
                }
                if (cbxNodeNo.Items.Count > 0)
                {
                    cbxNodeNo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxSensorNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sensorName = null;
                sensorEnables.TryGetValue(Convert.ToInt32(cbxSensorNo.Text), out sensorName);
                tbxSensorName.Text = sensorName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxNodeNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string nodeName = null;
                nodeEnables.TryGetValue(new SNode_id { sensorId = Convert.ToInt32(cbxSensorNo.Text), nodeId = Convert.ToInt32(cbxNodeNo.Text) }, out nodeName);
                tbxNodeName.Text = nodeName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool IsNotAddSensorState = false;
        bool IsNotAddNodeState = false;
        private void btnAddSensor_Click(object sender, EventArgs e)
        {
            try
            {
                if (page == null)
                {
                    throw new Exception("请选择需要操作的分区！");
                }
                if (IsNotAddNodeState)
                {
                    throw new Exception("请先退出添加状态！");
                }
                IsNotAddSensorState = !IsNotAddSensorState;
                if (IsNotAddSensorState)
                {
                    this.Cursor = Cursors.Cross;
                    btnAddSensor.BackColor = Color.Yellow;
                    btnAddSensor.Text = "退出";
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    btnAddSensor.BackColor = Color.Green;
                    btnAddSensor.Text = "添加";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            try
            {
                if (page == null)
                {
                    throw new Exception("请选择需要操作的分区！");
                }
                if (IsNotAddSensorState)
                {
                    throw new Exception("请先退出添加状态！");
                }
                IsNotAddNodeState = !IsNotAddNodeState;
                if (IsNotAddNodeState)
                {
                    this.Cursor = Cursors.Cross;
                    btnAddNode.BackColor = Color.Yellow;
                    btnAddNode.Text = "退出";
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    btnAddNode.BackColor = Color.Green;
                    btnAddNode.Text = "添加";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateNode_Click(object sender, EventArgs e)
        {
            try
            {
                if (page == null)
                {
                    throw new Exception("请选择需要操作的分区！");
                }
                if (this.Cursor == Cursors.Cross)
                {
                    throw new Exception("请先退出添加状态！");
                }
                page.UpdateNode(Convert.ToInt32(cbxSensorNo.Text), Convert.ToInt32(cbxNodeNo.Text), tbxNodeName.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateSensor_Click(object sender, EventArgs e)
        {
            try
            {
                if (page == null)
                {
                    throw new Exception("请选择需要操作的分区！");
                }
                if (this.Cursor == Cursors.Cross)
                {
                    throw new Exception("请先退出添加状态！");
                }
                page.UpdateSensor(Convert.ToInt32(cbxSensorNo.Text), tbxSensorName.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelSensor_Click(object sender, EventArgs e)
        {
            try
            {
                if (page == null)
                {
                    throw new Exception("请选择需要操作的分区！");
                }
                if (this.Cursor == Cursors.Cross)
                {
                    throw new Exception("请先退出添加状态！");
                }
                page.DelSensor(Convert.ToInt32(cbxSensorNo.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelNode_Click(object sender, EventArgs e)
        {
            try
            {
                if (page == null)
                {
                    throw new Exception("请选择需要操作的分区！");
                }
                if (this.Cursor == Cursors.Cross)
                {
                    throw new Exception("请先退出添加状态！");
                }
                page.DelNode(Convert.ToInt32(cbxSensorNo.Text), Convert.ToInt32(cbxNodeNo.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveSensorNode_Click(object sender, EventArgs e)
        {
            try
            {
                if (page == null)
                {
                    throw new Exception("请选择需要操作的分区！");
                }
                if (this.Cursor == Cursors.Cross)
                {
                    throw new Exception("请先退出添加状态！");
                }
                page.SaveSensorNode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GetEnables();
                Update_cbxSensorNo();
            }
        }

       
    }
}
