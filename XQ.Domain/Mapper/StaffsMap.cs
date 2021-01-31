using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace XQ.Domain.Mapper
{
    public class StaffsMap: EntityTypeConfiguration<Staffs>
    {
        public StaffsMap()
        {
            //主键
            this.HasKey(t => t.StaffId);

            //属性
            this.Property(t => t.StaffName).IsRequired();
        }
    }
}
