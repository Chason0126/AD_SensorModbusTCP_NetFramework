using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Sensor_SM9001A
{
    interface IModBusClient
    {
        void Open();
        void Close();
        void Send(int add, int funCode, int startAdd, int num);
        byte[] Receive(byte[] bytes);
    }
}
