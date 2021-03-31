using AutoMapper;
using Sea.Core.Application.Abstractions.Repositories;
using Sea.Core.Application.Abstractions.Repositories.Base;
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
    ///  用户仓储
    /// </summary>
    public class UserRepository : RepositoriesBase<UserEntity, Guid, UserDto,UserCreateDto,UserUpdateDto,ViewUser>, IUserRepository
    {
        private readonly IDbContextProvider<MyDbContext> _dbContextProvider;
        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserRepository(IDbContextProvider<MyDbContext> _dbContextProvider, IMapper mapper) : base(_dbContextProvider, mapper)
        {
            this._dbContextProvider = _dbContextProvider;
            this._mapper = mapper;
        }



    }
}