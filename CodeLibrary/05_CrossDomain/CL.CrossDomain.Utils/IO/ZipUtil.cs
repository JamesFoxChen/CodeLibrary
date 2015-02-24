using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Collections;

namespace CL.CrossDomain.Utils
{
    public class ZipUtil
    {
        #region 压缩
        /// <summary>
        /// 压缩文件夹
        /// </summary>
        public static bool ZipFolder(string inputFolderPath, string outputFilePath, string password)
        {
            try
            {
                ArrayList ar = GenerateFileList(inputFolderPath); // generate file list
                int TrimLength = (Directory.GetParent(inputFolderPath)).ToString().Length;
                // find number of chars to remove     
                TrimLength += 1; //remove '\'
                FileStream ostream;
                byte[] obuffer;

                ZipOutputStream oZipStream = new ZipOutputStream(File.Create(outputFilePath)); // create zip stream
                if (password != null && password != String.Empty)
                {
                    oZipStream.Password = password;
                }

                oZipStream.SetLevel(9); // maximum compression
                ZipEntry oZipEntry;
                //一个个文件的拷贝压缩
                foreach (string Fil in ar) // for each file, generate a zipentry
                {
                    oZipEntry = new ZipEntry(Fil.Remove(0, TrimLength));
                    oZipStream.PutNextEntry(oZipEntry);

                    if (!Fil.EndsWith(@"/")) // if a file ends with '/' its a directory
                    {
                        ostream = File.OpenRead(Fil);
                        obuffer = new byte[ostream.Length];
                        ostream.Read(obuffer, 0, obuffer.Length);
                        oZipStream.Write(obuffer, 0, obuffer.Length);//把读入的文件信息写入Zip对象
                    }
                }
                oZipStream.Finish();
                oZipStream.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private static ArrayList GenerateFileList(string Dir)
        {
            ArrayList fils = new ArrayList();
            bool Empty = true;
            foreach (string file in Directory.GetFiles(Dir)) // add each file in directory
            {
                fils.Add(file);
                Empty = false;
            }

            if (Empty)
            {
                if (Directory.GetDirectories(Dir).Length == 0)
                {
                    fils.Add(Dir + @"/");
                }
            }

            foreach (string dirs in Directory.GetDirectories(Dir)) // recursive
            {
                foreach (object obj in GenerateFileList(dirs))
                {
                    fils.Add(obj);
                }
            }
            return fils; // return file list
        }
        #endregion


        #region 解压缩
        /// <summary>
        /// 解压缩文件
        /// </summary>
        /// <param name="zipfilepath">待解压缩的文件路径</param>
        public static bool UnZip(string zipfilepath, string unZipPath, string password)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(zipfilepath));
            FileStream streamWriter = null;
            ZipEntry theEntry = null;

            try
            {
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string fileName = Path.GetFileName(theEntry.Name);

                    if (fileName != String.Empty)
                    {
                        //如果文件的压缩后大小为0那么说明这个文件是空的,因此不需要进行读出写入
                        if (theEntry.CompressedSize == 0)
                            break;

                        streamWriter = File.Create(unZipPath + theEntry.Name);

                        int size = 2048;
                        byte[] data = new byte[2048];

                        if (!string.IsNullOrWhiteSpace(password))
                        {
                            s.Password = password;
                        }

                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        streamWriter.Close();
                    }
                }
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                s.Close();
                streamWriter.Close();
                return false;
            }
        }
        #endregion
    }
}
