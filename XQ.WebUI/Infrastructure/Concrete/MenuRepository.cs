using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XQ.Domain.Concrete;
using XQ.Domain.Entities;
using XQ.WebUI.Infrastructure.Abstract;

namespace XQ.WebUI.Infrastructure.Concrete
{
    public class MenuRepository: IMenuRepository
    {

        private EFDbcontext staffsContext = new EFDbcontext();

		public List<string> Name(int? departmentId)
		{
			List<string> name = new List<string>();
			try
			{
				name = staffsContext.Staffs.Where(x => x.DepartmentId==departmentId).Select(x=>x.StaffName).ToList();
			}
			catch (NullReferenceException)
			{
				throw;
			}
			return name;
		}

		/// <summary>
		/// 查询用户角色
		/// </summary>
		/// <param name="staffName"></param>
		/// <returns></returns>
		public string StaffRole(string staffName)
        {
            try
            {
                Staffs staffModel = staffsContext.Staffs.Where(x => x.StaffName.Equals(staffName)).FirstOrDefault();
                if (staffModel.IsManager.Equals(true))
                    return "经理";
                else
                    return " ";
            }
            catch (NullReferenceException)
            {
                return "登陆失效";
            }
        }
    }
}