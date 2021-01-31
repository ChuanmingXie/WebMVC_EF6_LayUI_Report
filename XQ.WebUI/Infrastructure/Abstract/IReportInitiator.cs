using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.WebUI.Models;

namespace XQ.WebUI.Infrastructure.Abstract
{
    /// <summary>
    /// 实现汇报数据的初始化
    /// 扩展传地参数的接口
    /// </summary>
    public interface IReportInitiator
    {
        /// <summary>
        /// 将主界面数据进行填充
        /// </summary>
        /// <returns></returns>
        ReportModel ReportIndexDetails();
    }
}
