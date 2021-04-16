using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using XQ.Domain.Abstract;
using XQ.Domain.Concrete;
using XQ.WebUI.Infrastructure.Abstract;
using XQ.WebUI.Models;

namespace XQ.WebUI.Controllers
{
    /// <summary>
    /// 用户控制器:实现用户的登陆、退出、信息查看与更新
    /// </summary>
    public class AccountController : Controller
    {
        private IAuthProvider IAuth;

        /// <summary>
        /// 初始化构造函数
        /// </summary>
        /// <param name="iAuth"></param>
        public AccountController(IAuthProvider iAuth)
        {
            IAuth = iAuth;
        }

        /// <summary>
        /// 这个不能删除GET方法的起始位置
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 验证登陆信息
        /// </summary>
        /// <param name="staffAccount"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(StaffAccount staffAccount)
        {
            if (staffAccount!=null)
            {
                if(IAuth.Login(staffAccount.StaffName,staffAccount.StaffPwd))
                {
                    FormsAuthentication.SetAuthCookie(staffAccount.StaffName, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect Username or password");
                    return RedirectToAction("", "/404.html");
                    //return View();
                }
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// 退出登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Account");
        }
    }
}