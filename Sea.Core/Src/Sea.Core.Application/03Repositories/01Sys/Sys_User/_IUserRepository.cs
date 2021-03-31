using Sea.Core.Application.Abstractions.Repositories;
using Sea.Core.Application.Abstractions.Repositories.Base;
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
    /// 用户仓储
    /// </summary>
    public interface IUserRepository : IRepository<UserEntity, Guid>, IRepositoriesBase<UserEntity, Guid, UserDto,UserCreateDto,UserUpdateDto, ViewUser>
    {
        
    }
}
