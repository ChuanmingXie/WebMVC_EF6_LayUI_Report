using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Entities;

namespace XQ.WebUI.Infrastructure.Abstract
{
    public interface IMenuRepository
    {
        /// <summary>
        /// 获取用户身份
        /// </summary>
        /// <param name="staffName"></param>
        /// <returns></returns>
        string StaffRole(string staffName);
		
		/// <summary>
		/// 获取部门人员
		/// </summary>
		/// <param name="departmentId"></param>
		/// <returns></returns>
		List<string> Name(int? departmentId);
	}
}
