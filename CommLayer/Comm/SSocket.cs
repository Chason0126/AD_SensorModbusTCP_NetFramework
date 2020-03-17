using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Configuration;

namespace AD_Sensor_SM9001A
{
    class SSocket
    {
        private static Socket socket = null;
        private static readonly object syncRoot = new object();
        public static IPEndPoint ipe;

      

        private SSocket()
        { }

        public static Socket GetSocket()
        {
            if (socket == null)
            {
                lock (syncRoot)
                {
                    if (socket == null)
                    {
                        try
                        {
                            string ip = ConfigurationManager.AppSettings["ip"];
                            int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
                            IPAddress iPAddress = null;
                            IPAddress.TryParse(ip, out iPAddress);
                            ipe = new IPEndPoint(iPAddress, port);
                            
                            socket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                            
                        }
                        catch (SocketException e)
                        {
                            throw new Exception("addressFamily、socketType 和 protocolType 的组合会导致无效套接字" + e.Message);
                        }
                    }
                }
            }
            return socket;
        }
    }
}
