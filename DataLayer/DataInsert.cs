using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AD_Sensor_SM9001A
{
    class DataInsert
    {
        Thread thread;
        STemper temper;
        SQLInsert sqlInsert = new SQLInsert();
        public Queue<STemper> tempers = new Queue<STemper>();
        public Queue<STemper> alarms = new Queue<STemper>();
        public static readonly object syncRootTemper = new object();
        public static readonly object syncRootAlarm = new object();
        public DataInsert()
        {
            thread = new Thread(InsertTemper);
            thread.IsBackground = true;
            thread.Start();
        }

        private void InsertTemper()
        {
            while (true)
            {
                lock (syncRootTemper)
                {
                    if (tempers.Count > 0)
                    {
                        temper = tempers.Dequeue();
                        sqlInsert.Insert("insert into temper(sensorId,nodeId,dateTime,temper,status) values ('" + temper.sensorId + "','" + temper.sensorId + "','" + temper.dateTime + "','" + temper.temper + "','" + temper.status + "')");
                    }
                }
                lock (syncRootAlarm)
                {
                    if (alarms.Count > 0)
                    {
                        temper = alarms.Dequeue();
                        sqlInsert.Insert("insert into alarm(sensorId,nodeId,dateTime,temper,status) values ('" + temper.sensorId + "','" + temper.sensorId + "','" + temper.dateTime + "','" + temper.temper + "','" + temper.status + "')");
                    }
                }
                Thread.Sleep(10);
            }
        }

        public void InsertTemper(STemper temper)
        {
            lock (syncRootTemper)
            {
                tempers.Enqueue(temper);
            }
        }

        public void InsertAlarm(STemper temper)
        {
            lock (syncRootAlarm)
            {
                alarms.Enqueue(temper);
            }
        }
    }
}
