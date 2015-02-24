using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CL.CrossDomain.Utils.Utils.IO
{
    /// <summary>
    /// 缩略图裁剪模式
    /// </summary>
    public enum MakeThumbnailModelType
    {
        /// <summary>
        /// 指定高宽缩放（可能变形）
        /// </summary>
        HW = 0,
        /// <summary>
        /// 指定宽，高按比例   
        /// </summary>
        W = 1,
        /// <summary>
        /// 指定高，宽按比例
        /// </summary>
        H = 2,
        /// <summary>
        /// 指定高宽裁减（不变形） 
        /// </summary>
        Cut = 3
    }

    /// <summary>
    /// 图片工具类
    /// </summary>
    public static class ImageUtil
    {

        /// <summary>
        ///  将二进制保存成图片
        /// </summary>
        /// <param name="imageDatas">二进制</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static bool SaveImage(byte[] imageDatas, string filePath)
        {
            bool ret = false;
            System.Drawing.Image image = null;
            try
            {
                //如果是字符串的话
                //byte[] resultBytes = Convert.FromBase64String(ImageDatas);
                using (MemoryStream ImageMS = new MemoryStream())
                {
                    ImageMS.Write(imageDatas, 0, imageDatas.Length);
                    image = System.Drawing.Image.FromStream(ImageMS);
                    image.Save(filePath);
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                image.Dispose();
            }
            return ret;
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, out int towidth, out int toheight)
        {
            MakeThumbnailModelType mode;
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            towidth = 0;// width;
            toheight = 0;// height;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            if (ow > oh)
            {
                //宽大于高 ，将宽度设置为100，高按比例缩放
                towidth = 100;
                mode = MakeThumbnailModelType.W;

            }
            else
            {
                //高设置100 ，宽按照比例缩放
                toheight = 100;
                mode = MakeThumbnailModelType.H;
            }
            if (towidth == 0)
                towidth = originalImage.Width;
            if (toheight == 0)
                toheight = originalImage.Height;

            switch (mode)
            {
                case MakeThumbnailModelType.HW://指定高宽缩放（可能变形）                
                    break;
                case MakeThumbnailModelType.W://指定宽，高按比例                    
                    toheight = originalImage.Height * towidth / originalImage.Width;
                    break;
                case MakeThumbnailModelType.H://指定高，宽按比例
                    towidth = originalImage.Width * toheight / originalImage.Height;
                    break;

                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(0, 0, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }


        /// <summary>
        /// 生成缩略图头像并剪裁
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnailbyCut(string originalImagePath, string thumbnailPath, int width, int height, MakeThumbnailModelType mode, int x = 0, int y = 0)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            if (towidth == 0)
                towidth = originalImage.Width;
            if (toheight == 0)
                toheight = originalImage.Height;

            switch (mode)
            {
                case MakeThumbnailModelType.HW://指定高宽缩放（可能变形）                
                    break;
                case MakeThumbnailModelType.W://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case MakeThumbnailModelType.H://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case MakeThumbnailModelType.Cut://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, towidth, toheight),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        /// <summary>
        /// 在图片上增加文字水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_sy">生成的带文字水印的图片路径</param>
        public static void AddMarkWord(string Path, string Path_sy)
        {
            string addText = "测试水印";
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            System.Drawing.Font f = new System.Drawing.Font("Verdana", 16);
            System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);

            g.DrawString(addText, f, b, 15, 15);
            g.Dispose();

            image.Save(Path_sy);
            image.Dispose();
        }

        /**/
        /// <summary>
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_syp">生成的带图片水印的图片路径</param>
        /// <param name="Path_sypf">水印图片路径</param>
        public static void AddMarkPic(string Path, string Path_syp, string Path_sypf)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();

            image.Save(Path_syp);
            image.Dispose();
        }
    }



}
