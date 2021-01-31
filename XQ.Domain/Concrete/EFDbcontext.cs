using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XQ.Domain.Entities;

namespace XQ.Domain.Concrete
{
    /// <summary>
    /// 继承上下文类DbContext的用于初始化数据仓库和Fluent API
    /// </summary>
    public class EFDbcontext:DbContext
    {
        public EFDbcontext() : base("EFDbContext") { }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }
        public virtual DbSet<WorkActors> WorkActors { get; set; }
        public virtual DbSet<ReportDetials> WorkReport { get; set; }
        public virtual DbSet<Works> Works { get; set; }

        /// <summary>
        /// Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportDetials>().ToTable(nameof(WorkReport));
        }
    }
}
