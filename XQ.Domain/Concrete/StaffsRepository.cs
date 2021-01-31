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
    /// 员工/用户数据的接口实现
    /// </summary>
    public class StaffsRepository : IStaffsRepository
    {
        /// <summary>
        /// 初始化数据仓库
        /// </summary>
        private EFDbcontext staffsContext = new EFDbcontext();

		/// <summary>
		/// 获得全部员工数据
		/// </summary>
		public IEnumerable<Staffs> Staffs
		{
			get
			{
				return staffsContext.Staffs;
			}
		}

		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns></returns>
		public List<Staffs> StaffsInfo()
		{
			try
			{
				List<Staffs> staffsInfo = new List<Staffs>();
				staffsInfo = staffsContext.Staffs.OrderBy(x=>x.DepartmentId).ThenBy(x => x.StaffId).ToList();
				return staffsInfo;
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 获取指定员工全部数据
		/// </summary>
		/// <param name="staffId"></param>
		/// <returns></returns>
		public List<Staffs> StaffInfo(int staffId)
		{
			staffsContext.Configuration.ProxyCreationEnabled = true;
			staffsContext.Configuration.LazyLoadingEnabled = true;
			List<Staffs> staffInfo = staffsContext.Staffs.Where(x => x.StaffId.Equals(staffId)).ToList();
			return staffInfo;
		}

		/// <summary>
		/// 根据姓名获取员工数据
		/// </summary>
		/// <param name="staffName"></param>
		/// <returns></returns>
		public Staffs StaffInfoByName(string staffName)
		{
			return staffsContext.Staffs.FirstOrDefault(x => x.StaffName == staffName);
		}

		/// <summary>
		/// 添加员工（系统用户）信息
		/// </summary>
		/// <param name="staffModel">员工实体数据模型</param>
		/// <returns></returns>
		public bool Add(Staffs staffModel)
        {
            try
            {
                if(staffModel != null)
                {
                    staffsContext.Staffs.Add(staffModel);
                    staffsContext.SaveChanges();
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
        /// 更新修改员工信息
        /// </summary>
        /// <param name="staffModel">员工实体数据模型</param>
        /// <returns></returns>
        public bool Update(Staffs staffModel)
        {
            try
            {
                if(staffModel != null)
                {
                    Staffs oldModel = staffsContext.Staffs.FirstOrDefault(x => x.StaffId == staffModel.StaffId || x.StaffName == staffModel.StaffName);
                    oldModel.StaffName = staffModel.StaffName;
                    oldModel.StaffPwd = staffModel.StaffPwd;
                    oldModel.DepartmentId = staffModel.DepartmentId;
                    oldModel.IsManager = staffModel.IsManager;
                    oldModel.ActiveFlag = staffModel.ActiveFlag;
                    //oldModel.Address = staffModel.Address;
                    //oldModel.PhoneNumber = staffModel.PhoneNumber;
                    //oldModel.QQNumber = staffModel.QQNumber;
                    //oldModel.Website = staffModel.Website;
                    //oldModel.Wechat = staffModel.Wechat;
                    //oldModel.Email = staffModel.Email;
                    staffsContext.SaveChanges();
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
        /// 删除指定员工信息
        /// </summary>
        /// <param name="staffId">员工实体数据模型</param>
        /// <returns></returns>
        public bool Delete(int staffId)
        {
            try
            {
                Staffs model = staffsContext.Staffs.FirstOrDefault(x => x.StaffId == staffId);
                if(null!=model)
                {
                    staffsContext.Staffs.Remove(model);
                    staffsContext.SaveChanges();
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
