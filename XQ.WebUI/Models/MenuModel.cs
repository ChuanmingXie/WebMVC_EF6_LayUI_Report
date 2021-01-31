using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XQ.Domain.Entities;

namespace XQ.WebUI.Models
{
    public class MenuModel
    {
        public string LoginName { get; set; }
        public string LoginRole { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
		public List<string> Name { get; set; }
    }
}