using Qiniu.Auth.digest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Qiniu.FileOp;
using Qiniu.IO;
using Qiniu.IO.Resumable;
using Qiniu.RPC;
using Qiniu.RS;
using Qiniu.RSF;

namespace CL.Plugin.Qiniu
{
    internal class QiniuHelper
    {
       
        // CommonFun.GetConfigData(DataConfigKey.Qiniu.ToString(), DataConfigAttr.DOMAIN.ToString());
        /// <summary>
        /// 在网站/程序初始化时调用一次
        /// </summary>
        public static void Init()
        {
            //设置权限key
            QiniuConfig.ACCESS_KEY = QiniuConfig.ACCESS_KEY;
            //CommonFun.GetConfigData(DataConfigKey.Qiniu.ToString(), DataConfigAttr.ACCESS_KEY.ToString());
            //设置密匙key
            QiniuConfig.SECRET_KEY = QiniuConfig.SECRET_KEY;
            // CommonFun.GetConfigData(DataConfigKey.Qiniu.ToString(), DataConfigAttr.SECRET_KEY.ToString());
        }

        #region 查看单个文件属性信息
        /// <summary>
        /// 查看单个文件属性信息
        /// </summary>
        /// <param name="bucket">七牛云存储空间名</param>
        /// <param name="key">文件key</param>
        public static void Stat(string bucket, string key)
        {
            RSClient client = new RSClient();
            Entry entry = client.Stat(new EntryPath(bucket, key));
            if (entry.OK)
            {
                Console.WriteLine("Hash: " + entry.Hash);
                Console.WriteLine("Fsize: " + entry.Fsize);
                Console.WriteLine("PutTime: " + entry.PutTime);
                Console.WriteLine("MimeType: " + entry.MimeType);
                Console.WriteLine("Customer: " + entry.Customer);
            }
            else
            {
                Console.WriteLine("Failed to Stat");
            }
        }
        #endregion

        /// <summary>
        /// 复制单个文件
        /// </summary>
        /// <param name="bucketSrc">需要复制的文件所在的空间名</param>
        /// <param name="keySrc">需要复制的文件key</param>
        /// <param name="bucketDest">目标文件所在的空间名</param>
        /// <param name="keyDest">标文件key</param>
        public static void Copy(string bucketSrc, string keySrc, string bucketDest, string keyDest)
        {
            RSClient client = new RSClient();
            CallRet ret = client.Copy(new EntryPathPair(bucketSrc, keySrc, bucketDest, keyDest));
            if (ret.OK)
            {
                Console.WriteLine("Copy OK");
            }
            else
            {
                Console.WriteLine("Failed to Copy");
            }
        }

        /// <summary>
        /// 移动单个文件
        /// </summary>
        /// <param name="bucketSrc">需要移动的文件所在的空间名</param>
        /// <param name="keySrc">需要移动的文件</param>
        /// <param name="bucketDest">目标文件所在的空间名</param>
        /// <param name="keyDest">目标文件key</param>
        public static void Move(string bucketSrc, string keySrc, string bucketDest, string keyDest)
        {
            Console.WriteLine("\n===> Move {0}:{1} To {2}:{3}",
            bucketSrc, keySrc, bucketDest, keyDest);
            RSClient client = new RSClient();
            new EntryPathPair(bucketSrc, keySrc, bucketDest, keyDest);
            CallRet ret = client.Move(new EntryPathPair(bucketSrc, keySrc, bucketDest, keyDest));
            if (ret.OK)
            {
                Console.WriteLine("Move OK");
            }
            else
            {
                Console.WriteLine("Failed to Move");
            }
        }

        /// <summary>
        /// 删除单个文件
        /// </summary>
        /// <param name="bucket">文件所在的空间名</param>
        /// <param name="key">文件key</param>
        public static CallRet Delete(string bucket, string key)
        {
            bool re = false;
            //Console.WriteLine("\n===> Delete {0}:{1}", bucket, key);
            RSClient client = new RSClient();
            CallRet ret = client.Delete(new EntryPath(bucket, key));
            return ret;
        }
        /// <summary>
        /// 批量获取文件信息
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="keys"></param>
        public static void BatchStat(string bucket, string[] keys)
        {
            RSClient client = new RSClient();
            List<EntryPath> EntryPaths = new List<EntryPath>();
            foreach (string key in keys)
            {
                Console.WriteLine("\n===> Stat {0}:{1}", bucket, key);
                EntryPaths.Add(new EntryPath(bucket, key));
            }
            client.BatchStat(EntryPaths.ToArray());
        }
        /// <summary>
        /// 批量复制
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="keys"></param>
        public static void BatchCopy(string bucket, string[] keys)
        {
            List<EntryPathPair> pairs = new List<EntryPathPair>();
            foreach (string key in keys)
            {
                EntryPathPair entry = new EntryPathPair(bucket, key, Guid.NewGuid().ToString());
                pairs.Add(entry);
            }
            RSClient client = new RSClient();
            client.BatchCopy(pairs.ToArray());
        }

