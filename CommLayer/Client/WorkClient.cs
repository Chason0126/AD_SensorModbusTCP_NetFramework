using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CRC16;
using System.Configuration;

namespace AD_Sensor_SM9001A
{
    class WorkClient
    {
        CancellationTokenSource cancellation = new CancellationTokenSource();
        IModBusClient modBusClient = null;
        Thread workThread = null;
        List<int> sensorAdds;

        byte[] bytes;

        public CancellationTokenSource Cancellation { get => cancellation; set => cancellation = value; }

        /// <summary>
        /// 工作客户端类 封装业务逻辑 数据分析
        /// </summary>
        /// <param name="sensorAdds">启用的探测器地址编号 数组</param>
        public WorkClient(List<int> sensorAdds)
        {
            InitSensorData();
            this.sensorAdds = sensorAdds;
            modBusClient = new ModBusClient();
            workThread = new Thread(BussinessLogic);
            workThread.Start();
        }

        /// <summary>
        /// 初始化 探测器Data类中的List sensorDatas
        /// </summary>
        private void InitSensorData()
        {
            Data.sensorDatas = new List<CSensorData>();
            int sensorSum = Convert.ToInt32(ConfigurationManager.AppSettings["sensorSum"]);//读取配置文件
            for (int i = 0; i <= sensorSum; i++)
            {
                CSensorData sensorData = new CSensorData();
                sensorData.add = i;
                sensorData.alarmStatus = new int[256];
                sensorData.faultStatus = new int[256];
                sensorData.tempers = new int[256];
                Data.sensorDatas.Add(sensorData);
            }
        }

