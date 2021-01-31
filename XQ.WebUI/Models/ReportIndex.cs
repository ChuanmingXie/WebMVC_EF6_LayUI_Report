using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XQ.Domain.Concrete;
using XQ.Domain.Entities;

namespace XQ.WebUI.Models
{
    /// <summary>
    /// 主界面汇报的View模型,用于承载联合查询的数据
    /// </summary>
    public class ReportIndex
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        public int WorkId { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// 客户/机台ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 项目代码
        /// </summary>
        public string ProjectCode { get; set; }

        /// <summary>
        /// 客户/机台
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 任务概要
        /// </summary>
        public string WorkSummary { get; set; }

        /// <summary>
        /// 预估计工时
        /// </summary>
        public Nullable<double> EstimateHours { get; set; }

        /// <summary>
        /// 实际工时
        /// </summary>
        public Nullable<double> ActualHours { get; set; }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public Nullable<System.DateTime> ScheduleStart { get; set; }

        /// <summary>
        /// 实际开始时间
        /// </summary>
        public Nullable<System.DateTime> ActualStart { get; set; }

        /// <summary>
        /// 计划结束时间
        /// </summary>
        public Nullable<System.DateTime> ScheduleEnd { get; set; }

        /// <summary>
        /// 实际结束时间
        /// </summary>
        public Nullable<System.DateTime> ActualEnd { get; set; }
        
    }
}