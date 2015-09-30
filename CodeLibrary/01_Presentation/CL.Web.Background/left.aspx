<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="CL.Web.Background.Left" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>


    <!-- 所需的样式 -->
    <link rel="stylesheet" type="text/css" href="/Styles/reset.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/Styles/text.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/Styles/fonts/ptsans/stylesheet.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/Styles/fluid.css" media="screen" />

    <link rel="stylesheet" type="text/css" href="/Styles/mws.style.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/Styles/icons/icons.css" media="screen" />

    <!-- 插件的演示程序和样式表 -->
    <link rel="stylesheet" type="text/css" href="/Styles/demo.css" media="screen" />

    <link rel="stylesheet" type="text/css" href="/Plugins/colorpicker/colorpicker.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/Plugins/jimgareaselect/css/imgareaselect-default.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/Plugins/fullcalendar/fullcalendar.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/Plugins/fullcalendar/fullcalendar.print.css" media="print" />
    <link rel="stylesheet" type="text/css" href="/Plugins/tipsy/tipsy.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/Plugins/sourcerer/Sourcerer-1.2.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/Plugins/jgrowl/jquery.jgrowl.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/Plugins/spinner/spinner.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/Styles/jui/jquery.ui.css" media="screen" />

    <!-- 主题的样式表 -->
    <link rel="stylesheet" type="text/css" href="/Styles/mws.theme.css" media="screen" />

    <!-- JavaScript 插件 -->

    <script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="/Plugins/jimgareaselect/jquery.imgareaselect.min.js"></script>
    <script type="text/javascript" src="/Plugins/jquery.dualListBox-1.3.min.js"></script>
    <script type="text/javascript" src="/Plugins/jgrowl/jquery.jgrowl.js"></script>
    <script type="text/javascript" src="/Plugins/jquery.filestyle.js"></script>
    <script type="text/javascript" src="/Plugins/fullcalendar/fullcalendar.min.js"></script>
    <script type="text/javascript" src="/Plugins/jquery.dataTables.js"></script>

    <script type="text/javascript" src="/Plugins/colorpicker/colorpicker.js"></script>
    <script type="text/javascript" src="/Plugins/tipsy/jquery.tipsy.js"></script>
    <script type="text/javascript" src="/Plugins/sourcerer/Sourcerer-1.2.js"></script>
    <script type="text/javascript" src="/Plugins/jquery.placeholder.js"></script>
    <script type="text/javascript" src="/Plugins/jquery.validate.js"></script>
    <script type="text/javascript" src="/Plugins/jquery.mousewheel.js"></script>
    <script type="text/javascript" src="/Plugins/spinner/ui.spinner.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-ui.js"></script>

    <script type="text/javascript" src="/Scripts/mws.js"></script>
    <script type="text/javascript" src="/Scripts/demo.js"></script>
    <script type="text/javascript" src="/Scripts/themer.js"></script>

    <style>
        .active {
            background-color: #666;
        }

        div#mws-navigation ul li ul li:hover {
            background-color: #666;
        }
    </style>
</head>
<body>
    <!-- Necessary markup, do not remove -->

    <div id="mws-sidebar-bg"></div>

    <!-- Sidebar Wrapper -->
    <div id="mws-sidebar">

        <!-- Main Navigation -->
        <div id="mws-navigation">
            <ul id="menu">
                <li>
                    <a href="#" class="mws-i-24 i-blocks-images firstMenu">用户管理</a>
                    <%-- <ul <%= i > 0 ? "class='closed' style='display: none;'" : string.Empty %>>--%>
                    <ul>
                        <li><a href="/Pages/User/UserList.aspx" target="myframe">用户信息</a></li>
                    </ul>
                </li>
                <li>
                    <a href="#" class="mws-i-24 i-blocks-images firstMenu">商品管理</a>
                    <ul>
                        <li><a href="/Pages/Product/BrandList.aspx" target="myframe">品牌信息</a></li>
                        <li><a href="/Pages/Product/ProductList.aspx" target="myframe">商品信息</a></li>
                    </ul>
                </li>
                <li>
                    <a href="#" class="mws-i-24 i-blocks-images firstMenu">订单管理</a>
                    <ul>
                        <li><a href="/Pages/Order/OrderList.aspx" target="myframe">订单信息</a></li>
                    </ul>
                </li>
                <li>
                    <a href="#" class="mws-i-24 i-blocks-images firstMenu">进销存</a>
                    <ul>
                        <li><a href="/Pages/Invoicing/StockIn.aspx" target="myframe">入库操作</a></li>
                        <li><a href="/Pages/Invoicing/StockInLog.aspx" target="myframe">入库流水</a></li>
                    </ul>
                </li>
                <li>
                    <a href="#" class="mws-i-24 i-blocks-images firstMenu">其它</a>
                    <ul>
                        <li><a href="/Pages/Other/SwitchDataBase.aspx" target="myframe">切换数据库</a></li>
                        <li><a href="/Pages/Other/GenerateEntity.aspx" target="myframe">生成实体类</a></li>
                    </ul>
                </li>
            </ul>
        </div>
        <!-- End Navigation -->

    </div>

    <script type="text/javascript">
        $('#menu > li > ul > li').click(function () {
            $('#menu > li > ul > li').removeClass('active');
            $(this).addClass('active');
        });
        $("a.firstMenu").click(function () {
            $(this).closest("li").siblings().find("ul").attr("class", "closed").slideUp("fast");
        });
    </script>
</body>
</html>