        /// <summary>
        /// 批量移动
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="keys"></param>
        public static void BatchMove(string bucket, string[] keys)
        {
            List<EntryPathPair> pairs = new List<EntryPathPair>();
            foreach (string key in keys)
            {
                EntryPathPair entry = new EntryPathPair(bucket, key, Guid.NewGuid().ToString());
                pairs.Add(entry);
            }
            RSClient client = new RSClient();
            client.BatchMove(pairs.ToArray());
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="keys"></param>
        public static void BatchDelete(string bucket, string[] keys)
        {
            RSClient client = new RSClient();
            List<EntryPath> EntryPaths = new List<EntryPath>();
            foreach (string key in keys)
            {
                //Console.WriteLine("\n===> Stat {0}:{1}", bucket, key);
                EntryPaths.Add(new EntryPath(bucket, key));
            }
            client.BatchDelete(EntryPaths.ToArray());
        }
        /// <summary>
        /// 列出所有文件信息
        /// </summary>
        /// <param name="bucket"></param>
        public static List<DumpItem> List(int limit = 100, string prefix = "")
        {
            RSFClient rsf = new RSFClient(QiniuConfig.bucket);
            rsf.Prefix = prefix;
            rsf.Limit = limit;
            List<DumpItem> list = new List<DumpItem>();
            List<DumpItem> items;
            while ((items = rsf.Next()) != null)
            {
                list.AddRange(items);
                //todo
            }
            return list;
        }


        /// <summary>
        /// 普通上传文件
        /// key必须采用utf8编码，如使用非utf8编码访问七牛云存储将反馈错误
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="key">上传后的路径</param>
        /// <param name="fname">要上传的文件路径（文件必须存在）</param>
        public static PutRet PutFile(string key, string fname)
        {
            if (key.IndexOf('.') == -1) key += Path.GetExtension(fname);
            var policy = new PutPolicy(QiniuConfig.bucket, 3600);
            string upToken = policy.Token();
            PutExtra extra = new PutExtra();
            IOClient client = new IOClient();
            //client.PutFinished += (o, retTemp) =>
            //{
            //    if (retTemp.StatusCode == HttpStatusCode.OK)
            //    {
            //    }
            //    else if (retTemp.StatusCode == HttpStatusCode.BadGateway ||
            //        retTemp.StatusCode == HttpStatusCode.BadRequest ||
            //        retTemp.StatusCode == HttpStatusCode.GatewayTimeout ||
            //        retTemp.StatusCode == HttpStatusCode.GatewayTimeout ||
            //        retTemp.StatusCode == HttpStatusCode.InternalServerError)
            //    {
            //    }
            //};
            PutRet ret = client.PutFile(upToken, key, fname, extra);

            return ret;
        }
        /// <summary>
        /// 普通上传图片
        /// key必须采用utf8编码，如使用非utf8编码访问七牛云存储将反馈错误
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="key">上传后的路径</param>
        /// <param name="fname">要上传的文件路径（文件必须存在）</param>
        public static PutRet PutImage(string key, string fname, string mimeType = "image/jpg")
        {
            if (key.IndexOf('.') == -1) key += Path.GetExtension(fname);
            if (mimeType == "") mimeType = GetMimeTypeByExtension(Path.GetExtension(fname));
            var policy = new PutPolicy(QiniuConfig.bucket, 3600);
            string upToken = policy.Token();
            PutExtra extra = new PutExtra
            {
                MimeType = mimeType,
                Crc32 = 123,
                CheckCrc = CheckCrcType.CHECK,
                Params = new Dictionary<string, string>()
            };
            IOClient client = new IOClient();
            PutRet ret = client.PutFile(upToken, key, fname, extra);
            return ret;
        }

        /// <summary>
        /// 上传文件到网站服务器，再上传到七牛服务器
        /// </summary>
        /// <param name="fileData">页面/swf传过来的文件数据</param>
        /// <param name="fileType">预留</param>
        /// <param name="path">文件加逻辑路径，如：images/ </param>
        /// <param name="isOriginal">是否保留文件原名</param>
        /// <param name="prefix">不保留原名时，文件名的前缀部分</param>
        /// <returns></returns>
        public static PutRet UploadFile(HttpPostedFileBase fileData, string fileType = "", string path = "", string isOriginal = "", string prefix = "")
        {
            PutRet ret = null;
            if (fileData != null)
            {

                var fileExt = Path.GetExtension(fileData.FileName);
                var fileName = "";
                if (isOriginal != "1")
                {
                    fileName = "test";// DataHelper.CreateRandomName(fileExt);
                    if (prefix != "") fileName = prefix + fileName;
                }
                else fileName = Path.GetFileName(fileData.FileName).Replace(" ", "");

                var fileFullPath = "";
                bool isImage = false;
                string mimeType = GetMimeTypeByExtension(fileExt);
                if (mimeType == "")
                {
                    if (path.Len() == 0) path = "files/";
                    fileFullPath = Path.Combine(path, fileType);
                }
                else if (mimeType.StartsWith("image"))
                {
                    if (path.Len() == 0) path = "images/";
                    fileFullPath = Path.Combine(path, fileType);
                    isImage = true;
                }
                else
                {
                    if (path.Len() == 0) path = "other/";
                    fileFullPath = Path.Combine(path, fileType);
                }
                if (!Directory.Exists(QiniuConfig.cdnPath + fileFullPath))
                {
                    Directory.CreateDirectory(QiniuConfig.cdnPath + fileFullPath);
                }
                var fileFullName = QiniuConfig.cdnPath + fileFullPath + "/" + fileName;
                fileData.SaveAs(fileFullName);

                string key = string.Empty;
                //上传图片到七牛
                if (System.IO.File.Exists(fileFullName))
                {
                    // long len = fileData.ContentLength / 1024;
                    key = fileFullName.Replace(QiniuConfig.cdnPath, "").Replace("\\", "/").Replace("//", "/");
                    if (isImage) ret = PutImage(key, fileFullName, mimeType);
                    else ret = PutFile(key, fileFullName);
                }
            }
            return ret;
        }

        /// <summary>
        /// 通过后缀获取mime类型
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        private static string GetMimeTypeByExtension(string extension)
        {
            string mimeType = "";
            extension = extension.TrimStart('.').ToLowerInvariant();
            switch (extension)
            {
                case "gif":
                    mimeType = "image/gif";
                    break;
                case "png":
                    mimeType = "image/png";
                    break;
                case "bmp":
                    mimeType = "image/bmp";
                    break;
                case "jpeg":
                case "jpg":
                    mimeType = "image/jpg";
                    break;

            }
            return mimeType;
        }

        /// <summary>
        /// 断点续传
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="key"></param>
        /// <param name="fname"></param>
        public static void ResumablePutFile(string bucket, string key, string fname)
        {
            Console.WriteLine("\n===> ResumablePutFile {0}:{1} fname:{2}", bucket, key, fname);
            PutPolicy policy = new PutPolicy(bucket, 3600);
            string upToken = policy.Token();
            Settings setting = new Settings();
            ResumablePutExtra extra = new ResumablePutExtra();
            // extra.Notify += PutNotifyEvent;//(int blkIdx, int blkSize, BlkputRet ret);//上传进度通知事件
            ResumablePut client = new ResumablePut(setting, extra);
            client.PutFile(upToken, fname, Guid.NewGuid().ToString());
        }

        /// <summary>
        /// 得到文件的外链地址 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isPublic"></param>
        /// <returns></returns>
        public static string GetUrl(string key, bool isPublic = true)
        {
            string baseUrl = GetPolicy.MakeBaseUrl(QiniuConfig.Domain, key);
            if (isPublic) return baseUrl;
            string private_url = GetPolicy.MakeRequest(baseUrl);
            return private_url;
        }

        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isPublic"></param>
        /// <returns></returns>
        public static ImageInfoRet GetImageInfo(string key, bool isPublic = true)
        {
            string url = GetPolicy.MakeBaseUrl(QiniuConfig.Domain, key);
            //生成fop_url
            string imageInfoURL = ImageInfo.MakeRequest(url);
            //对其签名，生成private_url。如果是公有bucket此步可以省略
            if (!isPublic) imageInfoURL = GetPolicy.MakeRequest(imageInfoURL);
            ImageInfoRet infoRet = ImageInfo.Call(imageInfoURL);
            if (infoRet.OK)
            {
                Console.WriteLine("Format: " + infoRet.Format);
                Console.WriteLine("Width: " + infoRet.Width);
                Console.WriteLine("Heigth: " + infoRet.Height);
                Console.WriteLine("ColorModel: " + infoRet.ColorModel);
            }
            else
            {
                Console.WriteLine("Failed to ImageInfo");
            }
            return infoRet;
        }

        public static string GetImagePreviewUrl(string key, bool isPublic = true)
        {
            string url = GetPolicy.MakeBaseUrl(QiniuConfig.Domain, key);

            ImageView imageView = new ImageView { Mode = 0, Width = 200, Height = 200, Quality = 90, Format = "jpg" };
            string viewUrl = imageView.MakeRequest(url);
            if (!isPublic) viewUrl = GetPolicy.MakeRequest(viewUrl);//私链
            return viewUrl;
        }

        /// <summary>
        /// 获取水印图片
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <param name="waterString"></param>
        /// <param name="isPublic"></param>
        /// <param name="waterColor"></param>
        /// <returns></returns>
        public static string GetWaterMarker(string key, WaterType type = WaterType.No, string waterString = "", bool isPublic = true, string waterColor = "red")
        {
            string url = GetUrl(key);
            string markerUrl = string.Empty;
            switch (type)
            {
                case WaterType.Text:
                    {
                        //文字水印
                        WaterMarker marker = new TextWaterMarker(waterString, "", waterColor);
                        markerUrl = marker.MakeRequest(url);
                    }
                    break;
                case WaterType.Image:
                    {
                        //图片水印
                        WaterMarker marker = new ImageWaterMarker(waterString);
                        markerUrl = marker.MakeRequest(url);
                    }
                    break;
            }
            if (!isPublic && !string.IsNullOrEmpty(markerUrl)) markerUrl = GetPolicy.MakeRequest(markerUrl);
            return markerUrl;


        }

        /// <summary>
        /// 表单上传图片
        /// </summary>
        /// <param name="bucketName">内容空间名称</param>
        /// <param name="returnUrl">上传之后回调的地址</param>
        /// <param name="returnBody">返回的数据格式</param>
        /// <returns>生成的上传凭证</returns>
        public static string FormSubmit(string bucketName, string fileName,
            string returnUrl = "http://localhost:13010/UploadTest/receiver",
            string returnBody = "{\"name\": $(fname),\"size\": \"$(fsize)\",\"w\": \"$(imageInfo.width)\",\"h\": \"$(imageInfo.height)\",\"key\":$(etag)}"
            )
        {
            Mac mac = new Mac();
            //定义仓库名称

            PutPolicy putPolicy = new PutPolicy(bucketName);
            //定义回调地址
            putPolicy.ReturnUrl = returnUrl;
            //定义回调的数据格式
            putPolicy.ReturnBody = returnBody;
            //产生上传的凭据
            String uptoken = putPolicy.Token(mac);

            //定义图片名称

            return uptoken;
        }
        /// <summary>
        /// 原图地址
        /// </summary>
        /// <param name="Orginnal">原图地址</param>
        /// <param name="i">转换的地址类型
        /// 0:800x600
        /// 1:300x200
        /// 2:100x500
        /// </param>
        /// <returns>缩略图的地址</returns>
        public static string GetThumbnail(string Orginnal, int i)
        {
            string ret = Orginnal;
            switch (i)
            {
                case 0:
                    ret = Orginnal;
                    break;
                case 1:
                    ret = Orginnal + "?imageView2/1/w/800/h/600/q/75";
                    break;
                case 2:
                    ret = Orginnal + "?imageView2/1/w/300/h/200/q/100";
                    break;
                case 3:
                    ret = Orginnal + "?imageView2/1/w/100/h/500/q/75";
                    break;
                default:
                    break;

            }
            return ret;

        }
        /// <summary>
        /// 水印类型枚举
        /// </summary>
        public enum WaterType
        {
            /// <summary>
            /// 无水印
            /// </summary>
            No,
            /// <summary>
            /// 文字水印
            /// </summary>
            Text,
            /// <summary>
            /// 图片水印
            /// </summary>
            Image
        }
    }

}
