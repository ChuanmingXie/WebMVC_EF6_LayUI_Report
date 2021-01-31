/*
 * @Date:   2019-04-01
 * @Creater xiechuanming
 * +----------------------------------------------------------------------
 * | 针对主界面的配置和时钟设置
 * +----------------------------------------------------------------------
*/
layui.config({
	base: '../../static/js/',
    version: '101100'
}).use('admin');

layui.use(['jquery', 'admin'], function () {
    var $ = layui.jquery;
    $(function () {
        var login = JSON.parse(localStorage.getItem("login"));
        if (login) {
            if (login == 0) {
                return false;
            }
            else {
                return false
            }
        }
        else {
            return false;
        }
    })
})


$(function () {
    setInterval(getDate, 1000);
});

function getDate() {
    var today = new Date();
    var date = today.getFullYear() + "年" + twoDigits(today.getMonth() + 1) + "月" + twoDigits(today.getDate()) + "日 ";
    var week = " 星期" + "日一二三四五六 ".charAt(today.getDay());
    var time = twoDigits(today.getHours()) + ":" + twoDigits(today.getMinutes()) + ":" + twoDigits(today.getSeconds());
    $("#times").html(date + week + time);
}

function twoDigits(val) {
    if (val < 10)
        return "0" + val;
    return val;
}
