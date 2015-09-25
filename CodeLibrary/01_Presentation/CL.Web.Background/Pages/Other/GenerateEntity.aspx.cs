using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL.Biz.Background;
using CL.Biz.Background.Other;
using CL.CrossDomain.DomainModel.Background.Other.Request;
using CL.Web.Background.Pages.Common;

namespace CL.Web.Background.Pages.Other
{
    public partial class GenerateEntity : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDBTables();
            }
        }

        private void bindDBTables()
        {
            var dbTable = TableControlBiz.GetTables("");
            this.ddlDBTables.Items.Clear();
            this.ddlDBTables.Items.Add(new ListItem("请选择", ""));
            foreach (var item in dbTable)
            {
                this.ddlDBTables.Items.Add(new ListItem(item.TableName, item.TableName));
            }
        }

        protected void btnGenerateModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.ddlDBTables.SelectedValue))
            {
                Response.Write("<script>alert('请选择数据表！');</script>");
                return;
            }

            var request = new DBEntityGenerateRequest
            {
                DbTableName = this.ddlDBTables.SelectedValue,
                DbPascalTableName = this.ddlDBTables.SelectedValue
            };

            var biz = new ModelControlBiz(request);
            var code = biz.Generate();
            this.txtCode.Text = code.ToString();
        }
    }
}