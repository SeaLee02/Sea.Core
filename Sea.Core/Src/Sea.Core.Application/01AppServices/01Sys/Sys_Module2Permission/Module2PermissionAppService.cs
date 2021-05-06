using Sea.Core.Application.Abstractions;
using Sea.Core.Application.Repositories.Sys;
using Sea.Core.Entity.Sys;
using Sea.Core.Entity.Sys.Dto;
using Sea.Core.Entity.Sys.View;
using Sea.Core.Util.Framework.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.AppServices.Sys
{
    public class Module2PermissionAppService : 
        AppServicesBase<Module2PermissionEntity, string, Module2PermissionDto, Module2PermissionCreateDto, Module2PermissionUpdateDto, ViewModule2Permission>,
        IModule2PermissionAppService
    {
        private readonly IModule2PermissionRepository _module2PermissionRepository;
        public Module2PermissionAppService(IModule2PermissionRepository module2PermissionRepository)
        {
            this._module2PermissionRepository = module2PermissionRepository;
        }

        /// <summary>
        /// 获取单个  [用户表]  的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        public override async Task<Module2PermissionDto> GetDto(string id)
        {
            var dto = await this._module2PermissionRepository.GetDtoAsync(id);
            return dto;
        }

        /// <summary>
        /// 获取单个  [用户表] 视图的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        public override async Task<ViewModule2Permission> GetViewDto(string id)
        {
            var dto = await this._module2PermissionRepository.GetViewDtoAsync(id);
            return dto;
        }

        /// <summary>
        /// 获取  [用户表] 视图分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        public override async Task<MyPagedResult<ViewModule2Permission>> GetViewPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._module2PermissionRepository.GetViewPageAsync(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取  [用户表] 分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        public override async Task<MyPagedResult<Module2PermissionDto>> GetPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._module2PermissionRepository.GetPageAsync(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取 [用户表] 的所有信息
        /// </summary>
        /// <returns>list集合</returns>
        public override async Task<List<Module2PermissionDto>> GetAllListDto()
        {
            var listResult = await this._module2PermissionRepository.GetAllListDtoAsync();
            return listResult;
        }



        /// <summary>
        /// 创建  [用户表]
        /// </summary>
        /// <param name="input">创建输入实体</param>
        /// <returns>输出dto</returns>
        public override async Task<Module2PermissionDto> CreateByDto(Module2PermissionCreateDto input)
        {
            var dto = await this._module2PermissionRepository.CreateByDtoAsync(input);
            return dto;
        }

        /// <summary>
        /// 更新  [用户表]
        /// </summary>
        /// <param name="input">更新的实体的对象</param>
        /// <returns>更新后的对象</returns>
        public override async Task<Module2PermissionDto> UpdateByDto(Module2PermissionUpdateDto input)
        {
            var dto = await this._module2PermissionRepository.UpdateByDtoAsync(input);
            return dto;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">实体的id</param>
        /// <returns>task 空值</returns>
        public override async Task Delete(string id)
        {
            await this._module2PermissionRepository.DeleteAsync(id);
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
            await this._module2PermissionRepository.BatchDeleteAsync(newIds.ToArray());
        }

        public override async Task<IQueryable<Module2PermissionEntity>> Queryable(Expression<Func<Module2PermissionEntity, bool>> expression)
        {
            var result = await _module2PermissionRepository.Queryable(expression);
            return await Task.FromResult(result);
        }
    }
}
