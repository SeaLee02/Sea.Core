using Sea.Core.Application.Abstractions.Repositories;
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
    public interface IUserRepository : IRepository<UserEntity, string>, IRepositoriesBase<UserEntity, string, UserDto,UserCreateDto,UserUpdateDto, ViewUser>
    {
        
    }
}
