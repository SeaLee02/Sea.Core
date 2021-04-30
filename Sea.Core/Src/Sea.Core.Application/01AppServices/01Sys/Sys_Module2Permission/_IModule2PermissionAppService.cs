using Sea.Core.Application.Abstractions;
using Sea.Core.Entity.Sys;
using Sea.Core.Entity.Sys.Dto;
using Sea.Core.Entity.Sys.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.AppServices.Sys
{
    public interface IModule2PermissionAppService : 
        IAppServicesBase<Module2PermissionEntity, string, Module2PermissionDto, Module2PermissionCreateDto, Module2PermissionUpdateDto, ViewModule2Permission>
    {

    }
}
