using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Entities;

namespace XQ.Domain.Abstract
{
    /// <summary>
    /// 任务活动数据仓库接口定义
    /// </summary>
    public interface IWorkActorsRepository
    {
        /// <summary>
        /// 添加任务活动
        /// </summary>
        /// <param name="workActorModel"></param>
        /// <returns></returns>
        bool Add(WorkActors workActorModel);

        /// <summary>
        /// 更新任务活动
        /// </summary>
        /// <param name="workActorModel"></param>
        /// <returns></returns>
        bool Update(WorkActors workActorModel);

        /// <summary>
        /// 删除更新文档
        /// </summary>
        /// <param name="workActorId"></param>
        /// <returns></returns>
        bool Delete(int workActorId);

        /// <summary>
        /// 获取全部任务活动
        /// </summary>
        IEnumerable<WorkActors> WorkActors { get; }

        /// <summary>
        /// 获取指定任务活动
        /// </summary>
        /// <param name="workActorId"></param>
        /// <returns></returns>
        List<WorkActors> WorkActorInfo(int workActorId);
    }
}
