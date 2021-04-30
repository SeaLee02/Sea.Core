using AutoMapper;
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
    public class RoleRepository : RepositoriesBase<RoleEntity, string, RoleDto, RoleCreateDto, RoleUpdateDto, ViewRole>, IRoleRepository
    {
        private readonly IDbContextProvider<MyDbContext> _dbContextProvider;
        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        public RoleRepository(IDbContextProvider<MyDbContext> _dbContextProvider, IMapper mapper) : base(_dbContextProvider, mapper)
        {
            this._dbContextProvider = _dbContextProvider;
            this._mapper = mapper;
        }



    }
}