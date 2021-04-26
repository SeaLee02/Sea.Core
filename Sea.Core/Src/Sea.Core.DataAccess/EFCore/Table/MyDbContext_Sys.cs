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

        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<RoleEntity> RoleEntitys { get; set; }


        /// <summary>
        /// 用户角色
        /// </summary>
        public DbSet<User2RoleEntity> User2RoleEntitys { get; set; }


        /// <summary>
        /// 基础接口表
        /// </summary>
        public DbSet<ModuleEntity> ModuleEntitys { get; set; }


        /// <summary>
        /// 菜单表
        /// </summary>
        public DbSet<PermissionEntity> PermissionEntitys { get; set; }


        /// <summary>
        /// 接口权限表
        /// </summary>
        public DbSet<Module2PermissionEntity> Module2PermissionEntitys { get; set; }

    }
}
