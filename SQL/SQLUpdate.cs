using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Sensor_SM9001A
{
    class SQLUpdate : SQL_MySql_Database
    {
        public bool Update(string sql)
        {
            bool result = false;
            try
            {
                Open();
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                int count = cmd.ExecuteNonQuery();
                result = count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            finally
            {
                Close();
            }
            return result;
        }

        public bool SetProjName(string prjname)
        {
            bool result = false;
            try
            {
                int count = 0;
                string sql;
                Open();
                sql = "update prjname set prjname='" + prjname + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                count = cmd.ExecuteNonQuery() + count;
                result = count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            finally
            {
                Close();
            }
            return result;
        }

        public bool Update_Sensor(int sensorId, string sensorName, int startNo, int quantity, int length, int able)
        {
            bool result = false;
            try
            {
                int count = 0;
                string sql = "update sensor set sensorName = '" + sensorName + "', startNo = '" + startNo + "', quantity = '" + quantity + "', length = '" + length + "', able = '" + able + "' where sensorId = '" + sensorId + "'";
                Open();
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                count = cmd.ExecuteNonQuery() + count;
                result = count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            finally
            {
                Close();
            }
            return result;
        }

        public bool Update_Sensor(int sensorId, string sensorName, double locationx, double locationy, int areaid, int display)
        {
            bool result = false;
            try
            {
                int count = 0;
                string sql = "update sensor set sensorName = '" + sensorName + "', locationx = '" + locationx + "', locationy = '" + locationy + "', areaid = '" + areaid + "', display = '" + display + "' where sensorId = '" + sensorId + "'";
                Open();
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                count = cmd.ExecuteNonQuery() + count;
                result = count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            finally
            {
                Close();
            }
            return result;
        }


        public bool Update_Node(int sensorId, int startNo, int quantity, int length)
        {
            bool result = false;
            try
            {
                int count = 0;
                string sql;
                Open();
                for (int i = 1; i <= 255; i++)
                {
                    if (i >= startNo && i < startNo + quantity)
                    {
                        sql = "update node set nodeName='" + (length * i) + "米 ' ,able='1' where sensorId='" + sensorId + "' and nodeId='" + i + "'";
                    }
                    else
                    {
                        sql = "update node set nodeName='" + (length * i) + "米 ',able='0' where sensorId='" + sensorId + "' and nodeId='" + i + "'";
                    }
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    count = cmd.ExecuteNonQuery() + count;
                }
                result = count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            finally
            {
                Close();
            }
            return result;
        }

        public bool Update_Node(int sensorId, int nodeId, string nodeName,double locationx, double locationy, int areaId, int display)
        {
            bool result = false;
            try
            {
                int count = 0;
                string sql;
                Open();

                sql = "update node set nodeName='" + nodeName + "',locationx='" + locationx + "',locationy='" + locationy + "',areaid = '" + areaId + "', display = '" + display + "' where sensorId='" + sensorId + "' and nodeId='" + nodeId + "'";

                cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                count = cmd.ExecuteNonQuery() + count;

                result = count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            finally
            {
                Close();
            }
            return result;
        }

        public bool Update_Node(int sensorId, int startNo, int quantity)
        {
            bool result = false;
            try
            {
                int count = 0;
                string sql;
                Open();
                for (int i = 1; i <= 255; i++)
                {
                    if (i >= startNo && i < startNo + quantity)
                    {
                        sql = "update node set able='1' where sensorId='" + sensorId + "' and nodeId='" + i + "'";
                    }
                    else
                    {
                        sql = "update node set able='0' where sensorId='" + sensorId + "' and nodeId='" + i + "'";
                    }
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    count = cmd.ExecuteNonQuery() + count;
                }
                count = cmd.ExecuteNonQuery();
                result = count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            finally
            {
                Close();
            }
            return result;
        }

        public bool Update_Node(int sensorId, int nodeId, string nodeName)
        {
            bool result = false;
            try
            {
                int count = 0;
                string sql;
                Open();
                sql = "update node set nodeName='" + nodeName + "米' where sensorId='" + sensorId + "' and nodeId='" + nodeId + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                count = cmd.ExecuteNonQuery() + count;
                count = cmd.ExecuteNonQuery();
                result = count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            finally
            {
                Close();
            }
            return result;
        }

        /// <summary>
        /// 更新分区启用
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="able"></param>
        /// <returns></returns>
        public bool Update_Area(int areaId, int able, string areaName)
        {
            bool result = false;
            try
            {
                int count = 0;
                string sql;
                Open();
                sql = "update area set able='" + able + "' ,areaName='" + areaName + "' where areaId='" + areaId + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                count = cmd.ExecuteNonQuery() + count;
                result = count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            finally
            {
                Close();
            }
            return result;
        }

        /// <summary>
        /// 更新分区背图片
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="pic"></param>
        /// <returns></returns>
        public bool Update_PicPath(int areaId, string path)
        {
            bool result = false;
            try
            {
                int count = 0;
                string sql;
                Open();
                //if (pic.Length > 4194304)
                //{
                //    throw new Exception("图片过大！");
                //}
                sql = "update area set pic='" + path + "' where areaId='" + areaId + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                //cmd.Parameters.Add("@image", MySql.Data.MySqlClient.MySqlDbType.Binary, pic.Length);
                //cmd.Parameters["@image"].Value = pic;
                count = cmd.ExecuteNonQuery();
                result = count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Packets larger than max_allowed_packet are not allowed."))
                {
                    throw new Exception("图片过大！" + ex.Message + ex.StackTrace);
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
            finally
            {
                Close();
            }
            return result;
        }
    }
}
