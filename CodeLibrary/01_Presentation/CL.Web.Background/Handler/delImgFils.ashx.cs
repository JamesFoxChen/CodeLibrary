using System.Web;
using CL.Plugin.Qiniu;

namespace CL.Web.Background.Handler
{
    /// <summary>
    /// delImgFils 的摘要说明
    /// </summary>
    public class DelImgFils : IHttpHandler
    {
        public void ProcessRequest(HttpContext Current)
        {
            QiniuImageMng.DeleteImage(Current.Request["delImgFile"].ToString());            
            Current.Response.Write("ok");
            Current.Response.End();   
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