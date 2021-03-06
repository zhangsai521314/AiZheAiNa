﻿//张赛图片轮播，2016.8.31
//本插件使用jQuery v2.1.4，为JQ增加一个ZSISNull方法。无需引用css文件
//返回自动轮播的计时id
(function ($, window) {
    $.fn.ZSImgLunBo = function (options) {
        var op = $.extend({
            container: $(this),//生成内容的容器或者renderingMethod=html时ul的直接父级div
            jsonData: "",//轮播的数据图片路径及点击图片的跳转地址。格式 {"data":[{"href":"","src":""},{"href":"","src":""},{"href":"","src":""}]}
            renderingMethod: "json",//渲染方式，json方式指自动生成html,html方式指不需要自动生成html页面已有布局
            isShowLunBoAnNiu: true,//是否显示轮播按钮
            ziDingYiLunBoAnNiuClassName: "",//自己指定的轮播按钮（第一个为左或者上）
            isShowLunBoBiaoShi: true,//是否显示轮播标识       
            isOpenZiDongLunBo: true,//是否开启自动轮播
            ziDongLunBoMiao: 2,//每多少秒切换图片
            lunBoFangShi: "",//轮播的方式（图片的载入方式），fade（缓慢出现），toleft(单图左移)
            toInt: 1,//每次位移的宽度=toInt*单张图片的宽度，当lunBoFangShi为toleft生效
            speed: "normal",//动画的执行速度
            iSZiDongLunBo_Automatic: false//自动播放时是否执行倒播,在只有两组图的时候使用
        }, options);
        //数据为空则返回
        try {
            if (op.renderingMethod == "json") {
                jsonData = JSON.parse(op.jsonData);
                if (jsonData.data.length <= 0) {
                    return false;
                }
            }
        } catch (e) {
            return false;
        }
        //加载css
        if (!isInclude("ZSImgLunBo.css")) {
            var oCss = document.createElement("link");
            oCss.setAttribute("rel", "stylesheet");
            oCss.setAttribute("type", "text/css");
            oCss.setAttribute("href", getMyPath("ZSImgLunBo.js").substring(0, getMyPath("ZSImgLunBo.js").lastIndexOf("/") + 1) + "ZSImgLunBo.css");
            document.getElementsByTagName("head")[0].appendChild(oCss);
        }
        op.ziDongLunBoMiao = op.ziDongLunBoMiao * 1000;
        //设置容器为相对定位
        op.container.css("position", "relative");
        //生成id
        var divZSLunBoImg = ShengChengID("divZSLunBoImg"), divZSLunBoAnNiuIndivLunBoImg = ShengChengID("divZSLunBoAnNiuIndivLunBoImg"), divZSLunBoBiaoShiIndivLunBoImg = ShengChengID("divZSLunBoBiaoShiIndivLunBoImg");
        // 计数或者计算上下左右
        var daTuZiDongLunBoID = 0, ZSlunBoAnNiuClickJiShu = 0, ToLeft = "margin-left";
        //带#号的id,选择器使用
        var xdivZSLunBoImg = "#" + divZSLunBoImg, xdivZSLunBoAnNiuIndivLunBoImg = "#" + divZSLunBoAnNiuIndivLunBoImg, xdivZSLunBoBiaoShiIndivLunBoImg = "#" + divZSLunBoBiaoShiIndivLunBoImg;
        var s = 0;
        //判断渲染方式
        if (op.renderingMethod == "html") {
            xdivZSLunBoImg = "#" + op.container.attr("id");
        } else {
            //img容器加入到dom中
            op.container.append($("<div style='height:" + op.container.height() + "px;width:100%' class='divZSLunBoImg' id='" + divZSLunBoImg + "' miaoshu='滚动大图'><ul class='ZS-list-unstyled " + SwitchLiYangShi() + "'></ul></div>"));
            //图片数据加入到img容器中
            $.each(jsonData.data, function (index, item) {
                //加入图片数据
                if ($.ZSIsNull(item.href)) {
                    item.href = "javascript:void(0)";
                }
                $(xdivZSLunBoImg + " ul:first").append($("<li s='" + index + "'><a href='" + item.href + "'><img src='" + item.src + "'></a></li>"));
            });
            //横排排版设置ul的宽为图片宽的总和
            if (op.lunBoFangShi.toLowerCase() == "toleft") {
                var xdivZSLunBoImgwidth = 0;
                $(xdivZSLunBoImg + " ul img").each(function () {
                    xdivZSLunBoImgwidth = xdivZSLunBoImgwidth + $(this).width();
                });
                $(xdivZSLunBoImg + " ul:first").width(xdivZSLunBoImgwidth);
            };
        }
        //开启自动轮播
        if (op.isOpenZiDongLunBo) {
            daTuZiDongLunBoID = setInterval(ZiDongLunBo, op.ziDongLunBoMiao);
            //开启自动轮播时img容器的mousemove和mouseout的定义
            //img容器的mousemove，轮播按钮和轮播标识为mousemove等于img容器的mousemove
            $(xdivZSLunBoImg).mousemove(function () {
                clearInterval(daTuZiDongLunBoID);
                $(xdivZSLunBoImg + " ul:first").stop(false, true).animate(); //当前动画直接到达末状态；
            }).mouseout(function () {
                //img容器的mouseout需根据轮播方式选择开启自动轮播方式，轮播按钮和轮播标识为mouseout等于img容器的mouseout
                clearInterval(daTuZiDongLunBoID);
                daTuZiDongLunBoID = setInterval(ZiDongLunBo, op.ziDongLunBoMiao);
            });;
        }
        //显示轮播标识
        if (op.isShowLunBoBiaoShi) {
            op.container.append($("<div class='divZSLunBoBiaoShiIndivLunBoImg' id='" + divZSLunBoBiaoShiIndivLunBoImg + "'><ul class='ZS-list-inline'></ul></div>"));
            GenJuImgShuShengChengBiaoShi(xdivZSLunBoImg + " img", xdivZSLunBoBiaoShiIndivLunBoImg + " ul");
            $(xdivZSLunBoBiaoShiIndivLunBoImg + " ul li").each(function () {
                $(this).mousemove(function () {
                    $(xdivZSLunBoImg).mousemove();
                    $(xdivZSLunBoBiaoShiIndivLunBoImg + " ul li").each(function () {
                        $(this).find("span").removeClass("disc").addClass("HollowCircle");
                    });
                    $(xdivZSLunBoBiaoShiIndivLunBoImg + " ul li").eq($(this).index()).find("span").removeClass("HollowCircle").addClass("disc");
                    //图片出现的方式，需根据轮播方式选择
                    ZSlunBoAnNiuClickJiShu = $(this).index();
                    SwitchImgShowFangShi();
                }).mouseout(function () {
                    ZSlunBoAnNiuClickJiShu = $(this).index();
                    $(xdivZSLunBoImg).mouseout();
                });
            });
        }
        //显示轮播按钮
        if (op.isShowLunBoAnNiu) {
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
            ClickLuBoAnNiu(xdivZSLunBoAnNiuIndivLunBoImg + " div");
        }
        //自定义轮播按钮
        if (op.ziDingYiLunBoAnNiuClassName != "") {
            ClickLuBoAnNiu("." + op.ziDingYiLunBoAnNiuClassName);
        }
        //点击轮播按钮执行
        function ClickLuBoAnNiu(select) {
            $(select).each(function (index, item) {
                var $i = $(item);
                if (index == 0) {
                    //后退
                    $i.click(function (event) {
                        LunBoAnNiuClick("down");
                        event.preventDefault();
                    });
                } else {
                    //前进
                    $i.click(function (event) {
                        LunBoAnNiuClick("up");
                        event.preventDefault();
                    });
                };
                //轮播按钮的mousemove和mouseout等于img容器的mousemove和mouseout
                $(this).mousemove(function () {
                    $(xdivZSLunBoImg).mousemove();
                }).mouseout(function () {
                    $(xdivZSLunBoImg).mouseout();
                });
            });
        };
        return daTuZiDongLunBoID;

        //点击轮播按钮direction=up或down
        function LunBoAnNiuClick(direction) {
            //图片index的增减，判断该显示哪张图片
            if (direction == "up") {
                ToLeft = "margin-left";
                if ($(xdivZSLunBoImg + " li").length - 1 == ZSlunBoAnNiuClickJiShu) {
                    //当往后前到最后一个的时候再翻是第一个
                    ZSlunBoAnNiuClickJiShu = 0;
                } else {
                    ZSlunBoAnNiuClickJiShu++;
                }
            } else if (direction == "down") {
                ToLeft = "margin-right";
                if (ZSlunBoAnNiuClickJiShu == 0) {
                    //当往后翻到第一个的时候在反是最后一个
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
            if (op.iSZiDongLunBo_Automatic) {
                if (ZSlunBoAnNiuClickJiShu == 0) {
                    LunBoAnNiuClick("up");
                } else {
                    if (ToLeft == "margin-left") {
                        LunBoAnNiuClick("down");
                    } else {
                        LunBoAnNiuClick("up");
                    }
                }
            } else {
                LunBoAnNiuClick("up");
            }
        };

        //--------------------------------------------------在此处设置li的样式---------------------------------------------------
        function SwitchLiYangShi() {
            switch (op.lunBoFangShi.toLowerCase()) {
                case "fade":
                    return "ZS-li-ChongDie";
                    break;
                case "toleft":
                    return "ZS-list-inline-nopadding";
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
                    $(item).stop().animate({ opacity: 1 }, op.speed).css({ "z-index": "1" }, op.speed);
                } else {
                    $(item).stop().animate({ opacity: 0 }, op.speed).css({ "z-index": "0" }, op.speed);
                }
            });
        };

        //左移方式
        function ClickLunBoAnNiuShowImgToLeft() {
            $(xdivZSLunBoImg + " ul:first").stop(false, true).animate(); //当前动画直接到达末状态
            if (ToLeft == "margin-left") {
                $(xdivZSLunBoImg + " ul:first").animate({ marginLeft: -$(xdivZSLunBoImg + " ul:first li").eq(0).width() * op.toInt }, op.speed, function () {
                    $(xdivZSLunBoImg + " ul:first li").each(function (index, item) {
                        if (index < op.toInt) {
                            $(item).appendTo($(xdivZSLunBoImg + " ul:first"));
                        }
                    });
                    $(xdivZSLunBoImg + " ul:first").css("margin-left", "0px");
                })
            } else {
                for (var i = 0; i < op.toInt; i++) {
                    $(xdivZSLunBoImg + " ul:first").prepend($(xdivZSLunBoImg + " ul:first li:last"));
                }
                $(xdivZSLunBoImg + " ul:first").css("margin-left", -$(xdivZSLunBoImg + " ul:first li").eq(0).width() * op.toInt);
                $(xdivZSLunBoImg + " ul:first").animate({ marginLeft: 0 }, op.speed, function () {

                })
            }
        };

        //--------------------------------------------------在此处增加轮播方式---------------------------------------------------

        //--------------------------------------------------在此处选择轮播方式---------------------------------------------------
        function SwitchImgShowFangShi() {
            switch (op.lunBoFangShi.toLowerCase()) {
                case "fade":
                    ClickLunBoAnNiuShowImgFade();
                    break;
                case "toleft":
                    ClickLunBoAnNiuShowImgToLeft();
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