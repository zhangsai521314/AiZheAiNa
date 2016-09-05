//张赛图片轮播，2016.8.31
//本插件使用jQuery v2.1.4，为JQ增加一个ZSISNull方法，适合图片一张一张的轮播。无需引用css文件
//返回自动轮播的计时id
(function ($, window) {
    $.fn.ZSImgLunBo = function (options) {
        var op = $.extend({
            container: $(this),//生成内容的容器（保证原内容为空，否则清除）
            jsonData: "",//轮播的数据图片路径及点击图片的跳转地址。格式 {"data":[{"href":"","src":""},{"href":"","src":""},{"href":"","src":""}]}
            isLunShowBoAnNiu: true,//是否显示轮播按钮       
            isShowLunBoBiaoShi: true,//是否显示轮播标识       
            isOpenZiDongLunBo: true,//是否开启自动轮播
            ZiDongLunBoMiao: 2,//每多少秒切换图片
            LunBoFangShi: "",//轮播的方式（图片的载入方式），fade（缓慢出现），dantuzuoyi(单图左移)
        }, options);
        //数据为空则返回
        try {
            jsonData = JSON.parse(op.jsonData);
            if (jsonData.data.length <= 0) {
                return false;
            }
        } catch (e) {
            return false;
        }
        //加载css
        if (!isInclude("ZSImgLunBo.css")) {
            var oCss = document.createElement("link");
            oCss.setAttribute("rel", "stylesheet");
            oCss.setAttribute("type", "text/css");
            oCss.setAttribute("href", getRealPath() + "/Scripts/MyLunBo/ZSImgLunBo.css");
            document.getElementsByTagName("head")[0].appendChild(oCss);
        }
        op.ZiDongLunBoMiao = op.ZiDongLunBoMiao * 1000;
        //设置容器为相对定位
        op.container.css("position", "relative");
        //生成id
        var divZSLunBoImg = ShengChengID("divZSLunBoImg"), divZSLunBoAnNiuIndivLunBoImg = ShengChengID("divZSLunBoAnNiuIndivLunBoImg"), divZSLunBoBiaoShiIndivLunBoImg = ShengChengID("divZSLunBoBiaoShiIndivLunBoImg"), daTuZiDongLunBoID = 0, ZSlunBoAnNiuClickJiShu = 0;
        //带#号的id,选择器使用
        var xdivZSLunBoImg = "#" + divZSLunBoImg, xdivZSLunBoAnNiuIndivLunBoImg = "#" + divZSLunBoAnNiuIndivLunBoImg, xdivZSLunBoBiaoShiIndivLunBoImg = "#" + divZSLunBoBiaoShiIndivLunBoImg;
        //img容器加入到dom中
        op.container.append($("<div style='height:" + op.container.height() + "px;width:100%' class='divZSLunBoImg' id='" + divZSLunBoImg + "' miaoshu='滚动大图'><ul class='ZS-list-unstyled " + SwitchLiYangShi() + "'></ul></div>"));
        //图片数据加入到img容器中
        $.each(jsonData.data, function (index, item) {
            //加入图片数据
            if ($.ZSIsNull(item.href)) {
                item.href = "javascript:void(0)";
            }
            $(xdivZSLunBoImg + " ul:first").append($("<li ><a href='" + item.href + "'><img src='" + item.src + "'></a></li>"));
        });
        //横排排版设置ul的宽为图片宽的总和
        if (op.LunBoFangShi.toLowerCase() == "dantuzuoyi") {
            var xdivZSLunBoImgwidth = 0;
            $(xdivZSLunBoImg + " ul:first img").each(function () {
                xdivZSLunBoImgwidth += $(this).width();
            });
            $(xdivZSLunBoImg + " ul:first").width(xdivZSLunBoImgwidth);
        };
        //开启自动轮播
        if (op.isOpenZiDongLunBo) {
            ZiDongLunBo();
            //开启自动轮播时img容器的mousemove和mouseout的定义
            //img容器的mousemove，轮播按钮和轮播标识为mousemove等于img容器的mousemove
            $(xdivZSLunBoImg).mousemove(function () {
                clearInterval(daTuZiDongLunBoID);
            });
            //img容器的mouseout需根据轮播方式选择开启自动轮播方式，轮播按钮和轮播标识为mouseout等于img容器的mouseout
            $(xdivZSLunBoImg).mouseout(function () {
                ZiDongLunBo()
            });
        };
        //显示轮播标识
        if (op.isShowLunBoBiaoShi) {
            op.container.append($("<div class='divZSLunBoBiaoShiIndivLunBoImg' id='" + divZSLunBoBiaoShiIndivLunBoImg + "'><ul class='ZS-list-inline'></ul></div>"));
            GenJuImgShuShengChengBiaoShi(xdivZSLunBoImg + " a img", xdivZSLunBoBiaoShiIndivLunBoImg + " ul");
            $(xdivZSLunBoBiaoShiIndivLunBoImg + " ul li").each(function () {

                $(this).mouseout(function () {
                    ZSlunBoAnNiuClickJiShu = $(this).index();
                    $(xdivZSLunBoImg).mouseout();
                })

                $(this).mousemove(function () {
                    $(xdivZSLunBoImg).mousemove();
                    $(xdivZSLunBoBiaoShiIndivLunBoImg + " ul li").each(function () {
                        $(this).find("span").removeClass("disc").addClass("HollowCircle");
                    });
                    $(xdivZSLunBoBiaoShiIndivLunBoImg + " ul li").eq($(this).index()).find("span").removeClass("HollowCircle").addClass("disc");
                    //图片出现的方式，需根据轮播方式选择
                    ZSlunBoAnNiuClickJiShu = $(this).index();
                    SwitchImgShowFangShi();
                });
            });
        }
        //显示轮播按钮
        if (op.isLunShowBoAnNiu) {
            var imgHeight = op.container.height();
            var top = 0;
            if (imgHeight >= 240) {
                top = "40%";
            } else if (imgHeight >= 160 && imgHeight < 240) {
                top = "22%";
            } else if (imgHeight >= 124 && imgHeight < 160) {
                top = "18%";
            }
            op.container.append($("<div class='divZSLunBoAnNiuIndivLunBoImg' id='" + divZSLunBoAnNiuIndivLunBoImg + "'><div style='top:" + top + "'></div><div style='top:" + top + "'></div></div>"));
            //轮播按钮点击及鼠标离开自动轮播执行方式
            $(xdivZSLunBoAnNiuIndivLunBoImg + " div").each(function (index, item) {
                var $i = $(item);
                if (index == 0) {
                    //后退
                    $i.click(function () {
                        LunBoAnNiuClick("down");
                    });
                } else {
                    //前进
                    $i.click(function () {
                        LunBoAnNiuClick("up");
                    });
                };
                if (op.isOpenZiDongLunBo) {
                    //轮播按钮的mousemove和mouseout等于img容器的mousemove和mouseout
                    $(this).mousemove(function () {
                        $(xdivZSLunBoImg).mousemove();
                    });
                    $(this).mouseout(function () {
                        $(xdivZSLunBoImg).mouseout();
                    })
                };
            });
        }

        return daTuZiDongLunBoID;

        //点击轮播按钮direction=up或down
        function LunBoAnNiuClick(direction) {
            //图片index的增减，判断该显示哪张图片
            if (direction == "up") {
                if ($(xdivZSLunBoImg + " li").length - 1 == ZSlunBoAnNiuClickJiShu) {
                    ZSlunBoAnNiuClickJiShu = 0;
                } else {
                    ZSlunBoAnNiuClickJiShu++;
                }
            } else if (direction == "down") {
                if (ZSlunBoAnNiuClickJiShu == 0) {
                    ZSlunBoAnNiuClickJiShu = $(xdivZSLunBoImg + " li").length - 1;
                } else {
                    ZSlunBoAnNiuClickJiShu--;
                }
            } else {
                return false;
            }
            //图片出现的方式，需根据轮播方式选择
            SwitchImgShowFangShi();
            //轮播标识的切换
            if (op.isShowLunBoBiaoShi) {
                $(xdivZSLunBoBiaoShiIndivLunBoImg + " ul li").each(function () {
                    $(this).find("span").removeClass("disc").addClass("HollowCircle");
                });
                $(xdivZSLunBoBiaoShiIndivLunBoImg + " ul li").eq(ZSlunBoAnNiuClickJiShu).find("span").removeClass("HollowCircle").addClass("disc");
            }
        };

        //自动轮播
        function ZiDongLunBo() {
            daTuZiDongLunBoID = setInterval(function () {
                LunBoAnNiuClick("up");
            }, op.ZiDongLunBoMiao);
        };

        //--------------------------------------------------在此处设置li的样式---------------------------------------------------
        function SwitchLiYangShi() {
            switch (op.LunBoFangShi.toLowerCase()) {
                case "fade":
                    return "ZS-li-ChongDie";
                    break;
                case "dantuzuoyi":
                    return "ZS-list-inline";
                    break;
                default:
                    return "ZS-li-YinCang";
            }
        };
        //--------------------------------------------------在此处设置li的样式---------------------------------------------------

        //--------------------------------------------------在此处增加轮播方式---------------------------------------------------

        //默认出现方式
        function ClickLunBoAnNiuShowImgDefault() {
            $(xdivZSLunBoImg + " ul:first li").each(function () {
                $(this).hide();
            });
            $(xdivZSLunBoImg + " ul:first li").eq(ZSlunBoAnNiuClickJiShu).show();
        };

        //fade轮播出现方式
        function ClickLunBoAnNiuShowImgFade() {
            //li重叠
            $(xdivZSLunBoImg + " ul:first li").each(function (index, item) {
                if (index == ZSlunBoAnNiuClickJiShu) {
                    $(item).stop().animate({ opacity: 1 }, 500).css({ "z-index": "1" });
                } else {
                    $(item).stop().animate({ opacity: 0 }, 500).css({ "z-index": "0" });
                }
            });
        };

        //单图左移方式
        function ClickLunBoAnNiuShowImgDanTuZuoYi() {
            $(xdivZSLunBoImg + " ul:first").animate({ "margin-left": -$(xdivZSLunBoImg + " ul:first li").eq(1).width() }, function () {
                $(xdivZSLunBoImg + " ul:first li:first").appendTo($(xdivZSLunBoImg + " ul:first"));
                $(xdivZSLunBoImg + " ul:first").css("margin-left", "0px");
            })
        };

        //--------------------------------------------------在此处增加轮播方式---------------------------------------------------

        //--------------------------------------------------在此处选择轮播方式---------------------------------------------------
        function SwitchImgShowFangShi() {
            switch (op.LunBoFangShi.toLowerCase()) {
                case "fade":
                    ClickLunBoAnNiuShowImgFade();
                    break;
                case "dantuzuoyi":
                    ClickLunBoAnNiuShowImgDanTuZuoYi();
                    break;
                default:
                    ClickLunBoAnNiuShowImgDefault();
            }
        };
        //--------------------------------------------------在此处选择轮播方式---------------------------------------------------

        //生成id
        function ShengChengID(str) {
            var id = str + "_" + Math.round(Math.random() * (99999 - 88888) + 88888);
            while ($("#" + id).length > 1) {
                id = str + "_" + Math.round(Math.random() * (99999 - 88888) + 88888);
            }
            return id;
        };

        //根据图片的多少生成<li>○</li>
        function GenJuImgShuShengChengBiaoShi(select, appendToSelect) {
            $(select).each(function (index, item) {
                if (index == 0) {
                    $(appendToSelect).append($("<li><span class='disc'></span></li>"));
                } else {
                    $(appendToSelect).append($("<li><span class='HollowCircle'></span></li>"));
                }
            });
        };

        //判断页面是否引用了css或js
        function isInclude(name) {
            var js = /js$/i.test(name);
            var es = document.getElementsByTagName(js ? 'script' : 'link');
            var isbool = false;
            for (var i = 0; i < es.length; i++) {
                if (es[i][js ? 'src' : 'href'].indexOf(name) != -1) {
                    isbool = true;
                    break;
                }
            }
            if (isbool) {
                return true;
            } else {
                return false;
            }
        }

        //获取加载过文件(js,css)的路径
        function getMyPath(name) {
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

        //获取web根路径
        function getRealPath() {
            //获取当前网址，如： http://www.aizheaina.com/或http://www.aizheaina.com/Home/Login
            var curWwwPath = window.document.location.href;
            //获取主机地址之后的目录，如/Home/Login
            var pathName = window.document.location.pathname;
            if (pathName == "/") {
                //现在获取到的是http://www.aizheaina.com/,所以直接return
                return curWwwPath.substring(0, curWwwPath.length - 1);
            }
            var pos = curWwwPath.indexOf(pathName);
            var localhostPaht = curWwwPath.substring(0, pos);
            return localhostPaht;
        };
    };
})(jQuery, window);