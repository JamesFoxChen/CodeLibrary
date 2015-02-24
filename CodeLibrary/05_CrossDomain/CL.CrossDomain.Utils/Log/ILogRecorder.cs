using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.CrossDomain.Utils
{
    public interface ILogRecorder
    {
        void ProcessLog(SysLogType type, string name, string message, Exception exception);
    }
}
