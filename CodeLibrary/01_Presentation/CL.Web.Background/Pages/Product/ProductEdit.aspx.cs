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
        public string ProductDesc;

        private string RequestID
        {
            get { return Request["Id"]; }
        }

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
            var biz = new ProductInfoBiz();
            ProductInfoRequest productInfo = biz.GetProductInfo(this.RequestID);
            this.txtProductName.Text = productInfo.ProductName;
            this.hdBrandID.Value = productInfo.BrandID;
            this.txtBrandName.Value = new BrandInfoBiz().GetBrandInfo(productInfo.BrandID).BrandName;
            this.txtMarketPrice.Text = productInfo.MarketPrice.ToString();
            this.txtSalesPrice.Text = productInfo.SalesPrice.ToString();
            this.txtBarCode.Text = productInfo.BarCode;
            this.ckbShowStatus.Checked = productInfo.ShowStatus == (int)ShowStatus.上架;
            if (!string.IsNullOrWhiteSpace(productInfo.DefaultPhotoUrl))
            {
                this.imgDefaultPhotoUrl.ImageUrl = QiniuImageMng.GetImage(productInfo.DefaultPhotoUrl, QiniuImageSize.小图);
            }
            if (!string.IsNullOrWhiteSpace(productInfo.PhotoUrl))
            {
                string[] productInfos = productInfo.PhotoUrl.Substring(0, productInfo.PhotoUrl.Length - 1).Split(';');
                for (int i = 0; i < productInfos.Length; i++)
                {
                    literalPhotoUrl.Text += "<img id='imgs" + i + "' src=\"" + QiniuImageMng.GetImage(productInfos[i], QiniuImageSize.小图) + "\"><a href='javascript:void(0);' id='imga" + i + "' onclick='if(confirm(\"是否删除图片？\")){delImgFile(\"" + productInfos[i] + "\",\"imgs" + i + "\",\"imga" + i + "\");}'>删除</a>";
                }
            }
            this.txtProductNote.Text = productInfo.ProductNote;
            this.ProductDesc = productInfo.ProductDesc;
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
            if (string.IsNullOrWhiteSpace(this.RequestID))
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
            var productInfo = new ProductInfoRequest
            {
                ProductName = this.txtProductName.Text.Trim(),
                BrandID = this.hdBrandID.Value,
                MarketPrice = this.txtMarketPrice.Text.ToDecimalOrNull(),
                SalesPrice = this.txtSalesPrice.Text.ToDecimalOrNull(),
                BarCode = this.txtBarCode.Text.Trim(),
                ShowStatus = (int)ShowStatus.上架,
                PhotoUrl = this.hdPhotoUrl.Value,
                ProductNote = this.txtProductNote.Text.Trim(),
                ProductDesc = this.hdProductDesc.Value.Trim(),
                OrderIndex = 1,
            };

            if (this.fileDefaultPhoto.HasFile)
            {
                string filePath = ImgFileExtensions.FileImg(this.fileDefaultPhoto.PostedFile);
                var result = QiniuImageMng.UploadImage(filePath);
                productInfo.DefaultPhotoUrl = result.FileName;

            }
            return productInfo;
        }

        private void addProductInfo()
        {
            var productInfo = getModel();
            productInfo.DataSource = (int)DataSourceType.后台;
            var biz = new ProductInfoBiz();
            bool result = biz.AddProductInfo(productInfo).IsSuccess;
             base.AlertCommon(result, "ProductList.aspx");
        }

        private void updateProductInfo()
        {
            var ProductInfo = getModel();
            ProductInfo.ID = this.RequestID;

            var biz = new ProductInfoBiz();
            bool result = biz.UpdateProductInfo(ProductInfo).IsSuccess;
            base.AlertCommon(result, "ProductList.aspx");
        }
    }
}