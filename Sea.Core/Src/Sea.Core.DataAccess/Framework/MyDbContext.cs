using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Entity
{

    /// <summary>
    /// 上下文信息
    /// </summary>
    public partial class MyDbContext : DbContext
    {


        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            //DbFilterConfiguration.InitContextFilter(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //IEnumerable<IMutableEntityType> entityTypes = modelBuilder.Model.GetEntityTypes();
            //foreach (IMutableEntityType entityType in entityTypes)
            //{
            //    //初始化过滤器
            //    DbFilterConfiguration.InitGobalFilter(entityType, modelBuilder);
            //    //ViewConfiguration.InitViews(entityType); // 初始化视图
            //}

            // 配置entity,有的类需要配置的,统一配置
            Assembly configAssembly = Assembly.Load("Sea.Core.Entity");

            modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);

        }


        //需要ioc的
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"server=.;database=MyCoreDB;uid=sa;pwd=123");
        //    }
        //}

    }
}
