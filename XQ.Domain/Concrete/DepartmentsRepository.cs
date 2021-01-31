using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Abstract;
using XQ.Domain.Entities;

namespace XQ.Domain.Concrete
{
	/// <summary>
	/// 部门数据的接口现实
	/// </summary>
    public class DepartmentsRepository : IDepartmentsRepository
    {
		/// <summary>
		/// 初始化数据仓库
		/// </summary>
		private EFDbcontext departmentContext = new EFDbcontext();

		/// <summary>
		/// 获取全部部门信息
		/// </summary>
        public IEnumerable<Departments> Departments
        {
            get
            {
				return departmentContext.Departments;
            }
        }

		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns></returns>
		public List<Departments> DepartmentInfo()
		{
			try
			{
				List<Departments> departmentInfo = new List<Departments>();
				departmentInfo = departmentContext.Departments.ToList();
				return departmentInfo;
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 获取指定数据
		/// </summary>
		/// <param name="departmentId"></param>
		/// <returns></returns>
		public List<Departments> DepartmentInfo(int departmentId)
		{
			departmentContext.Configuration.ProxyCreationEnabled = true;
			departmentContext.Configuration.LazyLoadingEnabled = true;

			List<Departments> departmentInfo = new List<Departments>();
			departmentInfo = departmentContext.Departments.Where(x => x.DepartmentId == departmentId).ToList();
			return departmentInfo;
		}

		/// <summary>
		/// 添加部门设置
		/// </summary>
		/// <param name="departmentModel"></param>
		/// <returns></returns>
		public bool Add(Departments departmentModel)
        {
			try
			{
				if(null!=departmentModel)
				{
					departmentContext.Departments.Add(departmentModel);
					departmentContext.SaveChanges();
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
        }

		/// <summary>
		/// 更新部门数据
		/// </summary>
		/// <param name="departmentModel"></param>
		/// <returns></returns>
		public bool Update(Departments departmentModel)
        {
			try
			{
				if(departmentModel!=null)
				{
					Departments oldModel = departmentContext.Departments.FirstOrDefault(x => x.DepartmentId == departmentModel.DepartmentId);
					oldModel.DepartmentName = departmentModel.DepartmentName;
					departmentContext.SaveChanges();
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
        }

		/// <summary>
		/// 删除指定数据
		/// </summary>
		/// <param name="departmentId"></param>
		/// <returns></returns>
		public bool Delete(int departmentId)
		{
			try
			{
				Departments departmentModel = departmentContext.Departments.FirstOrDefault(x => x.DepartmentId == departmentId);
				if (null != departmentModel)
				{
					departmentContext.Departments.Remove(departmentModel);
					departmentContext.SaveChanges();
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}

		}
	}
}
