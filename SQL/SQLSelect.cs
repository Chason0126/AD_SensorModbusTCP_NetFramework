using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_SensorModbusTCP_NetFramework
{
    class SQLSelect: SQL_MySql_Database
    {
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
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                pwd = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
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
                string sql = "select * from sensor";
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
                throw new Exception(ex.Message + ex.StackTrace);
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
                throw new Exception(ex.Message + ex.StackTrace);
            }
            finally
            {
                Close();
            }
            return sSensor;
        }
    }
}
