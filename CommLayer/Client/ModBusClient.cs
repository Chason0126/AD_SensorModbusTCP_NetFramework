using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using CRC16;

namespace AD_Sensor_SM9001A
{
    class ModBusClient : IModBusClient
    {

        private Comm comm = null;
        public ModBusClient()
        {
            string commType = ConfigurationManager.AppSettings["commType"];
            comm = (Comm)Assembly.Load("AD_Sensor").CreateInstance(commType);
        }

        //转发调用
        public void Open()
        {
            comm.Open();
        }

        public void Close()
        {
            comm.Close();
        }

        public void Send(int add, int funCode, int startAdd, int num)
        {
            byte[] bytes = new byte[8];
            try
            {
                bytes[0] = Convert.ToByte(add);
                bytes[1] = Convert.ToByte(funCode);
                bytes[2] = Convert.ToByte(startAdd >> 8);
                bytes[3] = Convert.ToByte(startAdd & 0xff);
                bytes[4] = Convert.ToByte(num >> 8);
                bytes[5] = Convert.ToByte(num & 0xff);
                bytes[6] = CRC16.CRC16.crc16(bytes, 6)[0];
                bytes[7] = CRC16.CRC16.crc16(bytes, 6)[1];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public byte[] Receive(byte[] bytes)
        {
            return comm.Receive(bytes);
        }
    }
}
