using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Sensor_SM9001A
{
    class CSensorData
    {
        public int add = 0;//探测器编号
        public int alarmState = 0;//火警状态
        public int faultState = 0;//故障状态
        public int maxTemper = 0;//实时最高温度
        public int maxTemperDistance = 0;//最高温度距离
        public int alarmDistance = 0;//首警距离
        public int faultDistance = 0;//首故障距离
        public int alarmCount = 0;//火警总数
        public int faultConut = 0;//故障总数
        public int[] alarmStatus;//节点报警状态
        public int[] faultStatus;//节点故障状态
        public int[] tempers;//节点温度信息
    }

    class Data
    {
        public static List<CSensorData> sensorDatas;//探测器数据  需要初始化
        public static int[] commFaultCount = new int[256];//通讯故障计数
        public static int[] queryAlarmCount = new int[256];//查询到的 火警数量
        public static int[] queryFaultCount = new int[256];//查询到的 故障数量
    }

    class HomeParam
    {
        public static string projName = null;
        public static int userLevel = 1;//用户等级

        public static int runState;//主界面显示的运行状态 0系统停止 1系统运行
        public static int commFaultSum = 0;//通讯故障总数
        public static int queryAlarmSum = 0;//节点火警总数
        public static int queryFaultSum = 0;//节点故障总数
        public static int commFaultThreshold = 20;

        public static bool IsNotUpdateMsg = false;
        public static readonly object dictionaryObj = new object();
        public static Dictionary<int, SCommFaultMsg> commFaultMsg = new Dictionary<int, SCommFaultMsg>();
        public static Dictionary<SNode_id, SAlarmMsg> alarmMsg = new Dictionary<SNode_id, SAlarmMsg>();
        public static Dictionary<SNode_id, SFaultMsg> faultMsg = new Dictionary<SNode_id, SFaultMsg>();

    }
    class Sensor_NodeMsg
    {
        public static Dictionary<int, SSensor> sensorMsg = new Dictionary<int, SSensor>();//存储启用的探测器的信息
        public static Dictionary<SNode_id, SNode> nodeMsg = new Dictionary<SNode_id, SNode>();//存取启用的 节点的信息
    }
}
