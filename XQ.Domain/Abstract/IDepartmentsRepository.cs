using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Entities;

namespace XQ.Domain.Abstract
{
    /// <summary>
    /// 部门数据仓库接口定义
    /// </summary>
    public interface IDepartmentsRepository
    {
        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <param name="departmentModel">部门实体</param>
        /// <returns></returns>
        bool Add(Departments departmentModel);

        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="departmentModel"></param>
        /// <returns></returns>
        bool Update(Departments departmentModel);

        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        bool Delete(int departmentId);

        /// <summary>
        /// 获取全部部门信息
        /// </summary>
        IEnumerable<Departments> Departments { get; }

		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns></returns>
		List<Departments> DepartmentInfo();

        /// <summary>
        /// 获取指定部门信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        List<Departments> DepartmentInfo(int departmentId);
    }
}
