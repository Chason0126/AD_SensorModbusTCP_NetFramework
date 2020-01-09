using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.IO.Ports;

namespace AD_SensorModbusTCP_NetFramework
{
    public abstract class Modbus
    {
        /// <summary>
        /// 与底层建立连接
        /// </summary>
        public abstract void Connect();

        /// <summary>
        /// 发送数据
        /// </summary>
        public abstract void Send(byte[] bytes);

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <returns></returns>
        public abstract byte[] Receive(byte[] bytes);

        /// <summary>
        /// 断开连接
        /// </summary>
        public abstract void Close();
    }

    public class ModbusTCP_SyncNetWorkStream : Modbus//可以有多重实现  同步 异步  socket tcpclient  networkstream
    {
        NetworkStream networkStream;
        Socket socket;
        IPEndPoint iPEndPoint;
        /// <summary>
        /// 从配置文件中 获取  网络参数
        /// </summary>
        public ModbusTCP_SyncNetWorkStream()
        {
            try
            {
                IPAddress iP = IPAddress.Parse(ConfigurationManager.AppSettings["IP"]);
                int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
                this.iPEndPoint = new IPEndPoint(iP, port);
            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg("读取配置文件失败:" + ex.Message + ex.StackTrace);
            }
           
        }

        public override void Connect()
        {
            try
            {
                if (socket == null)
                {
                    socket = new Socket(iPEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    IAsyncResult asyncResult = socket.BeginConnect(iPEndPoint, null, null);
                    bool success = asyncResult.AsyncWaitHandle.WaitOne(1000);
                    if (!success)
                    {
                        throw new SocketException();
                    }
                    if (socket.Connected)
                    {
                        networkStream = new NetworkStream(socket);
                        networkStream.ReadTimeout = 200;
                        networkStream.WriteTimeout = 200;
                    }
                }
                else
                {
                    if (!socket.Connected)
                    {
                        socket = new Socket(iPEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                        IAsyncResult asyncResult = socket.BeginConnect(iPEndPoint, null, null);
                        bool success = asyncResult.AsyncWaitHandle.WaitOne(1000);
                        if (!success)
                        {
                            throw new SocketException();
                        }
                        //socket.Connect(iPEndPoint);
                        if (socket.Connected)
                        {
                            networkStream = new NetworkStream(socket);
                            networkStream.ReadTimeout = 200;
                            networkStream.WriteTimeout = 200;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Connected()
        {
            try
            {
                if (socket != null)
                {
                    return socket.Connected;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public override void Send(byte[] bytes)
        {
            try
            {
                networkStream.Write(bytes, 0, bytes.Length);
            }
            catch (ArgumentNullException)
            {
                throw;//参数 为 null
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;//参数超出范围
            }
            catch (IOException)
            {
                throw;//写入到网络时失败
            }
            catch (ObjectDisposedException)
            {
                throw;//Socket 已关闭
            }
            catch (Exception)
            {
                throw;//
            }
        }

        public override byte[] Receive(byte[] bytes)
        {
            try
            {
                networkStream.Read(bytes, 0, bytes.Length);
            }
            catch (ArgumentNullException)
            {
                throw;//参数 为 null
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;//长度出错
            }
            catch (IOException)
            {
                throw;//Socket 已关闭
            }
            catch (ObjectDisposedException)
            {
                throw;//NetworkStream已关闭
            }
            catch (Exception)
            {
                throw;//
            }
            return bytes;
        }

        public override void Close()
        {
            if (socket != null)
            {
                socket.Close();
            }
        }
    }

    public class ModbusRTU_SerialPort : Modbus
    {
        SerialPort serialPort;
        string portName;//串口名COM X
        int baudRate;//波特率
        public ModbusRTU_SerialPort()
        {
            try
            {
                this.portName = Convert.ToString(ConfigurationManager.AppSettings["portName"]);
                this.baudRate = Convert.ToInt32(ConfigurationManager.AppSettings["baudRate"]);
            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg("读取配置文件失败:" + ex.Message + ex.StackTrace);
            }
        }

        public override void Connect()
        {
            try
            {
                if (serialPort == null)
                {
                    serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
                    serialPort.Open();
                }
                else
                {
                    serialPort.Open();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                DataClass.ShowErrMsg("对端口的访问被拒绝" + ex.Message + ex.StackTrace);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                DataClass.ShowErrMsg("此实例的一个或多个属性无效" + ex.Message + ex.StackTrace);
            }
            catch(ArgumentException ex)
            {
                DataClass.ShowErrMsg("端口名称不是以“COM”开始的。 或 - 端口的文件类型不受支持。" + ex.Message + ex.StackTrace);
            }
            catch (IOException ex)
            {
                DataClass.ShowErrMsg("此端口处于无效状态" + ex.Message + ex.StackTrace);
            }
            catch(InvalidOperationException ex)
            {
                DataClass.ShowErrMsg("当前实例上的指定端口已经打开" + ex.Message + ex.StackTrace);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsOpen()
        {
            if (serialPort != null)
            {
                return false;
            }
            else
            {
                return serialPort.IsOpen;
            }
        }

        public override void Send(byte[] bytes)
        {
            try
            {
                serialPort.Write(bytes, 0, bytes.Length);
            }
            catch(ArgumentNullException ex)
            {
                DataClass.ShowErrMsg(" 传递的 buffer 为 null。" + ex.Message + ex.StackTrace);

            }
            catch (InvalidOperationException ex)
            {
                DataClass.ShowErrMsg("指定的端口未打开" + ex.Message + ex.StackTrace);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                DataClass.ShowErrMsg("参数超出了所传递的 buffer 的有效区域" + ex.Message + ex.StackTrace);

            }
            catch (ArgumentException ex)
            {
                DataClass.ShowErrMsg("offset 加上 count 大于 buffer 的长度" + ex.Message + ex.StackTrace);

            }
            catch (TimeoutException ex)
            {
                DataClass.ShowErrMsg("该操作未在超时时间到期之前完成" + ex.Message + ex.StackTrace);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public override byte[] Receive(byte[] bytes)
        {
            try
            {
                serialPort.Read(bytes, 0, bytes.Length);
            }
            catch(ArgumentNullException ex)
            {
                DataClass.ShowErrMsg("传递的 buffer 为 null。" + ex.Message + ex.StackTrace);

            }
            catch (InvalidOperationException ex)
            {
                DataClass.ShowErrMsg("指定的端口未打开" + ex.Message + ex.StackTrace);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                DataClass.ShowErrMsg("参数超出了所传递的 buffer 的有效区域" + ex.Message + ex.StackTrace);

            }
            catch (ArgumentException ex)
            {
                DataClass.ShowErrMsg("offset 加上 count 大于 buffer 的长度。" + ex.Message + ex.StackTrace);

            }
            catch (TimeoutException ex)
            {
                DataClass.ShowErrMsg("没有可以读取的字节" + ex.Message + ex.StackTrace);

            }
            catch (Exception)
            {

                throw;
            }
            return bytes;
        }

        public override void Close()
        {
            try
            {
                serialPort.Close();
            }
            catch(IOException ex)
            {
                DataClass.ShowErrMsg("此端口处于无效状态" + ex.Message + ex.StackTrace);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public static class ModbusFactory
    {
        public static Modbus GetModbus(string type)
        {
            Modbus modbus = null;
            if (type == "RTU")
            {
                modbus = new ModbusRTU_SerialPort();
            }
            else if (type == "TCP")
            {
                modbus = new ModbusTCP_SyncNetWorkStream();
            }
            return modbus;
        }
    }
}
