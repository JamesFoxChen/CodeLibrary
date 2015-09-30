<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockInLog.aspx.cs" Inherits="CL.Web.Background.Pages.Invoicing.StockInLog" %>

<%@ Register Src="/Controls/Pagnation.ascx" TagPrefix="uc1" TagName="Pagnation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var GB_ROOT_DIR = '/Scripts/greybox/';
    </script>
    <link href="/Scripts/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="/Scripts/greybox/AJS.js"></script>
    <script type="text/javascript" charset="utf-8" src="/Scripts/greybox/AJS_fx.js"></script>
    <script type="text/javascript" charset="utf-8" src="/Scripts/greybox/gb_scripts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="mws-panel grid_8">
        <div class="mws-panel-header">
            <span class="mws-i-24 i-table-1">查询条件</span>
        </div>

        <div class="mws-panel-body mws-form">
            <div class="mws-form-row">
                商品编号：<asp:TextBox ID="txtDisplayID" runat="server" CssClass="mws-textinput" />
                商品名称：<asp:TextBox ID="txtProductName" runat="server" CssClass="mws-textinput" />
                <a href="/Pages/Common/ProductListQuery.aspx" title="请选择商品" rel="gb_page_fs[]">选择</a>
                <asp:HiddenField ID="hdProductID" runat="server" />
                条形码：<asp:TextBox ID="txtBarCode" runat="server" CssClass="mws-textinput"></asp:TextBox>
                入库开始时间：<asp:TextBox ID="txtDateStart" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd',autoPickDate:true})"></asp:TextBox>
                入库结束时间：<asp:TextBox ID="txtDateEnd" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd',autoPickDate:true})"></asp:TextBox>
                &nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="mws-button green" OnClick="btnQuery_Click" />
            </div>
        </div>

        <div class="mws-panel-header">
            <span class="mws-i-24 i-table-1" id="bt">入库日志</span>
        </div>
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <div class="mws-panel-body" id="divList" runat="server">
            <table class="mws-table">
                <thead>
                    <tr>
                        <%--<th class="auto-style1">规格名称</th>--%>
                        <th class="auto-style1">商品编号</th>
                        <th class="auto-style1">商品名称</th>
                        <th class="auto-style1">条形码</th>
                        <th class="auto-style1">入库数量</th>
                        <th class="auto-style1">操作人</th>
                        <th class="auto-style1">操作时间</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt" runat="server">
                        <ItemTemplate>
                            <tr class="gradeX">
                                <%--<td><%# DataBinder.Eval(Container.DataItem,"SpecName")%></td>--%>
                                <td><%# DataBinder.Eval(Container.DataItem,"DisplayID")%></td>
                                <td><%# DataBinder.Eval(Container.DataItem,"ProductName")%></td>
                                <td><%# DataBinder.Eval(Container.DataItem,"BarCode")%></td>
                                <td><%# DataBinder.Eval(Container.DataItem,"StockInCount")%></td>
                                <td><%# DataBinder.Eval(Container.DataItem,"UserName")%></td>
                                <td><%# DataBinder.Eval(Container.DataItem,"Created","{0:yyyy-MM-dd HH:mm:ss}")%></td>
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
</asp:Content>