        private void BussinessLogic()
        {
            try
            {
                int inspectionTime = Convert.ToInt32(ConfigurationManager.AppSettings["inspectionTime"]);
                modBusClient.Open();
                while (!Cancellation.IsCancellationRequested)
                {
                    foreach (int add in sensorAdds)
                    {
                        QueryStatus(add);//检查状态
                        if (Data.sensorDatas[add].alarmState == 1 && Data.queryAlarmCount[add] != Data.sensorDatas[add].alarmCount)
                        {
                            QueryAlarm(add);//检查火警
                        }
                        if (Data.sensorDatas[add].alarmState == 0 && Data.queryAlarmCount[add] != 0)
                        {
                            QueryAlarm(add);//检查火警
                        }
                        if (Data.sensorDatas[add].faultState == 1 && Data.queryFaultCount[add] != Data.sensorDatas[add].faultConut)
                        {
                            QueryFault(add);//检查故障
                        }
                        if (Data.sensorDatas[add].faultState == 0 && Data.queryFaultCount[add] != 0)
                        {
                            QueryFault(add);//检查故障
                        }
                        QueryTemper(add);//巡检温度
                    }
                    HomeParam.runState = 1;
                    Thread.Sleep(inspectionTime);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                modBusClient.Close();
                HomeParam.runState = 0;
            }
        }

        /// <summary>
        /// 查询探测器状态
        /// </summary>
        /// <param name="add">从机编址</param>
        private void QueryStatus(int add)
        {
            try
            {
                bytes = new byte[5 + 8 * 2];
                Array.Clear(bytes, 0, bytes.Length);
                modBusClient.Send(add, 3, 1, 8);
                modBusClient.Receive(bytes);
                DataAnalysis_Status(add, bytes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void DataAnalysis_Status(int add, byte[] bytes)
        {
            try
            {
                byte[] bytesCRC = CRC16.CRC16.crc16(bytes, bytes.Length - 2);
                if (bytesCRC[0] == bytes[bytes.Length - 2] || bytesCRC[1] == bytes[bytes.Length - 1])
                {
                    Data.sensorDatas[add].alarmState = bytes[3] << 8 | bytes[4];
                    Data.sensorDatas[add].faultState = bytes[5] << 8 | bytes[6];
                    Data.sensorDatas[add].maxTemper = bytes[7] << 8 | bytes[8];
                    Data.sensorDatas[add].maxTemperDistance = bytes[9] << 8 | bytes[10];
                    Data.sensorDatas[add].alarmDistance = bytes[11] << 8 | bytes[12];
                    Data.sensorDatas[add].faultDistance = bytes[13] << 8 | bytes[14];
                    Data.sensorDatas[add].alarmCount = bytes[15] << 8 | bytes[16];
                    Data.sensorDatas[add].faultConut = bytes[17] << 8 | bytes[18];
                }
                else
                {
                    Data.commFaultCount[add]++;//通讯故障计数
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void QueryTemper(int add)
        {
            try
            {
                bytes = new byte[5 + 100 * 2];

                Array.Clear(bytes, 0, bytes.Length);
                modBusClient.Send(add, 4, 1, 100);
                modBusClient.Receive(bytes);
                DataAnalysis_Temper(add, 1, bytes);

                Array.Clear(bytes, 0, bytes.Length);
                modBusClient.Send(add, 4, 101, 100);
                modBusClient.Receive(bytes);

                DataAnalysis_Temper(add, 2, bytes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void DataAnalysis_Temper(int add, int times, byte[] bytes)
        {
            try
            {
                byte[] bytesCRC = CRC16.CRC16.crc16(bytes, bytes.Length - 2);
                if (bytesCRC[0] == bytes[bytes.Length - 2] || bytesCRC[1] == bytes[bytes.Length - 1])
                {
                    switch (times)
                    {
                        case 1:
                            for (int i = 1; i <= 100; i++)
                            {
                                Data.sensorDatas[add].tempers[i] = bytes[2 + 2 * i] << 8 | bytes[3 + 2 * i];
                            }
                            break;
                        case 2:
                            for (int i = 1; i <= 100; i++)
                            {
                                Data.sensorDatas[add].tempers[i + 100] = bytes[2 + 2 * i] << 8 | bytes[3 + 2 * i];
                            }
                            break;
                    }
                    Data.commFaultCount[add] = 0;//通讯故障计数
                }
                else
                {
                    Data.commFaultCount[add]++;//通讯故障计数
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void QueryAlarm(int add)
        {
            try
            {
                bytes = new byte[5 + 2 * 13];

                Array.Clear(bytes, 0, bytes.Length);
                modBusClient.Send(add, 3, 21, 13);
                modBusClient.Receive(bytes);
                DataAnalysis_Alarm(add, 1, bytes);

                Array.Clear(bytes, 0, bytes.Length);
                modBusClient.Send(add, 3, 41, 13);
                modBusClient.Receive(bytes);
                DataAnalysis_Alarm(add, 2, bytes);

                UpdateAlarmCount(add);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void DataAnalysis_Alarm(int add, int times, byte[] bytes)
        {
            try
            {
                byte[] bytesCRC = CRC16.CRC16.crc16(bytes, bytes.Length - 2);
                if (bytesCRC[0] == bytes[bytes.Length - 2] || bytesCRC[1] == bytes[bytes.Length - 1])
                {
                    switch (times)
                    {
                        case 1:
                            for (int i = 1; i <= 13; i++)
                            {
                                for (int j = 1; j <= 8; j++)
                                {
                                    Data.sensorDatas[add].alarmStatus[(i - 1) * 8 + j] = (bytes[2 + 2 * i] << 8 | bytes[3 + 2 * i]) & (0x01 << (j - 1));
                                }
                            }
                            break;
                        case 2:
                            for (int i = 1; i <= 13; i++)
                            {
                                for (int j = 1; j <= 8; j++)
                                {
                                    Data.sensorDatas[add].alarmStatus[(i - 1) * 8 + j + 104] = (bytes[2 + 2 * i] << 8 | bytes[3 + 2 * i]) & (0x01 << (j - 1));
                                }
                            }
                            break;
                    }
                    Data.commFaultCount[add] = 0;//通讯故障计数
                }
                else
                {
                    Data.commFaultCount[add]++;//通讯故障计数
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void QueryFault(int add)
        {
            try
            {
                bytes = new byte[5 + 2 * 13];

                Array.Clear(bytes, 0, bytes.Length);
                modBusClient.Send(add, 3, 61, 13);
                modBusClient.Receive(bytes);
                DataAnalysis_Fault(add, 1, bytes);

                Array.Clear(bytes, 0, bytes.Length);
                modBusClient.Send(add, 3, 81, 13);
                modBusClient.Receive(bytes);
                DataAnalysis_Fault(add, 2, bytes);

                UpdateFaultCount(add);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void DataAnalysis_Fault(int add, int times, byte[] bytes)
        {
            try
            {
                byte[] bytesCRC = CRC16.CRC16.crc16(bytes, bytes.Length - 2);
                if (bytesCRC[0] == bytes[bytes.Length - 2] || bytesCRC[1] == bytes[bytes.Length - 1])
                {

                    switch (times)
                    {
                        case 1:
                            for (int i = 1; i <= 13; i++)
                            {
                                for (int j = 1; j <= 8; j++)
                                {
                                    Data.sensorDatas[add].faultStatus[(i - 1) * 8 + j] = (bytes[2 + 2 * i] << 8 | bytes[3 + 2 * i]) & (0x01 << (j - 1));
                                }
                            }
                            break;
                        case 2:
                            for (int i = 1; i <= 13; i++)
                            {
                                for (int j = 1; j <= 8; j++)
                                {
                                    Data.sensorDatas[add].faultStatus[(i - 1) * 8 + j + 104] = (bytes[2 + 2 * i] << 8 | bytes[3 + 2 * i]) & (0x01 << (j - 1));
                                }
                            }
                            break;
                    }
                    Data.commFaultCount[add] = 0;//通讯故障计数
                }
                else
                {
                    Data.commFaultCount[add]++;//通讯故障计数
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void UpdateAlarmCount(int add)
        {
            Data.queryAlarmCount[add] = 0;
            for (int i = 1; i < 256; i++)
            {
                if (Data.sensorDatas[add].alarmStatus[i] == 1)
                {
                    Data.queryAlarmCount[add]++;
                }
            }
        }
        private void UpdateFaultCount(int add)
        {
            Data.queryFaultCount[add] = 0;
            for (int i = 1; i < 256; i++)
            {
                if (Data.sensorDatas[add].faultStatus[i] == 1)
                {
                    Data.queryFaultCount[add]++;
                }
            }
        }
    }
}
