<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pagnation.ascx.cs" Inherits="CL.Web.Background.Pagnation" %>
<div>
    <input type="hidden" ID="hdCurrentPageIndex" Name="hdCurrentPageIndex" runat="server" />
    <input type="hidden" ID="hdTotalCount" Name="hdTotalCount" runat="server" />
    <asp:Button ID="btnFirstPage" Name="btnFirstPage" runat="server" Text="首页" OnClick="btnFirstPage_Click" />
    <asp:Button ID="btnPreviousPage" Name="btnPreviousPage" runat="server" Text="上一页" OnClick="btnPreviousPage_Click" />
    <asp:Button ID="btnNextPage" Name="btnNextPage" runat="server" Text="下一页" OnClick="btnNextPage_Click" />
    <asp:Button ID="btnLastPage" Name="btnLastPage" runat="server" Text="尾页" OnClick="btnLastPage_Click" Style="height: 21px" />
</div>
