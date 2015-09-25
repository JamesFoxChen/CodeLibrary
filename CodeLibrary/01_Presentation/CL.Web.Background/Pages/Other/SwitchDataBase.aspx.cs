using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL.Biz.Common;
using CL.Web.Background.Pages.Common;

namespace CL.Web.Background.Pages.Other
{
    public partial class SwitchDataBase : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.BindDDL(this.ddlDataBase, DataBaseEnum.SqlServer);
            }
        }

        protected void btnSwitch_Click(object sender, EventArgs e)
        {

        }
    }
}