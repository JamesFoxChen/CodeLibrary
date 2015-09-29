<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductListQuery.aspx.cs" Inherits="CL.Web.Background.Pages.Common.ProductListQuery" %>

<%@ Register Src="~/Controls/Pagnation.ascx" TagPrefix="uc1" TagName="Pagnation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <script type="text/javascript">
        function SelectProduct(data) {
            try {
                parent.parent.document.getElementById('ContentPlaceHolder1_txtProductName').value = data.productName;
                parent.parent.document.getElementById('ContentPlaceHolder1_hfProductID').value = data.id;
                parent.parent.document.getElementById('ContentPlaceHolder1_txtProductName').focus();
            } catch (ex) { };
            if (typeof parent.parent.selectProductCallBack == 'function') {
                parent.parent.selectProductCallBack(data);
            }
            parent.parent.GB_hide();
        }

    </script>
    <div class="mws-panel grid_8">
        <div class="mws-panel-header">
            <span class="mws-i-24 i-table-1">查询条件</span>
        </div>
        <div class="mws-panel-body mws-form">
            <div class="mws-form-row">
                商品编号：<asp:TextBox ID="txtDisplayID" runat="server" CssClass="mws-textinput"></asp:TextBox>
                商品名称：<asp:TextBox ID="txtProductName" runat="server" CssClass="mws-textinput"></asp:TextBox>
                是否上架：<asp:DropDownList ID="ddlShowStatus" runat="server" CssClass="mws-textinput"></asp:DropDownList>
                创建开始时间：<asp:TextBox ID="txtCreatedStartDate" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd',autoPickDate:true})"></asp:TextBox>
                创建结束时间：<asp:TextBox ID="txtCreatedEndDate" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd',autoPickDate:true})"></asp:TextBox>
                &nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="mws-button green" OnClick="btnQuery_Click" />
            </div>
        </div>
        <div class="mws-panel-header">
            <span class="mws-i-24 i-table-1" id="bt">商品管理</span>
        </div>
        <div class="mws-panel-body">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <div id="divList" runat="server">
                <table class="mws-table">
                    <thead>
                        <tr>
                            <th></th>
                            <th>编号</th>
                            <th>商品名称
                            </th>
                            <th>商品状态
                            </th>
                            <th>市场价 
                            </th>
                            <th>销售价 
                            </th>
                            <th>添加时间
                            </th>
                            <th>排序
                            </th>
                            <th>操作
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpt" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                          <a href="#" class="selected" onclick='SelectProduct(
                                            {id:"<%#Eval("ID")%>",productName:"<%#Eval("ProductName").ToString()%>"})'>选择</a>
                                    </td>
                                    <td>
                                        <%# Eval("DisplayID") %>
                                    </td>
                                    <td>
                                        <%# Eval("ProductName") %>
                                    </td>
                                    <td>
                                        <%# Eval("ShowStatusDesc") %>
                                    </td>
                                 
                                    <td>
                                        <%# Eval("MarketPrice") %>
                                    </td>
                                    <td>
                                        <%# Eval("SalesPrice") %>
                                    </td>
                                    <td>
                                        <%# Eval("Created","{0:yyyy-MM-dd HH:mm:ss}") %>
                                  
                                    <td>
                                        <%# Eval("OrderIndex") %>
                                    </td>
                                    <td></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div>
                    <%=PaginationHtml%>
                </div>
                <uc1:Pagnation runat="server" ID="Pagnation" />
            </div>
        </div>
    </div>
</asp:Content>
