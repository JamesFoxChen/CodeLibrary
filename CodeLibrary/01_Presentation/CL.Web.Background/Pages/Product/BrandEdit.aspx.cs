using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL.Biz.Background.Product;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.Product.Request;
using CL.Web.Background.Pages.Common;
using CL.Plugin.Qiniu;

namespace CL.Web.Background.Pages.Product
{
    public partial class BrandEdit : BasePage
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
            var biz = new BrandInfoBiz();
            BrandInfoRequest brandInfo = biz.GetBrandInfo(Request["Id"]);
            this.txtBrandName.Text = brandInfo.BrandName;
            this.txtIntroduce.Text = brandInfo.Introduce;
            this.txtOrderIndex.Text = brandInfo.OrderIndex.ToString();
            this.ckbShowStatus.Checked = brandInfo.ShowStatus == (int)ShowStatus.上架;
            this.txtPhone.Text= brandInfo.Phone;
            this.txtCompany.Text = brandInfo.Company;
            if (brandInfo.LogoImage != null)
            {
                imgLogoImage.ImageUrl = QiniuImageMng.GetImage(brandInfo.LogoImage, QiniuImageSize.小图);
                hinddenLogoImage.Value = brandInfo.LogoImage;
            }
        }
    }
}