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
using CL.Plugin.Qiniu;
using CL.Web.Background.Pages.Common;

namespace CL.Web.Background.Pages.Product
{
    public partial class ProductEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initProductList();
                if (Request["Id"] != null)
                {
                    loadData();
                }
            }
        }
        private void loadData()
        {
           
        }


        private void initProductList()
        {
            var response =
               new BrandInfoBiz().GetBrandList(new BrandListRequest
               {
                   ShowStatus = (int)ShowStatus.上架
               });
            foreach (var item in response.DataList)
            {
                this.ltlBrandList.Text += "<li style=\"width:180px;\"><a href=\"javascript:BrandSelected('" + item.ID + "','" + item.BrandName.Replace("'", "’") + "');\">" + item.BrandName.Replace("'", "’") + "</a></li>";
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Request["Id"]))
            {
                addProductInfo();
            }
            else
            {
                updateProductInfo();
            }
        }

        private ProductInfoRequest getModel()
        {
            var ProductInfo = new ProductInfoRequest
            {
                ProductName = this.txtProductName.Text.Trim(),
                BrandID = this.hdBrandID.Value,
                PhotoUrl = this.hdPhotoUrl.Value,
                OrderIndex = 1,
                ShowStatus = (int)ShowStatus.上架
            };

            //if (fileLogoImage.HasFile)
            //{
            //    string filePath = ImgFileExtensions.FileImg(fileLogoImage.PostedFile);
            //    var result = QiniuImageMng.UploadImage(filePath);
            //    ProductInfo.LogoImage = result.FileName;

            //}
            return ProductInfo;
        }

        private void addProductInfo()
        {
            var productInfo = getModel();
            productInfo.DataSource = (int)DataSourceType.后台;
            var biz = new ProductInfoBiz();
            if (!biz.AddProductInfo(productInfo).IsSuccess)
            {
                Response.Write("<script>alert('操作失败！');location.href='ProductList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('操作成功！');location.href='ProductList.aspx';</script>");
            }
        }

        private void updateProductInfo()
        {
            var ProductInfo = getModel();
            ProductInfo.ID = Request["Id"];

            var biz = new ProductInfoBiz();
            if (!biz.UpdateProductInfo(ProductInfo).IsSuccess)
            {
                Response.Write("<script>alert('操作失败！');location.href='ProductList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('操作成功！');location.href='ProductList.aspx';</script>");
            }
        }
    }
}