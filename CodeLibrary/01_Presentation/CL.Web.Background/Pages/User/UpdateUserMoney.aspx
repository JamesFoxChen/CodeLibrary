<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateUserMoney.aspx.cs" Inherits="CL.Web.Background.Pages.User.UpdateUserMoney" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mws-panel-header">
        <span>会员金额</span>
    </div>
    <div class="mws-panel-body">
        <div class="mws-panel-content">

            <div class="mws-form">
                <input type="hidden" id="BID" value="" runat="server" />
                <div class="mws-form-inline">
                    <div class="mws-form-row">
                        <label>会员名称<span class="RedStar">*</span></label>
                        <div class="mws-form-item large">
                            <asp:Label ID="lblUserName" runat="server"></asp:Label>
                        </div>
                    </div>

                    <div class="mws-form-row">
                        <label>可用金额<span class="RedStar">*</span></label>
                        <div class="mws-form-item large">
                            <asp:Label ID="lblUserMoney" runat="server"></asp:Label>
                        </div>
                    </div>

                    <div class="mws-form-row">
                        <label>修改金额<span class="RedStar">*</span></label>
                        <div class="mws-form-item large">
                            <asp:TextBox ID="txtValue" runat="server" class="mws-textinput required digits" Text="0"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="mws-button-row">
                    <asp:Button ID="btnOK" class="button" runat="server" CssClass="mws-button red" OnClick="btnOK_Click" Text="提交信息" />
                    <input type="button" onclick="location.href = 'UserMoneyInfo.aspx'" class="mws-button blue" value="返回" />
                </div>
            </div>

        </div>

    </div>
</asp:Content>
