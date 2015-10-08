using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.Other.Request;
using CL.CrossDomain.DomainModel.Background.Other.Response;

namespace CL.Biz.Background.Other
{
    public class ModelControlBiz
    {
        #region 加载
        private DBEntityGenerateRequest entity;

        public ModelControlBiz(DBEntityGenerateRequest ent)
        {
            this.entity = ent;
        }
        #endregion


        #region 生成实体类
        /// <summary>
        /// 生成实体类
        /// </summary>
        public StringBuilder Generate()
        {
            var sbTemp = new StringBuilder();

            List<DBTablesColumnRepsosne> lstColumns = ColumnControlBiz.GetColumnsByTableName(this.entity.DbTableName);
            //ColumnControl.GetColRelaPascalName(lstColumns);

            string colName;

            #region 生成命名空间和类

            sbTemp.Append("using System;");
            sbTemp.Append(Constant.Newline);
            sbTemp.Append(Constant.Newline).Append("namespace ").Append(this.entity.PrefixNameSpace);
            sbTemp.Append(Constant.Newline).Append("{");
            sbTemp.Append(Constant.Newline).Append("/// <summary>");
            sbTemp.Append(Constant.Newline).Append("///").Append(this.entity.DbTableComments).Append("(实体类)");
            sbTemp.Append(Constant.Newline).Append("/// </summary>");
            sbTemp.Append(Constant.Newline).Append("[Serializable]");

            sbTemp.Append(Constant.Newline).Append("public class ").Append(this.entity.PrefixClass).Append(this.entity.DbPascalTableName);//.Append(": PanPass.Library.Entities.Base.DbEntityBase");
            sbTemp.Append(Constant.Newline).Append("{");

            #endregion

            #region 生成构造函数

            sbTemp.Append(Constant.Newline).Append("/// <summary>");
            sbTemp.Append(Constant.Newline).Append("///").Append(this.entity.DbTableComments).Append("(构造函数)");
            sbTemp.Append(Constant.Newline).Append("/// </summary>");
            sbTemp.Append(Constant.Newline).Append("public ").Append(this.entity.PrefixClass).Append(this.entity.DbPascalTableName).Append("()");
            sbTemp.Append(Constant.Newline).Append("{");

            //生成构造函数
            foreach (var item in lstColumns)
            {
                string oriColumnName = item.Column_Name;

                string initValue = "null";

                //colName = ST_RuleSetView_Opt.ST_RuleSetView.IsPascal == 1 ? lstColumns.Rows[i]["PascalName"].ToString() : oriColumnName;
                colName = oriColumnName;
                sbTemp.Append(Constant.Newline).Append("this.").Append(colName).Append(" = ").Append(initValue).Append(";");
            }
            sbTemp.Append("\r\n}");

            #endregion

            #region 生成属性
            foreach (var item in lstColumns)
            {
                var oriColumnName = item.Column_Name;

                //colName = ST_RuleSetView_Opt.ST_RuleSetView.IsPascal == 1 ? lstColumns.Rows[i]["PascalName"].ToString() : oriColumnName;
                colName = oriColumnName;

                string tempType = item.DATA_TYPE;
                string tempDescription = item.Comments;
                string tempPrecision = item.DATA_PRECISION;
                string tempScale = item.DATA_SCALE;

                sbTemp.Append(Constant.Newline);
                sbTemp.Append("\r\n/// <summary>");
                sbTemp.Append("\r\n///").Append(tempDescription);
                sbTemp.Append("\r\n/// </summary>");

                //sbTemp.AppendFormat("\r\npublic {0} ", ST_RuleSetView_Opt.ST_RuleSetView.IsUseVirtualProp == 1 ? "virtual" : "");
                sbTemp.AppendFormat("\r\npublic {0} ", "");
                sbTemp.Append(DataTypeConvertBiz.ConvertType(tempType, tempPrecision, tempScale));

                sbTemp.Append(" ").
                Append(colName).
                Append(" { get; set; }");
            }
            sbTemp.Append("\r\n}");
            sbTemp.Append("\r\n}");

            #endregion

            return sbTemp;
        }
        #endregion
    }
}
