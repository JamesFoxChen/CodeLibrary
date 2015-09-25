<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SwitchDataBase.aspx.cs" Inherits="CL.Web.Background.Pages.Other.SwitchDataBase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div>
        <asp:DropDownList ID="ddlDataBase" runat="server"></asp:DropDownList>
    </div>
     <div>
         <asp:Button ID="btnSwitch" runat="server" Text="切换数据库" OnClick="btnSwitch_Click" />
    </div>
    <div>
        <asp:TextBox ID="txtCode" runat="server" TextMode="MultiLine" Rows="5" Columns="100"> </asp:TextBox>
    </div>
</asp:Content>
