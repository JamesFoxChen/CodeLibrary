using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL.Biz.Background.Product;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.Product.Request;
using CL.Framework.Extensions;
using CL.Web.Background.Pages.Common;
using CL.Plugin.Qiniu;

namespace CL.Web.Background.Pages.Product
{
    public partial class BrandEdit : BasePage
    {
        public string Introduce;

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
            this.Introduce = brandInfo.Introduce;
            this.txtOrderIndex.Text = brandInfo.OrderIndex.ToString();
            this.ckbShowStatus.Checked = brandInfo.ShowStatus == (int)ShowStatus.上架;
            this.txtPhone.Text = brandInfo.Phone;
            this.txtCompany.Text = brandInfo.Company;
            if (brandInfo.LogoImage != null)
            {
                imgLogoImage.ImageUrl = QiniuImageMng.GetImage(brandInfo.LogoImage, QiniuImageSize.小图);
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Request["Id"]))
            {
                addBrandInfo();
            }
            else
            {
                updateBrandInfo();
            }
        }

        private BrandInfoRequest getModel()
        {
            var brandInfo = new BrandInfoRequest
            {
                BrandName = this.txtBrandName.Text.Trim(),
                Introduce = this.hdIntroduce.Value,
                OrderIndex = this.txtOrderIndex.Text.ToInt32OrMinValue(),
                ShowStatus = this.ckbShowStatus.Checked ? (int)ShowStatus.上架 : (int)ShowStatus.下架,
                Phone = this.txtPhone.Text.Trim(),
                Company = this.txtCompany.Text.Trim()
            };

            if (fileLogoImage.HasFile)
            {    
                string filePath = ImgFileExtensions.FileImg(fileLogoImage.PostedFile);
                var result = QiniuImageMng.UploadImage(filePath);
                brandInfo.LogoImage = result.FileName;
            }
            return brandInfo;
        }

        private void addBrandInfo()
        {
            var brandInfo = getModel();
            brandInfo.DataSource = (int)DataSourceType.后台;
            var biz = new BrandInfoBiz();
            if (!biz.AddBrandInfo(brandInfo).IsSuccess)
            {
                Response.Write("<script>alert('操作失败！');location.href='BrandList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('操作成功！');location.href='BrandList.aspx';</script>");
            }
        }

        private void updateBrandInfo()
        {
            var brandInfo = getModel();
            brandInfo.ID = Request["Id"];

            var biz = new BrandInfoBiz();
            if (!biz.UpdateBrandInfo(brandInfo).IsSuccess)
            {
                Response.Write("<script>alert('操作失败！');location.href='BrandList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('操作成功！');location.href='BrandList.aspx';</script>");
            }
        }
    }
}