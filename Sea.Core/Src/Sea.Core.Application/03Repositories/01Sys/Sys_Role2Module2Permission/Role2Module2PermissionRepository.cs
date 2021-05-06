using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sea.Core.Application.Abstractions.Repositories;
using Sea.Core.Entity;
using Sea.Core.Entity.Sys;
using Sea.Core.Entity.Sys.Dto;
using Sea.Core.Entity.Sys.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.Repositories.Sys
{

    /// <summary>
    /// 角色仓储
    /// </summary>
    public class Role2Module2PermissionRepository : 
        RepositoriesBase<Role2Module2PermissionEntity, string,Role2Module2PermissionDto, Role2Module2PermissionCreateDto, 
            Role2Module2PermissionUpdateDto, ViewRole2Module2Permission>,
        IRole2Module2PermissionRepository
    {
        private readonly IDbContextProvider<MyDbContext> _dbContextProvider;
        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Role2Module2PermissionRepository(IDbContextProvider<MyDbContext> dbContextProvider, IMapper mapper) : base(dbContextProvider, mapper)
        {
            this._dbContextProvider = dbContextProvider;
            this._mapper = mapper;
        }

        /// <summary>
        /// 获取角色,获取角色模块对应关系，可以使用视图来简单解决  联合查询
        /// </summary>
        /// <returns></returns>
        public async Task<List<Role2Module2PermissionEntity>> RoleModuleMaps()
        {
            var db = this._dbContextProvider.GetDbContext();

            var result = await  db.Role2Module2PermissionEntitys.Include(x => x.RoleEntity).Include(x => x.ModuleEntity).ToListAsync() ;

            return await Task.FromResult(result);

        }
    }
}