using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XQ.Domain.Concrete;
using XQ.Domain.Entities;
using XQ.WebUI.Infrastructure.Abstract;

namespace XQ.WebUI.Infrastructure.Concrete
{
    /// <summary>
    /// 实现登陆验证提供者
    /// </summary>
    public class AuthProvider : IAuthProvider
    {
        private EFDbcontext staffsContext = new EFDbcontext();
        /// <summary>
        /// 用户信息登陆验证
        /// </summary>
        /// <param name="staffName">登录名</param>
        /// <param name="staffPwd">登陆密码</param>
        /// <returns></returns>
        public bool Login(string staffName, string staffPwd)
        {
            try
            {
                Staffs model = staffsContext.Staffs.Where(x => x.StaffName.Equals(staffName)).Where(x => x.StaffPwd.Equals(staffPwd)).FirstOrDefault();
                if (null != model)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {				
                return false;
            }
        }

    }
}