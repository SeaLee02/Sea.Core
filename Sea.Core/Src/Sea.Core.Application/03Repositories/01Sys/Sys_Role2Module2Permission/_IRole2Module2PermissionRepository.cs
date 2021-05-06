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
    public interface IRole2Module2PermissionRepository : 
        IRepository<Role2Module2PermissionEntity, string>, IRepositoriesBase<Role2Module2PermissionEntity, string, Role2Module2PermissionDto, 
            Role2Module2PermissionCreateDto, Role2Module2PermissionUpdateDto, ViewRole2Module2Permission>
    {
        Task<List<Role2Module2PermissionEntity>> RoleModuleMaps();
    }
}
