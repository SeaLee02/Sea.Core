using Sea.Core.Application.Abstractions;
using Sea.Core.Application.Repositories.Sys;
using Sea.Core.Entity.Sys;
using Sea.Core.Entity.Sys.Dto;
using Sea.Core.Entity.Sys.View;
using Sea.Core.Util.Extensions;
using Sea.Core.Util.Framework.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.AppServices.Sys
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserAppService: AppServicesBase<UserEntity, string, UserDto, UserCreateDto, UserUpdateDto,ViewUser>, 
        IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository  _roleRepository;
        private readonly IUser2RoleRepository _user2RoleRepository;
        private readonly IModule2PermissionAppService  _module2PermissionAppService;


        public UserAppService(IUserRepository  userRepository, IRoleRepository roleRepository, IUser2RoleRepository user2RoleRepository, IModule2PermissionAppService module2PermissionAppService)
        {
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            this._user2RoleRepository = user2RoleRepository;
            this._module2PermissionAppService = module2PermissionAppService;
        }

        #region 框架方法     
        /// <summary>
        /// 获取单个  [用户表]  的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        public override async Task<UserDto> GetDto(string id)
        {
            var dto = await this._userRepository.GetDtoAsync(id);
            return dto;
        }

        /// <summary>
        /// 获取单个  [用户表] 视图的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        public override async Task<ViewUser> GetViewDto(string id)
        {
            var dto = await this._userRepository.GetViewDtoAsync(id);
            return dto;
        }

        /// <summary>
        /// 获取  [用户表] 视图分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        public override async Task<MyPagedResult<ViewUser>> GetViewPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._userRepository.GetViewPageAsync(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取  [用户表] 分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        public override async Task<MyPagedResult<UserDto>> GetPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._userRepository.GetPageAsync(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取 [用户表] 的所有信息
        /// </summary>
        /// <returns>list集合</returns>
        public override async Task<List<UserDto>> GetAllListDto()
        {
            var listResult = await this._userRepository.GetAllListDtoAsync();
            return listResult;
        }



        /// <summary>
        /// 创建  [用户表]
        /// </summary>
        /// <param name="input">创建输入实体</param>
        /// <returns>输出dto</returns>
        public override async Task<UserDto> CreateByDto(UserCreateDto input)
        {
            var dto = await this._userRepository.CreateByDtoAsync(input);
            return dto;
        }

        /// <summary>
        /// 更新  [用户表]
        /// </summary>
        /// <param name="input">更新的实体的对象</param>
        /// <returns>更新后的对象</returns>
        public override async Task<UserDto> UpdateByDto(UserUpdateDto input)
        {
            var dto = await this._userRepository.UpdateByDtoAsync(input);
            return dto;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">实体的id</param>
        /// <returns>task 空值</returns>
        public override async Task Delete(string id)
        {
            await this._userRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="deleteDto"></param>
        /// <returns></returns>
        public override async Task BatchDelete(DeleteDto deleteDto)
        {
            string strId = deleteDto.Id;
            IEnumerable<string> ids = strId.Split(",").Select(x => x.Replace("'", string.Empty));
            List<string> newIds = new List<string>();
            foreach (var id in ids)
            {
                newIds.Add(id);
            }
            await this._userRepository.BatchDeleteAsync(newIds.ToArray());
        }




        public override async Task<IQueryable<UserEntity>> Queryable(Expression<Func<UserEntity, bool>> expression)
        {
            var result = await _userRepository.Queryable(expression);
            return await Task.FromResult(result);
        }
        #endregion


        /// <summary>
        /// 获取用户角色名称
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPwd"></param>
        /// <returns></returns>
        public async Task<string> GetUserRoleNameStr(string loginName, string loginPwd)
        {
            string roleName = "";
            var user = (await Queryable(a => a.LoginName == loginName && a.LoginPwd == loginPwd)).FirstOrDefault();
            var roleList = await _roleRepository.Queryable();
            if (user != null)
            {
                var userRoles = (await _user2RoleRepository.Queryable(ur => ur.UserId == user.Id)).ToList();
                if (userRoles.Count > 0)
                {
                    var arr = userRoles.Select(ur => ur.RoleId).ToList();
                    var roles = roleList.Where(d => arr.Contains(d.Id));

                    roleName = string.Join(',', roles.Select(r => r.Name).ToArray());
                }
            }
            return roleName;
        }

        public async Task<bool> InitData()
        {
          return  await this._userRepository.InitData();

        }
    }
}
