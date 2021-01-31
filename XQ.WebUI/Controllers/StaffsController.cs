using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XQ.Domain.Abstract;
using XQ.Domain.Concrete;
using XQ.Domain.Entities;

namespace XQ.WebUI.Controllers
{
    public class StaffsController : Controller
    {
		private IStaffsRepository IStaff;

		public StaffsController(IStaffsRepository iStaff)
		{
			IStaff = iStaff;
		}

		/// <summary>
		/// 呈现View界面
		/// </summary>
		/// <returns></returns>
        // GET: Staffs
        public ActionResult StaffIndex()
        {
            return View();
        }

		/// <summary>
		/// 为前台表格获取数据
		/// </summary>
		/// <param name="page">页面个数</param>
		/// <param name="limit">每一页的行数</param>
		/// <returns></returns>
		public JsonResult GetStaffInfo(int page,int limit)
		{
			List<Staffs> staffsInfo = IStaff.StaffsInfo();
			return Json(new
			{
				code = 0,					//数据状态
				msg = "",                   //状态信息
				count = staffsInfo.Count(),	//数据总数
				data = staffsInfo.Skip((page - 1) * limit).Take(limit).ToList(),//数据列表
				page = page,                //表格分页数
				limit = limit,              //每页面行数
			}, JsonRequestBehavior.AllowGet);
		}
    }
}