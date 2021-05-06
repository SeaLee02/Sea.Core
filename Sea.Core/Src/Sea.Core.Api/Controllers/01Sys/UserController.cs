using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sea.Core.Application.AppServices.Sys;
using Sea.Core.Entity.Sys;
using Sea.Core.Entity.Sys.Dto;
using Sea.Core.Entity.Sys.View;
using Sea.Core.Util.Framework.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sea.Core.Api.Controllers
{
    /// <summary>
    /// 用户信息
    /// </summary>
    
    public class UserController : SysControllerBase
    {
        private readonly IUserAppService  _userAppService;
        public UserController(IUserAppService userAppService)
        {
            this._userAppService = userAppService;
        }

        /// <summary>
        /// 获取单个  [课程表]  的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        [HttpGet]
        public async Task<UserDto> GetDto(string id)
        {
            var dto = await this._userAppService.GetDto(id);
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// 获取单个  [应用系统表] 视图的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        [HttpGet]
        public async Task<ViewUser> GetViewDto(string id)
        {
            var dto = await this._userAppService.GetViewDto(id);
            return dto;
        }

        /// <summary>
        /// 获取  [应用系统表] 视图分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        [HttpPost]
        public async Task<MyPagedResult<ViewUser>> GetViewPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._userAppService.GetViewPage(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取  [应用系统表] 分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        [HttpPost]
        public async Task<MyPagedResult<UserDto>> GetPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._userAppService.GetPage(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取 [应用系统表] 的所有信息
        /// </summary>
        /// <returns>list集合</returns>
        [HttpGet]
        public async Task<List<UserDto>> GetAllListDto()
        {
            var listResult = await this._userAppService.GetAllListDto();
            return listResult;
        }

        /// <summary>
        /// 创建  [应用系统表]
        /// </summary>
        /// <param name="input">创建输入实体</param>
        /// <returns>输出dto</returns>
        [HttpPost]
        public async Task<UserDto> CreateByDto(UserCreateDto input)
        {
            var dto = await this._userAppService.CreateByDto(input);
            return dto;
        }

        /// <summary>
        /// 更新  [应用系统表]
        /// </summary>
        /// <param name="input">更新的实体的对象</param>
        /// <returns>更新后的对象</returns>
        [HttpPut]
        public async Task<UserDto> UpdateByDto(UserUpdateDto input)
        {
            var dto = await this._userAppService.UpdateByDto(input);
            return dto;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="deleteDto"></param>
        /// <returns></returns>
       [HttpDelete]
        public async Task BatchDelete(DeleteDto deleteDto)
        {
            await this._userAppService.BatchDelete(deleteDto);
        }

        [HttpGet]
        public async Task<string> GetAuthorize()
        {           
            return await Task.FromResult("授权请求成功");
        }

        [HttpGet]
        public async Task<string> GetNoAuthorize()
        {
            return await Task.FromResult("没有授权请求成功");
        }
    }
}
