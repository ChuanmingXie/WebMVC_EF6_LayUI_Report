using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XQ.Domain.Abstract;
using XQ.Domain.Concrete;
using XQ.Domain.Entities;
using XQ.WebUI.Infrastructure.Abstract;
using XQ.WebUI.Models;

namespace XQ.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IReportInitiator IReport;
		private IStaffsRepository IStaff;
        private IMenuRepository IMenu;
        public HomeController(IReportInitiator iReport, IMenuRepository iMenu,IStaffsRepository iStaff)
        {
            IReport = iReport;
            IMenu = iMenu;
			IStaff = iStaff;
        }
        /// <summary>
        /// 处理顶级菜单的控制器:传递角色、当前时间、当前用户
        /// </summary>
        public string userName = System.Web.HttpContext.Current.User.Identity.Name;
        public ActionResult Index()
        {
			try
			{
				MenuModel menuModel = new MenuModel
				{
					LoginName = userName,
					LoginRole = IMenu.StaffRole(userName),
					LoginTime = DateTime.Now,
					Name = IMenu.Name(IStaff.StaffInfoByName(userName).DepartmentId)
				};
				return PartialView(menuModel);
			}
			catch
			{
				return RedirectToAction("Login", "Account");
			}

        }

        /// <summary>
        /// 整合后的汇报数据返回控制器:传递周报讨论所需的全部数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ReportInfo()
        {
            return View(IReport.ReportIndexDetails());
        }
    }
}