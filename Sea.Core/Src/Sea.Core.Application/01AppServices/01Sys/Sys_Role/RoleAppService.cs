using Sea.Core.Application.Abstractions;
using Sea.Core.Application.Repositories.Sys;
using Sea.Core.Entity.Sys;
using Sea.Core.Entity.Sys.Dto;
using Sea.Core.Entity.Sys.View;
using Sea.Core.Util.Framework.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.AppServices.Sys
{
    public class RoleAppService : AppServicesBase<RoleEntity, string, RoleDto, RoleCreateDto, RoleUpdateDto, ViewRole>, IRoleAppService
    {
        private readonly IRoleRepository  _roleRepository;
        public RoleAppService(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        /// <summary>
        /// 获取单个  [用户表]  的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        public override async Task<RoleDto> GetDto(string id)
        {
            var dto = await this._roleRepository.GetDtoAsync(id);
            return dto;
        }

        /// <summary>
        /// 获取单个  [用户表] 视图的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        public override async Task<ViewRole> GetViewDto(string id)
        {
            var dto = await this._roleRepository.GetViewDtoAsync(id);
            return dto;
        }

        /// <summary>
        /// 获取  [用户表] 视图分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        public override async Task<MyPagedResult<ViewRole>> GetViewPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._roleRepository.GetViewPageAsync(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取  [用户表] 分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        public override async Task<MyPagedResult<RoleDto>> GetPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._roleRepository.GetPageAsync(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取 [用户表] 的所有信息
        /// </summary>
        /// <returns>list集合</returns>
        public override async Task<List<RoleDto>> GetAllListDto()
        {
            var listResult = await this._roleRepository.GetAllListDtoAsync();
            return listResult;
        }



        /// <summary>
        /// 创建  [用户表]
        /// </summary>
        /// <param name="input">创建输入实体</param>
        /// <returns>输出dto</returns>
        public override async Task<RoleDto> CreateByDto(RoleCreateDto input)
        {
            var dto = await this._roleRepository.CreateByDtoAsync(input);
            return dto;
        }

        /// <summary>
        /// 更新  [用户表]
        /// </summary>
        /// <param name="input">更新的实体的对象</param>
        /// <returns>更新后的对象</returns>
        public override async Task<RoleDto> UpdateByDto(RoleUpdateDto input)
        {
            var dto = await this._roleRepository.UpdateByDtoAsync(input);
            return dto;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">实体的id</param>
        /// <returns>task 空值</returns>
        public override async Task Delete(string id)
        {
            await this._roleRepository.DeleteAsync(id);
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
            await this._roleRepository.BatchDeleteAsync(newIds.ToArray());
        }

    }
}
