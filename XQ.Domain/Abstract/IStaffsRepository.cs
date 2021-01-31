using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Entities;

namespace XQ.Domain.Abstract
{
    /// <summary>
    /// 员工/用户数据仓库接口定义
    /// </summary>
    public interface IStaffsRepository
    {
        /// <summary>
        /// 添加员工/用户信息
        /// </summary>
        /// <param name="staffModel"></param>
        /// <returns></returns>
        bool Add(Staffs staffModel);

        /// <summary>
        /// 更新员工/用户信息
        /// </summary>
        /// <param name="staffModel"></param>
        /// <returns></returns>
        bool Update(Staffs staffModel);

        /// <summary>
        /// 删除员工/用户信息
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        bool Delete(int staffId);

        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        IEnumerable<Staffs> Staffs { get; }

		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns></returns>
		List<Staffs> StaffsInfo();

        /// <summary>
        /// 根据StaffID获取指定用户信息
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        List<Staffs> StaffInfo(int staffId);

        /// <summary>
        /// 根据姓名获取用户信息
        /// </summary>
        /// <param name="staffName"></param>
        /// <returns></returns>
        Staffs StaffInfoByName(string staffName);
    }
}
