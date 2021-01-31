using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XQ.Domain.Concrete;
using XQ.Domain.Entities;
using XQ.WebUI.Infrastructure.Abstract;
using XQ.WebUI.Models;

namespace XQ.WebUI.Infrastructure.Concrete
{
    /// <summary>
    /// 汇报数据初始化器，防止在前台Controller里面出现大方法
    /// </summary>
    public class ReportInitiator : IReportInitiator
    {
        private EFDbcontext reportContext = new EFDbcontext();
        /// <summary>
        /// 周报数据初始化器,后期加入时间参数和部门参数，进行扩展
        /// </summary>
        /// <returns></returns>
        public ReportModel ReportIndexDetails()
        {
            var reportIndex = from Projects in reportContext.Projects
                              join Works in reportContext.Works on Projects.ProjectId equals Works.ProjectId
                              join Customers in reportContext.Customers on Works.CustomerId equals Customers.CustomerId
                              where (Works.ActualEnd == null) && (Works.DepartmentId == 1)
                              orderby Projects.ProjectCode
                              select new ReportIndex
                              {
                                  WorkId = Works.WorkId,
                                  ProjectId=Projects.ProjectId,
                                  CustomerId=Customers.CustomerId,
                                  ProjectCode = Projects.ProjectCode,
                                  CustomerName = Customers.CustomerName,
                                  WorkSummary = Works.WorkSummary,
                                  EstimateHours = Works.EstimateHours,
                                  ActualHours = Works.ActualHours,
                                  ScheduleStart = Works.ScheduleStart,
                                  ActualStart = Works.ActualStart,
                                  ScheduleEnd = Works.ScheduleEnd,
                                  ActualEnd = Works.ActualEnd,
                              };
            var reportDetails = from WorkReport in reportContext.WorkReport
                                join ReportDetails in reportIndex on WorkReport.WorkId equals ReportDetails.WorkId
                                select new ReportDetails
                                {
                                    WorkId = ReportDetails.WorkId,
                                    StaffName = WorkReport.StaffName,
                                    ReportTime = WorkReport.ReportTime,
                                    ReportText = WorkReport.ReportText,
                                };
            ReportModel reportRepository = new ReportModel
            {
                ReportIndex = reportIndex.ToList(),
                ReportDetails = reportDetails.ToList()
            };
            return reportRepository;
        }
    }
}