using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQ.Domain.Entities
{
    public class Departments
    {
		/// <summary>
		/// 创建:谢传明
		/// 日期:2019-3-25 11:26
		/// 描述:采集部门数据实体
		/// </summary>
		//public Departments()
		//{
		//	this.Works = new HashSet<Works>();
		//}

		#region

		/// <summary>
		/// 部门ID
		/// </summary>
		[Column("DepartmentId")]
        [Key]
        public int DepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Column("DepartmentName")]
        public string DepartmentName { get; set; }

		#endregion

		//public virtual ICollection<Works> Works { get; set; }
	}
}
