using AutoMapper;
using Sea.Core.Application.Abstractions.Repositories;
using Sea.Core.Entity;
using Sea.Core.Entity.Sys;
using Sea.Core.Entity.Sys.Dto;
using Sea.Core.Entity.Sys.View;
using Sea.Core.Util.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.Repositories.Sys
{
    /// <summary>
    ///  用户仓储
    /// </summary>
    public class UserRepository : RepositoriesBase<UserEntity, string, UserDto, UserCreateDto, UserUpdateDto, ViewUser>, IUserRepository
    {
        private readonly IDbContextProvider<MyDbContext> _dbContextProvider;
        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserRepository(IDbContextProvider<MyDbContext> _dbContextProvider, IMapper mapper) : base(_dbContextProvider, mapper)
        {
            this._dbContextProvider = _dbContextProvider;
            this._mapper = mapper;
        }

        public async Task<bool> InitData()
        {
        
                var db = this._dbContextProvider.GetDbContext();
                //用户
                UserEntity userEntity = new UserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    LoginName = "superAdmin",
                    LoginPwd = MD5Helper.MD5Encrypt32("123qwe"),
                    RealName = "超级管理员",
                    Status = 0
                };
                await db.UserEntitys.AddAsync(userEntity);
                //角色
                RoleEntity roleEntity = new RoleEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "SuperAdmin",
                    Description = "超级管理员",
                    IsEnabled=true
                };
                await db.RoleEntitys.AddAsync(roleEntity);
                //用户角色关系
                User2RoleEntity user2RoleEntity = new User2RoleEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userEntity.Id,
                    RoleId = roleEntity.Id
                };
                await db.User2RoleEntitys.AddAsync(user2RoleEntity);

                //接口----API的地址接口
                ModuleEntity moduleEntity = new ModuleEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "测试授权接口",
                    LinkUrl = "api/sys/user/GetAuthorize",
                    IsEnabled=true,
                    IsMenu=false,
                    OrderSort=0
                };
                await db.ModuleEntitys.AddAsync(moduleEntity);
                //模块---菜单,按钮





                //角色--接口--模块
                Role2Module2PermissionEntity role2Module2PermissionEntity = new Role2Module2PermissionEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    RoleId = roleEntity.Id,
                    ModuleId = moduleEntity.Id
                };
                await db.Role2Module2PermissionEntitys.AddAsync(role2Module2PermissionEntity);

                await db.SaveChangesAsync();
                return await Task.FromResult(true);
 

        }
    }
}