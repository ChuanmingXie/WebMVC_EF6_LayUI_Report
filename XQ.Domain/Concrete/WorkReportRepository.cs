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
    /// 工作汇报数据的接口实现
    /// </summary>
    public class WorkReportRepository : IWorkReportRepository
    {
        private EFDbcontext workReportContext = new EFDbcontext();

        /// <summary>
        /// 获取全部汇报数据
        /// </summary>
        public IEnumerable<ReportDetials> WorkReports
        {
            get
            {
                return workReportContext.WorkReport;
            }
        }

        /// <summary>
        /// 添加汇报数据
        /// </summary>
        /// <param name="workReportModel"></param>
        /// <returns></returns>
        public bool Add(ReportDetials workReportModel)
        {
            try
            {
                if(workReportModel!=null)
                {
                    workReportContext.WorkReport.Add(workReportModel);
                    workReportContext.SaveChanges();
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
            }
        }

        /// <summary>
        /// 删除汇报数据
        /// </summary>
        /// <param name="workReportId"></param>
        /// <returns></returns>
        public bool Delete(int workReportId)
        {
            try
            {
                ReportDetials workReportModel = workReportContext.WorkReport.FirstOrDefault(x => x.Id == workReportId);
                if(workReportModel!=null)
                {
                    workReportContext.WorkReport.Remove(workReportModel);
                    workReportContext.SaveChanges();
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
            }
        }

        /// <summary>
        /// 修改汇报数据
        /// </summary>
        /// <param name="workReportModel"></param>
        /// <returns></returns>
        public bool Update(ReportDetials workReportModel)
        {
            try
            {
                if(null!=workReportModel)
                {
                    ReportDetials oldModel = workReportContext.WorkReport.FirstOrDefault(x => x.Id == workReportModel.Id);
                    oldModel.WorkHours = workReportModel.WorkHours;
                    oldModel.ReportText = workReportModel.ReportText;
                    workReportContext.SaveChanges();
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
            }
        }

        /// <summary>
        /// 获取指定汇报数据
        /// </summary>
        /// <param name="workReportId"></param>
        /// <returns></returns>
        public List<ReportDetials> WorkReportInfo(int workReportId)
        {
            workReportContext.Configuration.ProxyCreationEnabled = true;
            workReportContext.Configuration.LazyLoadingEnabled = true;

            List<ReportDetials> workReportInfo = new List<ReportDetials>();
            workReportInfo = workReportContext.WorkReport.Where(x => x.Id.Equals(workReportId)).ToList();
            return workReportInfo;
        }
    }
}
