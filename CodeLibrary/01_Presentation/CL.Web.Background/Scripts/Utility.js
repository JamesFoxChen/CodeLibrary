window.Utility = window.Utility || {};
window.Utility.Controls = window.Utility.Controls || {};
(function (ns) {
    // 函数名称： registerNameSpace
    // 函数功能： 注册命名空间
    // 函数参数： nameSpace    命名空间: a.b.c
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-02-22 21:01:54
    ns.registerNameSpace = function (nameSpace) {
        var arrNameSpace;
        var ns;

        if (!nameSpace) {
            return window;
        }
        arrNameSpace = nameSpace.split(".");
        ns = window;
        for (var i = 0; i < arrNameSpace.length; i++) {
            if (i == 0 && arrNameSpace[i] == "window") {
                continue;
            }

            ns[arrNameSpace[i]] = ns[arrNameSpace[i]] || {};
            ns = ns[arrNameSpace[i]];
        }
        return ns;
    }
    // 函数名称： processAjax
    // 函数功能： JQuery Ajax操作
    // 函数参数： optionData.url: ajax请求地址; optionData.getData: 用户数据(Json); optionData.postData: 用户数据(Json)
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-02-22 21:01:54
    ns.processAjax = function (optionData) {
        var url, ret;
        var startIndex, endIndex;
        var jReturn;

        if (!optionData.url) {
            return { "Status": "ERROR", "Message": "optionData.url参数未设置!", Value: null }
        }
        if (optionData.getData && typeof (optionData.getData) != "object") {
            return { "Status": "ERROR", "Message": "optionData.getData类型不匹配或参数未设置!", Value: null }
        }
        if (optionData.postData && typeof (optionData.postData) != "object") {
            return { "Status": "ERROR", "Message": "optionData.postData类型不匹配或参数未设置!", Value: null }
        }

        if (!optionData.getData) {
            url = optionData.url;
        } else {
            url = optionData.url + (optionData.url.indexOf("?") > -1 ? "&" : "?") + $.param(optionData.getData);
        }

        $.ajax({
            url: url,
            type: "post",
            async: (optionData.async === false ? false : true),
            dataType: "text",
            data: optionData.postData,
            success: function (data) {
                handlerAjaxResult(data, optionData.callBack);
            },
            error: function (data) {
                handlerAjaxResult(data.responseText, optionData.callBack);
            }
        });

        return ret;
    }


    ns.NativeAjax= function (optionData) {
        var url, ret;
        var startIndex, endIndex;
        var jReturn;

        if (!optionData.url) {
            return { "Status": "ERROR", "Message": "optionData.url参数未设置!", Value: null }
        }
        if (optionData.getData && typeof (optionData.getData) != "object") {
            return { "Status": "ERROR", "Message": "optionData.getData类型不匹配或参数未设置!", Value: null }
        }
        if (optionData.postData && typeof (optionData.postData) != "object") {
            return { "Status": "ERROR", "Message": "optionData.postData类型不匹配或参数未设置!", Value: null }
        }

        if (!optionData.getData) {
            url = optionData.url;
        } else {
            url = optionData.url + (optionData.url.indexOf("?") > -1 ? "&" : "?") + $.param(optionData.getData);
        }

        $.ajax({
            url: url,
            type: "post",
            async: (optionData.async === false ? false : true),
            dataType: "text",
            data: optionData.postData,
            success: function (data) {
                handlerAjaxResult(data, optionData.callBack);
            },
            error: function (data) {
                handlerAjaxResult(data.responseText, optionData.callBack);
            }
        });

        return ret;
    }

    function handlerAjaxResult(data, callBack) {
        try {
            jReturn = eval("(" + data + ")");
        } catch (ex) {
            startIndex = data.indexOf("<title>");
            if (startIndex > 0) {
                endIndex = data.indexOf("</title>");
                jReturn = { Status: "ERROR", Message: data.substring(startIndex + 7, endIndex), Value: null };
            } else if (!data) {
                jReturn = { Status: "ERROR", Message: "请求返回数据为空！", Value: null };
            } else {
                jReturn = { Status: "ERROR", Message: "返回Json数据失败！", Value: data };
            }
        }
        if (callBack && typeof callBack === "function") {
            ret = callBack(jReturn);
        } else {
            ret = jReturn;
        }
    }

    // 函数名称： format
    // 函数功能： 用日期格式化(yyyy-MM-dd HH:mm:ss)
    // 函数参数： 无
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    Date.prototype.format = function (format) {
        var o = {
            "M+": this.getMonth() + 1,
            "d+": this.getDate(),
            "H+": this.getHours(),
            "h+": this.getHours() - 12,
            "m+": this.getMinutes(),
            "s+": this.getSeconds(),
            "q+": Math.floor((this.getMonth() + 3) / 3),
            "S": this.getMilliseconds()
        }

        if (/(y+)/.test(format)) {
            format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        }

        for (var k in o) {
            if (new RegExp("(" + k + ")").test(format)) {
                format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
            }
        }
        return format;
    }

    // 函数名称： toDate
    // 函数功能： 字符串转日期对象
    // 函数参数： format: 格式化参数
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    String.prototype.toDate = function (format) {
        var t = ['y+', 'M+', 'd+', 'H+', 'h+', 'm+', 's+', 'S'];
        var v = [];

        for (var k in t) {
            var temp = new RegExp("(" + t[k] + ")", 'g');
            temp.test(format);
            var index = temp.lastIndex;
            if (index == 0) {
                v[k] = 0;
                continue;
            }
            var length = format.match(temp)[0].length;
            index -= length;
            v[k] = parseInt(this.substr(index, length));
        }
        v[1]--;
        v[4] += 12;
        return new Date(v[0], v[1], v[2], v[3] || v[4], v[5], v[6]);
    }

    // 函数名称： addYear
    // 函数功能： 年份加减(负值表示减)
    // 函数参数： 无
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    Date.prototype.addYear = function (value) {
        this.setFullYear(this.getFullYear() + value);
    }
    // 函数名称： addMonth
    // 函数功能： 月份加减
    // 函数参数： 无
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    Date.prototype.addMonth = function (value) {
        this.setMonth(this.getMonth() + value);
    }
    // 函数名称： addDay
    // 函数功能： 天数加减
    // 函数参数： 无
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    Date.prototype.addDay = function (value) {
        this.setDay(this.getDay() + value);
    }
    // 函数名称： addHours
    // 函数功能： 小时加减
    // 函数参数： 无
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    Date.prototype.addHours = function (value) {
        this.setHours(this.getHours() + value);
    }
    // 函数名称： addMinutes
    // 函数功能： 分钟加减
    // 函数参数： 无
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    Date.prototype.addMinutes = function (value) {
        this.setMinutes(this.getMinutes() + value);
    }
    // 函数名称： addSeconds
    // 函数功能： 秒加减
    // 函数参数： 无
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    Date.prototype.addSeconds = function (value) {
        this.setSeconds(this.getSeconds() + value);
    }

    // 函数名称： plus
    // 函数功能： 数字相加
    // 函数参数： num: 操作数, prec: 保留精度
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    Number.prototype.plus = function (num, prec) {
        var p = Math.max(this.getPrecision(), parseFloat(num).getPrecision());
        var m = Math.pow(10, p);
        return Math.round((this * m + num * m) / Math.pow(10, p - prec)) / Math.pow(10, prec);
    }

    // 函数名称： minus
    // 函数功能： 数字相减
    // 函数参数： num: 操作数, prec: 保留精度
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    Number.prototype.minus = function (num, prec) {
        var p = Math.max(this.getPrecision(), parseFloat(num).getPrecision());
        var m = Math.pow(10, p);
        return Math.round((this * m - num * m) / Math.pow(10, p - prec)) / Math.pow(10, prec);
    }

    // 函数名称： multiple
    // 函数功能： 数字相乘
    // 函数参数： num: 操作数, prec: 保留精度
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    Number.prototype.multiple = function (num, prec) {
        var m1 = this.getPrecision();
        var m2 = parseFloat(num).getPrecision();
        return Math.round(((this * Math.pow(10, m1)) * (num * Math.pow(10, m2))) / Math.pow(10, m1 + m2 - prec)) / Math.pow(10, prec);
    }

    // 函数名称： divide
    // 函数功能： 数字相除
    // 函数参数： num: 操作数, prec: 保留精度
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    Number.prototype.divide = function (num, prec) {
        var p = Math.max(this.getPrecision(), parseFloat(num).getPrecision());
        var m = Math.pow(10, p);
        return Math.round(((this * m) / (num * m)) * Math.pow(10, prec)) / Math.pow(10, prec);
    }

    // 函数名称： getPrecision
    // 函数功能： 获取数字的精度
    // 函数参数： 无
    // 返 回 值： 无
    // 创 建 人： 
    // 创建日期： 2014-05-11 11:57:24
    Number.prototype.getPrecision = function () {
        var s = this.toString();
        var p = s.indexOf(".");
        return p == -1 ? 0 : (s.length - p - 1);
    }
})(window.Utility);

/// 系统常量
window.Constant = {
    AjaxStatus: { OK: "OK", NO: "NO", ERROR: "ERROR" },
    EmptyGuid: "00000000-0000-0000-0000-000000000000"
}