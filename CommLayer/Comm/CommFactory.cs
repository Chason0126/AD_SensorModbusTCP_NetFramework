using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Sensor_SM9001A
{
    class CommFactory
    {
        public static Comm GetComm(string arg)
        {
            Comm comm = null;
            try
            {
                if (arg.Equals("RTU"))
                {
                    comm = new ModBus_RTU();
                }
                else if (arg.Equals("TCP"))
                {
                    comm = new ModBus_TCP();
                }
                else if (arg.Equals("ASCII"))
                {
                    throw new Exception("预留的通讯协议");
                }
                else
                {
                    throw new Exception("通讯协议参数异常");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return comm;
        }
    }
}
