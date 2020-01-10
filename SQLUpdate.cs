using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_SensorModbusTCP_NetFramework
{
    class SQLUpdate: SQL_MySql_Database
    {
        public bool Update(string sql)
        {
            bool result = false;
            try
            {
                Open();
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                int count= cmd.ExecuteNonQuery();
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
    }
}
