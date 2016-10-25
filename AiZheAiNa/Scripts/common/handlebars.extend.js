//注意Handlebars的helper不能写在模板页，引用也不行

//为Handlebars增加的heper，判断取余后是否为0
Handlebars.registerHelper("isquyueq", function (i, x, options) {
    if (i % x == 0) {
        //满足添加继续执行
        return options.fn(this);
    }
    else {
        //不满足条件执行{{else}}部分
        return options.inverse(this);
    }
});

//比较,operator为比较方式 right为待比较变量 多组的话可以用&&分开,示例
//{{#compare divHengPaiTouBuDaoHang2Name "!=" "服务&&社区" }}
//{{/compare}}
//表示的意思就是 divHengPaiTouBuDaoHang2Name！="服务" && divHengPaiTouBuDaoHang2Name!="社区" 的情况下可以继续执行
Handlebars.registerHelper("compare", function (left, operator, right, options) {
    if (arguments.length < 3) {
        throw new Error('Handlerbars Helper "compare" needs 2 parameters');
    }
    var b = true;
    var operators = {
        '==': function (l, r) {
            for (var i = 0; i < r.length; i++) {
                if (l == r[i]) {
                } else {
                    b = false;
                    break;
                }
            }
            return b;
        },
        '===': function (l, r) {
            for (var i = 0; i < r.length; i++) {
                if (l === r[i]) {
                } else {
                    b = false;
                    break;
                }
            }
            return b;
        },
        '!=': function (l, r) {
            for (var i = 0; i < r.length; i++) {
                if (l != r[i]) {
                } else {
                    b = false;
                    break;
                }
            }
            return b;
        },
        '!==': function (l, r) {
            for (var i = 0; i < r.length; i++) {
                if (l !== r[i]) {
                } else {
                    b = false;
                    break;
                }
            }
            return b;
        },
        '<': function (l, r) {
            for (var i = 0; i < r.length; i++) {
                if (l < r[i]) {
                } else {
                    b = false;
                    break;
                }
            }
            return b;
        },
        '>': function (l, r) {
            for (var i = 0; i < r.length; i++) {
                if (l > r[i]) {
                } else {
                    b = false;
                    break;
                }
            }
            return b;
        },
        '<=': function (l, r) {
            for (var i = 0; i < r.length; i++) {
                if (l <= r[i]) {
                } else {
                    b = false;
                    break;
                }
            }
            return b;
        },
        '>=': function (l, r) {
            for (var i = 0; i < r.length; i++) {
                if (l >= r[i]) {
                } else {
                    b = false;
                    break;
                }
            }
            return b;
        },
        'typeof': function (l, r) {
            for (var i = 0; i < r.length; i++) {
                if (typeof l == r[i]) {
                } else {
                    b = false;
                    break;
                }
            }
            return b;
        }
    };

    if (!operators[operator]) {
        throw new Error('Handlerbars Helper "compare" doesn\'t know the operator ' + operator);
    }
    right = right.split("&&");
    var result = operators[operator](left, right);

    if (result) {
        return options.fn(this);
    } else {
        return options.inverse(this);
    }
});

//注册一个Handlebars Helper,用来将索引+1，因为默认是从0开始的
Handlebars.registerHelper("addOne", function (index, options) {
    return parseInt(index) + 1;
});