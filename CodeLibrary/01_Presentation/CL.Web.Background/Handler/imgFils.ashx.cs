using System.Web;
using CL.Framework.Extensions;
using CL.Plugin.Qiniu;

namespace CL.Web.Background.Handler
{
    /// <summary>
    /// imgFils 的摘要说明
    /// </summary>
    public class ImgFils : IHttpHandler
    {
        public void ProcessRequest(HttpContext Current)
        {
            HttpPostedFile httpFile = Current.Request.Files[0];
            string filePath = ImgFileExtensions.FileImg(httpFile);
            var result = QiniuImageMng.UploadImage(filePath);
            Current.Response.Write("{\"jsonrpc\" : \"2.0\", \"result\" : \"" + result.FileName + "\", \"id\" : \"id\"}");
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