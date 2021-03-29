using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Entity
{
    public partial class MyDbContext
    {

        //public DbSet<ViewDemoClass> ViewDemoClass { get; set; }


        /// <summary>
        ///  5.0 改成 DbSet
        /// </summary>
        //public DbQuery<ViewDemoClass> ViewDemoClass { get; set; }


    }
}
