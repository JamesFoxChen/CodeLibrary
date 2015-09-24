using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace CL.Plugin.Excel
{   /// <summary>
    /// 导出Excel
    /// </summary>
    public class ExcelHelper
    {
        #region 属性
        /// <summary>
        /// workbook
        /// </summary>
        private IWorkbook wb;
        /// <summary>
        /// 标题
        /// </summary>
        public string[] column { get; set; }
        /// <summary>
        /// 文本对齐样式
        /// </summary>
        public ExcelCellTextAlign[] columnAlign { get; set; }
        #endregion


        #region 构造函数
        /// <summary>
        /// 无参构造函数创建空Workbook(2003)
        /// </summary>
        public ExcelHelper()
        {
            //创建Sheet 2003
            wb = new HSSFWorkbook();
            // 2007
            //wb = new XSSFWorkbook();
        }

        /// <summary>
        /// 将流转为workbook
        /// </summary>
        /// <param name="s">流</param>
        public ExcelHelper(Stream s)
        {
            wb = WorkbookFactory.Create(s);
        }

        /// <summary>
        /// 读取Excel文件,转为workbook
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public ExcelHelper(string filePath)
        {
            Stream s;
            if (File.Exists(filePath) == false)
            {
                throw new FileNotFoundException(filePath);
            }

            s = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            wb = WorkbookFactory.Create(s);
        }
        #endregion


        #region 公共方法
        /// <summary>
        /// 创建Sheet(如果没有则创建)
        /// </summary>
        /// <param name="sheetName">Sheet名称</param>
        /// <returns></returns>
        public ISheet GetSheet(string sheetName)
        {
            ISheet sheet;

            sheet = wb.GetSheet(sheetName);
            // sheet = wb.GetSheetAt(0);

            if (sheet == null)
            {
                sheet = wb.CreateSheet(sheetName);
            }

            return sheet;
        }

        /// <summary>
        /// 创建Sheet(如果没有则创建)
        /// </summary>
        /// <param name="sheetIndex">sheet索引</param>
        /// <returns></returns>
        public ISheet GetSheet(int sheetIndex)
        {
            return wb.GetSheetAt(sheetIndex);
        }

        /// <summary>
        /// 绑定列数据源
        /// </summary>
        /// <param name="sheetName">Sheet名称</param>
        /// <param name="columnIndex">列索引</param>
        /// <param name="dataSource">列数据源</param>
        public void SetColumnDataSource(string sheetName, Int32 columnIndex, string[] dataSource)
        {
            CreateListConstaint(GetSheet(sheetName), columnIndex, dataSource);
        }

        /// <summary>
        /// 填充数据到worksheet
        /// </summary>
        /// <param name="sheetName">worksheet名称</param>
        /// <param name="dt">数据源</param>
        /// <param name="title">标题</param>
        public void FillData(string sheetName, DataTable dt, string title)
        {
            #region 定义变量
            ISheet sheet;
            ICell cell;
            IRow row;
            ICellStyle CellTitle, CellLeft, CellCenter;

            int intRow, intColumn, intLeft, intTop, intHead;
            int i, j;
            string strValue;
            #endregion

            #region 初始化数据
            intLeft = 1;
            intTop = 3;
            intHead = 1;

            sheet = wb.GetSheet(sheetName);
            CellTitle = GetCellTitleStyle();
            CellLeft = GetCellLeftStyle();
            CellCenter = GetCellCenterStyle();

            //行集,列集
            intRow = dt.Rows.Count;
            intColumn = dt.Columns.Count;

            //excel最大行65536限制
            if (intRow > 65536 - 2)
            {
                intRow = 65536 - 2;
            }
            #endregion

            #region 设置标题
            for (i = 0; i <= intTop - 1; i++)
            {
                for (j = 0; j <= intLeft + intColumn - 1; j++)
                {
                    if (i == 1 && j > 0)
                    {
                        cell = GetExcelCell(sheet, i, j);
                        cell.SetCellValue(title);
                        cell.CellStyle = CellCenter;
                    }
                }
                row = GetExcelRow(sheet, i);
                row.Height = 20 * 20;
            }
            #endregion

            #region 设置列名称和样式
            for (i = 0; i <= intHead - 1; i++)
            {
                for (j = 0; j <= intColumn - 1; j++)
                {
                    cell = GetExcelCell(sheet, i + intTop, j + intLeft);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                    cell.CellStyle = CellTitle;
                }
                row = GetExcelRow(sheet, i);
                row.Height = 20 * 20;
            }
            #endregion

            #region 设置内容
            for (i = 0; i <= intRow - 1; i++)
            {
                for (j = 0; j <= intColumn - 1; j++)
                {
                    cell = GetExcelCell(sheet, i + intTop, j + intLeft);
                    strValue = dt.Rows[i][j].ToString();
                    if (!string.IsNullOrEmpty(strValue))
                    {
                        cell.SetCellValue(strValue);
                    }
                    if (i > intHead - 1)
                    {
                        if ((j >= 1 && j <= 4) || j == 6 || j == 8)
                        {
                            cell.CellStyle = CellCenter;
                        }
                        else
                        {
                            cell.CellStyle = CellLeft;
                        }
                    }
                    else
                    {
                        cell.CellStyle = CellTitle;
                    }
                }
                row = GetExcelRow(sheet, i);
                row.Height = 20 * 20;
            }
            #endregion

            #region 设置行高
            row = GetExcelRow(sheet, i + 1);
            row.Height = 20 * 20;
            row = GetExcelRow(sheet, i + 2);
            row.Height = 20 * 20;
            #endregion

            #region 设置列宽
            sheet.SetColumnWidth(0, 0 * 256);
            for (i = 0; i < 3; i++)
            {
                sheet.SetColumnWidth(i + 1, 20 * 256);
            }
            sheet.SetColumnWidth(i + 1, 1 * 256);
            #endregion

            #region 合并单元格
            sheet.AddMergedRegion(new CellRangeAddress(1, 1, 1, intColumn));
            #endregion
        }


        /// <summary>
        /// 填充数据到worksheet
        /// </summary>
        /// <param name="sheetName">worksheet名称</param>
        /// <param name="dt">数据源</param>
        /// <param name="title">标题</param>
        public void FillDataNew(string sheetName, DataTable dt, string title, bool showSequence)
        {
            #region 定义变量
            ISheet sheet;
            ICell cell;
            IRow row;
            ICellStyle CellTitle, CellLeft, CellCenter, CellRight;

            int intRow, intColumn, intLeft, intTop, intHead;
            int i, j, excelRow, page = 0, totalCount = 65536;
            string strValue;
            #endregion

            #region 初始化数据
            intLeft = 0;
            intTop = 0;
            intHead = 1;

            //行集,列集
            intRow = dt.Rows.Count;
            intColumn = dt.Columns.Count;
            totalCount -= intTop + intHead;

            sheet = GetSheet(sheetName);
            CellTitle = GetCellTitleStyle();
            CellLeft = GetCellLeftStyle();
            CellCenter = GetCellCenterStyle();
            CellRight = GetCellRightStyle();


            if (showSequence)
            {
                intColumn++;
            }


            //excel最大行65536限制
            //if (intRow > 65536 - 2)
            //{
            //    intRow = 65536 - 2;
            //}
            #endregion

            #region 设置标题
            for (i = 0, excelRow = 0; i < intTop; i++, excelRow++)
            {
                if (i / totalCount != page)
                {
                    excelRow = i % totalCount;
                    page = i / totalCount;
                    sheet = GetSheet(sheetName + page.ToString());
                }
                for (j = 0; j < intLeft + intColumn; j++)
                {
                    if (i == 1 && j > 0)
                    {
                        cell = GetExcelCell(sheet, excelRow, j);
                        cell.SetCellValue(title);
                        cell.CellStyle = CellCenter;
                    }
                }
                row = GetExcelRow(sheet, excelRow);
                row.Height = 20 * 20;
            }
            #endregion
            if (column == null || column.Length > dt.Columns.Count)
            {
                List<string> list = new List<string>();
                List<ExcelCellTextAlign> ca = new List<ExcelCellTextAlign>();
                if (showSequence)
                {
                    list.Add("序号");
                    ca.Add(ExcelCellTextAlign.Center);
                }
                foreach (DataColumn item in dt.Columns)
                {
                    list.Add(item.ColumnName);
                    ca.Add(ExcelCellTextAlign.Left);
                }
                column = list.ToArray();
                columnAlign = ca.ToArray();
            }
            #region 设置列名称和样式
            for (i = 0; i < intHead; i++)
            {
                for (j = 0; j < intColumn; j++)
                {
                    cell = GetExcelCell(sheet, i + intTop, j + intLeft);
                    cell.SetCellValue(column[j]);
                    cell.CellStyle = CellTitle;
                }
                row = GetExcelRow(sheet, i);
                row.Height = 20 * 20;
            }
            #endregion

            #region 设置内容
            page = 0;
            sheet = GetSheet(sheetName);
            for (i = 0, excelRow = 0; i < intRow; i++, excelRow++)
            {
                if (i / totalCount != page)
                {
                    excelRow = i % totalCount;
                    page = i / totalCount;
                    sheet = GetSheet(sheetName + page.ToString());
                }
                for (j = 0; j < intColumn; j++)
                {
                    cell = GetExcelCell(sheet, excelRow + intTop + intHead, j + intLeft);

                    if (showSequence)
                    {
                        if (j == 0)
                        {
                            strValue = (i + 1).ToString();
                        }
                        else
                        {
                            strValue = dt.Rows[i][j - 1].ToString();
                        }
                    }
                    else
                    {
                        strValue = dt.Rows[i][j].ToString();
                    }
                    if (!string.IsNullOrEmpty(strValue))
                    {
                        cell.SetCellValue(strValue);
                    }
                    if (columnAlign[j] == ExcelCellTextAlign.Left)
                    {
                        cell.CellStyle = CellLeft;
                    }
                    else if (columnAlign[j] == ExcelCellTextAlign.Center)
                    {
                        cell.CellStyle = CellCenter;
                    }
                    else if (columnAlign[j] == ExcelCellTextAlign.Right)
                    {
                        cell.CellStyle = CellRight;
                    }
                    else
                    {
                        cell.CellStyle = CellLeft;
                    }
                }
                row = GetExcelRow(sheet, excelRow);
                row.Height = 20 * 20;
            }
            #endregion

            #region 设置行高
            row = GetExcelRow(sheet, excelRow + 1);
            row.Height = 20 * 20;
            row = GetExcelRow(sheet, excelRow + 2);
            row.Height = 20 * 20;
            #endregion

            #region 设置列宽
            //sheet.SetColumnWidth(0, 0 * 256);
            for (i = 0; i < column.Length + intLeft; i++)
            {
                sheet.SetColumnWidth(i + 1, 20 * 256);
            }
            //sheet.SetColumnWidth(i + 1, 1 * 256);
            #endregion

            #region 合并单元格
            //sheet.AddMergedRegion(new CellRangeAddress(1, 1, 1, intColumn));
            #endregion
        }

        /// <summary>
        /// 把workbook导出
        /// </summary>
        /// <param name="excelName">导出excel文件的名称</param>
        public void ExportExcelFile(string excelName)
        {
            //string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + Guid.NewGuid().ToString("N") ;
            //using (FileStream ms = new FileStream(HttpContext.Current.Server.MapPath("/Template/" + fileName  + ".xlsx"), FileMode.Create, FileAccess.Write))
            using (MemoryStream ms = new MemoryStream())
            {
                wb.Write(ms);
                ms.Flush();
                ms.Position = 0;
                //FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("/Template/" + fileName + ".xlsx"), FileMode.Open, FileAccess.Read);     

                DownloadFile df = new DownloadFile(ms, excelName + DateTime.Now.ToString("yyyyMMddhh") + ".xls");
                df.Download();
            }
        }

        /// <summary>
        /// 保存excel文档
        /// </summary>
        /// <param name="path">路径</param>
        public void SaveExcel(string path)
        {
            //保存Excel文档
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                wb.Write(file);
                file.Dispose();
            }
            //hssfworkbook.Dispose();
        }

        /// <summary>
        /// 把指定的Sheet转为DataTable
        /// </summary>
        /// <param name="sheet">Sheet</param>
        /// <param name="isFirstLineHead">是否把第一行作为表头</param>
        /// <returns></returns>
        public DataTable GetDataTable(ISheet sheet, bool isFirstLineHead)
        {
            return SheetToDataTable(sheet, isFirstLineHead);
        }

        /// <summary>
        /// 把指定的Sheet转为DataTable
        /// </summary>
        /// <param name="sheetName">Sheet</param>
        /// <param name="isFirstLineHead">是否把第一行作为表头</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sheetName, bool isFirstLineHead)
        {
            return SheetToDataTable(GetSheet(sheetName), isFirstLineHead);
        }

        /// <summary>
        /// 把指定的Sheet转为DataTable
        /// </summary>
        /// <param name="sheetIndex">Sheet</param>
        /// <param name="isFirstLineHead">是否把第一行作为表头</param>
        /// <returns></returns>
        public DataTable GetDataTable(int sheetIndex, bool isFirstLineHead)
        {
            return SheetToDataTable(GetSheet(sheetIndex), isFirstLineHead);
        }

        /// <summary>
        /// 标题单元格样式
        /// </summary>
        /// <returns></returns>
        public ICellStyle GetCellTitleStyle()
        {
            ICellStyle style;

            style = wb.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            style.TopBorderColor = HSSFColor.Black.Index;
            style.RightBorderColor = HSSFColor.Black.Index;
            style.BottomBorderColor = HSSFColor.Black.Index;
            style.LeftBorderColor = HSSFColor.Black.Index;
            style.BorderTop = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.FillForegroundColor = HSSFColor.Grey25Percent.Index;
            style.FillPattern = FillPattern.Squares;
            style.FillBackgroundColor = HSSFColor.Grey25Percent.Index;

            return style;
        }

        /// <summary>
        /// 标题单元格居左样式
        /// </summary>
        /// <returns></returns>
        public ICellStyle GetCellLeftStyle()
        {
            ICellStyle style;

            style = wb.CreateCellStyle();
            style.TopBorderColor = HSSFColor.Black.Index;
            style.RightBorderColor = HSSFColor.Black.Index;
            style.BottomBorderColor = HSSFColor.Black.Index;
            style.LeftBorderColor = HSSFColor.Black.Index;
            style.BorderTop = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.Alignment = HorizontalAlignment.Left;

            return style;
        }

        /// <summary>
        /// 标题单元格居中样式
        /// </summary>
        /// <returns></returns>
        public ICellStyle GetCellCenterStyle()
        {
            ICellStyle style;

            style = wb.CreateCellStyle();
            style.TopBorderColor = HSSFColor.Black.Index;
            style.RightBorderColor = HSSFColor.Black.Index;
            style.BottomBorderColor = HSSFColor.Black.Index;
            style.LeftBorderColor = HSSFColor.Black.Index;
            style.BorderTop = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.Alignment = HorizontalAlignment.Center;

            return style;
        }

        /// <summary>
        /// 标题单元格居右样式
        /// </summary>
        /// <returns></returns>
        public ICellStyle GetCellRightStyle()
        {
            ICellStyle style;

            style = wb.CreateCellStyle();
            style.TopBorderColor = HSSFColor.Black.Index;
            style.RightBorderColor = HSSFColor.Black.Index;
            style.BottomBorderColor = HSSFColor.Black.Index;
            style.LeftBorderColor = HSSFColor.Black.Index;
            style.BorderTop = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.Alignment = HorizontalAlignment.Right;

            return style;
        }

        /// <summary>
        /// 获取Excel的行
        /// </summary>
        /// <param name="sheet">sheet</param>
        /// <param name="Y">行号</param>
        /// <returns></returns>
        public IRow GetExcelRow(ISheet sheet, int Y)
        {
            IRow row;
            row = sheet.GetRow(Y);

            if (row == null)
            {
                row = sheet.CreateRow(Y);
            }
            return row;
        }

        /// <summary>
        /// 获取行的单元格
        /// </summary>
        /// <param name="sheet">sheet</param>
        /// <param name="X">列号</param>
        /// <returns></returns>
        public ICell GetExcelCell(IRow sheet, int X)
        {
            ICell cell;
            cell = (ICell)sheet.GetCell(X);

            if (cell == null)
            {
                cell = (ICell)sheet.CreateCell(X);
            }
            return cell;
        }

        /// <summary>
        /// 获取sheet的单元格
        /// </summary>
        /// <param name="sheet">sheet</param>
        /// <param name="X">列序号</param>
        /// <param name="Y">行序号</param>
        /// <returns></returns>
        public ICell GetExcelCell(ISheet sheet, int X, int Y)
        {
            return GetExcelCell(GetExcelRow(sheet, X), Y);
        }
        #endregion


        #region 私有方法
        /// <summary>
        /// 将sheet转为DataTable
        /// </summary>
        /// <param name="sheet">sheet</param>
        /// <param name="header">是否把第一行作为表头</param>
        /// <returns></returns>
        private DataTable SheetToDataTable(ISheet sheet, bool header)
        {
            DataTable dt;
            DataRow first, dataRow;
            IRow row;
            ICell cell;
            string colName;
            object cellValue;

            if (sheet == null)
            {
                return null;
            }
            var rows = sheet.GetRowEnumerator();

            dt = new DataTable();
            row = null;
            // 排除前面的空白行
            while (rows.MoveNext())
            {
                row = (IRow)rows.Current;
                if (row.LastCellNum > -1)
                {
                    break;
                }
            }
            if (row == null)
            {
                return null;
            }
            // 初始化数据集的列(把第一个非空白行作为标题或用列序号作为标题)
            for (int i = 0; i < row.LastCellNum; i++)
            {
                cell = GetExcelCell(row, i);
                colName = header ? cell.ToString() : i.ToString();
                dt.Columns.Add(colName, typeof(string));
            }
            // 是否把第一行作为列, 若不是则添加到datatable中, 注意合并单元格会引起列名相同报错
            if (!header)
            {
                first = dt.NewRow();
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    cell = GetExcelCell(row, i);
                    first[i] = cell.ToString();
                }
                dt.Rows.Add(first);
            }
            // 遍历每行, 把数据添加到DataTable中
            while (rows.MoveNext())
            {
                row = (IRow)rows.Current;
                dataRow = dt.NewRow();

                for (int i = 0; i < row.LastCellNum; i++)
                {
                    cell = GetExcelCell(row, i);
                    cellValue = null;

                    switch (cell.CellType)
                    {
                        //文本
                        case CellType.String:
                            cellValue = cell.StringCellValue;
                            break;
                        //数值
                        case CellType.Numeric:
                            cellValue = Convert.ToDouble(cell.NumericCellValue);
                            break;
                        // bool
                        case CellType.Boolean:
                            cellValue = cell.BooleanCellValue;
                            break;
                        // 空白
                        case CellType.Blank:
                            cellValue = string.Empty;
                            break;
                        default: cellValue = string.Empty;
                            break;
                    }
                    //typeof(T).GetProperty(fields[j]).SetValue(t, cellValue, null);

                    dataRow[i] = cellValue;
                }
                dt.Rows.Add(dataRow);
            }

            return dt;
        }

        /// <summary>
        /// 为Sheet绑定数据源
        /// </summary>
        /// <param name="sheet">Sheet</param>
        /// <param name="columnIndex">列索引</param>
        /// <param name="dataSource">列数据源</param>
        private void CreateListConstaint(ISheet sheet, Int32 columnIndex, string[] dataSource)
        {
            CellRangeAddressList regions = new CellRangeAddressList(0, 65535, columnIndex, columnIndex);
            DVConstraint constraint = DVConstraint.CreateExplicitListConstraint(dataSource);
            // 2003
            IDataValidation dataValidate = new HSSFDataValidation(regions, constraint);
            // 2007
            // IDataValidation dataValidate = new XSSFDataValidation(regions, constraint);
            sheet.AddValidationData(dataValidate);
        }
        #endregion


        #region 待处理
        /// <summary>
        /// Excel相关样式
        /// </summary>
        /// <param name="cell"></param>
        private void setExcelCellStyle(ICell cell)
        {
            IFont font;
            ICellStyle style;
            IDataFormat format;
            IWorkbook wookbook;
            ISheet sheet;

            wookbook = new HSSFWorkbook();

            sheet = wookbook.GetSheetAt(0);
            //保护Excel
            sheet.ProtectSheet("123456");

            font = wookbook.CreateFont();

            //字体粗细
            font.Boldweight = 2;
            font.FontHeight = 11;
            //字体颜色
            font.Color = HSSFColor.Red.Index;

            //创建单元格样式
            style = wookbook.CreateCellStyle();
            //单元格字体
            style.SetFont(font);
            //锁定单元格
            style.IsLocked = true;

            //单元格边框
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderTop = BorderStyle.Thin;
            //单元格边框颜色
            style.BottomBorderColor = HSSFColor.Green.Index;
            //单元格背景颜色
            style.FillForegroundColor = HSSFColor.Red.Index;
            style.FillPattern = FillPattern.Squares;
            style.FillBackgroundColor = HSSFColor.Red.Index;
            //文字居中
            style.Alignment = HorizontalAlignment.Center;
            //时间格式化
            format = wookbook.CreateDataFormat();
            style.DataFormat = format.GetFormat("yyyy年m月d日");
            //保留两位小数
            style.DataFormat = format.GetFormat("0.00");
            //中文大小写
            style.DataFormat = format.GetFormat("[DbNum2][$-804]0");

            //合并单元格
            sheet.AddMergedRegion(new CellRangeAddress(1, 2, 1, 3));

            //设置列宽
            //ws.SetColumnWidth(i + 1, 15 * 256);
            //设置行高
            //row.Height = 30 * 20;

            cell.CellStyle = style;
            //基本计算
            cell.CellFormula = "B1+C1";
            //函数计算
            cell.CellFormula = "sum(B2:F2)";
        }

        // 转color
        private short GetXLColour(IWorkbook workbook, System.Drawing.Color SystemColour)
        {
            // style.FillForegroundColor = GetXLColour(workbook, LevelOneColor);
            // Color LevelOneColor = Color.FromArgb(143, 176, 229);

            short s = 0;
            HSSFPalette XlPalette = ((HSSFWorkbook)workbook).GetCustomPalette();
            HSSFColor XlColour = XlPalette.FindColor(SystemColour.R, SystemColour.G, SystemColour.B);
            if (XlColour == null)
            {
                if (NPOI.HSSF.Record.PaletteRecord.STANDARD_PALETTE_SIZE < 255)
                {
                    if (NPOI.HSSF.Record.PaletteRecord.STANDARD_PALETTE_SIZE < 64)
                    {
                        //NPOI.HSSF.Record.PaletteRecord.STANDARD_PALETTE_SIZE = 64;
                        //NPOI.HSSF.Record.PaletteRecord.STANDARD_PALETTE_SIZE += 1;
                        XlColour = XlPalette.AddColor(SystemColour.R, SystemColour.G, SystemColour.B);
                    }
                    else
                    {
                        XlColour = XlPalette.FindSimilarColor(SystemColour.R, SystemColour.G, SystemColour.B);
                    }

                    s = XlColour.Indexed;
                }
            }
            else
            {
                s = XlColour.Indexed;
            }

            return s;
        }
        #endregion

    }
}
