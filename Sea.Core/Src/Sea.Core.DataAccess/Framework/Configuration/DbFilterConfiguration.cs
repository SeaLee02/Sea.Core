namespace My.D3.DataAccess.Framework.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Sea.Core.Entity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// 过滤器的配置
    /// </summary>
    public class DbFilterConfiguration
    {
        private static readonly object Obj = new object();

        /// <summary>
        /// 正针对表进行过滤
        /// </summary>
        /// <param name="db"></param>
        public static void InitContextFilter(MyDbContext db)
        {
            //根据登入人,针对某些表进行过滤，多租户的全局过滤
            //db.Filter<ViewPFUser>(q => q.Where(x => x.IsDeleted == 0));
            //db.ViewPFUser.AsNoFilter() 取消过滤
            //db.Filter<ViewDemoStudent>(q => q.Where(x => x.StuName == "admin"));
        }


        /// <summary>
        /// 初始化全局的过滤,如软自带的
        /// </summary>
        /// <param name="entityType">过滤</param>
        /// <param name="modelBuilder">builder</param>
        public static void InitGobalFilter(IMutableEntityType entityType, ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }
            IEnumerable<IMutableProperty> props = entityType.GetProperties();
            if (props.Any(x => x.Name == "IsDeleted"))
            {
                ParameterExpression parameter = Expression.Parameter(entityType.ClrType, "e");
                byte defaultValue = 0;
                BinaryExpression body = Expression.Equal(
                    Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(byte) }, parameter, Expression.Constant("IsDeleted")),
               Expression.Constant(defaultValue));
                //modelBuilder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
                if (entityType.Name.ToLower().Contains("view"))
                {
                    modelBuilder.Entity(entityType.ClrType).HasNoKey().HasQueryFilter(Expression.Lambda(body, parameter));
                    //modelBuilder.Query(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
                }
                else
                {
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
                }
            }
        }
    }
}

