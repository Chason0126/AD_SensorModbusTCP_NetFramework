using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Sensor_SM9001A
{
    abstract class Comm
    {
        public abstract void Open();
        public abstract void Send(byte[] bytes);
        public abstract byte[] Receive(byte[] bytes);
        public abstract void Close();
    }
}
