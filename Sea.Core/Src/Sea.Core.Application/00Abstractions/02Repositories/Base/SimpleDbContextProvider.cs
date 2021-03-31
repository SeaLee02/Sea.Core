using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.Abstractions.Repositories
{
    /// <summary>
    /// 用作依赖注册。需要注册IDbContextProvider 上下文
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public class SimpleDbContextProvider<TDbContext> : IDbContextProvider<TDbContext>
           where TDbContext : DbContext
    {

        public TDbContext DbContext { get; }
        public SimpleDbContextProvider(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public TDbContext GetDbContext()
        {
            return DbContext;
        }
    }
}
