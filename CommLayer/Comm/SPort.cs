using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Configuration;

namespace AD_Sensor_SM9001A
{
    class SPort
    {
        private static SerialPort serialPort = null;
        private static readonly object syncRoot = new object();
        private SPort()
        {

        }
        public static SerialPort GetPort()
        {
            try
            {
                string portName = ConfigurationManager.AppSettings["portName"];
                int baudRate = Convert.ToInt32(ConfigurationManager.AppSettings["baudRate"]);
                Parity parity = (Parity)(Convert.ToInt32(ConfigurationManager.AppSettings["parity"]));
                int dataBits = Convert.ToInt32(ConfigurationManager.AppSettings["dataBits"]);
                StopBits stopBits = (StopBits)Convert.ToInt32(ConfigurationManager.AppSettings["stopBits"]);
                int readTimeout= Convert.ToInt32(ConfigurationManager.AppSettings["readTimeout"]);
                int writeTimeout= Convert.ToInt32(ConfigurationManager.AppSettings["writeTimeout"]);
                if (serialPort == null)
                {
                    lock (syncRoot)
                    {
                        if (serialPort == null)
                        {
                            try
                            {
                                serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                                serialPort.ReadTimeout = readTimeout;
                                serialPort.WriteTimeout = writeTimeout;
                            }
                            catch (IOException e)
                            {
                                throw new Exception("未能找到或打开指定的端口" + e.Message);
                            }
                        }
                    }
                }
                else
                {
                    serialPort.PortName = portName;
                    serialPort.BaudRate = baudRate;
                    serialPort.Parity = parity;
                    serialPort.DataBits = dataBits;
                    serialPort.StopBits = stopBits;
                    serialPort.ReadTimeout = readTimeout;
                    serialPort.WriteTimeout = writeTimeout;
                }
            }
            catch (Exception e)
            {

                throw new Exception("串口配置文件异常" + e.Message);
            }
            return serialPort;
        }

    }
}
