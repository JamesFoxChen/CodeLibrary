using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CL.Framework.Extensions
{
    public class ImgFileExtensions
    {

        private static string uploadImageKey = "UploadImages";

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="fileUpload">上传的图片</param>
        /// <param name="AppSetting">上传地址</param>
        /// <returns>图片虚拟路径</returns>
        public static string FileImg(HttpPostedFile fileUpload)
    {
            Boolean fileOk = false;
            //取得文件的扩展名,并转换成小写
            string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
            //验证上传文件是否图片格式
            fileOk = IsImage(fileExtension);

            if (fileOk)
            {
                //string filepath = DateTime.Now.ToString("yyyyMMdd") + "/";

                if (Directory.Exists(HttpContext.Current.Request.MapPath(ConfigurationSettings.AppSettings[uploadImageKey].Trim())) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(HttpContext.Current.Request.MapPath(ConfigurationSettings.AppSettings[uploadImageKey].Trim()));
                }
                string virpath = DateTime.Now.ToString("yyyyMMddHHmmssffff") + fileExtension;//这是存到服务器上的虚拟路径
                string mappath = HttpContext.Current.Request.MapPath(ConfigurationSettings.AppSettings[uploadImageKey].Trim()) + virpath;//转换成服务器上的物理路径
                fileUpload.SaveAs(mappath);//保存图片
                return mappath;

            }
     
            return "上传失败";
        }


        public static string FileImg(HttpPostedFileBase fileUpload)
        {
            Boolean fileOk = false;
            //取得文件的扩展名,并转换成小写
            string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
            //验证上传文件是否图片格式
            fileOk = IsImage(fileExtension);

            if (fileOk)
            {
                //string filepath = DateTime.Now.ToString("yyyyMMdd") + "/";

                if (Directory.Exists(HttpContext.Current.Request.MapPath(ConfigurationSettings.AppSettings[uploadImageKey].Trim())) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(HttpContext.Current.Request.MapPath(ConfigurationSettings.AppSettings[uploadImageKey].Trim()));
                }
                string virpath = DateTime.Now.ToString("yyyyMMddHHmmssffff") + fileExtension;//这是存到服务器上的虚拟路径
                string mappath = HttpContext.Current.Request.MapPath(ConfigurationSettings.AppSettings[uploadImageKey].Trim()) + virpath;//转换成服务器上的物理路径
                fileUpload.SaveAs(mappath);//保存图片
                return mappath;

            }
 
            return "上传失败";
        }

        #region 验证是否指定的图片格式
        /// <summary>
        /// 验证是否指定的图片格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsImage(string str)
        {
            bool isimage = false;
            string thestr = str.ToLower();
            //限定只能上传jpg和gif图片
            string[] allowExtension = { ".jpg", ".gif", ".bmp", ".png", ".jpeg" };
            //对上传的文件的类型进行一个个匹对
            for (int i = 0; i < allowExtension.Length; i++)
            {
                if (thestr == allowExtension[i])
                {
                    isimage = true;
                    break;
                }
            }
            return isimage;
        }
        #endregion
    }
}
