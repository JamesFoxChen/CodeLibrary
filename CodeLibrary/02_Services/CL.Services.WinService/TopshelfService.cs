using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.Services.WinService
{
    public class TopshelfService
    {
        public void Start()
        {
            while (true)
            {
                //每十分钟操作一次
                sendCmd();
                Thread.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["Log_Interval"]));
            }
        }

        public void Stop()
        {
        }
        //
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
            string where =ConfigurationManager.AppSettings["Log_Where"];//"WHERE sc-status<>200";
            string server = ConfigurationManager.AppSettings["Log_Server"];// "127.0.0.1";
            string dbConfig = ConfigurationManager.AppSettings["Log_DBConfig"];//"database:Log_IIS -username:sa -password:123";
            string sqlserverCmd = @"logparser ""{0},* FROM {1} TO {2} {3}"" -o:SQL -server:{4} -driver:""SQL Server"" -{5} -createtable:ON";
            sqlserverCmd = string.Format(sqlserverCmd, select, filePath, tableName, where, server, dbConfig);

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

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
        }
    }
}
