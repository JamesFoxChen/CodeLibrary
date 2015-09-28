﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="CL.Web.Background.Pages.Product.ProductEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--  <script type="text/javascript" charset="utf-8" src="/Plugins/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/Plugins/ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/Plugins/ueditor/lang/zh-cn/zh-cn.js"></script>
    <link href="/Scripts/spectrum/spectrum.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/spectrum/spectrum.js" type="text/javascript"></script>--%>
    <link rel="stylesheet" type="text/css" href="/Plugins/diyUpload/css/webuploader.css" />
    <link rel="stylesheet" type="text/css" href="/Plugins/diyUpload/css/diyUpload.css" />
    <script type="text/javascript" src="/Plugins/diyUpload/js/webuploader.html5only.min.js"></script>
    <script type="text/javascript" src="/Plugins/diyUpload/js/diyUpload.js"></script>
    <br />
    <div class="mws-panel grid_8">

        <div class="mws-panel-header">
            <span>产品管理</span>
        </div>
        <div class="mws-panel-body">
            <div class="mws-panel-content">

                <div class="mws-form">
                    <input type="hidden" id="BID" value="" runat="server" />
                    <div class="mws-form-inline">
                        <div class="mws-form-row">
                            <label>产品名称<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtProductName" runat="server" class="mws-textinput required" />
                            </div>
                        </div>

                        <div class="mws-form-row">
                            <label>商品图片<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:Literal ID="literalPhotoUrl" runat="server"></asp:Literal>
                                <div id="box">
                                    <div id="test"></div>
                                    <input type="hidden" runat="server" id="hiddenPhotoUrl" class="mws-textinput" />
                                </div>
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

        function check() {
        }

        function delImgFile(filepath, id, a) {
            $.ajax({
                type: "get",
                url: "/Handler/DelImgFils.ashx",
                data: { "delImgFile": filepath },
                async: false,
                success: function (data) {
                    if (data == "ok") {
                        $("#ContentPlaceHolder1_hiddenPhotoUrl").val($("#ContentPlaceHolder1_hiddenPhotoUrl").val().replace(filepath + ";", ""));
                        $("#" + id).remove();
                        $("#" + a).remove();
                    }
                }
            });
        }

        $('#test').diyUpload($("#ContentPlaceHolder1_hiddenPhotoUrl"), {
            url: '/Handler/ImgFils.ashx',
            success: function (data) {
                console.info(data);
            },
            error: function (err) {
                console.info(err);
            }
        });

    </script>
</asp:Content>
