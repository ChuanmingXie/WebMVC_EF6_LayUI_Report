using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace XQ.Domain.Entities
{
    /// <summary>
    /// 创建：谢传明
    /// 日期：2019-3-23 15:30
    /// 描述：采集员工（系统用户）实体数据
    /// </summary>
    public class Staffs
    {
        //public Staffs()
        //{
        //    this.WorkActors = new HashSet<WorkActors>();
        //    this.WorkReport = new HashSet<WorkReport>();
        //}

        #region 实体成员

        /// <summary>
        /// 员工号
        /// </summary>
        [Column("StaffId")][Key]
        public int StaffId { get; set; }

        /// <summary>
        /// 部门号
        /// </summary>
        [Column("DepartmentId")]
        public Nullable<int> DepartmentId { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [Column("StaffName")]
        public string StaffName { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        [Column("StaffPwd")]
        public string StaffPwd { get; set; }

        /// <summary>
        /// 是否为经理
        /// </summary>
        [Column("IsManager")]
        public Nullable<bool> IsManager { get; set; }

        /// <summary>
        /// 是否在职
        /// </summary>
        [Column("ActiveFlag")]
        public Nullable<int> ActiveFlag { get; set; }

        //public string PhoneNumber { get; set; }
        //public string Photo { get; set; }
        //public string Email { get; set; }
        //public Nullable<System.DateTime> Birthday { get; set; }
        //public string QQNumber { get; set; }
        //public string Website { get; set; }
        //public string Wechat { get; set; }
        //public string Address { get; set; }
        //public string Introduce { get; set; }

        #endregion

        //public virtual ICollection<WorkActors> WorkActors { get; set; }
        //public virtual ICollection<WorkReport> WorkReport { get; set; }

    }
}
