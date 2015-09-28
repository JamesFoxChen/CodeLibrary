<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="BrandEdit.aspx.cs" Inherits="CL.Web.Background.Pages.Product.BrandEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <script type="text/javascript" src="/Plugins/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" src="/Plugins/ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" src="/Plugins/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript" src="/Plugins/diyUpload/js/diyUpload.js"></script>
    <link rel="stylesheet" type="text/css" href="/Plugins/diyUpload/css/webuploader.css" />
    <link rel="stylesheet" type="text/css" href="/Plugins/diyUpload/css/diyUpload.css" />
    <script type="text/javascript" src="/Plugins/diyUpload/js/webuploader.html5only.min.js"></script>

    <link href="/Scripts/spectrum/spectrum.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/spectrum/spectrum.js" type="text/javascript"></script>--%>

    <script type="text/javascript" charset="utf-8" src="/Plugins/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/Plugins/ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/Plugins/ueditor/lang/zh-cn/zh-cn.js"></script>
    <link href="/Scripts/spectrum/spectrum.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/spectrum/spectrum.js" type="text/javascript"></script>

    <br />
    <div class="mws-panel grid_8">

        <div class="mws-panel-header">
            <span>品牌管理</span>
        </div>
        <div class="mws-panel-body">
            <div class="mws-panel-content">

                <div class="mws-form">
                    <input type="hidden" id="BID" value="" runat="server" />
                    <div class="mws-form-inline">
                        <div class="mws-form-row">
                            <label>品牌名称<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtBrandName" runat="server" class="mws-textinput required" />
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>序号<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtOrderIndex" runat="server" class="mws-textinput required digits" />
                            </div>
                        </div>

                        <div class="mws-form-row">
                            <label>图片Logo<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:FileUpload ID="fileLogoImage" runat="server" CssClass="mws-textinput" /><span class="RedStar">在前端作为品牌默认图片展示</span>
                                <br />
                                <asp:Image ID="imgLogoImage" runat="server" />
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>是否上架</label>
                            <div class="mws-form-item large">
                                <asp:CheckBox ID="ckbShowStatus" Checked="True" runat="server" />
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>电话</label>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtPhone" runat="server" class="mws-textinput" />
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>所属公司</label>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtCompany" runat="server" class="mws-textinput" />
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>品牌介绍</label>
                            <div class="mws-form-item large">
                                &nbsp;<script id="Introduce" type="text/plain" style="width: 800px; height: 400px;"><%=Introduce %> </script>
                                <input type="hidden" runat="server" id="hdIntroduce" />
                            </div>
                        </div>
                    </div>
                    <div class="mws-button-row">
                        <asp:Button ID="btnOK" class="button" runat="server" CssClass="mws-button red" Text="提交信息" OnClientClick="return check();" OnClick="btnOK_Click" />
                        <input type="button" onclick="javaScript: history.go(-1);" class="mws-button blue" value="返回" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        //加载富文本框
        var ProductInfos = UE.getEditor('Introduce');

        function check() {
            $("#ContentPlaceHolder1_hdIntroduce").val(UE.getEditor('Introduce').getContent());
        }
    </script>
</asp:Content>
