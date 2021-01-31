using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQ.Domain.Entities
{
    /// <summary>
    /// 创建:谢传明
    /// 日期:2019-3-25 11:20
    /// 描述:采集任务数据
    /// </summary>
    public class Works
    {
        public Works()
        {
            this.WorkActors = new HashSet<WorkActors>();
            this.WorkReport = new HashSet<ReportDetials>();
        }

        #region 实体成员
        /// <summary>
        /// 工作任务ID
        /// </summary>
        [Column("WorkId")][Key]
        public int WorkId { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        [Column("ProjectId")]
        public Nullable<int> ProjectId { get; set; }

        /// <summary>
        /// 客户/机台ID
        /// </summary>
        [Column("CustomerId")]
        public Nullable<int> CustomerId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [Column("DepartmentId")]
        public Nullable<int> DepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Column("DepartmentName")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 工作任务概述
        /// </summary>
        [Column("WorkSummary")]
        public string WorkSummary { get; set; }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        [Column("ScheduleStart")]
        public Nullable<System.DateTime> ScheduleStart { get; set; }

        /// <summary>
        /// 计划完成时间
        /// </summary>
        [Column("ScheduleEnd")]
        public Nullable<System.DateTime> ScheduleEnd { get; set; }

        /// <summary>
        /// 预估工时
        /// </summary>
        [Column("EstimateHours")]
        public Nullable<double> EstimateHours { get; set; }

        /// <summary>
        /// 实际开始时间
        /// </summary>
        [Column("ActualStart")]
        public Nullable<System.DateTime> ActualStart { get; set; }

        /// <summary>
        /// 实际结束时间
        /// </summary>
        [Column("ActualEnd")]
        public Nullable<System.DateTime> ActualEnd { get; set; }

        /// <summary>
        /// 实际工时
        /// </summary>
        [Column("ActualHours")]
        public Nullable<double> ActualHours { get; set; }

        /// <summary>
        /// 完成状态:
        /// Scheduled=0,
        /// Started=10,
        /// Completed=20,
        /// Canceled=30,
        /// 过去的Termitated=40
        /// </summary>
        [Column("CompleteFlag")]
        public Nullable<int> CompleteFlag { get; set; }
        #endregion

        public virtual Customers Customers { get; set; }
        public virtual Departments Departments { get; set; }
        public virtual Projects Projects { get; set; }

        public virtual ICollection<WorkActors> WorkActors { get; set; }
        public virtual ICollection<ReportDetials> WorkReport { get; set; }
    }
}
