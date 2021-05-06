using Sea.Core.Entity.Framework;
using Sea.Core.Util.Framework.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.Abstractions
{

    /// <summary>
    /// 服务层接口基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TView"></typeparam>
    public interface IAppServicesBase<TEntity, TPrimaryKey, TEntityDto, TCreateInput, TUpdateInput, TView>
      where TEntity : class, IEntity<TPrimaryKey>
      where TEntityDto : class, IEntity<TPrimaryKey>
      where TCreateInput : class, IEntity<TPrimaryKey>
      where TUpdateInput : class, IEntity<TPrimaryKey>
      where TView : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 获取单个的viewdto对象
        /// </summary>
        /// <param name="primaryKey">获取对象转成dto</param>
        /// <returns>dto对象</returns>
        Task<TView> GetViewDto(TPrimaryKey id);

        /// <summary>
        /// 获取单个实体实体数据
        /// </summary>
        /// <param name="primaryKey">实体的ID</param>
        /// <returns>视图数据</returns>
        Task<TEntityDto> GetDto(TPrimaryKey id);

        /// <summary>
        /// 视图分页
        /// </summary>
        /// <param name="pagedInputDto">分页输入对象</param>
        /// <returns>分页对象</returns>
        Task<MyPagedResult<TView>> GetViewPage(PagedInputDto pagedInputDto);

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pagedInputDto">分页输入</param>
        /// <returns>分页对象</returns>
        Task<MyPagedResult<TEntityDto>> GetPage(PagedInputDto pagedInputDto);

        /// <summary>
        /// 获取所有的实体数据
        /// </summary>
        /// <returns>视图数据</returns>
        Task<List<TEntityDto>> GetAllListDto();

        /// <summary>
        /// 实体创建异步
        /// </summary>
        /// <param name="input">输入对象</param>
        /// <returns>返回输出对象</returns>
        Task<TEntityDto> CreateByDto(TCreateInput input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input">更新输入对象</param>
        /// <returns>主键值</returns>
        Task<TEntityDto> UpdateByDto(TUpdateInput input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">更新输入对象</param>
        /// <returns>Task空值</returns>
        Task Delete(TPrimaryKey id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">更新输入对象</param>
        /// <returns>r任务</returns>
        Task BatchDelete(DeleteDto deleteDto);

        Task<IQueryable<TEntity>> Queryable(Expression<Func<TEntity, bool>> expression);

        Task<IQueryable<TEntity>> Queryable();

    }
}
