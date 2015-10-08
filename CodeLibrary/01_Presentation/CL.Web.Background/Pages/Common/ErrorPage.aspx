<%@ Page Language="C#" AutoEventWireup="true" Inherits="CL.Web.Background.Pages.Common.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%: this.ex.Message %></title>
    <style type="text/css">
        body {
            margin: 0;
        }

        .main {
            margin-top: 50px;
            width: 100%;
            text-align: center;
        }
    </style>
</head>
<body>
    <div style="position: fixed; text-align: center; width: 100%; height: 100%; background-color: #ddd;">
        <img src="/images/500.png" style="width: 35%; margin-top: 30px;" />
        <p style="margin-top: 20px; font-size: 1.5em;">您被来自火星的Bug击中了...</p>
    </div>
</body>
</html>
