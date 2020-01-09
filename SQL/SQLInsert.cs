using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_SensorModbusTCP_NetFramework
{
    class SQLInsert: SQL_MySql_Database
    {
        public bool Insert(string sql)
        {
            bool result = false;
            try
            {
                Open();
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                result = true;
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
    }
}
