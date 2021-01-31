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
    /// 工作任务数据的接口实现
    /// </summary>
    public class WorksRepository : IWorksRepository
    {
        private EFDbcontext worksContext = new EFDbcontext();

        /// <summary>
        /// 获取全部任务
        /// </summary>
        public IEnumerable<Works> Works
        {
            get
            {
                return worksContext.Works;
            }
        }

        /// <summary>
        /// 添加工作任务
        /// </summary>
        /// <param name="workModel"></param>
        /// <returns></returns>
        public bool Add(Works workModel)
        {
            try
            {
                if(null!=workModel)
                {
                    worksContext.Works.Add(workModel);
                    worksContext.SaveChanges();
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
                //throw;
            }
        }

        /// <summary>
        /// 删除指定任务
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public bool Delete(int workId)
        {
            try
            {
                Works WorkModel = worksContext.Works.FirstOrDefault(x => x.WorkId == workId);
                if(WorkModel != null)
                {
                    worksContext.Works.Remove(WorkModel);
                    worksContext.SaveChanges();
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
                //throw;
            }
        }

        /// <summary>
        /// 修改工作任务信息
        /// </summary>
        /// <param name="workModel"></param>
        /// <returns></returns>
        public bool Update(Works workModel)
        {
            try
            {
                if(workModel!=null)
                {
                    Works oldModel = worksContext.Works.FirstOrDefault(x => x.WorkId == workModel.WorkId);
                    oldModel.WorkSummary = workModel.WorkSummary;
                    oldModel.EstimateHours = workModel.EstimateHours;
                    worksContext.SaveChanges();
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
                //throw;
            }
        }

        /// <summary>
        /// 修改工作计划的时间
        /// </summary>
        /// <param name="workModel"></param>
        /// <param name="scheduleStart"></param>
        /// <param name="scheduleEnd"></param>
        /// <returns></returns>
        public bool Update(Works workModel, DateTime scheduleStart, DateTime scheduleEnd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取指定任务信息
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public List<Works> WorkInfo(int workId)
        {
            worksContext.Configuration.ProxyCreationEnabled = true;
            worksContext.Configuration.LazyLoadingEnabled = true;
            List<Works> workInfo = new List<Works>();
            workInfo = worksContext.Works.Where(x => x.WorkId.Equals(workId)).ToList();
            return workInfo;
        }
    }
}
