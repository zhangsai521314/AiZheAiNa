//张赛，2016.9.5
//获取所有请求的数据的url
(function () {
    var UrlJson = function () {

    };

    //请求
    UrlJson.prototype.GetJsonPage = function (type, dataType, url, dataJson) {
        var that = this;
        var s = 0;
        $.ajax({
            async: false,
            url: url,
            type: type,
            dataType: dataType,
            data: dataJson,
            success: function (data) {
                s = data;
                laypage({
                    cont: "page", //容器。
                    pages: 10, //通过后台拿到的总页数  
                    curr: dataJson.pageIndex, //初始化当前页  
                    skin: '#FF4B4B', //皮肤颜色
                    groups: 4, //连续显示分页数  
                    skip: true, //是否开启跳页  
                    first: '首页', //若不显示，设置false即可  
                    last: '尾页', //若不显示，设置false即可  
                    jump: function (e, firlst) { //触发分页后的回
                        if (!firlst) {
                            dataJson.pageIndex = e.curr;
                            s = that.GetJsonPage(type, dataType, url, dataJson);
                            if (typeof (callBack) == "function") {
                                callBack(s);
                            }
                        }
                    }
                });
                return data;
            },
            error: function () {
                return 0;
            }
        });
        return s;
    };

    //jsonp方式请求数据并分页
    UrlJson.prototype.GetJsonPageJsonp = function (type, jsonp, url, dataJson) {
        var that = this;
        var s = 0;
        $.ajax({
            async: false,
            url: url,
            type: type,
            dataType: "jsonp",
            data: dataJson,
            jsonp: jsonp,
            success: function (data) {
                s = data;
                laypage({
                    cont: "page", //容器。
                    pages: 10, //通过后台拿到的总页数  
                    curr: dataJson.pageIndex, //初始化当前页  
                    skin: '#FF4B4B', //皮肤颜色
                    groups: 4, //连续显示分页数  
                    skip: true, //是否开启跳页  
                    first: '首页', //若不显示，设置false即可  
                    last: '尾页', //若不显示，设置false即可  
                    jump: function (e, firlst) { //触发分页后的回
                        if (!firlst) {
                            dataJson.pageIndex = e.curr;
                            s = that.GetJsonPage(type, dataType, url, dataJson);
                            if (typeof (callBack) == "function") {
                                callBack(s);
                            }
                        }
                    }
                });
                return data;
            },
            error: function () {
                return 0;
            }
        });
        return s;
    };

    UrlJson.prototype.getMyPath = function (name) {
        var kuZhanMing = name.split(".")[name.split(".").length - 1];
        if (kuZhanMing == "js") {
            scriptArr = document.getElementsByTagName('script');
        } else if (kuZhanMing == "css") {
            scriptArr = document.getElementsByTagName('link');
        } else {
            return "";
        }
        for (var i = 0; i < scriptArr.length; i++) {
            if (kuZhanMing == "js") {
                if (scriptArr[i].src.split("/")[scriptArr[i].src.split('/').length - 1] == name) {
                    return scriptArr[i].src;
                    break;
                }
            } else {
                if (scriptArr[i].href.split("/")[scriptArr[i].href.split('/').length - 1] == name) {
                    return scriptArr[i].href;
                    break;
                }
            }
        }
        return "";
    }

    this.UrlJson = UrlJson;

}).call(this);