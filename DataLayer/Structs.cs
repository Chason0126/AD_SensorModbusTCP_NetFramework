using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_Sensor_SM9001A
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

    public struct SNode
    {
        public int sensorId;
        public int nodeId;
        public string nodeName;
        public int enable;
    }

    public struct SArea
    {
        public int areaId;
        public int orderId;
        public string areaName;
        public int enable;
    }

    public struct SSpParam
    {
        public string portName;//串口名称
        public int baudRate;//串口波特率
        public Parity parity;//就检验位
        public int dataBits;//数据位
        public StopBits stopBits;//停止位
        public int readTimeout;//串口读超时
        public int writeTimeout;//写超时
    }
    public struct SNode_id
    {
        public int sensorId;
        public int nodeId;
    }

    public struct SAlarmMsg//火警信息结构体
    {
        public int sensorId;
        public int nodeId;
        public DateTime dateTime;
        public string type;
        public string remarks;
    }

    public struct SFaultMsg//故障信息结构体
    {
        public int sensorId;
        public int nodeId;
        public DateTime dateTime;
        public string type;
        public string remarks;
    }
    public struct SCommFaultMsg
    {
        public int sensorId;
        public DateTime dateTime;
        public string type;
        public string remarks;
    }

    public struct SSensorDisplay
    {
        public int sensorId;
        public string sensorName;
        public int able;
        public double locationX;
        public double locationY;
        public int areaId;
        public int display;
    }

    public struct SNodeDisplay
    {
        public int sensorId;
        public int nodeId;
        public string nodeName;
        public int able;
        public double locationX;
        public double locationY;
        public int areaId;
        public int display;
    }

    public struct STemper
    {
        public int sensorId;
        public int nodeId;
        public DateTime dateTime;
        public int temper;
        public string status;//正常 故障  首警 火警
    }
}
