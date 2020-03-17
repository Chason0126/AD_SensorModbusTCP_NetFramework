using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AD_Sensor_SM9001A
{
    class SQLSelect : SQL_MySql_Database
    {
        /// <summary>
        /// 获取工程名称
        /// </summary>
        /// <returns></returns>
        public string GetProjName()
        {
            string projName = null;
            try
            {
                string sql = "select prjName from prjName ";
                Open();
                cmd = new MySqlCommand(sql, conn);
                projName = cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                throw new Exception("获取工程名称失败！" + e.Message);
            }
            return projName;
        }

        /// <summary>
        /// 根据密码Id查询 密码
        /// </summary>
        /// <param name="pwdId"></param>
        /// <returns></returns>
        public string Select_Pwd(int pwdId)
        {
            string pwd = string.Empty;
            try
            {
                string sql = "select passWord from pwd where pwdId='" + pwdId + "'";
                Open();
                cmd = new MySqlCommand(sql, conn);
                pwd = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("获取密码表失败" + ex.Message);
            }
            finally
            {
                Close();
            }
            return pwd;
        }

        /// <summary>
        /// 获取探测器信息表
        /// </summary>
        /// <returns></returns>
        public List<SSensor> Select_Sensor()
        {
            List<SSensor> list = new List<SSensor>();
            SSensor sSensor;
            try
            {
                string sql = "select * from sensor order by sensorId";
                Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    sSensor = new SSensor();
                    sSensor.sensorId = Convert.ToInt32(mySqlDataReader.GetValue(0));
                    sSensor.sensorName = Convert.ToString(mySqlDataReader.GetValue(1));
                    sSensor.startNo = Convert.ToInt32(mySqlDataReader.GetValue(2));
                    sSensor.quantity = Convert.ToInt32(mySqlDataReader.GetValue(3));
                    sSensor.length = Convert.ToInt32(mySqlDataReader.GetValue(4));
                    sSensor.enable = Convert.ToInt32(mySqlDataReader.GetValue(5));
                    list.Add(sSensor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取探测器表失败" + ex.Message);
            }
            finally
            {
                Close();
            }
            return list;
        }

        /// <summary>
        /// 获取启用的探测器
        /// </summary>
        /// <returns></returns>
        public List<SSensor> Select_SensorEnable()
        {
            List<SSensor> list = new List<SSensor>();
            SSensor sSensor;
            try
            {
                string sql = "select * from sensor where able=1 order by sensorId ";
                Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    sSensor = new SSensor();
                    sSensor.sensorId = Convert.ToInt32(mySqlDataReader.GetValue(0));
                    sSensor.sensorName = Convert.ToString(mySqlDataReader.GetValue(1));
                    sSensor.startNo = Convert.ToInt32(mySqlDataReader.GetValue(2));
                    sSensor.quantity = Convert.ToInt32(mySqlDataReader.GetValue(3));
                    sSensor.length = Convert.ToInt32(mySqlDataReader.GetValue(4));
                    sSensor.enable = Convert.ToInt32(mySqlDataReader.GetValue(5));
                    list.Add(sSensor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取探测器表失败" + ex.Message);
            }
            finally
            {
                Close();
            }
            return list;
        }

        /// <summary>
        /// 获取指定的探测器信息
        /// </summary>
        /// <param name="sensorId">探测器编号</param>
        /// <returns></returns>
        public SSensor Select_Sensor(int sensorId)
        {
            SSensor sSensor = new SSensor();
            try
            {
                string sql = "select * from sensor where sensorId='" + sensorId + "'";
                Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    sSensor.sensorId = Convert.ToInt32(mySqlDataReader.GetValue(0));
                    sSensor.sensorName = Convert.ToString(mySqlDataReader.GetValue(1));
                    sSensor.startNo = Convert.ToInt32(mySqlDataReader.GetValue(2));
                    sSensor.quantity = Convert.ToInt32(mySqlDataReader.GetValue(3));
                    sSensor.length = Convert.ToInt32(mySqlDataReader.GetValue(4));
                    sSensor.enable = Convert.ToInt32(mySqlDataReader.GetValue(5));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取探测器表失败" + ex.Message);
            }
            finally
            {
                Close();
            }
            return sSensor;
        }


        /// <summary>
        /// 按探测器编号获取节点表 
        /// </summary>
        /// <param name="sensorId">探测器编号</param>
        /// <returns></returns>
        public List<SNode> Select_Node(int sensorId)
        {
            List<SNode> list = new List<SNode>();
            SNode sNode;
            try
            {
                string sql = "select * from node where sensorId='" + sensorId + "' order by nodeId";
                Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    sNode = new SNode();
                    sNode.sensorId = Convert.ToInt32(mySqlDataReader.GetValue(0));
                    sNode.nodeId = Convert.ToInt32(mySqlDataReader.GetValue(1));
                    sNode.nodeName = Convert.ToString(mySqlDataReader.GetValue(2));
                    sNode.enable = Convert.ToInt32(mySqlDataReader.GetValue(3));
                    list.Add(sNode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取节点表失败" + ex.Message);
            }
            finally
            {
                Close();
            }
            return list;
        }

        /// <summary>
        /// 获取启用的节点
        /// </summary>
        /// <param name="sensorId">探测器编号</param>
        /// <returns></returns>
        public List<SNode> Select_NodeEnable(int sensorId)
        {
            List<SNode> list = new List<SNode>();
            SNode sNode;
            try
            {
                string sql = "select * from node where sensorId='" + sensorId + "' and able=1 order by nodeId";
                Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    sNode = new SNode();
                    sNode.sensorId = Convert.ToInt32(mySqlDataReader.GetValue(0));
                    sNode.nodeId = Convert.ToInt32(mySqlDataReader.GetValue(1));
                    sNode.nodeName = Convert.ToString(mySqlDataReader.GetValue(2));
                    sNode.enable = Convert.ToInt32(mySqlDataReader.GetValue(3));
                    list.Add(sNode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取节点表失败" + ex.Message);
            }
            finally
            {
                Close();
            }
            return list;
        }

        public SNode Select_Node(int sensorId, int nodeId)
        {
            SNode sNode = new SNode();
            try
            {
                string sql = "select * from node where sensoId='" + sensorId + "' and nodeId='" + nodeId + "'";
                Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    sNode = new SNode();
                    sNode.sensorId = Convert.ToInt32(mySqlDataReader.GetValue(0));
                    sNode.nodeId = Convert.ToInt32(mySqlDataReader.GetValue(1));
                    sNode.nodeName = Convert.ToString(mySqlDataReader.GetValue(2));
                    sNode.enable = Convert.ToInt32(mySqlDataReader.GetValue(3));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取节点表失败" + ex.Message);
            }
            finally
            {
                Close();
            }
            return sNode;
        }

        public List<SArea> Select_Area()
        {
            List<SArea> list = new List<SArea>();
            SArea sArea = new SArea();
            try
            {
                string sql = "select * from area order by orderId desc";
                Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    sArea.areaId = Convert.ToInt32(mySqlDataReader.GetValue(0));
                    sArea.orderId = Convert.ToInt32(mySqlDataReader.GetValue(1));
                    sArea.areaName = Convert.ToString(mySqlDataReader.GetValue(2));
                    sArea.enable = Convert.ToInt32(mySqlDataReader.GetValue(3));
                    list.Add(sArea);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取分区表失败" + ex.Message);
            }
            finally
            {
                Close();
            }
            return list;
        }

        public SArea Select_Area(int areaId)
        {
            SArea sArea = new SArea();
            try
            {
                string sql = "select * from area where areaId ='" + areaId + "'";
                Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    sArea.areaId = Convert.ToInt32(mySqlDataReader.GetValue(0));
                    sArea.orderId = Convert.ToInt32(mySqlDataReader.GetValue(1));
                    sArea.areaName = Convert.ToString(mySqlDataReader.GetValue(2));
                    sArea.enable = Convert.ToInt32(mySqlDataReader.GetValue(3));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取分区表失败" + ex.Message);
            }
            finally
            {
                Close();
            }
            return sArea;
        }

        /// <summary>
        /// 获取用于展示图标的探测器表
        /// </summary>
        /// <returns>List<SSensorDisplay></returns>
        public List<SSensorDisplay> Select_SensorDisplay()
        {

            List<SSensorDisplay> list = new List<SSensorDisplay>();
            SSensorDisplay sensorDisplay;
            try
            {
                string sql = "select * from sensor where able=1 order by sensorId asc";
                Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    sensorDisplay.sensorId = Convert.ToInt32(mySqlDataReader.GetValue(0));
                    sensorDisplay.sensorName = Convert.ToString(mySqlDataReader.GetValue(1));
                    sensorDisplay.able = Convert.ToInt32(mySqlDataReader.GetValue(5));
                    sensorDisplay.locationX = Convert.ToDouble(mySqlDataReader.GetValue(6));
                    sensorDisplay.locationY = Convert.ToDouble(mySqlDataReader.GetValue(7));
                    sensorDisplay.areaId = Convert.ToInt32(mySqlDataReader.GetValue(8));
                    sensorDisplay.display = Convert.ToInt32(mySqlDataReader.GetValue(9));
                    list.Add(sensorDisplay);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取探测器表失败" + ex.Message);
            }
            finally
            {
                Close();
            }
            return list;
        }

        /// <summary>
        /// 获取用于展示图标的节点表
        /// </summary>
        /// <param name="sensorId"></param>
        /// <returns></returns>
        public List<SNodeDisplay> Select_NodeDisplay(int sensorId)
        {

            List<SNodeDisplay> list = new List<SNodeDisplay>();
            SNodeDisplay nodeDisplay;
            try
            {
                string sql = "select * from node where able=1 and sensorId='" + sensorId + "' order by sensorId asc";
                Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    nodeDisplay.sensorId = Convert.ToInt32(mySqlDataReader.GetValue(0));
                    nodeDisplay.nodeId = Convert.ToInt32(mySqlDataReader.GetValue(1));
                    nodeDisplay.nodeName = Convert.ToString(mySqlDataReader.GetValue(2));
                    nodeDisplay.able = Convert.ToInt32(mySqlDataReader.GetValue(3));
                    nodeDisplay.locationX = Convert.ToDouble(mySqlDataReader.GetValue(4));
                    nodeDisplay.locationY = Convert.ToDouble(mySqlDataReader.GetValue(5));
                    nodeDisplay.areaId = Convert.ToInt32(mySqlDataReader.GetValue(6));
                    nodeDisplay.display = Convert.ToInt32(mySqlDataReader.GetValue(7));
                    list.Add(nodeDisplay);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取探测器表失败" + ex.Message);
            }
            finally
            {
                Close();
            }
            return list;
        }
    }
}
