using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XQ.Domain.Abstract;
using XQ.Domain.Entities;

namespace XQ.WebUI.Controllers
{
    public class DepartmentController : Controller
    {
		private IDepartmentsRepository IDepartment;
		public DepartmentController(IDepartmentsRepository iDepartment)
		{
			IDepartment = iDepartment;
		}
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

		/// <summary>
		/// 呈现View界面
		/// </summary>
		/// <returns></returns>
		public ActionResult Department()
		{
			return View();
		}

		/// <summary>
		/// 获取数据
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public JsonResult GetDepartment(int page,int limit)
		{
			List<Departments> departments = IDepartment.DepartmentInfo();
			return Json(new
			{
				page = page,
				limit = limit,
				code = 0,                   //数据状态的字段名称,默认：code(不可缺省)
				msg = "",                   //状态信息的字段名称,默认：msg(不可缺省)
				count = departments.Count(),//数据总数的字段名称,默认count(不可缺省)
				data = departments.Skip((page-1)*limit).Take(limit),         //数据列表的字段名称,默认data(不可缺省)
			}, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// 更新数据
		/// </summary>
		/// <param name="updateDepartment"></param>
		/// <returns></returns>
		[HttpPost]
		public bool UpadteDepartment(Departments updateDepartment)
		{
			return IDepartment.Update(updateDepartment);
		}

		/// <summary>
		/// 删除数据
		/// </summary>
		/// <param name="departmentId"></param>
		/// <returns></returns>
		[HttpPost]
		public bool DeleteDepartment(int departmentId)
		{
			return IDepartment.Delete(departmentId);
		}

		/// <summary>
		/// 添加数据
		/// </summary>
		/// <param name="departmentModel"></param>
		/// <returns></returns>
		[HttpPost]
		public bool AddDepartment(Departments departmentModel)
		{
			return IDepartment.Add(departmentModel);
		}
    }
}