using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_SensorModbusTCP_NetFramework
{
    /// <summary>
    /// 连接到mysql
    /// </summary>
    public class SQL_MySql : SQL
    {
        string connstr = string.Empty;
        public SQL_MySql()
        {
            connstr = "data source =localhost;user id=root;password=adsensor;pooling=false;charset=utf8";
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
