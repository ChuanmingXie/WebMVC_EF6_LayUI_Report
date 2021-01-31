using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Entities;

namespace XQ.Domain.Abstract
{
    /// <summary>
    /// 任务数据仓库接口定义
    /// </summary>
    public interface IWorksRepository
    {
        /// <summary>
        /// 添加任务计划
        /// </summary>
        /// <param name="workModel"></param>
        /// <returns></returns>
        bool Add(Works workModel);

        /// <summary>
        /// 修改任务计划信息
        /// </summary>
        /// <param name="workModel"></param>
        /// <returns></returns>
        bool Update(Works workModel);

        /// <summary>
        /// 修改任务计划的时间
        /// </summary>
        /// <param name="workModel"></param>
        /// <param name="scheduleStart"></param>
        /// <param name="scheduleEnd"></param>
        /// <returns></returns>
        bool Update(Works workModel,DateTime scheduleStart,DateTime scheduleEnd);

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        bool Delete(int workId);

        /// <summary>
        /// 获取全部任务
        /// </summary>
        IEnumerable<Works> Works { get; }

        /// <summary>
        /// 获取指定任务信息
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        List<Works> WorkInfo(int workId);

    }
}
