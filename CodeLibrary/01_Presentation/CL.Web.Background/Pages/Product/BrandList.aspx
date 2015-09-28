<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrandList.aspx.cs" Inherits="CL.Web.Background.Pages.Product.BrandList" %>

<%@ Register Src="~/Controls/Pagnation.ascx" TagPrefix="uc1" TagName="Pagnation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="mws-panel grid_8">
        <div class="mws-panel-header">
            <span class="mws-i-24 i-table-1">查询条件</span>
        </div>

        <div class="mws-panel-body mws-form">
            <div class="mws-form-row">
                品牌名称：<asp:TextBox ID="txtBrandName" runat="server" CssClass="mws-textinput"></asp:TextBox>
                是否上架：<asp:DropDownList ID="ddlShowStatus" runat="server" CssClass="mws-textinput"></asp:DropDownList>
                来源：<asp:DropDownList ID="ddlDataSource" runat="server" name="selectBox" CssClass="mws-textinput">
                </asp:DropDownList>
                &nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="mws-button green" OnClick="btnQuery_Click" />
            </div>
        </div>

        <div class="mws-panel-header">
            <span class="mws-i-24 i-table-1">品牌管理</span>
        </div>
        <div class="mws-panel-toolbar top clearfix">
            <ul>
                <li><a href="BrandEdit.aspx" class="mws-ic-16 ic-accept">添加</a></li>
            </ul>
        </div>
        <asp:Label ID="lblMsg" runat="server"></asp:Label>

        <div class="mws-panel-body" id="divList" runat="server">
            <table class="mws-table">
                <thead>
                    <tr>
                        <th>品牌名称</th>
                        <th>状态</th>
                        <th>排序</th>
                        <th>来源</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt" runat="server" OnItemCommand="rpt_ItemCommand">
                        <ItemTemplate>
                            <tr class="gradeX">
                                <td><%#Eval("BrandName") %></td>
                                <td>
                                    <%#Eval("ShowStatusDesc") %>
                                </td>
                                <td><%#Eval("OrderIndex") %></td>
                                <td><%#Eval("DataSourceDesc") %></td>
                                <td>
                                    <a href="BrandEdit.aspx?id=<%#Eval("ID") %>">修改</a>
                                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('您确认要删除吗？')">删除</asp:LinkButton>
                                </td>
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
