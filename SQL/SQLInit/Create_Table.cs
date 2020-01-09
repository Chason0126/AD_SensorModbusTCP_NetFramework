using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_SensorModbusTCP_NetFramework
{
    public class Create_Table : SQL_MySql_Database
    {
        public bool CreateTable(string tableName, string sql)
        {
            bool result = false;
            try
            {
                Open();
                cmd = new MySqlCommand(sql, conn);
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
        public bool IsTable_Exit(string tableName)
        {
            bool result = false;
            try
            {
                string sql = "select * from information_schema.tables where table_schema='" + database + "' and table_name = '" + tableName + "'";
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
    }
}
