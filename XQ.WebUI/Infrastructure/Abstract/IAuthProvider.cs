using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Entities;

namespace XQ.WebUI.Infrastructure.Abstract
{
    /// <summary>
    /// 登陆验证提供者接口
    /// </summary>
    public interface IAuthProvider
    {
        /// <summary>
        /// 系统用户的登陆验证
        /// </summary>
        /// <param name="staffName"></param>
        /// <param name="staffPwd"></param>
        /// <returns></returns>
        bool Login(string staffName, string staffPwd);

    }
}
