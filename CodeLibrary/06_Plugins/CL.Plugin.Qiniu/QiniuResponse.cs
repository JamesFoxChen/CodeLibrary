using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Plugin.Qiniu
{
    public class QiniuUploadResponse
    {
        public QiniuUploadResponse()
        {
            this.IsOK = false;
            this.Msg = "";
            this.FileName = "";
        }

        public bool IsOK { get; set; }

        public string Msg { get; set; }

        public string FileName { get; set; }
    }

    public class QiniuDeleteResponse
    {
        public QiniuDeleteResponse()
        {
            this.IsOK = false;
            this.Msg = "";
        }
        public bool IsOK { get; set; }

        public string Msg { get; set; }
    }
}
