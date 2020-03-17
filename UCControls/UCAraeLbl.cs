using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_Sensor_SM9001A
{
    public partial class UCAraeLbl : UserControl
    {
        SQLUpdate sqlUpdate = new SQLUpdate();
        SArea sArea = new SArea();
        public UCAraeLbl(SArea sArea)
        {
            InitializeComponent();
            this.sArea = sArea;
            this.areaId = sArea.areaId;
            this.areaName = sArea.areaName;
            this.able = sArea.enable;
        }

        private int areaId;//分区编号 
        private string areaName;//分区名称
        private int able;
        private string pic;

        public int AreaId { get => areaId; set => areaId = value; }
        public string AreaName { get => areaName; set => areaName = value; }
        public int Able { get => able; set => able = value; }
        public string Pic { get => pic; set => pic = value; }

        private void UCAraeLbl_Load(object sender, EventArgs e)
        {
            timerMain.Start();
            //if (HomeParam.runState != 0)
            //{
            //    this.ContextMenu = null;
            //}else if (HomeParam.runState == 0)
            //{
            //    InitCms();
            //}
        }

        private void InitCms()
        {
            if (able == 0)
            {
                启用ToolStripMenuItem.Visible = true;
                删除ToolStripMenuItem.Visible = false;
            }
            else if (able == 1)
            {
                启用ToolStripMenuItem.Visible = false;
                删除ToolStripMenuItem.Visible = true;
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            lblAreaName.Text = areaName;
            lblAreaMaxTemp.Text = "最高温度：";
        }

        private void pnlArea_MouseEnter(object sender, EventArgs e)
        {
            if (HomeParam.runState == 0)
            {
                return;
            }
            pnlArea.BackColor = Color.AliceBlue;
        }

        private void pnlArea_MouseLeave(object sender, EventArgs e)
        {
            if (HomeParam.runState == 0)
            {
                return;
            }
            pnlArea.BackColor = Color.LightSkyBlue;
        }

        private void lblAreaName_MouseEnter(object sender, EventArgs e)
        {
            if (HomeParam.runState == 0)
            {
                return;
            }
            pnlArea.BackColor = Color.AliceBlue;
        }

        private void lblAreaName_MouseLeave(object sender, EventArgs e)
        {
            if (HomeParam.runState == 0)
            {
                return;
            }
            pnlArea.BackColor = Color.LightSkyBlue;
        }

        private void lblAreaMaxTemp_MouseEnter(object sender, EventArgs e)
        {
            if (HomeParam.runState == 0)
            {
                return;
            }
            pnlArea.BackColor = Color.AliceBlue;
        }

        private void lblAreaMaxTemp_MouseLeave(object sender, EventArgs e)
        {
            if (HomeParam.runState == 0)
            {
                return;
            }
            pnlArea.BackColor = Color.LightSkyBlue;
        }

        private void 启用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlUpdate.Update_Area(areaId, 1, lblAreaName.Text);
            pnlArea.BackColor = Color.LightSkyBlue;
            Able = 1;
            InitCms();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlUpdate.Update_Area(areaId, 0, lblAreaName.Text);
            pnlArea.BackColor = Color.Gray;
            Able = 0;
            InitCms();
        }

        public event GetMsg getMsg;
        private void pnlArea_Click(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.Cross)
            {
                MessageBox.Show("请先退出添加状态！");
                return;
            }
            getMsg(sArea);//鼠标点击  会触发这个事件 这个事件是一个委托   当在福父窗体中注册这一事件  当在父窗体中点击触发这个事件  便会 触发在父窗体中新注册的时间
        }

        private void lblAreaName_Click(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.Cross)
            {
                MessageBox.Show("请先退出添加状态！");
                return;
            }
            getMsg(sArea);
        }

        private void lblAreaMaxTemp_Click(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.Cross)
            {
                MessageBox.Show("请先退出添加状态！");
                return;
            }
            getMsg(sArea);
        }
    }
    public delegate void GetMsg(SArea sArea);
}
