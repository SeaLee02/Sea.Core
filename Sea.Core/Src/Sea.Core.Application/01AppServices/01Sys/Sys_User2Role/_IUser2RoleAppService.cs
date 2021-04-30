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
    public interface IUser2RoleAppService : IAppServicesBase<User2RoleEntity, string, User2RoleDto, User2RoleCreateDto, User2RoleUpdateDto, ViewUser2Role>
    {
    }
}
