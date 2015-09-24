<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="CL.Web.Background.Top" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

<!-- 所需的样式 -->

<link rel="stylesheet" type="text/css" href="Styles/mws.style.css" media="screen" />
<link rel="stylesheet" type="text/css" href="Styles/icons/icons.css" media="screen" />

<!-- 主题的样式表 -->
<link rel="stylesheet" type="text/css" href="Styles/mws.theme.css" media="screen" />

<!-- JavaScript 插件 -->

</head>
<body>
   <form runat="server">

<!-- Header Wrapper -->
	<div id="mws-header" class="clearfix">
   
    	<div id="mws-logo-container">
        	<div id="mws-logo-wrap">
            	<img src="/Images/logo.jpg" alt="mws admin" />
			</div>
        </div>
       
        <div id="mws-user-tools" class="clearfix">
            <div id="mws-user-info" class="mws-inset">
                <div id="mws-user-functions">
                    <div id="mws-username">
                        你好, <asp:Label ID="lblUserName" runat="server" Text="Fox"></asp:Label>
                    </div>
                    <ul>
                    	<!--<li><a href="#">查看信息</a></li>-->
                        <li><a href="#"  target="myframe">修改密码</a></li>
                        <li><asp:LinkButton ID="lbtnLoginout" runat="server" >退出</asp:LinkButton></li>
                    </ul>
                </div>
            </div>
            <!-- End User Functions -->
        </div>
    </div>
    </form>
</body>
</html>
