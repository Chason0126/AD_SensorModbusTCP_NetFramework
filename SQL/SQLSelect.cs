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
            return pwd;
        }
    }
}
