using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XQ.WebUI.Models
{
    /// <summary>
    /// 整合任务工作数据和汇报细节数据
    /// </summary>
    public class ReportModel
    {

        /// <summary>
        /// 任务工作数据细节
        /// </summary>
        public IEnumerable<ReportIndex> ReportIndex { get; set; }

        /// <summary>
        /// 汇报进展细节数据
        /// </summary>
        public IEnumerable<ReportDetails>ReportDetails { get; set; }
        
    }
}