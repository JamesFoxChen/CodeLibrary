using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using CL.Framework.Utils;
using System.Timers;


namespace CL.Services.WinService
{
    public class TopshelfService
    {
        public void Start()
        {
            TextLogUtil.Error("不要关本窗体，谢谢-陈志");
            writeIISLogToSqlserver();
            deleteHistoryRecord();
            deleteRepeatRecord();
            executeRecord();

            //var dt = AdoMng.Get("SELECT * FROM IISLog_table");
            //deleteRepeatRecordInner();
        }

        public void Stop()
        {
        }


        #region 执行写入IIS日志写入数据库日志
        /// <summary>
        /// 执行写入IIS日志写入数据库日志
        /// </summary>
        private void writeIISLogToSqlserver()
        {
            try
            {
                //每十分钟操作一次
                var interval = Convert.ToInt32(ConfigurationManager.AppSettings["Log_ReadLogAndWriteToDBInterval"]);
                var mt = new Timer(interval);
                mt.Enabled = true;
                mt.Elapsed += (o, e) =>
                {
                    var t = (Timer)o;
                    t.AutoReset = false;
                    t.Enabled = false;
                    t.Stop();
                    sendCmd();
                    t.Enabled = true;
                    t.AutoReset = true;
                    t.Start();
                };
            }
            catch (Exception ex)
            {
                TextLogUtil.Error(ex.Message);
            }
        }

        /// <summary>
        /// 发送命令行命令
        /// </summary>
        private void sendCmd()
        {
            string locationCmd = ConfigurationManager.AppSettings["Log_LogParsePath"]; //@"cd C:\Program Files (x86)\Log Parser 2.2\";

            string select = ConfigurationManager.AppSettings["Log_Select"];
            //"SELECT TO_LOCALTIME(TO_TIMESTAMP(ADD(TO_STRING(date, 'yyyy-MM-dd '), TO_STRING(time, 'hh:mm:ss')),'yyyy-MM-dd hh:mm:ss')) AS RequestTime";

            string fileDirPath = ConfigurationManager.AppSettings["Log_FileDirPath"];// @"C:\";
            string filePath = fileDirPath + "u_ex" + DateTime.Now.ToString("yyMMddHH") + ".log";  //u_ex150630.log  u_ex15063013
            if (!File.Exists(filePath)) return;

            //如果读日志影响到写日志操作，则将日志复制成临时文件，并临时文件读日志
            //string tempFilePath = fileDirPath + "temp.log";
            //if (File.Exists(tempFilePath))
            //{
            //    File.Delete(tempFilePath);
            //}
            //File.Copy(filePath,tempFilePath);

            string tableName = ConfigurationManager.AppSettings["Log_TableName"];//"IISLog_table";
            string where = ConfigurationManager.AppSettings["Log_Where"];//"WHERE sc-status<>200";
            string server = ConfigurationManager.AppSettings["Log_Server"];// "127.0.0.1";
            string dbConfig = ConfigurationManager.AppSettings["Log_DBConfig"];//"database:Log_IIS -username:sa -password:123";
            string sqlserverCmd = @"logparser ""{0},* FROM {1} TO {2} {3}"" -o:SQL -server:{4} -driver:""SQL Server"" -{5} -createtable:ON";


            sqlserverCmd = string.Format(sqlserverCmd, select, filePath, tableName, where, server, dbConfig);

            //TextLogUtil.Debug(locationCmd);
            //TextLogUtil.Debug(sqlserverCmd);

            executeCMD(locationCmd, sqlserverCmd);
        }

        /// <summary>
        /// 执行控制台命令
        /// </summary>
        /// <param name="locationCmd">定位目录</param>
        /// <param name="toSqlServerCmd">执行命令</param>
        private void executeCMD(string locationCmd, string toSqlServerCmd)
        {
            var p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(locationCmd);
            p.StandardInput.WriteLine(toSqlServerCmd);
            //p.StandardInput.WriteLine(str + "&exit");
            p.StandardInput.AutoFlush = true;
            p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令

            String StrInfo = p.StandardOutput.ReadToEnd();
            Console.WriteLine(StrInfo);

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
        }

