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
    /// 日期:2019-3-25 11:15
    /// 描述:采集客户/机台数据实体
    /// </summary>
    public class Customers
    {
        //public Customers()
        //{
        //    this.Works = new HashSet<Works>();
        //}
        
        #region 实体成员

        /// <summary>
        /// 客户/机台ID
        /// </summary>
        [Column("CustomerId")][Key]
        public int CustomerId { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        [Column("ProjectId")]
        public Nullable<int> ProjectId { get; set; }

        /// <summary>
        /// 客户/机台代码
        /// </summary>
        [Column("CustomerCode")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// 客户/机台名称
        /// </summary>
        [Column("CustomerName")]
        public string CustomerName { get; set; }

        #endregion

        //public virtual Projects Projects { get; set; }
        //public virtual ICollection<Works> Works { get; set; }
    }
}
