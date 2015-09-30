<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockIn.aspx.cs" Inherits="CL.Web.Background.Pages.Invoicing.StockIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript">
        var GB_ROOT_DIR = '/Scripts/greybox/';
    </script>
    <link href="/Scripts/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript"  src="/Scripts/greybox/AJS.js"></script>
    <script type="text/javascript"  src="/Scripts/greybox/AJS_fx.js"></script>
    <script type="text/javascript"  src="/Scripts/greybox/gb_scripts.js"></script>
    <script type="text/javascript" src="/Scripts/nativeAjax.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="mws-panel grid_8">
        <div class="mws-panel-header">
            <span class="mws-i-24 i-check" runat="server" id="add">入库操作</span>
        </div>
        <div class="mws-panel-body">
            <div class="mws-panel-content">
                <div class="mws-form">
                    <div class="mws-form-inline">
                        <div class="mws-form-row">
                            <label>商品<span class="RedStar">*</span></label>
                           <a href="/Pages/Common/ProductListQuery.aspx" title="请选择商品" rel="gb_page_fs[]">选择</a>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtProductName" runat="server" Width="85%" CssClass="mws-textinput" onfocus="ProductNameFocus()" />
                                <asp:HiddenField ID="hdProductID" runat="server" />
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>条形码<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtBarCode" runat="server" Width="85%" CssClass="mws-textinput" />
                            </div>
                        </div>
                      <%--  <div class="mws-form-row">
                            <label>规格<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:DropDownList runat="server" ID="ddlSpec" Width="250px">
                                </asp:DropDownList>
                                <asp:Button ID="btnGetSpec" runat="server" Text="获取规格" Visible="False" />
                            </div>
                        </div>--%>

                        <div class="mws-form-row">
                            <label>入库数量<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:TextBox ID="txtStockInCount" runat="server" name="urlField" Width="180px" class="mws-textinput" onkeyup="value=value.replace(/[^\d]/g,'')" MaxLength="6"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="mws-button-row">
                        <asp:Button ID="btnOK" class="button" runat="server" CssClass="mws-button red" OnClick="btnOK_Click" Text="提交" OnClientClick="return confirm('您是否确认入库?');" />
                        &nbsp;
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ProductNameFocus() {
            var data={};
            data.ProductID = document.getElementById("ContentPlaceHolder1_hdProductID").value;

            if (data.ProductID === '') {
                return false;
            }

            Ajax.request({
                url: "/Handler/Ajax.ashx",
                data: data,
                success: function (xhr) {
                    var d = eval('(' + xhr.responseText + ')');
                    document.getElementById("ContentPlaceHolder1_txtBarCode").value = d.BarCode;
                },
                error: function (xhr) {
                    alert('faliure!');
                }
            });
        }
    </script>
</asp:Content>
