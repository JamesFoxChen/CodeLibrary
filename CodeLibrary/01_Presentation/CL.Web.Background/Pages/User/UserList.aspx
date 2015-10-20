<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="CL.Web.Background.Pages.User.UserList" %>

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
                手机号：<asp:TextBox ID="txtMobile" runat="server" CssClass="mws-textinput"></asp:TextBox>
                真实姓名：<asp:TextBox ID="txtTrueName" runat="server" CssClass="mws-textinput"></asp:TextBox>
                支付方式：<asp:DropDownList ID="ddlAccountStatus" runat="server" name="selectBox" CssClass="mws-textinput">
                </asp:DropDownList>
                用户类型：<asp:DropDownList ID="ddlUserType" runat="server" name="selectBox" CssClass="mws-textinput">
                </asp:DropDownList>
                来源：<asp:DropDownList ID="ddlDataSource" runat="server" name="selectBox" CssClass="mws-textinput">
                </asp:DropDownList>
                注册开始时间：<asp:TextBox ID="txtDateStart" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd',autoPickDate:true})"></asp:TextBox>
                注册结束时间：<asp:TextBox ID="txtDateEnd" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd',autoPickDate:true})"></asp:TextBox>
                &nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="mws-button green" OnClick="btnQuery_Click" />
                &nbsp;<asp:Button ID="btnExport" runat="server" Text="导出" CssClass="mws-button green" OnClick="btnExport_Click"  />
            </div>
        </div>

        <div class="mws-panel-header">
            <span class="mws-i-24 i-table-1" id="bt">用户列表</span>
        </div>
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <div class="mws-panel-body" id="divList" runat="server">
            <table class="mws-table">
                <thead>
                    <tr>
                        <%--<th>编号</th>--%>
                        <th>会员名</th>
                        <th>真实姓名</th>
                        <th>用户类型</th>
                        <th>地址</th>
                        <th>手机号</th>
                        <th>注册时间</th>
                        <th>更新时间</th>
                        <th>状态</th>
                        <th>来源</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt" runat="server" OnItemCommand="rpt_ItemCommand">
                        <ItemTemplate>
                            <tr class="gradeX">
                                <%--<td><%#Eval("ID") %></td>--%>
                                <td><a href="UserLevels.aspx?ID=<%#Eval("ID") %>"><%#Eval("UserName") %></a></td>
                                <td><%#Eval("TrueName") %></td>
                                <td><%#Eval("UserTypeDesc") %></td>
                                <td><%#Eval("Addr") %></td>
                                <td><%#Eval("Mobile") %></td>
                                <td><%# Eval("Created","{0:yyyy-MM-dd HH:mm:ss}") %></td>
                                <td><%# Eval("Updated","{0:yyyy-MM-dd HH:mm:ss}") %></td>
                                <td><%#Eval("AccountStatusDesc") %></td>
                                <td><%#Eval("DataSourceDesc") %></td>
                                <td>
                                    <asp:LinkButton ID="lbtn" CommandName="UpdateAccountStatus" OnClientClick="return confirm('您是否确认操作?');" CommandArgument='<%#Eval("ID") %>' runat="server">
                                    <%# Eval("AccountStatus").ToString()=="1"?"冻结":"解冻" %></asp:LinkButton>
                                    <a href="UpdateUserMoney.aspx?ID=<%#Eval("ID")%>">可用金额修改</a>
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

