using System;
using CL.Biz.Background.Other;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.Other.Request;
using CL.Framework.Extensions;
using CL.Framework.Utils;
using CL.Plugin.Qiniu;
using CL.Web.Background.Pages.Common;

namespace CL.Web.Background.Pages.Display
{
    public partial class MPollImageEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL(ddlBizID, MPollImageType.首页);
                if (Request["Id"] != null) //修改
                {
                    LoadData();
                    ddlBizID.Enabled = false;
                }
            }
        }

        private void LoadData()
        {
            var biz = new MPollImagesBiz();
            var data = biz.GetMPollImage(Request["Id"]);
            ddlBizID.SelectedValue = data.BizID.ToString();
            ddlOrderIndex.SelectedValue = data.OrderIndex.ToString();
            txtImageLink.Value = data.ImageLink;
            imgImageUrl.ImageUrl = QiniuImageMng.GetImage(data.ImageID);
            hiddenImageUrl.Value = data.ImageID;
            hdImageID.Value = data.ImageID;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ddlBizID.SelectedValue))
            {
                Response.Write("<script>alert('请选择【业务类型】！');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtImageLink.Value))
            {
                Response.Write("<script>alert('图片链接不能为空！');</script>");
                return;
            }

            if (Request["Id"] == null) //新增
            {
                add();
            }
            else
            {
                update();
            }
        }

        private string getImageID()
        {
            string filePath = ImgFileExtensions.FileImg(fileImageUrl.PostedFile);
            var photoresult = QiniuImageMng.UploadImage(filePath);
            imgImageUrl.ImageUrl = QiniuImageMng.GetImage(photoresult.FileName);
            return photoresult.FileName;

        }
        private void add()
        {
            if (!fileImageUrl.HasFile)
            {
                Response.Write("<script>alert('请先上传图片！');</script>");
                return;
            }

            var request = new MPollImagesRequest
            {
                ID = StringUtil.GetGUID(),
                BizID = ddlBizID.SelectedValue.ToInt32OrNull(),
                OrderIndex = ddlOrderIndex.SelectedValue.ToInt32(),
                ImageLink = txtImageLink.Value.Trim(),
                Created = DateTime.Now,
                ImageID = getImageID()
            };

            var biz = new MPollImagesBiz();
            var data = biz.AddMPollImage(request);
            if (data > 0)
            {
                //new RedisCommon().RemoveMPollImages();
                Response.Write("<script>alert('操作成功！');</script>");
                Response.Redirect("MPollImageList.aspx");
            }
            else
            {
                Response.Write("<script>alert('操作失败！');</script>");
            }
        }

        private void update()
        {
            var request = new MPollImagesRequest
            {
                ID = Request["Id"],
                BizID = ddlBizID.SelectedValue.ToInt32OrNull(),
                OrderIndex = ddlOrderIndex.SelectedValue.ToInt32(),
                ImageLink = txtImageLink.Value.Trim(),
                Created = DateTime.Now
            };

            if (!fileImageUrl.HasFile)  //不修改图片
            {
                request.ImageID = hdImageID.Value;
            }
            else
            {
                request.ImageID = getImageID();
            }

            var biz = new MPollImagesBiz();
            var data = biz.UpdateMPollImage(request);
            if (data > 0)
            {
                //new RedisCommon().RemoveMPollImages();
                Response.Write("<script>alert('操作成功！');location.href='MPollImageList.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('操作失败！');</script>");
            }
        }
    }
}