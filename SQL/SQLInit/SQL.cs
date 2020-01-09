using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_SensorModbusTCP_NetFramework
{
    public abstract class SQL
    {
       public MySqlCommand cmd;
       public  MySqlConnection conn;

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public abstract void Open();
        /// <summary>
        /// 关数据库连接
        /// </summary>
        public abstract void Close();
    }


   

       

    
}
