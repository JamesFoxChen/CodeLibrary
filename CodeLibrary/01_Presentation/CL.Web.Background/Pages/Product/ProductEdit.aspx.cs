using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL.Web.Background.Pages.Common;

namespace CL.Web.Background.Pages.Product
{
    public partial class ProductEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["Id"] != null)
                {
                    loadData();
                }
            }
        }
        private void loadData()
        {
        }


        protected void btnOK_Click(object sender, EventArgs e)
        {
         
        }

    }
}