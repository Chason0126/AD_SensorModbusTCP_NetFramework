using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Security;

namespace AD_Sensor_SM9001A
{
    class ModBus_TCP:Comm
    {
        Socket socket = null;
        public ModBus_TCP()
        {
            socket = SSocket.GetSocket();
        }

        public override void Open()
        {
            try
            {
                socket.Connect(SSocket.ipe);
            }
            catch (ArgumentNullException)
            {
                throw new Exception("ipe为null");
            }
            catch (SocketException)
            {
                throw new Exception("尝试访问套接字时出错");
            }
            catch (ObjectDisposedException)
            {
                throw new Exception("Socket 已关闭");
            }
            catch (SecurityException)
            {
                throw new Exception("调用堆栈中的较高调用方无权执行所请求的操作");
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Socket置于侦听状态");
            }
        }

        public override void Send(byte[] bytes)
        {
            try
            {
                socket.Send(bytes, bytes.Length, 0);
            }
            catch (ArgumentNullException)
            {
                throw new Exception("buffer 为 null");
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new Exception("size 小于 0 或超过缓冲区的大小");
            }
            catch (SocketException)
            {
                throw new Exception("访问套接字时发生操作系统错误");
            }
            catch (ObjectDisposedException)
            {
                throw new Exception("Socket 已关闭");
            }
        }

        public override byte[] Receive(byte[] bytes)
        {
            try
            {
                socket.Receive(bytes, bytes.Length, 0);
            }
            catch (ArgumentNullException)
            {
                throw new Exception("buffer 为 null");
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new Exception("size 超出了 buffer 的大小");
            }
            catch (SocketException)
            {
                throw new Exception("尝试访问套接字时出错");
            }
            catch (ObjectDisposedException)
            {
                throw new Exception("Socket 已关闭");
            }
            catch (SecurityException)
            {
                throw new Exception("调用堆栈中的调用方没有所需的权限");
            }
            return bytes;
        }

        public override void Close()
        {
            try
            {
                socket.Close();
            }
            catch (Exception)
            {
                throw new Exception("关闭socket失败");
            }
        }
    }
}
