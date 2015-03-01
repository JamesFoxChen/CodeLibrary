using CL.Plugin.Excel;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CL.Web.MVC.Controllers
{
    public class ExcelController : Controller
    {
        //
        // GET: /Excel/
        public ActionResult Write()
        {
            var workbook = new HSSFWorkbook();//从流内容创建Workbook对象
            ISheet sheet = ((HSSFWorkbook)workbook).CreateSheet("sheetOne");//创建工作表

            IRow row = sheet.CreateRow(0);//在工作表中添加一行
            ICell cell = row.CreateCell(1);//在行中添加一列
            cell.SetCellValue("test");//设置列的内容
            setCellStyle(workbook, cell);
            mergeCell(sheet, 0, 0, 1, 4);

            sheet = ((HSSFWorkbook)workbook).CreateSheet("sheet2");//创建工作表
            setCellDropdownlist(sheet);
            setCellInputNumber(sheet);

            string filePath = Server.MapPath("~/ExportFiles/test.xls");
            FileStream fs = new FileStream(filePath, FileMode.Create);
            workbook.Write(fs);
            fs.Close();

            return null;
        }

        /// <summary>
        /// 设置单元格为下拉框并限制输入值
        /// </summary>
        /// <param name="sheet"></param>
        private void setCellDropdownlist(ISheet sheet)
        {
            //设置生成下拉框的行和列
            var cellRegions = new CellRangeAddressList(0, 65535, 0, 0);

            //设置 下拉框内容
            DVConstraint constraint = DVConstraint.CreateExplicitListConstraint(
                new string[] { "itemA", "itemB", "itemC" });

            //绑定下拉框和作用区域，并设置错误提示信息
            HSSFDataValidation dataValidate = new HSSFDataValidation(cellRegions, constraint);
            dataValidate.CreateErrorBox("输入不合法", "请输入下拉列表中的值。");
            dataValidate.ShowPromptBox = true;

            sheet.AddValidationData(dataValidate);
        }

        /// <summary>
        /// 设置单元格只能输入数字
        /// </summary>
        /// <param name="sheet"></param>
        private void setCellInputNumber(ISheet sheet)
        {
            //设置生成下拉框的行和列
            var cellRegions = new CellRangeAddressList(0, 65535, 1, 1);

            //第二个参数int comparisonOperator  参考源码获取
            //https://github.com/tonyqus/npoi
            //NPOITest项目
            DVConstraint constraint = DVConstraint.CreateNumericConstraint(
                ValidationType.INTEGER, OperatorType.BETWEEN, "0", "100");
            
            HSSFDataValidation dataValidate = new HSSFDataValidation(cellRegions, constraint);
            dataValidate.CreateErrorBox("输入不合法", "请输入1~100的数字。");
            //dataValidate.PromptBoxTitle = "ErrorInput";

            sheet.AddValidationData(dataValidate);
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="firstRow"></param>
        /// <param name="lastRow"></param>
        /// <param name="firstCell"></param>
        /// <param name="lastCell"></param>
        private void mergeCell(ISheet sheet, int firstRow, int lastRow, int firstCell, int lastCell)
        {
            sheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, firstCell, lastCell));//2.0使用 2.0以下为Region
        }

        /// <summary>
        /// 设置单元格样式
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="cell"></param>
        private void setCellStyle(HSSFWorkbook workbook, ICell cell)
        {
            HSSFCellStyle fCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFFont ffont = (HSSFFont)workbook.CreateFont();
            ffont.FontHeight = 20 * 20;
            ffont.FontName = "宋体";
            ffont.Color = HSSFColor.Red.Index;
            fCellStyle.SetFont(ffont);

            fCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//垂直对齐
            fCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//水平对齐
            cell.CellStyle = fCellStyle;
        }
    }
}
