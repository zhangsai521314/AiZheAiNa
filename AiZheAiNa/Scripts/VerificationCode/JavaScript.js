(function () {

    var jsonData = function () {

    };

    //data就是参数{pageindex:1,pageSize:10},因为每个页面的搜索条件不同，所以data让传成这种，在这不修改的传给后台
    //这个事只获取json数据不分页
    jsonData.prototype.GetJson = function (url, data) {
        $.ajax({
            url: url,
            data: data,
            suress: function (data) {
                return data;
            }
        });
    };
    //data就是参数{pageindex:1,pageSize:10},因为每个页面的搜索条件不同，所以data让传成这种，在这不修改的传给后台
    //这个事只获取json数据并分页
    jsonData.prototype.GetJsonPage = function (url, data) {
        var datas = 1;
        $.ajax({
            url: url,
            data: data,
            suress: function (data) {
                datas = data;
                laypage({
                    cont: 'page', //容器。
                    pages: 50, //通过后台拿到的总页数  
                    curr: pageIndex, //初始化当前页  
                    skin: '#FF4B4B', //皮肤颜色
                    groups: 4, //连续显示分页数  
                    skip: true, //是否开启跳页  
                    first: '首页', //若不显示，设置false即可  
                    last: '尾页', //若不显示，设置false即可  
                    jump: function (e, firlst) { //触发分页后的回
                        if (!firlst) {
                            var s = JSON.parse(data);
                            s.pageIndex = e.curr;
                            this.GetJsonPage(url, JSON.stringify(s));
                        }
                    }
                });
            }
        });
        return datas;
    };

    this.vCode = vCode;

}).call(this);