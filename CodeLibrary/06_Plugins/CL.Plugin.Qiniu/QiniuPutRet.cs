using Qiniu.RPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CL.Plugin.Qiniu
{
    internal class QiniuPutRet : CallRet
    {
        /// <summary>
		/// 如果 uptoken 没有指定 ReturnBody，那么返回值是标准的 QiniuPutRet 结构
		/// </summary>
		public string Hash { get; private set; }

		/// <summary>
		/// 如果传入的 key == UNDEFINED_KEY，则服务端返回 key
		/// </summary>
		public string key { get; private set; }

		public QiniuPutRet (CallRet ret)
            : base(ret)
		{
			if (!String.IsNullOrEmpty (Response)) {
				try {
					Unmarshal (Response);
				} catch (Exception e) {
					Console.WriteLine (e.ToString ());
					this.Exception = e;
				}
			}
		}

        private void Unmarshal(string json)
        {
            try
            {
                Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                object tmp;
                if (dict.TryGetValue("hash", out tmp))
                    Hash = (string)tmp;
                if (dict.TryGetValue("key", out tmp))
                    key = (string)tmp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }	
    }
}
