using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace AD_SensorModbusTCP_NetFramework
{
    class SQLCreate
    {
        Create_Init create_Init = new Create_Init();
        Create_Table create_Table = new Create_Table();
        SQLInsert sqlInsert = new SQLInsert();
        public SQLCreate(BackgroundWorker worker)
        {
            try
            {
                //创建数据库
                worker.ReportProgress(10, "创建数据库" + ConfigurationManager.AppSettings["database"].ToString() + "");
                if(!create_Init.Create_DB(ConfigurationManager.AppSettings["database"].ToString()))
                {
                    throw new Exception("创建数据库失败");
                }

                //创建用户并授权（对应的数据库的最小权限）
                worker.ReportProgress(15, "检查用户");
                if(!create_Init.Create_User("adsensor", "adsensor"))
                {
                    throw new Exception("创建用户失败");
                }

                worker.ReportProgress(20, "创建数据表pwd");
                if (!create_Table.IsTable_Exit("pwd"))
                {
                    if (!create_Table.CreateTable("pwd", "create table pwd(pwdId tinyint unsigned, userName varchar(20) ,passWord varchar(32),primary key(pwdId))"))
                    {
                        throw new Exception("创建数据表Pwd失败");
                    }
                    else
                    {
                        if(!sqlInsert.Insert("insert into pwd(pwdId, userName, passWord) values(1, 'generalUser', '" + Encryption.GetMD5Hash("userSM9001") + "')"))
                        {
                            throw new Exception("插入数据表Pwd失败");
                        }
                        if (!sqlInsert.Insert("insert into pwd(pwdId,userName,passWord) values (2,'sysOperator','" + Encryption.GetMD5Hash("operatorSM9001") + "')"))
                        {
                            throw new Exception("插入数据表Pwd失败");
                        }
                        if (!sqlInsert.Insert("insert into pwd(pwdId,userName,passWord) values (3,'sysAdministrator','" + Encryption.GetMD5Hash("adminSM9001") + "')"))
                        {
                            throw new Exception("插入数据表Pwd失败");
                        }
                    }
                }
                

                worker.ReportProgress(30, "创建数据表prjname");
                if (!create_Table.IsTable_Exit("prjname"))
                {
                    if (!create_Table.CreateTable("prjname", "create table prjname(prjId  tinyint unsigned,prjName varchar(32),primary key(prjId))"))
                    {
                        throw new Exception("创建数据表prjname失败");
                    }
                    else
                    {
                        if (!sqlInsert.Insert("insert into prjname(prjId,prjName) values ('1','无锡圣敏传感科技股份有限公司')"))
                        {
                            throw new Exception("插入数据表pejname失败");
                        }
                    }
                }
               
                
               
                //if (!IsTabExit("prtname"))
                //{
                //    worker.ReportProgress(30, "创建数据表prtname");
                //    if (!Create_Table_prtName())
                //    {
                //        throw new Exception("创建数据表prtName失败");
                //    }
                //}

                //if (!IsTabExit("device"))
                //{
                //    worker.ReportProgress(50, "创建数据表device");
                //    if (!Create_Table_device())
                //    {
                //        throw new Exception("创建数据表device失败");
                //    }
                //}
                //if (!IsTabExit("channel"))
                //{
                //    worker.ReportProgress(60, "创建数据表channel");
                //    if (!Create_Table_channel())
                //    {
                //        throw new Exception("创建数据表channel失败");
                //    }
                //}
                //if (!IsTabExit("pagepic"))
                //{
                //    worker.ReportProgress(70, "创建数据表pagepic");
                //    if (!Create_Table_PagePic())
                //    {
                //        throw new Exception("创建数据表pagePic失败");
                //    }
                //}
                //if (!IsTabExit("alarm"))
                //{
                //    worker.ReportProgress(80, "创建数据表alarm");
                //    if (!Create_Table_alarm())
                //    {
                //        throw new Exception("创建数据表alarm失败");
                //    }
                //}
                //if (!IsTabExit("audit"))
                //{
                //    worker.ReportProgress(90, "创建数据表audit");
                //    if (!Create_Table_audit())
                //    {
                //        throw new Exception("创建数据表audit失败");
                //    }
                //}
            }
            catch (Exception ex)
            {
                DataClass.ShowErrMsg("数据库创建失败" + ex.Message + ex.StackTrace);
            }
            finally
            {
                worker.CancelAsync();
            }
        }
    }
}
