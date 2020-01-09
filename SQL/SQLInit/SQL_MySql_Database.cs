using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_SensorModbusTCP_NetFramework
{
    /// <summary>
    /// 连接到MySql的具体数据库
    /// </summary>
    public class SQL_MySql_Database : SQL
    {
        string connstr = string.Empty;
        public string database = string.Empty;
        string user_id = string.Empty;
        string password = string.Empty;
        public SQL_MySql_Database()
        {
            database = ConfigurationManager.AppSettings["database"].ToString();
            user_id = ConfigurationManager.AppSettings["user_id"].ToString();
            password = ConfigurationManager.AppSettings["password"].ToString();
            connstr = "data source =localhost;database=" + database + ";user id=" + user_id + ";password=" + password + ";pooling=false;charset=utf8";
        }
        public override void Open()
        {
            conn = new MySqlConnection(connstr);
            conn.Open();
        }

        public override void Close()
        {
            conn.Close();
        }

    }
}
