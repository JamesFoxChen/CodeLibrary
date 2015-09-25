<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerateEntity.aspx.cs" Inherits="CL.Web.Background.Pages.Other.GenerateEntity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    数据库：<asp:DropDownList ID="ddlDBTables" runat="server"></asp:DropDownList>&nbsp;<asp:Button ID="btnGenerateModel" runat="server" Text="生成实体类" OnClick="btnGenerateModel_Click" />
    <br />
    <asp:TextBox ID="txtCode" runat="server" Height="610px" TextMode="MultiLine" Width="1074px" ></asp:TextBox>
</asp:Content>
