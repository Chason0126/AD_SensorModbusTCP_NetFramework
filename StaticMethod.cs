using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Sensor_SM9001A
{
    public class StaticMethod
    {
        /// <summary>
        /// 给定路径 将 image转为 byte[]
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] ImgToBytes(string path)
        {
            Bitmap bitmap = new Bitmap(path);
            MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, ImageFormat.Bmp);
            byte[] bytes = new byte[memoryStream.Length];
            try
            {
                memoryStream.Position = 0;
                memoryStream.Read(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                memoryStream.Close();
            }
            return bytes;
        }
        /// <summary>
        /// 将byte[]还原为image
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Image BytesToImg(byte[] bytes)
        {
            MemoryStream memoryStream = new MemoryStream();
            Image image;
            try
            {
                memoryStream = new MemoryStream(bytes);
                image = Image.FromStream(memoryStream);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                memoryStream.Close();
            }
            return image;

        }

        public static byte[] ImgToBytes(Image image)
        {
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Bmp);
            byte[] bytes = new byte[memoryStream.Length];
            try
            {
                memoryStream.Position = 0;
                memoryStream.Read(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                memoryStream.Close();
            }
            return bytes;
        }

        public static void CopyAreaPic(string sourcePic, int areaid)
        {
            try
            {
                string path = Environment.CurrentDirectory + "\\" + "AreaPic";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\" + areaid + ".jpg";
                File.Copy(sourcePic, path, true);
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("调用方没有所要求的权限。 或 destFileName 是只读");
            }
            catch (ArgumentNullException)
            {
                throw new Exception(" sourceFileName 或 destFileName 为null");
            }
            catch (ArgumentException)
            {
                throw new Exception(" sourceFileName 或 destFileName 无效");
            }
            catch (PathTooLongException)
            {
                throw new Exception(" 指定的路径和/或文件名超过了系统定义的最大长度");
            }
            catch (DirectoryNotFoundException)
            {
                throw new Exception(" sourceFileName 或 destFileName 中指定的路径无效（例如，它位于未映射的驱动器上）。");
            }
            catch (FileNotFoundException)
            {
                throw new Exception("未找到 sourceFileName");
            }
            catch (IOException)
            {
                throw new Exception(" destFileName 存在且 overwrite 是 false。 或 - 发生了 I/O 错误。");
            }
            catch (NotSupportedException)
            {
                throw new Exception("sourceFileName 或 destFileName 的格式无效");
            }
            catch (Exception ex)
            {
                Log.log.Error("图片存储异常", ex);
                throw new Exception("图片存储异常");
            }

        }

        /// <summary>
        /// 获取 数据库中启用的 探测器与节点数据
        /// </summary>
        public static void GetSensorNodeMsg()
        {
            try
            {
                SQLSelect sqlSelect = new SQLSelect();
                Sensor_NodeMsg.sensorMsg.Clear();
                Sensor_NodeMsg.nodeMsg.Clear();
                List<SSensor> tempSensorMsgs = sqlSelect.Select_SensorEnable();
                foreach (SSensor sensor in tempSensorMsgs)
                {
                    Sensor_NodeMsg.sensorMsg.Add(sensor.sensorId, sensor);
                }
                foreach (int sensorId in Sensor_NodeMsg.sensorMsg.Keys)
                {
                    List<SNode> tempNodeMsgs = sqlSelect.Select_NodeEnable(sensorId);
                    foreach (SNode node in tempNodeMsgs)
                    {
                        Sensor_NodeMsg.nodeMsg.Add(new SNode_id { sensorId = node.sensorId, nodeId = node.nodeId }, node);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("获取探测器、节点信息失败！请检查后重试。");
            }
        }

        public static void GetDisplays(out Dictionary<int, SSensorDisplay> sensorDisplays, out Dictionary<SNode_id, SNodeDisplay> nodeDiplays)
        {
            try
            {
                sensorDisplays = new Dictionary<int, SSensorDisplay>();
                nodeDiplays = new Dictionary<SNode_id, SNodeDisplay>();
                foreach (SSensorDisplay sensorDisplay in new SQLSelect().Select_SensorDisplay())
                {
                    sensorDisplays.Add(sensorDisplay.sensorId, sensorDisplay);
                    foreach (SNodeDisplay nodeDisplay in new SQLSelect().Select_NodeDisplay(sensorDisplay.sensorId))
                    {
                        nodeDiplays.Add(new SNode_id { sensorId = nodeDisplay.sensorId, nodeId = nodeDisplay.nodeId }, nodeDisplay);
                    }
                }

            }
            catch (Exception)
            {
                throw new Exception("获取探测器、节点信息失败");
            }

        }
    }
}
