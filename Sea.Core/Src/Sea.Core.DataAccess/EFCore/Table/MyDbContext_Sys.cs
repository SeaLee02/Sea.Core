using Microsoft.EntityFrameworkCore;
using Sea.Core.Entity.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Entity
{
    public partial class MyDbContext
    {
        /// <summary>
        /// 用户信息
        /// </summary>
       public DbSet<UserEntity> UserEntitys { get; set; }

        //      /// <summary>
        //      /// 班级表
        //      /// </summary>
        //public DbSet<DemoClassEntity> DemoClass { get; set; }
    }
}
