using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AD_Sensor_SM9001A
{
    public partial class FrmMain : Form
    {
        SArea tempSArea;
        UCPage page;
        DataInsert dataInsert;
        private Dictionary<int, List<int>> enableNodes = new Dictionary<int, List<int>>();
        SQLSelect sqlSelect = new SQLSelect();
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public FrmMain()
        {
            InitializeComponent();
            InitPrjName();
            InitArea();
            timerMain.Start();//主时钟事件
            timerInsertData.Start();//存储数据
            dataInsert = new DataInsert();
        }



        private void InitPrjName()
        {
            try
            {
                HomeParam.projName = new SQLSelect().GetProjName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitArea()
        {
            try
            {
                pnlArea.Controls.Clear();
                List<SArea> sAreas = new SQLSelect().Select_Area();
                foreach (SArea sArea in sAreas)
                {
                    UCAraeLbl areaLbl = new UCAraeLbl(sArea);
                    areaLbl.getMsg += AreaLbl_getMsg;

                    if (sArea.enable == 1)//分区启用
                    {
                        areaLbl.Dock = DockStyle.Top;
                        pnlArea.Controls.Add(areaLbl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("分区异常", ex.Message);
            }
        }

        private void AreaLbl_getMsg(SArea sArea)
        {
            try
            {
                tempSArea = sArea;
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
                Dictionary<int, SSensorDisplay> sensorDisplays = new Dictionary<int, SSensorDisplay>();
                Dictionary<SNode_id, SNodeDisplay> nodeDiplays = new Dictionary<SNode_id, SNodeDisplay>();
                StaticMethod.GetDisplays(out sensorDisplays, out nodeDiplays);
                page = new UCPage(tempSArea.areaId, sensorDisplays, nodeDiplays, false);
                page.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(page);
            }
            catch (Exception ex)
            {
                MessageBox.Show("page页加载异常！" + ex.Message);
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            try
            {
                lblTime.Text = DateTime.Now.ToString();
                switch (HomeParam.userLevel)
                {
                    case 1:
                        lblWelcome.Text = "欢迎！普通用户";
                        break;
                    case 2:
                        lblWelcome.Text = "你好！系统操作员";
                        break;
                    case 3:
                        lblWelcome.Text = "您好！系统管理员";
                        break;
                }
                if (HomeParam.runState == 0)
                {
                    lblRunState.Text = "系统停止";
                }
                else if (HomeParam.runState == 1)
                {
                    lblRunState.Text = "系统运行";
                }
                HomeParam.commFaultSum = 0;
                HomeParam.queryAlarmSum = 0;
                HomeParam.queryFaultSum = 0;
                for (int i = 0; i < 256; i++)//总数统计
                {
                    if (Data.commFaultCount[i] >= HomeParam.commFaultThreshold)
                    {
                        HomeParam.commFaultSum++;
                    }
                    HomeParam.queryAlarmSum += Data.queryAlarmCount[i];
                    HomeParam.queryFaultSum += Data.queryFaultCount[i];
                }
                lblFire.Text = "火警 " + HomeParam.queryAlarmSum;//主界面显示 数量
                lblFault.Text = "故障 " + (HomeParam.commFaultSum + HomeParam.queryFaultSum);
                lblProjName.Text = HomeParam.projName;

                if (HomeParam.IsNotUpdateMsg)
                {
                    lock (HomeParam.dictionaryObj)
                    {
                        int count = 0;
                        dgvFire.Rows.Clear();
                        foreach (SAlarmMsg alarmMsg in HomeParam.alarmMsg.Values)
                        {
                            count++;
                            dgvFire.Rows.Add(count, alarmMsg.sensorId.ToString() + "-" + alarmMsg.nodeId.ToString(), alarmMsg.type, alarmMsg.dateTime, alarmMsg.remarks);
                        }
                        count = 0;
                        dgvFault.Rows.Clear();
                        foreach (SCommFaultMsg commFaultMsg in HomeParam.commFaultMsg.Values)
                        {
                            count++;
                            dgvFault.Rows.Add(count, commFaultMsg.sensorId, commFaultMsg.type, commFaultMsg.dateTime, commFaultMsg.remarks);
                        }
                        foreach (SFaultMsg faultMsg in HomeParam.faultMsg.Values)
                        {
                            count++;
                            dgvFault.Rows.Add(count, faultMsg.sensorId.ToString() + "-" + faultMsg.nodeId.ToString(), faultMsg.type, faultMsg.dateTime, faultMsg.remarks);
                        }
                    }
                    HomeParam.IsNotUpdateMsg = false;
                }
                if (HomeParam.alarmMsg.Count == 0 && HomeParam.commFaultMsg.Count == 0 && HomeParam.faultMsg.Count == 0)
                {
                    spcHome.Panel2Collapsed = true;
                }
                else
                {
                    spcHome.Panel2Collapsed = false;
                }
            }
            catch (Exception ex)
            {
                Log.log.Error("主时钟事件错误！", ex);
            }
        }

        private void btnSySConfig_Click(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.Cross)
            {
                MessageBox.Show("请先退出添加状态！");
                return;
            }
            if (workClient != null)
            {
                workClient.Cancellation.Cancel();
                workClient = null;
            }
            spcMain.Panel2Collapsed = true;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new UCSysConfig());
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.Cross)
            {
                MessageBox.Show("请先退出添加状态！");
                return;
            }
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.Cross)
            {
                MessageBox.Show("请先退出添加状态！");
                return;
            }
            if (HomeParam.userLevel == 1)
            {
                FrmCheckPwd frmCheckPwd = new FrmCheckPwd();
                if (frmCheckPwd.ShowDialog() == DialogResult.OK)
                {

                }
                else
                {
                    return;
                }
            }
            this.Close();
            Environment.Exit(0);
        }

        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.Cross)
            {
                MessageBox.Show("请先退出添加状态！");
                return;
            }
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }






        WorkClient workClient;
        private void btnProjConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Cursor == Cursors.Cross)
                {
                    MessageBox.Show("请先退出添加状态！");
                    return;
                }
                if (workClient != null)
                {
                    workClient.Cancellation.Cancel();
                    workClient = null;
                }
                pnlMain.Controls.Clear();
                spcMain.Panel2Collapsed = true;
                pnlMain.Controls.Add(new UCProjConfig());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnMainPage_Click(object sender, EventArgs e)//点击主页按钮
        {
            try
            {
                if (this.Cursor == Cursors.Cross)
                {
                    MessageBox.Show("请先退出添加状态！");
                    return;
                }
                StaticMethod.GetSensorNodeMsg();
                GetEnableNodes();//更新启用的节点
                if (workClient != null)
                {
                    List<int> tempSensorId = new List<int>();
                    foreach (int sensorId in Sensor_NodeMsg.sensorMsg.Keys)
                    {
                        tempSensorId.Add(sensorId);
                    }
                    workClient = new WorkClient(tempSensorId);
                }

                spcMain.Panel2Collapsed = false;
                pnlMain.Controls.Clear();

                UCHome home = new UCHome(0, 1000);
                home.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(home);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDataAnalyse_Click(object sender, EventArgs e)
        {
            return;
            if (this.Cursor == Cursors.Cross)
            {
                MessageBox.Show("请先退出添加状态！");
                return;
            }
            spcMain.Panel2Collapsed = false;
        }

        private void btnFireData_Click(object sender, EventArgs e)
        {
            return;
            if (this.Cursor == Cursors.Cross)
            {
                MessageBox.Show("请先退出添加状态！");
                return;
            }
            spcMain.Panel2Collapsed = false;
        }

        /// <summary>
        /// 更新启用的节点
        /// </summary>
        private void GetEnableNodes()
        {
            enableNodes.Clear();
            List<SSensor> sensors = sqlSelect.Select_SensorEnable();
            foreach (SSensor sensor in sensors)
            {
                List<int> tempNodes = new List<int>();
                List<SNode> nodes = sqlSelect.Select_NodeEnable(sensor.sensorId);
                foreach (SNode node in nodes)
                {
                    tempNodes.Add(node.nodeId);
                }
                enableNodes.Add(sensor.sensorId, tempNodes);
            }
        }

        STemper temper;
        private void timerInsertData_Tick(object sender, EventArgs e)
        {
            if (HomeParam.runState == 1)
            {
                foreach (int enableSensorId in enableNodes.Keys)
                {
                    List<int> enableNoedIds;
                    enableNodes.TryGetValue(enableSensorId, out enableNoedIds);
                    foreach (int enableNodeId in enableNoedIds)
                    {
                        temper.sensorId = enableNodeId;
                        temper.nodeId = enableNodeId;
                        temper.temper = Data.sensorDatas[enableSensorId].tempers[enableNodeId];
                        temper.dateTime = DateTime.Now;
                        if (Data.sensorDatas[enableSensorId].alarmStatus[enableNodeId] == 1)//火警
                        {
                            if (HomeParam.alarmMsg.Count == 0)
                            {
                                temper.status = "首警";
                                dataInsert.InsertTemper(temper);
                            }
                            else
                            {
                                temper.status = "火警";
                                dataInsert.InsertTemper(temper);
                            }

                        }else if (Data.sensorDatas[enableSensorId].faultStatus[enableNodeId] == 1)
                        {
                            temper.status = "故障";
                            dataInsert.InsertTemper(temper);
                        }else if (Data.commFaultCount[enableSensorId] == 0)
                        {
                            temper.status = "正常";
                            dataInsert.InsertTemper(temper);
                        }
                    }
                }
            }
        }
    }
}