        #endregion

        #region 删除重复数据
        /// <summary>
        /// 删除重复数据
        /// </summary>
        private void deleteRepeatRecord()
        {
            try
            {
                //每十分钟操作一次
                var interval = Convert.ToInt32(ConfigurationManager.AppSettings["Log_DeleteRepeatRecordInterval"]);
                var mt = new Timer(interval);
                mt.Enabled = true;
                mt.Elapsed += (o, e) =>
                {
                    var t = (Timer)o;
                    t.AutoReset = false;
                    t.Enabled = false;
                    t.Stop();
                    deleteRepeatRecordInner();
                    t.Enabled = true;
                    t.AutoReset = true;
                    t.Start();
                };
            }
            catch (Exception ex)
            {
                TextLogUtil.Error(ex.Message);
            }
        }

        private void deleteRepeatRecordInner()
        {
            string sql = @"DELETE FROM [Log_IIS].[dbo].[IISLog_table]
                            WHERE id not in 
                            (select MAX(Id) from [IISLog_table] group by [RequestTime]
                                  ,[LogFilename]
                                  ,[LogRow]
                                  ,[date]
                                  ,[time]
                                  ,[cIp]
                                  ,[csUsername]
                                  ,[sSitename]
                                  ,[sComputername]
                                  ,[sIp]
                                  ,[sPort]
                                  ,[csMethod]
                                  ,[csUriStem]
                                  ,[csUriQuery]
                                  ,[scStatus]
                                  ,[scSubstatus]
                                  ,[scWin32Status]
                                  ,[scBytes]
                                  ,[csBytes]
                                  ,[timeTaken]
                                  ,[csVersion]
                                  ,[csHost]
                                  ,[csUserAgent]
                                  ,[csCookie]
                                  ,[csReferer]
                                  ,[sEvent]
                                  ,[sProcessType]
                                  ,[sUserTime]
                                  ,[sKernelTime]
                                  ,[sPageFaults]
                                  ,[sTotalProcs]
                                  ,[sActiveProcs]
                                  ,[sStoppedProcs] having count(*) > 1)";
            AdoMng.Execute(sql);
        }

        #endregion

        #region 删除历史数据
        /// <summary>
        /// 删除历史数据
        /// </summary>
        private void deleteHistoryRecord()
        {
            try
            {
                System.Threading.Thread t = new System.Threading.Thread(deleteHistoryRecordInner);
                t.Name = "ExecuteLogDataStart";
                t.Start();
            }
            catch (Exception ex)
            {
                TextLogUtil.Error(ex.Message);
            }
        }

        private void deleteHistoryRecordInner()
        {
            while (true)
            {
                if (DateTime.Now.ToString("HHmmss") == "000000")  //每天00：00：00清除一遍数据库
                {

                }
                else
                {
                    //TextLogUtil.Debug(DateTime.Now.ToString("HHmmss"));
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        #endregion

        #region 处理数据
        /// <summary>
        /// 处理数据
        /// </summary>
        private void executeRecord()
        {
            try
            {
                //每十分钟操作一次
                var interval = Convert.ToInt32(ConfigurationManager.AppSettings["Log_ExecuteRecordInterval"]);
                var mt = new Timer(interval);
                mt.Enabled = true;
                mt.Elapsed += (o, e) =>
                {
                    var t = (Timer)o;
                    t.AutoReset = false;
                    t.Enabled = false;
                    t.Stop();
                    executeRecordInner();
                    t.Enabled = true;
                    t.AutoReset = true;
                    t.Start();
                };
            }
            catch (Exception ex)
            {
                TextLogUtil.Error(ex.Message);
            }
        }

        private void executeRecordInner()
        {
        }

        #endregion
    }
}
