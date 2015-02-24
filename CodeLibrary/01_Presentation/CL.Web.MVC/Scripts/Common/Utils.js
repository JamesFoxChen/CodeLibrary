var Utils =
{
    //字符串格式化
    StringFormat: function () {
        if (arguments.length == 0)  //格式化参数不是固定的
            return null;
        var str = arguments[0];
        for (var i = 1; i < arguments.length; i++) {
            var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
            str = str.replace(re, arguments[i]);
        }
        return str;
    },

    // val为经json直接序列化后的C#的DateTime类型的数据
    FormatTime: function (val) {
        var re = /-?\d+/;
        var m = re.exec(val);
        var d = new Date(parseInt(m[0]));
        // 按【2014-01-11 19:09:11】的格式返回日期
        return d.Format("yyyy-MM-dd hh:mm:ss");
    },

    //配置jqGrid表格根据页面宽度动态适配，两个参数分别为表格id与表格所在父容器的id，通过动态匹配父容器宽度来实现
    //第三个参数为宽度偏移值，为了适配不同的页面
    SetGridWidthDynamic: function (tableId, parentContainerId, offsetValue) {
        if ($.browser.msie && parseInt($.browser.version, 10) < 8) {
            return;
        }

        $(window).resize(function () {
            Utils.SetGridWidth(tableId, parentContainerId, offsetValue);
        });
    },

    //手动触发表格的宽度自适应
    SetGridWidth: function (tableId, parentContainerId, offsetValue) {
        var grid = $(tableId);
        if (grid && grid.length == 1) {
            var parentWidth = $(parentContainerId).width();
            if (parentWidth > 1680) {  //避免出现不断拉宽的问题
                return;
            }
            var gridWidth = grid.width();

            if (parentWidth > 0 && Math.abs(parentWidth - gridWidth) > 10) {
                grid.setGridWidth(parentWidth - offsetValue);
            }
        }
    },

    ChangeGridTrCss: function (tableId, rowId, className) {
        if (tableId && rowId && className) {
            var $tr = $(tableId + ">tbody").find("tr[id='" + rowId + "']");
            $tr.removeClass("ui-widget-content");
            $tr.addClass(className);
        }
    },

    // 复制对像
    Clone: function (myObj) {
        if (typeof (myObj) != 'object') { return myObj; }
        if (myObj == null) { return myObj; }

        var myNewObj = new Object();

        for (var i in myObj) {
            myNewObj[i] = this.Clone(myObj[i]);
        }

        return myNewObj;
    },

    //日志打印
    Log: function (msg) {
        if (typeof console != undefined) {
            var str = Utils.StringFormat("【{0}】{1}", (new Date()).Format("yyyy-MM-dd hh:mm:ss"), msg);
            console.log(str);
        }
    },

    HtmlEncode: function (str) {
        var s = "";
        if (str.length == 0)
            return "";
        s = str.replace(/&/g, "&amp;");
        s = s.replace(/</g, "&lt;");
        s = s.replace(/>/g, "&gt;");
        s = s.replace(/ /g, "&nbsp;");
        s = s.replace(/\'/g, "&#39;");
        s = s.replace(/\"/g, "&quot;");
        return s;
    },

    HtmlDecode: function (str) {
        var s = "";
        if (str.length == 0)
            return "";
        s = str.replace(/&amp;/g, "&");
        s = s.replace(/&lt;/g, "<");
        s = s.replace(/&gt;/g, ">");
        s = s.replace(/&nbsp;/g, " ");
        s = s.replace(/&#39;/g, "\'");
        s = s.replace(/&quot;/g, "\"");
        return s;
    },

    // 显示弹出框
    ShowDialog: function (bottonId, dialogId, leftPx, topPx, OnBodyDown) {
        var cityObj = $(bottonId);
        var cityOffset = $(bottonId).offset();
        $(dialogId).css({ left: cityOffset.left - leftPx + "px", top: cityOffset.top + cityObj.outerHeight() - topPx + "px" }).show();
        if (OnBodyDown) {
            $("body").bind("mousedown", OnBodyDown);
        }
    },

    // 导出文件(url对应到一个具体的Action，Action中通过HttpContext.Write下载文件
    DownloadFile: function (url) {
        if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE 7.0") > 0) {
            location.href = url;
        }
        else {
            var frame = $("#__DownloadFrame");
            if (frame.length == 0) {
                frame = $("<iframe id='__DownloadFrame' style='display:none'>");
                $("body").append(frame);
            }
            frame.attr("src", url);
        }
    },

    // str:源中英文字符串 len:要截取的长度
    SubString: function (str, len) {
        var newLength = 0;
        var newStr = "";
        var chineseRegex = /[^\x00-\xff]/g;
        var singleChar = "";
        var strLength = str.replace(chineseRegex, "**").length;
        for (var i = 0; i < strLength; i++) {
            singleChar = str.charAt(i).toString();
            if (singleChar.match(chineseRegex) != null) {
                newLength += 2;
            }
            else {
                newLength++;
            }
            if (newLength > len) {
                break;
            }
            newStr += singleChar;
        }

        if (strLength > len) {
            newStr += "...";
        }
        return newStr;
    },

    IsValue: function (d) {
        return (IsObject(d) || IsString(d) || IsNumber(d) || IsBoolean(d))
    },

    IsBoolean: function (d) {
        return typeof d === "boolean"
    },

    IsArray: function (d) {
        return d &&
            typeof d === 'object' &&
            value.constructor === Array;
    },

    IsNull: function (d) {
        return d === null
    },

    IsNumber: function (d) {
        return typeof d === "number" && isFinite(d)
    },

    IsString: function (d) {
        return typeof d === "string"
    },

    IsEmpty: function (d) {
        if (!IsString(d) && IsValue(d)) {
            return false
        } else {
            if (!IsValue(d)) {
                return true
            }
        }
        d = c.trim(d).replace(/\ \;/ig, "").replace(/\ \;/ig, "");
        return d === ""
    },

    IsUndefined: function (d) {
        return typeof d === "undefined"
    },

    IsObject: function (d) {
        return (d && (typeof d === "object" || IsFunction(d))) || false
    },

    IsFunction: function (d) {
        return typeof d === "function"
    },

    IsArray: function (d) {
        if (d.constructor.toString().indexOf("Array") == -1) {
            return false;
        } else {
            return true;
        }
    },

    GetRandomId: function () {    //得到随机ID
        var rad = "";
        for (var i = 0; i < 12; i++) {
            rad += Math.floor(Math.random() * 10);
        }
        return rad;
    },

    GetIeVersion: function () {//得到IE版本
        if (d.browser.msie) {
            var ieVersion = 8;
            ieVersion = 8;
            if (d.browser.version < 8) {
                ieVersion = 7;
                if (d.browser.version < 7) {
                    ieVersion = 6;
                }
            }
        } else {
            ieVersion = -1;
        }
        return ieVersion;
    }
}