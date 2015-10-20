<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MPollImageList.aspx.cs" Inherits="CL.Web.Background.Pages.Display.MPollImageList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="mws-panel grid_8">
        <div class="mws-panel-header">
            <span class="mws-i-24 i-table-1" id="bt">微信活动图</span>
        </div>
        <div class="mws-panel-body">
            <div class="mws-panel-toolbar top clearfix">
                <ul>
                    <li><a href="MPollImageEdit.aspx" class="mws-ic-16 ic-accept">添加</a></li>
                </ul>
            </div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <div class="mws-panel-body" id="divList" runat="server">
            <table class="mws-table">
                <thead>
                    <tr>
                        <th>类型名称</th>
                        <th>图片链接</th>
                        <th>显示序号</th>
                        <th>图片</th>
                        <th>创建时间</th>
                        <th>修改时间</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt" runat="server" OnItemCommand="rpt_ItemCommand">
                        <ItemTemplate>
                            <tr class="gradeX">
                                <td><%#Eval("BizIDDesc") %></td>
                                <td><%#Eval("ImageLink") %></td>
                                <td><%#Eval("OrderIndex") %></td>
                                <td>
                                    <asp:Image ID="img" runat="server"  ImageUrl='<%#Eval("ImageUrl") %>' /></td>
                                <td><%#Eval("Created") %></td>
                                <td><%#Eval("Updated") %></td>
                                <td>
                                    <a href="MPollImageEdit.aspx?ID=<%#Eval("ID")%>">修改</a>
                                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="IsDelete" CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('确定删除吗？')">删除</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
