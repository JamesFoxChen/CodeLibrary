<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserMoneyInfo.aspx.cs" Inherits="CL.Web.Background.Pages.User.UserMoneyInfo" %>

<%@ Register Src="/Controls/Pagnation.ascx" TagPrefix="uc1" TagName="Pagnation" %>
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
                会员名：<asp:TextBox ID="txtUserName" runat="server" CssClass="mws-textinput"></asp:TextBox>
                会员手机号：<asp:TextBox ID="txtMobile" runat="server" CssClass="mws-textinput"></asp:TextBox>
                &nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="mws-button green" OnClick="btnQuery_Click" />
            </div>
        </div>

        <div class="mws-panel-header">
            <span class="mws-i-24 i-table-1" id="bt">会员可用金额</span>
        </div>
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
        <div class="mws-panel-body" id="divList" runat="server" visible="false">
            会员名：<asp:Label ID="lblUserName" runat="server"></asp:Label><br />
            会员手机号：<asp:Label ID="lblMobile" runat="server"></asp:Label><br />
            总可用金额：<asp:Label ID="lblTotalValue" runat="server"></asp:Label><br />
            <br />
            <table class="mws-table">
                <thead>
                    <tr>
                        <th>会员名</th>
                        <th>金额</th>
                        <th>时间</th>
                        <th>备注</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt" runat="server">
                        <ItemTemplate>
                            <tr class="gradeX">
                                <td><%#Eval("UserName") %></td>
                                <td><%#Eval("Value") %></td>
                                <td><%#Eval("Created") %></td>
                                <td><%#Eval("Remark") %></td>
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
