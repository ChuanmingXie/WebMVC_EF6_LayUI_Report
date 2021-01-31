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
    /// 日期:2019-3-25 11:49
    /// 描述:采集任务活动数据实体
    /// </summary>
    public class WorkActors
    {
        #region 实体成员

        /// <summary>
        /// 任务活动ID编号
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
        /// 富有责任的
        /// </summary>
        [Column("Reponsible")]
        public Nullable<bool> Reponsible { get; set; }

        #endregion

        public virtual Staffs Staffs { get; set; }
        public virtual Works Works { get; set; }
    }
}
