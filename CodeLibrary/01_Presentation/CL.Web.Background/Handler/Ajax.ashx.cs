using System.Web;
using CL.Biz.Background.Product;
using CL.Framework.Extensions;
using CL.Plugin.Qiniu;
using Newtonsoft.Json;

namespace CL.Web.Background.Handler
{
    /// <summary>
    /// Ajax 的摘要说明
    /// </summary>
    public class Ajax : IHttpHandler
    {
        public void ProcessRequest(HttpContext current)
        {
            var productID = current.Request["ProductID"];

            if (!string.IsNullOrWhiteSpace(productID))
            {
                var productInfo = new ProductInfoBiz().GetProductInfo(productID);
                var response = new
                {
                    BarCode = productInfo.BarCode
                };

                current.Response.Write(JsonConvert.SerializeObject(response));
                current.Response.End();
            }

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}