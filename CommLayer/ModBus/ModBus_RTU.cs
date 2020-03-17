using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace AD_Sensor_SM9001A
{
    class ModBus_RTU:Comm
    {
        SerialPort serialPort = null;

        public ModBus_RTU()
        {
            try
            {
                serialPort = SPort.GetPort();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override void Open()
        {
            try
            {
                serialPort.Open();
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("对端口的访问被拒绝");
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new Exception("一个或多个属性无效");
            }
            catch (ArgumentException)
            {
                throw new Exception("端口名称不是以“COM”开始的");
            }
            catch (IOException)
            {
                throw new Exception("此端口处于无效状态");
            }
            catch (InvalidOperationException)
            {
                throw new Exception("当前实例上的指定端口已经打开");
            }
        }

        public override void Close()
        {
            try
            {
                serialPort.Close();
            }
            catch (IOException)
            {
                throw new Exception("此端口处于无效状态");
            }
        }

        public override void Send(byte[] bytes)
        {
            try
            {
                serialPort.Write(bytes, 0, bytes.Length);
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("传递的 buffer 为 null。", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("指定的端口未打开！", ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new Exception("参数超出了所传递的 buffer 的有效区域！", ex);
            }
            catch (ArgumentException ex)
            {
                throw new Exception("offset 加上 count 大于 buffer 的长度！", ex);

            }
            catch (TimeoutException ex)
            {
                throw new Exception("该操作未在超时时间到期之前完成！", ex);
            }
        }

        public override byte[] Receive(byte[] bytes)
        {
            try
            {
                serialPort.Read(bytes, 0, bytes.Length);
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("传递的 buffer 为 null。！", ex);

            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("指定的端口未打开！", ex);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new Exception("参数超出了所传递的 buffer 的有效区域！", ex);

            }
            catch (ArgumentException ex)
            {
                throw new Exception("offset 加上 count 大于 buffer 的长度。！", ex);

            }
            catch (TimeoutException ex)
            {
                throw new Exception("没有可以读取的字节！", ex);
            }
            return bytes;
        }
    }
}
