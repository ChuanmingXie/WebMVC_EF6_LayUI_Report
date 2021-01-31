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
    /// 日期:2019-3-25 11:30
    /// 描述:采集任务汇报数据实体
    /// </summary>
    public class ReportDetials
    {
        #region

        /// <summary>
        /// 任务汇报ID编号
        /// </summary>
        [Column("Id")][Key]
        public int Id { get; set; }

        /// <summary>
        /// 工作任务ID
        /// </summary>
        [Column("WorkId")]
        public Nullable<int> WorkId { get; set; }

        /// <summary>
        /// 员工号
        /// </summary>
        [Column("StaffId")]
        public Nullable<int> StaffId { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [Column("StaffName")]
        public string StaffName { get; set; }

        /// <summary>
        /// 汇报时间
        /// </summary>
        [Column("ReportTime")]
        public Nullable<System.DateTime> ReportTime { get; set; }

        /// <summary>
        /// 工作用时
        /// </summary>
        [Column("WorkHours")]
        public Nullable<double> WorkHours { get; set; }

        /// <summary>
        /// 汇报内容
        /// </summary>
        [Column("ReportText")]
        public string ReportText { get; set; }

        #endregion

        public virtual Staffs Staffs { get; set; }

        public virtual Works Works { get; set; }


    }
}
