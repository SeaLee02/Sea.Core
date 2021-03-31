using Sea.Core.Entity.Framework;
using Sea.Core.Util.Framework.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.Abstractions.Repositories
{
    /// <summary>
    /// 仓储基类接口定义一些实体仓储公用方法
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    /// <typeparam name="TEntityDto">展示实体</typeparam>
    public interface IRepositoriesBase<TEntity, TPrimaryKey, TEntityDto, TCreateInput, TUpdateInput, TView>  //应该继承一个接口  里面  有一些扩展方法  IRepositories
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : class, IEntity<TPrimaryKey>
        where TCreateInput : class, IEntity<TPrimaryKey>
        where TUpdateInput: class, IEntity<TPrimaryKey>
        where TView : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 获取单个的viewdto对象
        /// </summary>
        /// <param name="primaryKey">获取对象转成dto</param>
        /// <returns>dto对象</returns>
        Task<TView> GetViewDtoAsync(TPrimaryKey primaryKey);


        /// <summary>   
        ///  视图分页
        /// </summary>
        /// <code>
        /// <![CDATA[
        ///  PagedInputDto pagedInputDto = new PagedInputDto()
        ///                 {
        ///                     PageIndex = 1,
        ///                     PageSize = 10,
        ///                     Order = "StuName desc"
        ///                 };
        ///                 pagedInputDto.Filter = new PageFilterDto()
        ///                 {
        ///                     Type = "and",
        ///                     Conditions = new System.Collections.Generic.List<Condition>()
        ///                     {
        ///                         new Condition() { Attribute = "StuName", Datatype = "nvarchar", Operatoer = "like", Value = "0" },
        ///                         new Condition() { Attribute = "Birthday", Datatype = "int", Operatoer = "null" }
        ///                     },
        ///                     Filters = new System.Collections.Generic.List<PageFilterDto>()
        ///                     {
        ///                         new PageFilterDto()
        ///                         {
        ///                             Type = "or",
        ///                             Conditions = new System.Collections.Generic.List<Condition>()
        ///                             {
        ///                                 new Condition() { Attribute = "ApproveState", Datatype = "nvarchar",
        ///                                     Operatoer = "eq", Value = "审核中" }
        ///                             }
        ///                         }
        ///                     }
        ///                 };
        ///                 var pagedResult = service.GetPage(pagedInputDto);
        /// ]]>
        /// </code>
        /// <param name="pagedInputDto">分页输入对象</param>
        /// <returns>分页对象</returns>
        Task<MyPagedResult<TView>> GetViewPageAsync(PagedInputDto pagedInputDto);


        /// <summary>   
        ///  分页
        /// </summary>
        /// <code>
        /// <![CDATA[
        ///  PagedInputDto pagedInputDto = new PagedInputDto()
        ///                 {
        ///                     PageIndex = 1,
        ///                     PageSize = 10,
        ///                     Order = "StuName desc"
        ///                 };
        ///                 pagedInputDto.Filter = new PageFilterDto()
        ///                 {
        ///                     Type = "and",
        ///                     Conditions = new System.Collections.Generic.List<Condition>()
        ///                     {
        ///                         new Condition() { Attribute = "StuName", Datatype = "nvarchar", Operatoer = "like", Value = "0" },
        ///                         new Condition() { Attribute = "Birthday", Datatype = "int", Operatoer = "null" }
        ///                     },
        ///                     Filters = new System.Collections.Generic.List<PageFilterDto>()
        ///                     {
        ///                         new PageFilterDto()
        ///                         {
        ///                             Type = "or",
        ///                             Conditions = new System.Collections.Generic.List<Condition>()
        ///                             {
        ///                                 new Condition() { Attribute = "ApproveState", Datatype = "nvarchar",
        ///                                     Operatoer = "eq", Value = "审核中" }
        ///                             }
        ///                         }
        ///                     }
        ///                 };
        ///                 var pagedResult = service.GetPage(pagedInputDto);
        /// ]]>
        /// </code>
        /// <param name="pagedInputDto">分页输入</param>
        /// <returns>分页对象</returns>
        Task<MyPagedResult<TEntityDto>> GetPageAsync(PagedInputDto pagedInputDto);


        /// <summary>
        /// 获取所有的实体数据
        /// </summary>
        /// <returns>视图数据</returns>
        Task<List<TEntityDto>> GetAllListDtoAsync();

        /// <summary>
        /// 返回对应的dto类型
        /// </summary>
        /// <typeparam name="TDto">映射了该实体的dto返回</typeparam>
        /// <returns>返回对应的dto</returns>
        Task<List<TDto>> GetAllListDtoAsync<TDto>();

        /// <summary>
        /// 获取单个实体实体数据
        /// </summary>
        /// <param name="primaryKey">实体的ID</param>
        /// <returns>视图数据</returns>
        Task<TEntityDto> GetDtoAsync(TPrimaryKey primaryKey);

        /// <summary>
        /// 返回对应的dtos对象
        /// </summary>
        /// <typeparam name="TDto">dto类类型</typeparam>
        /// <param name="primaryKey">dtol类型</param>
        /// <returns>对应的dto类型数据</returns>
        Task<TDto> GetDtoAsync<TDto>(TPrimaryKey primaryKey);

        /// <summary>
        /// 实体创建异步
        /// </summary>
        /// <param name="input">输入对象</param>
        /// <returns>返回输出对象</returns>
        Task<TEntityDto> CreateByDtoAsync(TCreateInput input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input">更新输入对象</param>
        /// <returns>主键值</returns>
        Task<TEntityDto> UpdateByDtoAsync(TUpdateInput input);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">更新输入对象</param>
        /// <returns>r任务</returns>
        Task BatchDeleteAsync(TPrimaryKey[] ids);
    }
}
