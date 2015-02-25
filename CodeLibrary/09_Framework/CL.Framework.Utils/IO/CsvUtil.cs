using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace CL.Framework.Utils
{
    public class CsvUtil
    {
        public static bool ExportToCsv(DataTable dt, string filePath, bool isWriteTitle)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, false);

                int iColCount = dt.Columns.Count;

                if (isWriteTitle)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        sw.Write(dt.Columns[i].ColumnName);
                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }

                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }

                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }
                    }

                    sw.Write(sw.NewLine);
                }

                sw.Close();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        public static DataTable ReadFromCsv(string filePath, bool hasTitle = true)
        {
            try
            {
                var dt = new DataTable();

                StreamReader sr = new StreamReader(filePath);

                string[] titles = sr.ReadLine().Split(',');
                for (int i = 0; i < titles.Length; i++)
                {
                    if (hasTitle)
                    {
                        dt.Columns.Add(titles[i]);
                    }
                    else
                    {
                        dt.Columns.Add("titles" + (i + 1).ToString());
                    }
                }

                if (!hasTitle)
                {
                    dt.Rows.Add(titles);
                }

                string tempStr = "";
                while (!string.IsNullOrWhiteSpace((tempStr = sr.ReadLine())))
                {
                    if (!string.IsNullOrWhiteSpace(tempStr))
                    {
                        dt.Rows.Add(tempStr.Split(','));
                    }
                }

                sr.Close();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
