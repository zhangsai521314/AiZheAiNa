
//支持中文和字母和数字和下划线
//str验证的字符串,minlength最小长度, maxlength最大长度
function Verification_Chinese_Letter_Number_Underline(str, minlength, maxlength) {
    if (minlength <= 0 && str.length <= 0) {
        return true;
    }
    var reg = /^[a-zA-Z0-9\u4e00-\u9fa5_]+/;
    if (reg.test(str)) {
        if (str.length >= minlength && str.length <= maxlength) {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
};
//支持字母和数字和下划线
//str验证的字符串,minlength最小长度, maxlength最大长度
function Verification_Letter_Number_Underline(str, minlength, maxlength) {
    if (minlength <= 0 && str.length <= 0) {
        return true;
    }
    var reg = /^[A-Za-z0-9_]+$/;
    if (reg.test(str)) {
        if (str.length >= minlength && str.length <= maxlength) {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
};
//支持字母和数字
//str验证的字符串,minlength最小长度, maxlength最大长度
function Verification_Letter_Number(str, minlength, maxlength) {
    if (minlength <= 0 && str.length <= 0) {
        return true;
    }
    var reg = /^[A-Za-z0-9]+$/;
    if (reg.test(str)) {
        if (str.length >= minlength && str.length <= maxlength) {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
};
//支持汉字
//str验证的字符串,minlength最小长度, maxlength最大长度
function Verification_Chinese(str, minlength, maxlength) {
    if (minlength <= 0 && str.length <= 0) {
        return true;
    }
    var reg = /^[\u4e00-\u9fa5]+$/;
    if (reg.test(str)) {
        if (str.length >= minlength && str.length <= maxlength) {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
};
//支持字母
//str验证的字符串,minlength最小长度, maxlength最大长度
function Verification_Letter_Number(str, minlength, maxlength) {
    if (minlength <= 0 && str.length <= 0) {
        return true;
    }
    var reg = /^[A-Za-z]+$/;
    if (reg.test(str)) {
        if (str.length >= minlength && str.length <= maxlength) {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
};
//支持数字验证(正整数，小数)
//str验证的字符串,minlength最小长度, maxlength最大长度,wholeMaxLength整数部分的最大长度,smallMaxLength小数部分最大的长度
function Verification_Whole_Small_Number(str, minlength, maxlength, wholeMaxLength, smallMaxLength) {
    if (minlength <= 0 && str.length <= 0) {
        return true;
    }
    var reg = /^(?:[1-9][0-9]*|0)(?:.[0-9]+)?$/;
    if (reg.test(str)) {
        if (str.length >= minlength && str.length <= maxlength + 1) {
            var whole, small, split = [];
            split = str.split(".");
            for (var i = 0; i < split.length; i++) {
                if (i == 0) {
                    if (split[i].length > wholeMaxLength) {
                        return false;
                    }
                }
                if (i == 1) {
                    if (split[i].length > smallMaxLength) {
                        return false;
                    }
                }
            }
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
};

//支持数字验证(正整数)
//str验证的字符串,minlength最小长度, maxlength最大长度
function Verification_WholeNumber(str, minlength, maxlength) {
    if (minlength <= 0 && str.length <= 0) {
        return true;
    }
    var reg = /^[0-9]+$/;
    if (reg.test(str)) {
        if (str.length >= minlength && str.length <= maxlength) {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
};



//邮箱验证
function Verification_Email(strEmail) {
    var reg = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    return reg.test(strEmail);
};
//固定电话验证
//正确格式010-12345678、0912-1234567、(010)-12345678、(0912)1234567、(010)12345678、(0912)-1234567、01012345678、09121234567
function Verification_TelePhone(str_TelePhone) {
    var reg = /^(^0\d{2}-?\d{8}$)|(^0\d{3}-?\d{7}$)|(^\(0\d{2}\)-?\d{8}$)|(^\(0\d{3}\)-?\d{7}$)|(^0\d{3}-?\d{8}$)$/;
    return reg.test(str_TelePhone);
};
//手机号码的验证
//支持13,15,17,14,18开头
function Verification_Phone(str_Phone) {
    var reg = /^(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/;
    return reg.test(str_Phone);
};
//15和18位的身份证号验证
function Verification_IdCard(idCard) {
    //15位和18位身份证号码的正则表达式
    var regIdCard = /^(^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$)|(^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[Xx])$)$/;

    //如果通过该验证，说明身份证格式正确，但准确性还需计算
    if (regIdCard.test(idCard)) {
        if (idCard.length == 18) {
            var idCardWi = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2); //将前17位加权因子保存在数组里
            var idCardY = new Array(1, 0, 10, 9, 8, 7, 6, 5, 4, 3, 2); //这是除以11后，可能产生的11位余数、验证码，也保存成数组
            var idCardWiSum = 0; //用来保存前17位各自乖以加权因子后的总和
            for (var i = 0; i < 17; i++) {
                idCardWiSum += idCard.substring(i, i + 1) * idCardWi[i];
            }
            var idCardMod = idCardWiSum % 11; //计算出校验码所在数组的位置
            var idCardLast = idCard.substring(17); //得到最后一位身份证号码

            //如果等于2，则说明校验码是10，身份证号码最后一位应该是X
            if (idCardMod == 2) {
                if (idCardLast == "X" || idCardLast == "x") {
                    return true;
                } else {
                    return false;
                }
            } else {
                //用计算出的验证码与最后一位身份证号码匹配，如果一致，说明通过，否则是无效的身份证号码
                if (idCardLast == idCardY[idCardMod]) {
                    return true;
                } else {
                    return false;
                }
            }
        }
    } else {
        return false;
    }
}
//Ip地址的验证
function Verification_IP(str_IP) {
    var reg = /^((([1-9]\d?)|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}(([1-9]\d?)|(1\d{2})|(2[0-4]\d)|(25[0-5]))$/;
    return reg.test(str_IP);
};
//Web地址的验证
//只允许http、https、ftp这三种
function Verification_WebIP(str_WebIP) {
    var reg = /^(([hH][tT]{2}[pP][sS]?)|([fF][tT][pP]))\:\/\/[wW]{3}\.[\w-]+\.\w{2,4}(\/.*)?$/;
    return reg.test(str_WebIP);
};
//匹配月份
//"01"～"09"和"1"～"12"。
function Verification_Month(str) {
    var reg = /^(0?[1-9]|1[0-2])$/;
    return reg.test(str);
};
//时间验证格式 2016-10-1
function Verification_Date(date) {
    var reg = /^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$/;
    return reg.test(date);
}
//时间验证 格式 2004-8-11 19:44:28
function Verification_Datetime(datetime) {
    var reg = /^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$/;
    return reg.test(date);
}
//开始时间是否小于结束时间
function Verification_StartDateLessThanEndDate(startDate, endDate, isequal) {
    var startDate = new Date(startDate.replace(/-/g, "/"));
    var endDate = new Date(endDate.replace(/-/g, "/"));
    if (isequal) {
        if (startDate <= endDate) {
            return true;
        }
    } else {
        if (startDate < endDate) {
            return true;
        }
    }
    return false;
}

//判断值是否为空,为空返回True
function Verification_isNull(str) {
    if (str == null || typeof (str) == "undefined" || $.trim(str) == "" || $.trim(str).length <= 0) {
        return true;
    } else {
        return false;
    }
};

//邮政编码正则
function Verification_post(str) {
    var reg = /^[0-9]{6}$/;
    return reg.test(str);
};






//使光标总是定位在文本的最后start
$.fn.Verification_setCursorPosition = function (position) {
    if (this.length == 0) return this;
    return $(this).Verification_setSelection(position, position);
}
$.fn.Verification_setSelection = function (selectionStart, selectionEnd) {
    if (this.length == 0) return this;
    input = this[0];

    if (input.createTextRange) {
        var range = input.createTextRange();
        range.collapse(true);
        range.moveEnd('character', selectionEnd);
        range.moveStart('character', selectionStart);
        range.select();
    } else if (input.setSelectionRange) {
        input.focus();
        input.setSelectionRange(selectionStart, selectionEnd);
    }

    return this;
}
//使光标总是定位在文本的最后
$.fn.Verification_focusEnd = function () {
    this.Verification_setCursorPosition(this.val().length);
}
//使光标总是定位在文本的最后end