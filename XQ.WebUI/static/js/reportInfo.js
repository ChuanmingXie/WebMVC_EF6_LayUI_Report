/*
 * @Date:   2019-04-02
 * @Creater xiechuanming
 * +----------------------------------------------------------------------
 * | 针对表格table进行多行删除、浮动显示超出部分、操作报表的公用js文件
 * +----------------------------------------------------------------------
*/

//扩展的layui组件
layui.extend({
	admin: '{/}../../static/js/admin'
});

//添加对数据的操作
layui.use(['laydate', 'jquery', 'admin'], function () {
    var laydate = layui.laydate
        , form = layui.form
        ,$ = layui.jquery,
		admin = layui.admin;

    //实例化时间
	laydate.render({
	    elem: '#selectTime'
	});

	//任务状态-开始与结束
	window.member_stop = function (obj, id) {
		layer.confirm('确认要开始任务吗？', function(index) {
			if($(obj).attr('title') == '任务开始') {

				//发异步把用户状态进行更改
				$(obj).attr('title', '任务结束')
				$(obj).find('i').html('&#xe62f;');

				$(obj).parents("tr").find(".td-status").find('span').addClass('layui-btn-disabled').html('已结束任务');
				layer.msg('已结束任务!', {
					icon: 5,
					time: 1000
				});
			} else {
				$(obj).attr('title', '开始任务')
				$(obj).find('i').html('&#xe601;');

				$(obj).parents("tr").find(".td-status").find('span').removeClass('layui-btn-disabled').html('已开始任务');
				layer.msg('已开始任务!', {
					icon: 5,
					time: 1000
				});
			}
		});
	}

	//任务删除操作
	window.member_del = function (obj, id) {
		layer.confirm('确认要删除吗？', function(index) {
			//发异步删除数据
			$(obj).parents("tr").remove();
			layer.msg('已删除!', {
				icon: 1,
				time: 1000
			});
		});
	}

    //表格删除操作
	window.delAll = function (argument) {
		var data = tableCheck.getData();
		layer.confirm('确认要删除吗？' + data, function(index) {
			//捉到所有被选中的，发异步进行删除
			layer.msg('删除成功', {
				icon: 1
			});
			$(".layui-form-checked").not('.header').parents('tr').remove();
		});
	}
});

//为table添加浮动层
$(function () {
    $("td").on("mouseenter", function () {
        //js主要利用offsetWidth和scrollWidth判断是否溢出。
        //在这里scrollWidth是包含内容的完全高度，offsetWidth是当前表格单元格的宽度。
        if (this.offsetWidth < this.scrollWidth) {
            var that = this;
            var text = $(this).text();
            window.layer.tips(text, that, {
                tips: 1,
                time: 10000,
                area: ['430px', 'auto']
            });
        }
    });
})
