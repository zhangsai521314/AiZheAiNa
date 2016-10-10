$(function () {


    $.fn.myzom = function () {
        //加载css
        //if (!isInclude("myzom.css")) {
        //    alert(1);
        //    var oCss = document.createElement("link");
        //    oCss.setAttribute("rel", "stylesheet");
        //    oCss.setAttribute("type", "text/css");
        //    oCss.setAttribute("href", getMyPath("myzom.js").substring(0, getMyPath("myzom.js").lastIndexOf("/") + 1) + "myzom.css");
        //    document.getElementsByTagName("head")[0].appendChild(oCss);
        //}
        var that = $(this),
		$imgCon = that.find('.con-fangDaIMg'),//正常图片容器
	    $ZhangChangImg = $imgCon.find('img:first'),//正常图片
        $FangDaImg = $imgCon.find('img:last'),//正常图片
	    $Drag = that.find('.magnifyingBegin'),//拖动滑动容器
		$show = that.find('.magnifyingShow'),//放大镜显示区域
		$showIMg = $show.find('img'),//放大镜图片
		$ImgList = that.find('.divUpImgContent ul>li>img'),
		multiple = $show.width() / $Drag.width();

        $imgCon.mousemove(function (e) {
            $Drag.css('display', 'block');
            $show.css('display', 'block');
            //获取坐标的两种方法
            // var iX = e.clientX - this.offsetLeft - $Drag.width()/2,
            // 	iY = e.clientY - this.offsetTop - $Drag.height()/2,	
            var iX = e.pageX - $(this).offset().left - $Drag.width() / 2,
		   		iY = e.pageY - $(this).offset().top - $Drag.height() / 2,
		   		MaxX = $imgCon.width() - $Drag.width(),
		   		MaxY = $imgCon.height() - $Drag.height();

            /*这一部分可代替下面部分，判断最大最小值
		   	var DX = iX < MaxX ? iX > 0 ? iX : 0 : MaxX,
		   		DY = iY < MaxY ? iY > 0 ? iY : 0 : MaxY;
		   	$Drag.css({left:DX+'px',top:DY+'px'});	   		
		   	$showIMg.css({marginLeft:-3*DX+'px',marginTop:-3*DY+'px'});*/

            iX = iX > 0 ? iX : 0;
            iX = iX < MaxX ? iX : MaxX;
            iY = iY > 0 ? iY : 0;
            iY = iY < MaxY ? iY : MaxY;
            $Drag.css({ left: iX + 'px', top: iY + 'px' });
            $showIMg.css({ marginLeft: -multiple * iX + 'px', marginTop: -multiple * iY + 'px' });
            //return false;
        });
        $imgCon.mouseout(function () {
            $Drag.css('display', 'none');
            $show.css('display', 'none');
        });

        $ImgList.hover(function () {
            $ZhangChangImg.attr('src', $(this).data('zhengchang'));
            $FangDaImg.attr('src', $(this).data('bigimg'));
        });
    }

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

});