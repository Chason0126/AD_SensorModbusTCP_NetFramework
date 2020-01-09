using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_SensorModbusTCP_NetFramework
{
    public class Create_Init : SQL_MySql
    {
        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="dbName"></param>
        public bool Create_DB(string dbName)
        {
            bool result = false;
            try
            {
                if (!IsDB_Exit(dbName))//数据库不存在
                {
                    string sql = "create database " + dbName + "";
                    Open();
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                else//存在
                {
                    result = true;
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
            return result;
        }

        /// <summary>
        /// 判断数据库是否存在
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        private bool IsDB_Exit(string dbName)
        {
            bool result = false;
            try
            {
                string sql = "SELECT * FROM information_schema.SCHEMATA where SCHEMA_NAME='" + dbName + "'";
                Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = true;
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
            return result;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Create_User(string userName, string pwd)
        {
            bool result = false;
            try
            {
                if (!IsUser_Exit(userName))//不存在
                {
                    string sql = "CREATE USER  '" + userName + "'@'%'  IDENTIFIED BY  '" + pwd + "'";
                    Open();
                    cmd = new MySqlCommand(sql, conn);
                    int count = cmd.ExecuteNonQuery();
                    result = count >= 0 ? true : false;
                    if (!Grant(userName))
                    {
                        result = false;
                    }
                }
                else//存在
                {
                    result = true;
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
            return result;
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private bool IsUser_Exit(string userName)
        {
            bool result = false;
            try
            {
                string sql = " SELECT EXISTS(SELECT 1 FROM mysql.user WHERE user = '" + userName + "')";
                Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = Convert.ToInt32(reader.GetValue(0)) == 0 ? false : true;
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
            return result;
        }
        /// <summary>
        /// 用户授权  增删查改
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private bool Grant(string userName)
        {
            bool result = false;
            try
            {
                //Open();
                string sql = "grant select,insert,update,delete,create on SM9001A.* to '" + userName + "'";
                cmd = new MySqlCommand(sql, conn);
                int count = cmd.ExecuteNonQuery();
                result = count >= 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            finally
            {
                //Close();
            }
            return result;
        }
    }
}
