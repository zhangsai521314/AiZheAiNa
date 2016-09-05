//张赛，2016.9.5
//获取所有请求的数据的url
(function () {
    var UrlData = function () {

    };

    UrlData.prototype.GetUrl = function () {
        //临时数据形式
        var url = this.getMyPath("GetUrlData.js");
        url = url.substr(0, url.lastIndexOf("/js/")) + "/json/";
        var temp = {
            url1: url + "json1.json",
            url2: url + "json2.json",
            url3: url + "json3.json",
            url4: "4"
        };
        //正式
        var formal = {
            url1: "json/json1.json",
            url2: "2q",
            url3: "3q",
            url4: "4q"
        };
        return temp;
        //return formal;
    };
    //获取加载过文件(js,css)的路径
    UrlData.prototype.getMyPath = function (name) {
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

    this.UrlData = UrlData;

}).call(this);