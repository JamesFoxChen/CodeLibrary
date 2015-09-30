using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.Framework.Utils
{
    public class TextLogUtil
    {
        private static readonly object locker = new object();
        private static StreamWriter sw;
        private static Timer changePathTimer;
        private static readonly int CHANGEPATHINTERVAL = 60 * 1000;
        private static readonly string LOGFILENAMEFORMAT = "yyyyMMdd_HH";
        private static readonly string LOGLINEFORMAT = "HH:mm:ss_ffff";
        private static LogLevel logLevel;

        static TextLogUtil()
        {
            changePathTimer = new Timer(state =>
            {
                lock (locker)
                {
                    Close();
                    InitStreamWriter();
                }
            }, null, CHANGEPATHINTERVAL, CHANGEPATHINTERVAL);
            InitStreamWriter();
        }

        #region internal
        internal static void Close()
        {
            try
            {
                if (sw != null)
                    sw.Close();
            }
            catch
            {
            }
        }
        #endregion

        #region private

        private static void InitStreamWriter()
        {
            logLevel = LogLevel.Debug;
            try
            {
                sw = new StreamWriter(GetLogFileName(), true, Encoding.UTF8, 1024);
                sw.AutoFlush = true;
            }
            catch
            {
            }
        }

        private static string GetLogFileName()
        {
            string path = Path.Combine(ConfigurationManager.AppSettings["FileLogPath"] ?? AppDomain.CurrentDomain.BaseDirectory, "Log");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            string file = DateTime.Now.ToString(LOGFILENAMEFORMAT) + ".txt";
            return Path.Combine(path, file);
        }

        private static void Log(LogLevel logLevel, string format, params object[] args)
        {
            Log(logLevel, string.Format(format, args));
        }

        private static string WrapWithContext(LogLevel logLevel, string s)
        {
            StackTrace strackTrace = new StackTrace();
            StackFrame[] stackFrames = strackTrace.GetFrames();
            StackFrame stackFrame = null;
            for (int i = 0; i < stackFrames.Length; i++)
            {
                if (stackFrames[i].GetMethod().ReflectedType != typeof(TextLogUtil))
                {
                    stackFrame = stackFrames[i];
                    break;
                }
            }

            MethodBase methodBase = stackFrame.GetMethod();
            string method = string.Format("{0} {1}()", methodBase.DeclaringType.FullName, methodBase.Name);

            return string.Format("[{0}] @{1} #{2} {3} - {4}",
                logLevel,
                DateTime.Now.ToString(LOGLINEFORMAT),
                Thread.CurrentThread.ManagedThreadId,
                method, s);
        }

        #endregion

        #region public

        public static void Debug(string s)
        {
            if ((int)logLevel <= (int)LogLevel.Debug)
                Log(LogLevel.Debug, s);
        }

        public static void Debug(string format, params object[] args)
        {
            if ((int)logLevel <= (int)LogLevel.Debug)
                Log(LogLevel.Debug, format, args);
        }

        public static void Info(string s)
        {
            if ((int)logLevel <= (int)LogLevel.Info)
                Log(LogLevel.Info, s);
        }

        public static void Info(string format, params object[] args)
        {
            if ((int)logLevel <= (int)LogLevel.Info)
                Log(LogLevel.Info, format, args);
        }

        public static void Warning(string s)
        {
            if ((int)logLevel <= (int)LogLevel.Warning)
                Log(LogLevel.Warning, s);
        }

        public static void Warning(string format, params object[] args)
        {
            if ((int)logLevel <= (int)LogLevel.Warning)
                Log(LogLevel.Warning, format, args);
        }

        public static void Error(string s)
        {
            if ((int)logLevel <= (int)LogLevel.Error)
                Log(LogLevel.Error, s);
        }

        public static void Error(string format, params object[] args)
        {
            if ((int)logLevel <= (int)LogLevel.Error)
                Log(LogLevel.Error, format, args);
        }

        public static void ErrorWithException(string s, Exception ex)
        {
            if ((int)logLevel <= (int)LogLevel.Error)
                Log(LogLevel.Error, s + "\r\nMsg：" + ex.Message + "\r\nStack：" + ex.StackTrace);

            if (ex.InnerException != null)
            {
                Log(LogLevel.Error, "(InnerException):" + ex.InnerException.Message);
            }
        }


        public static void Log(LogLevel logLevel, string s)
        {
            //return;
            try
            {

                lock (locker)
                {
                    var message = WrapWithContext(logLevel, s);
#if DEBUG
                    switch (logLevel)
                    {
                        case LogLevel.Debug:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case LogLevel.Info:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case LogLevel.Warning:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case LogLevel.Error:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                    }
                    Console.WriteLine(message);
                    Console.ResetColor();
#endif
                    sw.WriteLine(message);
                }
            }
            catch
            {
            }
        }
        #endregion
    }


    public enum LogLevel
    {

        /// <summary>
        /// 无
        /// </summary>
        None = 99,
        /// <summary>
        /// 调试
        /// </summary>
        Debug = 1,
        /// <summary>
        /// 信息
        /// </summary>
        Info = 2,
        /// <summary>
        /// 警告
        /// </summary>
        Warning = 3,
        /// <summary>
        /// 轻微
        /// </summary>
        Slight = 4,
        /// <summary>
        /// 一般
        /// </summary>
        Error = 5,
        /// <summary>
        /// 严重
        /// </summary>
        Serious = 6,
        /// <summary>
        /// 致命
        /// </summary>
        Exception = 7
        //Trace, Debug, Information, Warnning, Error, Fatal 
    }
}
