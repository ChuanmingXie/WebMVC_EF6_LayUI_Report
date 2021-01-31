using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Entities;

namespace XQ.Domain.Abstract
{
    /// <summary>
    /// 任务汇报数据仓库接口定义
    /// </summary>
    public interface IWorkReportRepository
    {
        /// <summary>
        /// 添加任务汇报
        /// </summary>
        /// <param name="workReportModel"></param>
        /// <returns></returns>
        bool Add(ReportDetials workReportModel);

        /// <summary>
        /// 修改汇报信息
        /// </summary>
        /// <param name="workReportModel"></param>
        /// <returns></returns>
        bool Update(ReportDetials workReportModel);

        /// <summary>
        /// 删除汇报记录
        /// </summary>
        /// <param name="workReportId"></param>
        /// <returns></returns>
        bool Delete(int workReportId);

        /// <summary>
        /// 获取全部汇报记录
        /// </summary>
        IEnumerable<ReportDetials> WorkReports { get; }

        /// <summary>
        /// 获取指定汇报记录
        /// </summary>
        /// <param name="workReportId"></param>
        /// <returns></returns>
        List<ReportDetials> WorkReportInfo(int workReportId);
    }
}
