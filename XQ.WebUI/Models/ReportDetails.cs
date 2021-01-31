using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XQ.WebUI.Models
{
    /// <summary>
    /// 主界面汇报数据细节,承载任务资源和任务进展汇报的数据
    /// </summary>
    public class ReportDetails
    {
        /// <summary>
        /// 任务ID
        /// </summary>
        public Nullable<int> WorkId { get; set; }

        /// <summary>
        /// 为任务分配的人员
        /// </summary>
        public string StaffName { get; set; }

        /// <summary>
        /// 任务进展的汇报时间
        /// </summary>
        public Nullable<System.DateTime> ReportTime { get; set; }

        /// <summary>
        /// 汇报任务进展情况
        /// </summary>
        public string ReportText { get; set; }
    }
}