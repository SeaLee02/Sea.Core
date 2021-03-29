﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.Abstractions.Repositories.Base
{

    /// <summary>
    /// 上下文信息
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public interface IDbContextProvider<out TDbContext>
       where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }
}
