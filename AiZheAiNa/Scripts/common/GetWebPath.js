//获取web路径，pahtType获取的路径类型
function GetWebPath(pahtType) {
    //获取当前网址，如： http://localhost:8083/myproj/view/my.jsp
    var curWwwPath = window.document.location.href;
    //获取主机地址之后的目录，如： myproj/view/my.jsp
    var pathName = window.document.location.pathname;
    var pos = curWwwPath.indexOf(pathName);
    //获取主机地址，如： http://localhost:8083
    var localhostPaht = curWwwPath.substring(0, pos);
    //获取带"/"的项目名，如：/myproj
    var projectName = pathName.substring(0, pathName.substr(1).indexOf('/') + 1);

    //得到了 http://localhost:8083/myproj
    var realPath = localhostPaht + projectName;
    switch (pahtType) {
        case 1:
            return curWwwPath;
            break;
        case 2:
            return pathName;
            break;
        case 3:
            return localhostPaht;
            break;
        case 4:
            return realPath;
            break;
        default:
            return curWwwPath;
    }
};