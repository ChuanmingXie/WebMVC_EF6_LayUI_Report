using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Entities;

namespace XQ.Domain.Abstract
{
    /// <summary>
    /// 项目数据仓库接口定义
    /// </summary>
    public interface IProjectsRepository
    {
        /// <summary>
        /// 添加项目数据
        /// </summary>
        /// <param name="projectModel"></param>
        /// <returns></returns>
        bool Add(Projects projectModel);

        /// <summary>
        /// 更新项目数据
        /// </summary>
        /// <param name="projectModel"></param>
        /// <returns></returns>
        bool Update(Projects projectModel);

        /// <summary>
        /// 删除项目信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        bool Delete(int projectId);

        /// <summary>
        /// 获取全部项目
        /// </summary>
        IEnumerable<Projects> Projects { get; }

        /// <summary>
        /// 获取指定项目信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Projects ProjectInfo(int projectId);
    }
}
