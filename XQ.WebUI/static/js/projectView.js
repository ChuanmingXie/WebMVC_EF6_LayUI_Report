/*
 * @Date:   2019-04-04
 * @Creater xiechuanming
 * +----------------------------------------------------------------------
 * | 针对数据的项目数据的录入、编辑;工作任务的创建
 * +----------------------------------------------------------------------
*/

//扩展的layui组件
layui.extend({
    admin: '{/}../../static/js/admin'
});
layui.use(['element', 'form', 'layedit', 'laydate'], function () {

    //Tab的切换功能，切换事件监听等，需要依赖element模块
    var $ = layui.jquery, element = layui.element;
    var form = layui.form
    , layer = layui.layer
    , layedit = layui.layedit
    , laydate = layui.laydate;

    //实例化计划开始时间
    laydate.render({
        elem: '#schedulestart'
    });

    //实例化计划结束时间
    laydate.render({
        elem: '#scheduleend'
    });

    var editIndex = layedit.build('LAY_demo_editor');

    //异步添加项目数据
    form.on('submit(addproject)', function () {
        var project = {
            ProjectCode: $("input:text[name='ProjectCode']").val(),
            ProjectDesc: $("#projectDesc").val(),
        };
        $.ajax({
            url: '/Project/AddProject',
            data: { addProject: project },
            type: 'POST',
            dataType: "json",
        });
        layer.confirm('确认添加吗？', function (index) {
            layer.msg('已添加!', {
                icon: 1,
                time: 1000
            });
        });
        return false;
    });

    ///异步修改项目信息
    form.on('submit(updateproject)', function () {
        var updateproject = {
            ProjectId:$("#projectId").val(),
            ProjectCode:$("#updatecode").val(),
            ProjectDesc:$("#updatedesc").val(),
        }
        $.ajax({
            url: '/Project/UpdateProject',
            data: { updateProject: updateproject },
            type: 'POST',
            dataType: "json",
        });
        layer.confirm('确认更新吗？', function (index) {
            layer.msg('已更新!', {
                icon: 1,
                time: 1000
            });
        });
        return false;
    })
});