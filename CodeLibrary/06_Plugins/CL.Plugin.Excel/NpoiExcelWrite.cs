using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Plugin.Excel
{
    public class NpoiExcelWrite : IExcelWrite
    {
        public object CreateWorkBook()
        {
            var workbook = new HSSFWorkbook();//从流内容创建Workbook对象
            return workbook;
        }

        public object CreateSheet(object workbook, string sheetName)
        {
            if (workbook == null) throw new ArgumentNullException("workbook");
        
            ISheet sheet = ((HSSFWorkbook)workbook).CreateSheet(sheetName);//创建工作表
            return sheet;
        }

        public object CreateRow(object sheet, string row)
        {
            if (sheet == null) throw new ArgumentNullException("sheet");

            IRow irow = ((ISheet)sheet).CreateRow(Convert.ToInt32(row));//在工作表中添加一行
            return irow;
        }

        public object CreateCell(object row, string cell)
        {
            if (row == null) throw new ArgumentNullException("row");

            ICell icell = ((IRow)row).CreateCell(Convert.ToInt32(cell));//在工作表中添加一行
            return icell;
        }

        public void WriteFile(object workbook, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
