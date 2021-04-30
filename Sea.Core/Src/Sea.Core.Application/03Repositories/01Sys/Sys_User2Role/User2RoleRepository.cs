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
    public class User2RoleRepository : 
        RepositoriesBase<User2RoleEntity, string, User2RoleDto, User2RoleCreateDto, User2RoleUpdateDto, ViewUser2Role>,
        IUser2RoleRepository
    {
        private readonly IDbContextProvider<MyDbContext> _dbContextProvider;
        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        public User2RoleRepository(IDbContextProvider<MyDbContext> _dbContextProvider, IMapper mapper) : base(_dbContextProvider, mapper)
        {
            this._dbContextProvider = _dbContextProvider;
            this._mapper = mapper;
        }



    }
}