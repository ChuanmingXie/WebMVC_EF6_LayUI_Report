/*
 * @Date:   2019-04-04
 * @Creater xiechuanming
 * +----------------------------------------------------------------------
 * | 针对部门界面的配置和操作
 * +----------------------------------------------------------------------
*/

//扩展的layui组件
layui.extend({
	admin: '{/}../../static/js/admin'
});

//添加对数据的操作
layui.use('table', function () {
	var table = layui.table
		//, form = layui.form;		//针对锁定工具栏预留的接口

	//数据加载
	layer.load(3);
	setTimeout(function () {
		layer.closeAll('loading');
	}, 1000);

	table.render({
		elem: '#departmentInfo'
		, url: '/Department/GetDepartment'
		, title: '研发部门表'
		, toolbar: '#toolInTop'
		, cols: [[
			{ type: 'numbers' },
			{ type: 'checkbox' },
			{ field: 'DepartmentId', title: '部门编号', sort: true, align: 'center' },
			{ field: 'DepartmentName', title: '部门名称', edit: 'text', align: 'center' },
			{ fixed: 'right', title: '操作', toolbar: '#toolInLine', align: 'center' },
			//{ field: 'lock', title: '是否锁定', templet: '#checkboxInLine', align: 'center' },
		]]
		, page: true
		, request: {
			pageName: 'page'		//页码的参数名称，默认：page
			, limitName: 'limit'	//每页数据量的参数名，默认：limit
		}
		, response: {
			statusName: 'code'		//数据状态的字段名称，默认：code
			, statusCode: 0			//成功的状态码，默认：0
			, msgName: 'msg'		//状态信息的字段名称，默认：msg
			, countName: 'count'	//数据总数的字段名称，默认：count
			, dataName: 'data'		//数据列表的字段名称，默认：data
		}
	});

	//监听顶部工具栏(在此处进行与后台删除全部数据的交互)
	table.on('toolbar(departmentInfo)', function (obj) {
		var checkStatus = table.checkStatus(obj.config.id);
		switch (obj.event) {
			case 'isAll':
				layer.msg(checkStatus.isAll ? '全选' : '未全选');
				break;
		};
	});

	//监听编辑菜单栏(在此处进行与后台操作单行数据的交互)
	table.on('tool(departmentInfo)', function (obj) {
		var data = obj.data;

		if (obj.event === 'del') {
			layer.confirm('确定删除该行',
				function (index) {
					obj.del();
					layer.close(index);
					var departmentId = data.DepartmentId;
					$.post('/Department/DeleteDepartment',
						{ departmentId: departmentId },
						function (mesg) {
							if (mesg == 'True') {
								layer.msg("删除成功");
							}
							else if (mesg == 'False') {
								layer.msg("删除失败");
							}
						});
				});
		}
		else if (obj.event === 'edit') {
			layer.prompt({
				formType: 2,
				value: data.DepartmentName,
				title: '部门名称',
			},
				function (value, index) {
					var updatedepartment = {
						DepartmentId: obj.data.DepartmentId,
						DepartmentName: value
					};
					$.post('/Department/UpadteDepartment',
						{ updateDepartment: updatedepartment },
						function (mesg) {
							if (mesg == 'True') {
								layer.msg("修改成功");
							}
							else if (mesg == 'False') {
								layer.msg("更新失败");
							}
						});
					obj.update({
						DepartmentName: value
					});
					layer.close(index);
				});
		}
	});

	//监听单元格编辑(在此处进行与后台数据更新的交互)
	table.on('edit(departmentInfo)', function (obj) {
		var value = obj.value		//得到修改后的值
			, data = obj.data		//得到所在行所有键值
			//, field = obj.field;	//得到字段名
		var updatedepartment = {
			DepartmentId: obj.data.DepartmentId,
			DepartmentName: obj.data.DepartmentName
		};
		$.ajax({
			url: '/Department/UpadteDepartment',
			data: { updateDepartment: updatedepartment },
			type: 'POST',
			dataType: "json",
		});
		//layer.msg('[部门编号: ' + data.DepartmentId + '] <br/>' + field + ' 字段更改为：' + value);
		layer.msg('[部门编号: ' + data.DepartmentId + '] <br/>[部门名称更改为:' + value + ']');
	});

	//监听锁定本行的工具栏
	//form.on('checkbox(lockDemo)', function (obj) {
	//	//$(this.parentNode.parentNode.parentNode).style("readonly", true);
	//	$("table").find("a").eq(this.value).attr("disabled", "disabled");
	//	layer.tips(this.value + ' ' + this.name + '：' + obj.elem.checked, obj.othis);
	//});
});