using System;
using System.Configuration;
using System.IO.Ports;
using System.Net;

namespace AD_Sensor_SM9001A
{
    public class ConfigClass
    {
        /// <summary>
        /// 获取配置文件 串口参数
        /// </summary>
        /// <returns></returns>
        public static SSpParam Get_PortParam()
        {

            SSpParam spParam;
            try
            {
                spParam.portName = Convert.ToString(ConfigurationManager.AppSettings["portName"]);
                spParam.baudRate = Convert.ToInt32(ConfigurationManager.AppSettings["baudRate"]);
                spParam.parity = (Parity)Convert.ToInt32(ConfigurationManager.AppSettings["parity"]);
                spParam.dataBits = Convert.ToInt32(ConfigurationManager.AppSettings["dataBits"]);
                spParam.stopBits = (StopBits)Convert.ToInt32(ConfigurationManager.AppSettings["stopBits"]);
                spParam.readTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["readtimeout"]);
                spParam.writeTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["writeTimeout"]);
            }
            catch (Exception)
            {
                throw new Exception("【串口】配置文件【读取】异常，请检查后再试！");
            }
            return spParam;

        }

        /// <summary>
        /// 修改串口参数  其他参数需要通过配置文件修改
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="readTimeout">读超时</param>
        /// <param name="writeTimeout">写超时</param>
        public static void Set_PortParam(string portName, int baudRate, int readTimeout, int writeTimeout)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["portName"].Value = portName;
                configuration.AppSettings.Settings["baudRate"].Value = baudRate.ToString();
                configuration.AppSettings.Settings["readTimeout"].Value = readTimeout.ToString();
                configuration.AppSettings.Settings["writeTimeout"].Value = writeTimeout.ToString();
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
                throw new Exception("【串口】配置文件【修改】异常，请检查后再试！");
            }
        }

        public static void Set_PortParam(string portName, int baudRate)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["portName"].Value = portName;
                configuration.AppSettings.Settings["baudRate"].Value = baudRate.ToString();
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
                throw new Exception("【串口】配置文件【修改】异常，请检查后再试！");
            }
        }

        /// <summary>
        /// 获取配置文件 网络参数 
        /// </summary>
        /// <returns></returns>
        public static IPEndPoint Get_TCPParam()
        {
            try
            {
                IPEndPoint endPoint;
                IPAddress iPAddress = IPAddress.Parse(ConfigurationManager.AppSettings["ip"]);
                string port_ = ConfigurationManager.AppSettings["port"];
                int port = Convert.ToInt32(port_);
                endPoint = new IPEndPoint(iPAddress, port);
                return endPoint;
            }
            catch (ArgumentNullException)
            {
                throw new Exception(" address 为 null");
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new Exception(" address 或者port值超出范围");
            }
            catch (Exception)
            {
                throw new Exception("【网络】配置【读取】文件异常，请检查后再试！");
            }
        }

        /// <summary>
        /// 设置 配置文件中IP地址 端口号的信息 
        /// </summary>
        /// <param name="endPoint"></param>
        public static void Set_TCPParam(IPEndPoint endPoint)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["ip"].Value = endPoint.Address.ToString();
                configuration.AppSettings.Settings["port"].Value = endPoint.Port.ToString();
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
                throw new Exception("【网络】配置文件【修改】异常，请检查后再试！");
            }
        }

        public static string Get_commType()
        {
            string commType = null;
            try
            {
                commType = ConfigurationManager.AppSettings["commType"];
            }
            catch (Exception)
            {

                throw new Exception("【协议类型】配置文件【读取】异常，请检查后再试！");
            }
            return commType;
        }

        public static void Set_commType(string commType)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["commType"].Value = commType;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
                throw new Exception("【协议类型】配置文件【修改】异常，请检查后再试！");
            }
        }

        public static void Get_commParam(out int inspectionTime,out int readTimeout,out int writeTimeout)
        {
            try
            {
                inspectionTime = Convert.ToInt32(ConfigurationManager.AppSettings["inspectionTime"]);
                readTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["readTimeout"]);
                writeTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["writeTimeout"]);
            }
            catch (Exception)
            {
                throw new Exception("【通讯参数】配置文件【读取】异常，请检查后再试！");
            }
        }

        public static void Set_commParam(int inspectionTime)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["inspectionTime"].Value = inspectionTime.ToString();
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
                throw new Exception("【通讯参数】配置文件【修改】异常，请检查后再试！");
            }
        }
    }
}
