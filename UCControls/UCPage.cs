using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AD_Sensor_SM9001A
{
    public partial class UCPage : UserControl
    {
        private int areaId;
        string path;
        private bool addState;
        SQLUpdate sqlUpate = new SQLUpdate();
        private Dictionary<int, SSensorDisplay> sensorDisplays = new Dictionary<int, SSensorDisplay>();
        private Dictionary<SNode_id, SNodeDisplay> nodeDisplays = new Dictionary<SNode_id, SNodeDisplay>();
        public UCPage(int areaId, Dictionary<int, SSensorDisplay> sensorDisplays, Dictionary<SNode_id, SNodeDisplay> nodeDisplays, bool addState)
        {
            this.areaId = areaId;
            this.addState = addState;
            path = Environment.CurrentDirectory + "\\" + "AreaPic" + "\\" + areaId + ".jpg";
            this.sensorDisplays = sensorDisplays;
            this.nodeDisplays = nodeDisplays;
            InitializeComponent();
            InitPbx();
            Display();
        }
        private void InitPbx()
        {
            Image image = null;
            try
            {
                if (areaId <= 0 || areaId > 50)
                {
                    throw new Exception("非法的图片名称");
                }
                try
                {
                    if (File.Exists(path))
                    {
                        image = Image.FromFile(path);
                    }
                }
                catch (OutOfMemoryException)
                {
                    throw new Exception(" 该文件没有有效的图像格式。 或 - GDI+ 不支持文件的像素格式。");
                }
                catch (FileNotFoundException)
                {
                    throw new Exception("指定的文件不存在！");
                }
                catch (ArgumentException)
                {
                    throw new Exception("filename 为 System.Uri！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (image == null)
                {
                    pbx.BackgroundImage = Properties.Resources.nullPic;
                }
                else
                {
                    pbx.BackgroundImage = image;
                }
            }
        }

        public void Display()
        {
            try
            {
                pbx.Controls.Clear();
                foreach (SSensorDisplay sensorDisplay in sensorDisplays.Values)
                {
                    if (sensorDisplay.display == 1 && sensorDisplay.areaId == areaId)
                    {
                        UCSensorPic sensorPic = new UCSensorPic(sensorDisplay.areaId, sensorDisplay.sensorName, addState);
                        sensorPic.Location = new Point(Convert.ToInt32(sensorDisplay.locationX * pbx.Width), Convert.ToInt32(sensorDisplay.locationY * pbx.Height));
                        pbx.Controls.Add(sensorPic);
                    }
                }
                foreach (SNodeDisplay nodeDisplay in nodeDisplays.Values)
                {
                    if (nodeDisplay.display == 1 && nodeDisplay.areaId == areaId)
                    {
                        UCNodePic nodePic = new UCNodePic(nodeDisplay.sensorId, nodeDisplay.nodeId, nodeDisplay.nodeName, addState);
                        nodePic.Location = new Point(Convert.ToInt32(nodeDisplay.locationX * pbx.Width), Convert.ToInt32(nodeDisplay.locationY * pbx.Height));
                        pbx.Controls.Add(nodePic);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("探测器、节点加载失败！" + ex.Message);
            }
        }

        Point mouseDownLoaction;
        public event pageMouseDown GetMouseDownPosition;
        private void pbx_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLoaction = new Point(e.X, e.Y);
            GetMouseDownPosition(mouseDownLoaction);
        }

        public void AddSensor(int sensorId, string sensorName, int locationX, int locationY)
        {
            try
            {
                SSensorDisplay sensorDisplay;
                sensorDisplays.TryGetValue(sensorId, out sensorDisplay);
                if (sensorDisplay.display == 1)
                {
                    throw new Exception("探测器" + sensorId + "已经存在，请忽重复添加");
                }
                sensorDisplays.Remove(sensorId);
                sensorDisplays.Add(sensorId, new SSensorDisplay { sensorId = sensorId, sensorName = sensorName, able = 1, locationX = (double)locationX / pbx.Width, locationY = (double)locationY / pbx.Height, areaId = areaId, display = 1 });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Display();
            }
        }

        public void UpdateSensor(int sensorId, string sensorName)
        {
            try
            {
                SSensorDisplay sensorDisplay;
                sensorDisplays.TryGetValue(sensorId, out sensorDisplay);
                if (sensorDisplay.display == 0)
                {
                    throw new Exception("探测器不存在，请先添加该探测器！");
                }
                sensorDisplay.areaId = areaId;
                sensorDisplay.sensorName = sensorName;
                sensorDisplays.Remove(sensorId);
                sensorDisplays.Add(sensorId, sensorDisplay);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Display();
            }
        }

        public void DelSensor(int sensorId)
        {
            try
            {

                SSensorDisplay sensorDisplay;
                sensorDisplays.TryGetValue(sensorId, out sensorDisplay);
                if (sensorDisplay.display == 0)
                {
                    throw new Exception("探测器不存在，请先添加该探测器！");
                }
                if (MessageBox.Show("确定要删除该探测器吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    sensorDisplay.areaId = 0;
                    sensorDisplay.display = 0;
                    sensorDisplay.locationX = 0;
                    sensorDisplay.locationY = 0;
                    sensorDisplays.Remove(sensorId);
                    sensorDisplays.Add(sensorId, sensorDisplay);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Display();
            }
        }

        public void AddNode(int sensorId, int nodeId, string nodeName, int locationX, int locationY)
        {
            try
            {
                SNodeDisplay nodeDisplay;
                SNode_id node_Id = new SNode_id { sensorId = sensorId, nodeId = nodeId };
                nodeDisplays.TryGetValue(node_Id, out nodeDisplay);
                if (nodeDisplay.display == 1)
                {
                    throw new Exception("节点" + sensorId + "-" + nodeId + "+已经存在，请忽重复添加");
                }
                nodeDisplay.nodeName = nodeName;
                nodeDisplay.sensorId = sensorId;
                nodeDisplay.nodeId = nodeId;
                nodeDisplay.areaId = areaId;
                nodeDisplay.locationX = (double)locationX / pbx.Width;
                nodeDisplay.locationY = (double)locationY / pbx.Height;
                nodeDisplay.display = 1;
                nodeDisplays.Remove(node_Id);
                nodeDisplays.Add(node_Id, nodeDisplay);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Display();
            }
        }

        public void UpdateNode(int sensorId, int nodeId, string nodeName)
        {
            try
            {
                SNodeDisplay nodeDisplay;
                SNode_id node_Id = new SNode_id { sensorId = sensorId, nodeId = nodeId };
                nodeDisplays.TryGetValue(node_Id, out nodeDisplay);
                if (nodeDisplay.display == 0)
                {
                    throw new Exception("节点不存在，请先添加该节点！");
                }
                nodeDisplay.nodeName = nodeName;
                nodeDisplay.areaId = areaId;
                nodeDisplays.Remove(node_Id);
                nodeDisplays.Add(node_Id, nodeDisplay);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Display();
            }
        }

        public void DelNode(int sensorId, int nodeId)
        {
            try
            {
                SNodeDisplay nodeDisplay;
                SNode_id node_Id = new SNode_id { sensorId = sensorId, nodeId = nodeId };
                nodeDisplays.TryGetValue(node_Id, out nodeDisplay);
                if (nodeDisplay.display == 0)
                {
                    throw new Exception("节点不存在，请先添加该节点！");
                }
                if (MessageBox.Show("确定要删除该节点吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    nodeDisplay.areaId = 0;
                    nodeDisplay.display = 0;
                    nodeDisplay.locationX = 0;
                    nodeDisplay.locationY = 0;
                    nodeDisplays.Remove(node_Id);
                    nodeDisplays.Add(node_Id, nodeDisplay);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Display();
            }
        }

        public void SaveSensorNode()
        {
            try
            {
                FrmProgress frmProgress = new FrmProgress();
                frmProgress.Show();
                foreach (Control control in pbx.Controls)
                {

                    if (control is UCSensorPic)
                    {
                        frmProgress.SetPercent(25);
                        UCSensorPic sensorPic = control as UCSensorPic;
                        SSensorDisplay sensorDisplay;
                        sensorDisplays.TryGetValue(sensorPic.SensorId, out sensorDisplay);
                        sensorDisplay.locationX = (double)sensorPic.Location.X / pbx.Width;
                        sensorDisplay.locationY = (double)sensorPic.Location.Y / pbx.Height;
                        sensorDisplays.Remove(sensorPic.SensorId);
                        sensorDisplays.Add(sensorPic.SensorId, sensorDisplay);
                    }
                    else if (control is UCNodePic)
                    {
                        frmProgress.SetPercent(45);
                        UCNodePic nodePic = control as UCNodePic;
                        SNodeDisplay nodeDisplay;
                        SNode_id node_Id = new SNode_id { sensorId = nodePic.SensorId, nodeId = nodePic.NodeId };
                        nodeDisplays.TryGetValue(node_Id, out nodeDisplay);
                        nodeDisplay.locationX = (double)nodePic.Location.X / pbx.Width;
                        nodeDisplay.locationY = (double)nodePic.Location.Y / pbx.Height;
                        nodeDisplays.Remove(node_Id);
                        nodeDisplays.Add(node_Id, nodeDisplay);
                    }
                }
                foreach (SSensorDisplay sensor in sensorDisplays.Values)
                {
                    frmProgress.SetPercent(55);
                    if (!sqlUpate.Update_Sensor(sensor.sensorId, sensor.sensorName, sensor.locationX, sensor.locationY, sensor.areaId, sensor.display))
                    {
                        throw new Exception("保存失败，请重试！");
                    }
                }
                foreach (SNodeDisplay node in nodeDisplays.Values)
                {
                    frmProgress.SetPercent(80);
                    if (!sqlUpate.Update_Node(node.sensorId, node.nodeId, node.nodeName, node.locationX, node.locationY, node.areaId, node.display))
                    {
                        throw new Exception("保存失败，请重试！");
                    }
                }
                frmProgress.Close();
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Display();
            }
        }

        private void pbx_SizeChanged(object sender, EventArgs e)
        {
            Display();
        }
    }
    public delegate void pageMouseDown(Point point);
}
