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
    /// 日期:2019-3-25 11:03
    /// 描述:采集项目数据的实体
    /// </summary>
    public class Projects
    {
        public Projects()
        {
            this.Customers = new HashSet<Customers>();
            this.Works = new HashSet<Works>();
        }

        #region 实体成员

        /// <summary>
        /// 项目ID
        /// </summary>
        [Column("ProjectId")][Key]
        public int ProjectId { get; set; }

        /// <summary>
        /// 项目代码/名称
        /// </summary>
        [Column("ProjectCode")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 项目描述 Description
        /// </summary>
        [Column("ProjectDesc")]
        public string ProjectDesc { get; set; }

        #endregion

        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Works> Works { get; set; }
    }
}
