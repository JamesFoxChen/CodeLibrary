<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ProductEdit.aspx.cs" Inherits="CL.Web.Background.Pages.Product.ProductEdit" %>

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
    
    
    <script type="text/javascript" charset="utf-8" src="/Plugins/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/Plugins/ueditor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/Plugins/ueditor/lang/zh-cn/zh-cn.js"></script>
    <link href="/Scripts/spectrum/spectrum.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/spectrum/spectrum.js" type="text/javascript"></script>
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
                            <label>商品名称<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtProductName" runat="server" class="mws-textinput required" />
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>商品品牌<span class="RedStar">*</span></label>
                            <div class="mws-form-item small ">
                                <asp:HiddenField ID="hdBrandID" runat="server" />
                                <input type="text" runat="server" readonly="readonly" id="txtBrandName" class="mws-textinput required" />
                                <input type="button" id="mws-jui-dialog-mdl-btn" class="mws-button blue" value="选择" />

                                <div id="mws-jui-dialog">
                                    <div class="mws-form">
                                        <ul class="mws-form-list inline">
                                            <asp:Literal ID="ltlBrandList" runat="server"></asp:Literal>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>市场价<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtMarketPrice" runat="server" class="mws-textinput required digits"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>优惠价<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtSalesPrice" runat="server" class="mws-textinput required digits"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>条形码<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtBarCode" runat="server" class="mws-textinput required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>是否上架</label>
                            <div class="mws-form-item large">
                                <asp:CheckBox ID="ckbShowStatus" Checked="True" runat="server" />
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>图片默认图<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:FileUpload ID="fileDefaultPhoto" runat="server" CssClass="mws-textinput" /><span class="RedStar">在前端作为商品默认图片展示</span>
                                <br />
                                <asp:Image ID="imgDefaultPhotoUrl" runat="server" />
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>商品图片<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:Literal ID="literalPhotoUrl" runat="server"></asp:Literal>
                                <div id="box">
                                    <div id="test"></div>
                                    <input type="hidden" runat="server" id="hdPhotoUrl" class="mws-textinput" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="mws-form-row">
                        <label>商品说明</label>
                        <div class="mws-form-item large">
                            <asp:TextBox ID="txtProductNote" runat="server" TextMode="MultiLine" MaxLength="400"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label>商品描述</label>
                        <div class="mws-form-item large">
                            &nbsp;<script id="ProductDesc" type="text/plain" style="width: 800px; height: 400px;"><%=ProductDesc %> </script>
                            <input type="hidden" runat="server" id="hdProductDesc" />
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
    <script type="text/javascript">
        //加载富文本框
        UE.getEditor('ProductDesc');

        function check() {
            $("#ContentPlaceHolder1_hdProductDesc").val(UE.getEditor('ProductDesc').getContent());
        }

        $("#mws-jui-dialog-mdl-btn").bind("click", function (event) {
            $("#mws-jui-dialog").dialog("option", { modal: true }).dialog("open");
            event.preventDefault();
        });

        $("#mws-jui-dialog").dialog({
            autoOpen: false,
            title: "Brand",
            modal: true,
            width: "640",
            //buttons: [{
            //		text: "Close Dialog", 
            //		click: function() {
            //			$( this ).dialog( "close" );
            //		}}]
        });

        //选择分类时触发
        function BrandSelected(valueId, valueName) {
            var brandID = $("input[id$='hdBrandID']");
            if (brandID.val() != valueId) {
                brandID.val(valueId);
                $("input[id$='txtBrandName']").val(valueName);
            }
            $("#mws-jui-dialog").dialog("close");
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

        $('#test').diyUpload($("#ContentPlaceHolder1_hdPhotoUrl"), {
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
