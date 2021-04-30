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
    /// 用户角色
    /// </summary>
    public interface IUser2RoleRepository : IRepository<User2RoleEntity, string>, IRepositoriesBase<User2RoleEntity, string, User2RoleDto, User2RoleCreateDto, User2RoleUpdateDto, ViewUser2Role>
    {

    }
}