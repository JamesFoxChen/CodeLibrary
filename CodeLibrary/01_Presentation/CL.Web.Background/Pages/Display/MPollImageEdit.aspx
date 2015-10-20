<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MPollImageEdit.aspx.cs" Inherits="CL.Web.Background.Pages.Display.MPollImageEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mws-panel grid_8">
        <div class="mws-panel-header">
            <span>微信活动图片管理</span>
        </div>
        <div class="mws-panel-body">
            <div class="mws-panel-content">

                <div class="mws-form">
                    <div class="mws-form-inline">
                        <input type="hidden" runat="server" id="ParentID" value="0" />
                        <div class="mws-form-row">
                            <label>业务类型<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:DropDownList ID="ddlBizID" runat="server" name="selectBox" CssClass="mws-textinput">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>展示图片<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:FileUpload ID="fileImageUrl" runat="server" CssClass="mws-textinput" />
                                <br />
                                <asp:Image ID="imgImageUrl" runat="server" />
                                <input type="hidden" runat="server" id="hiddenImageUrl" />
                            </div>
                        </div>
                            <div class="mws-form-row">
                            <label>序号<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <asp:DropDownList ID="ddlOrderIndex" runat="server" name="selectBox" CssClass="mws-textinput">
                                    <asp:ListItem Text="1" Value="1" Selected="True"></asp:ListItem> 
                                    <asp:ListItem Text="2" Value="2" ></asp:ListItem> 
                                    <asp:ListItem Text="3" Value="3" ></asp:ListItem> 
                                    <asp:ListItem Text="4" Value="4" ></asp:ListItem> 
                                    <asp:ListItem Text="5" Value="5" ></asp:ListItem> 
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label>图片链接<span class="RedStar">*</span></label>
                            <div class="mws-form-item large">
                                <input type="text" runat="server" id="txtImageLink" class="mws-textinput required" value="" />
                            </div>
                        </div>
                    </div>
                    <div class="mws-button-row">
                        <asp:Button ID="btnOK" class="button" runat="server" CssClass="mws-button red" OnClick="btnOK_Click" Text="提交信息" />
                        <input type="button" onclick="javaScript: history.go(-1);" class="mws-button blue" value="返回" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hdImageID" runat="server" />
    
    <script type="text/javascript">
        $(function () {
            $("#ContentPlaceHolder1_btnOK").click(function () {
                if ($.trim($("#ContentPlaceHolder1_txtImageLink").val()) == '') {
                    alert("图片链接不能为空 ");
                    return false;
                }
                return true;
            });
        });
    </script>
</asp:Content>
