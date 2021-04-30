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
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : IRepository<RoleEntity, string>, IRepositoriesBase<RoleEntity, string, RoleDto, RoleCreateDto, RoleUpdateDto, ViewRole>
    {

    }
}