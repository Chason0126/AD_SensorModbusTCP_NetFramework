using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AD_Sensor_SM9001A
{
    class SQLProcedure:SQL_MySql_Database
    {
        public bool Call_Procedure(string proedureName)
        {
            bool result = false;
            try
            {
                Open();
                cmd = new MySqlCommand(proedureName, conn);
               
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@i", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@j", MySqlDbType.Int32));
                cmd.Parameters["@i"].Value = 255;
                cmd.Parameters["@j"].Value = 255;
                cmd.CommandText = proedureName;
                int count = cmd.ExecuteNonQuery();
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
