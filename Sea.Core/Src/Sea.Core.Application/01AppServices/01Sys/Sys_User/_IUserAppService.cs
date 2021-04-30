using Sea.Core.Application.Abstractions;
using Sea.Core.Entity.Sys;
using Sea.Core.Entity.Sys.Dto;
using Sea.Core.Entity.Sys.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.AppServices.Sys
{
    /// <summary>
    /// 用户信息服务
    /// </summary>
    public interface IUserAppService : IAppServicesBase<UserEntity, string, UserDto,UserCreateDto,UserUpdateDto,ViewUser>
    {
        public Task<List<UserEntity>> GetAll();


        public Task<IQueryable<UserEntity>> GetAll(Expression<Func<UserEntity, bool>> expression);
    }
}
