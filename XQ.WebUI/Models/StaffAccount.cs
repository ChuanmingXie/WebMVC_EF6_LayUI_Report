using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XQ.WebUI.Models
{
    public class StaffAccount
    {
        /// <summary>
        /// 员工/用户名
        /// </summary>
        [Required(ErrorMessage = "请输入姓名")]
        public string StaffName { get; set; }
        

        /// <summary>
        /// 员工/用户密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        public string StaffPwd { get; set; }
    }
}