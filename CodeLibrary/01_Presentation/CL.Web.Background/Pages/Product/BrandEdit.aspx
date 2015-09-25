<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrandEdit.aspx.cs" Inherits="CL.Web.Background.Pages.Product.BrandEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                            <label>品牌介绍</label>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtIntroduce" TextMode="MultiLine" class="mws-textinput" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>图片Logo<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:FileUpload ID="fileLogoImage" runat="server" CssClass="mws-textinput" /><span class="RedStar">在前端作为品牌图片显示</span>
                                <br />
                                <asp:Image ID="imgLogoImage" runat="server" />
                                <input type="hidden" value="" runat="server" id="hinddenLogoImage" />
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
                    </div>
                    <div class="mws-button-row">
                        <asp:Button ID="btnOK" class="button" runat="server" CssClass="mws-button red" OnClick="btnOK" Text="提交信息" OnClientClick="return confirm('您是否确认操作?');" />
                        <input type="button" onclick="javaScript: history.go(-1);" class="mws-button blue" value="返回" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
