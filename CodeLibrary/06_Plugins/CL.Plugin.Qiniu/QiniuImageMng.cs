using System;
using System.IO;
using CL.Framework.Utils;
using Qiniu.IO;
using Qiniu.RPC;

namespace CL.Plugin.Qiniu
{
    public class QiniuImageMng
    {

        #region 上传图片
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="filePath">图片路径</param>
        /// <returns></returns>
        public static QiniuUploadResponse UploadImage(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("filePath不能为空");
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentNullException("找不到filePath对应的文件");
            }

            string fileName = StringUtil.GetGUID();
            PutRet ret = QiniuHelper.PutImage(fileName, filePath);

            var response = new QiniuUploadResponse();
            if (ret.OK)
            {
                response.IsOK = true;
                response.FileName = ret.key;
                return response;
            }
            response.IsOK = false;
            response.Msg = ret.Exception.Message;
            response.FileName = fileName;
            return response;
        }
        #endregion

        #region 删除图片
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static QiniuDeleteResponse DeleteImage(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("fileName不能为空");
            }

            CallRet ret = QiniuHelper.Delete(QiniuConfig.bucket, fileName);

            var response = new QiniuDeleteResponse();
            if (ret.OK)
            {
                response.IsOK = true;
                return response;
            }

            response.IsOK = false;
            response.Msg = ret.Exception.Message;
            return response;
        }
        #endregion

        #region 获取图片
        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static string GetImage(string fileName, QiniuImageSize size = QiniuImageSize.原图)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return "";
                //throw new ArgumentNullException("fileName不能为空");
            }

            string imageParam = "?imageView2/1/w/{0}/h/{1}/q/30";
            switch (size)
            {
                case QiniuImageSize.原图:
                    imageParam = "";
                    break;
                case QiniuImageSize.低质量原图:
                    imageParam = "?imageView2/1/q/30";
                    break;
                case QiniuImageSize.大图:
                    imageParam = string.Format(imageParam, 800, 600);
                    break;
                case QiniuImageSize.中图:
                    imageParam = string.Format(imageParam, 640, 480);
                    break;
                case QiniuImageSize.小图:
                    imageParam = string.Format(imageParam, 320, 200);
                    break;
            }
            string url = QiniuConfig.ImageUrlPredix + fileName + imageParam;
            return url;
        }

        /// <summary>
        /// 获取微信产品详细图
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static string GetImageWeixinProudctDetail(string fileName)
        {
            return GetImage(fileName, QiniuImageSize.小图);
        }

        #endregion
    }
}
