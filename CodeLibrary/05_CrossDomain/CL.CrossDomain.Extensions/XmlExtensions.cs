using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


/// <summary>
/// Xml对象扩展类
/// </summary>
public static class XmlExtensions
{
    public static string AddDeclaration(this XElement source)
    {
        return @"<?xml version=""1.0"" encoding=""utf-8""?>" + Environment.NewLine + source.ToString();
    }

     //XElement ele = new XElement("File",
     //           new XAttribute("Type", "Warehouse"),
     //           new XAttribute("CreateTime", this.txtCreateTime.Text),
     //           new XAttribute("FileNo", this.txt文件序号.Text),
     //           new XAttribute("Priority", this.cmb文件优先级.SelectedItem == null ? this.cmb文件优先级.Text : this.cmb文件优先级.SelectedItem.ToString()),
     //            new XElement("Bill",
     //               new XAttribute("BillNumber", this.txt单号.Text),
     //               new XAttribute("BillType", this.cmb单据类型.Text),
     //               new XAttribute("FromWarehouseId", getId(this.cmb发货库房)),
     //               new XAttribute("FromWarehouseName", this.cmb发货库房.Text),
     //               new XAttribute("ToWarehouseId", getId(this.cmb收货库房)),
     //               new XAttribute("ToWarehouseName", this.cmb收货库房.Text),
     //               new XAttribute("FromDistributorId", getId(this.cmb发货经销商)),
     //               new XAttribute("FromDistributorName", this.cmb发货经销商.Text),
     //               new XAttribute("ToDistributorId", getId(this.cmb收货经销商)),
     //               new XAttribute("ToDistributorName", this.cmb收货经销商.Text),
     //               new XAttribute("BillDate", this.txt出入库时间.Text)
     //                     ));

     //       ele = XElement.Parse(getCodes(ele.ToString()));

     //       return @"<?xml version=""1.0"" encoding=""utf-8""?>" + Environment.NewLine + ele;
}

