using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_SensorModbusTCP_NetFramework
{
    public struct SSensor
    {
        public int sensorId;
        public string sensorName;
        public int startNo;
        public int quantity;
        public int length;
        public int enable;
    }
    public static class DataClass
    {
        #region
        public static void ShowErrMsg(string msg)
        {
#if DEBUG
            MessageBox.Show(msg);
#else
            MessageBox.Show(msg);
            string path = "D:" + "\\" + "SM9001A";
            string name = path + "\\" + "SM9001ALog.txt";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(name))
            {
                File.CreateText(name);
            }
            if (!IsLogInUse(name))
            {
                FileStream fileStream = new FileStream(name, FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(DateTime.Now.ToString() + ":--" + msg);
                streamWriter.Flush();
                streamWriter.Close();
                fileStream.Close();
            }
#endif
        }

        private static bool IsLogInUse(string path)
        {
            bool IsInuse = true;
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
                IsInuse = false;
            }
            catch
            {

            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return IsInuse;
        }
        #endregion
        public static int userLevel = 1;

    }
}
