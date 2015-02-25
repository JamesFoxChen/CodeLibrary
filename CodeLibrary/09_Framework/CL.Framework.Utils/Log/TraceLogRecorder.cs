//debug类的所有调用仅在程序的debug版本中有效；而trace类的调用能在release版本和debug版本中都有效。
//在该程序所在的目录里您可以发现出现了一个新的文件app.log
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;

namespace CL.Framework.Utils
{
    public class TraceLogRecorder : ILogRecorder
    {
        public void ProcessLog(SysLogType type, string name, string message, Exception exception)
        {
            TracePrint("{0},{1},{2},{3}", type, name, message, exception);
        }

        private static void TracePrint(string msg, params object[] os)
        {
            ClassHelper.CallFunction(typeof(Trace), "Print", msg, os);
        }
    }
}
