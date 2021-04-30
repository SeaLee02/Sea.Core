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
    public interface IRoleAppService: IAppServicesBase<RoleEntity, string, RoleDto, RoleCreateDto, RoleUpdateDto, ViewRole>
    {
    
    }
}
