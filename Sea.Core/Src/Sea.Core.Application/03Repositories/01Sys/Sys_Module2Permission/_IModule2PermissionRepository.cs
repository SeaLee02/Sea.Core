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
    public interface IModule2PermissionRepository :
        IRepository<Module2PermissionEntity, string>,
        IRepositoriesBase<Module2PermissionEntity, string, Module2PermissionDto, Module2PermissionCreateDto, Module2PermissionUpdateDto, ViewModule2Permission>
    {

    }
}