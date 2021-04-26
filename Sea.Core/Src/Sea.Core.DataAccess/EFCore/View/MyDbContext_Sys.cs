using Microsoft.EntityFrameworkCore;
using Sea.Core.Entity.Sys.View;
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
      /// 用户视图
      /// </summary>
        public DbSet<ViewUser> ViewUser { get; set; }



        /// <summary>
        ///  5.0 改成 DbSet
        /// </summary>
        //public DbQuery<ViewDemoClass> ViewDemoClass { get; set; }


    }
}
