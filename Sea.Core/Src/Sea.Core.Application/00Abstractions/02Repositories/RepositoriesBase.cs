using AutoMapper;
using Sea.Core.Entity;
using Sea.Core.Entity.Framework;
using Sea.Core.Util.Extensions;
using Sea.Core.Util.Framework.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.Abstractions.Repositories
{
    /// <summary>
    ///  response基类
    /// </summary>
    /// <typeparam name="TEntity">实体对象</typeparam>
    /// <typeparam name="TPrimaryKey">主键的类型</typeparam>
    /// <typeparam name="TEntityDto">实体展示的类型</typeparam>
    /// <typeparam name="TViewDto">viewDto的展示</typeparam>
    public class RepositoriesBase<TEntity, TPrimaryKey, TEntityDto, TCreateInput, TUpdateInput, TView> :
        EFCoreRepository<MyDbContext, TEntity, TPrimaryKey>,
        IRepositoriesBase<TEntity, TPrimaryKey, TEntityDto, TCreateInput, TUpdateInput, TView>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : class, IEntity<TPrimaryKey>
        where TCreateInput : class, IEntity<TPrimaryKey>
        where TUpdateInput : class, IEntity<TPrimaryKey>
        where TView : class, IEntity<TPrimaryKey>
    {
        //private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        private readonly IDbContextProvider<MyDbContext> _dbContextProvider;

        /// <summary>
        /// 构造函数，传递上下文
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public RepositoriesBase(IDbContextProvider<MyDbContext> dbContextProvider, IMapper mapper) : base(dbContextProvider)
        {
            this._dbContextProvider = dbContextProvider;
            _mapper = mapper;
        }

        ///// <summary>
        ///// 仓储构造方法
        ///// </summary>
        ///// <param name="db">数据库连接</param>
        ///// <param name="mapper">映射</param>
        //public RepositoriesBase(MyDbContext db, IMapper mapper)
        //{
        //    this._db = db;
        //    this._mapper = mapper;
        //}


        /// <summary>
        /// 获取单个的dto对象
        /// </summary>
        /// <param name="primaryKey">获取对象转成dto</param>
        /// <returns>dto对象</returns>
        public virtual async Task<TView> GetViewDtoAsync(TPrimaryKey primaryKey)
        {
            var db = this._dbContextProvider.GetDbContext();
            Expression<Func<TView, bool>> func = this.CreateViewEqualityExpressionForId(primaryKey);
            TView view = db.Set<TView>().FirstOrDefault(func);
            return await Task.FromResult(view);
        }


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
        public virtual async Task<MyPagedResult<TView>> GetViewPageAsync(PagedInputDto pagedInputDto)
        {
            var db = this._dbContextProvider.GetDbContext();
            MyPagedResult<TView> pageResult = await db.Set<TView>().GetPageAsync<TView, TView>(pagedInputDto);
            return pageResult;
        }


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
        /// <param name="pagedInputDto">分页输入对象</param>
        /// <returns>分页对象</returns>
        public virtual async Task<MyPagedResult<TEntityDto>> GetPageAsync(PagedInputDto pagedInputDto)
        {
            var db = this._dbContextProvider.GetDbContext();
            var pageResult = await db.Set<TEntity>().GetPageAsync<TEntity, TEntityDto>(pagedInputDto);
            return pageResult;
        }

        /// <summary>
        /// 获取所有数据List
        /// </summary>
        /// <returns>转换后的dto</returns>
        public virtual async Task<List<TEntityDto>> GetAllListDtoAsync()
        {
            var dtoList = await this.GetAllListDtoAsync<TEntityDto>();
            return dtoList;
        }

        /// <summary>
        /// 返回对应的dto类型集合
        /// </summary>
        /// <typeparam name="TDto">映射了该实体的dto返回</typeparam>
        /// <returns>返回对应的dto</returns>
        public virtual async Task<List<TDto>> GetAllListDtoAsync<TDto>()
        {
            var list = await base.GetAllListAsync(); ;
            var dtoList = this._mapper.Map<List<TDto>>(list);
            return dtoList;
        }

        /// <summary>
        /// 获取单个的dto对象
        /// </summary>
        /// <param name="primaryKey">获取对象转成dto</param>
        /// <returns>dto对象</returns>
        public async Task<TEntityDto> GetDtoAsync(TPrimaryKey primaryKey)
        {
            var dto = await this.GetDtoAsync<TEntityDto>(primaryKey);
            return dto;
        }

        /// <summary>
        /// 返回对应的dto对象
        /// </summary>
        /// <typeparam name="TDto">dto类型</typeparam>
        /// <param name="primaryKey">主键</param>
        /// <returns>对应的dto类型的值</returns>
        public virtual async Task<TDto> GetDtoAsync<TDto>(TPrimaryKey primaryKey)
        {
            var db = this._dbContextProvider.GetDbContext();
            var entity = await base.GetAsync(primaryKey);

            foreach (var navgation in db.Entry(entity).Navigations)
            {
                await navgation.LoadAsync();
            }

            var dto = this._mapper.Map<TDto>(entity);
            return dto;
        }

        /// <summary>
        /// 根据输入的dto创建对象
        /// </summary>
        /// <param name="input">创建输入的dto</param>
        /// <returns>展示的dto</returns>
        public virtual async Task<TEntityDto> CreateByDtoAsync(TCreateInput input)
        {
            var db = this._dbContextProvider.GetDbContext();
            var entity = this._mapper.Map<TEntity>(input);
            entity = await base.InsertAsync(entity);
            await db.SaveChangesAsync();
            return _mapper.Map<TEntityDto>(entity);
        }

        /// <summary>
        /// 更新的dto
        /// </summary>
        /// <param name="input">输入对象</param>
        /// <returns>展示的Dto</returns>
        public virtual async Task<TEntityDto> UpdateByDtoAsync(TUpdateInput input)
        {
            var db = this._dbContextProvider.GetDbContext();
            // 找出实体
            var oldEntity = await base.GetAsync(input.Id);
            // 对比变化 只更新不为空的属性值
            var entity = input.ObjectMapTo(oldEntity);
            entity = await base.UpdateAsync(entity);
            await db.SaveChangesAsync();
            return _mapper.Map<TEntityDto>(entity);
        }


        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">id的集合</param>
        /// <returns>任务</returns>
        public virtual async Task BatchDeleteAsync(TPrimaryKey[] ids)
        {
            var db = this._dbContextProvider.GetDbContext();
            foreach (var id in ids)
            {
                await this.DeleteAsync(id);
            }
            await db.SaveChangesAsync();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="expression"></param>
        ///// <returns></returns>
        //public virtual async Task<IQueryable<TEntity>> Queryable(Expression<Func<TEntity, bool>> expression)
        //{
        //    var db = this._dbContextProvider.GetDbContext();
        //    return await Task.FromResult(db.Set<TEntity>().Where(expression));
        //}


        /// <summary>
        /// 根据主键查询构建lambdaParam参数
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        private Expression<Func<TView, bool>> CreateViewEqualityExpressionForId(TPrimaryKey id)
        {
            ParameterExpression lambdaParam = Expression.Parameter(typeof(TView));
            BinaryExpression lambdaBody = Expression.Equal(Expression.PropertyOrField(lambdaParam, "Id"), Expression.Constant(id, typeof(TPrimaryKey)));
            return Expression.Lambda<Func<TView, bool>>(lambdaBody, lambdaParam);
        }
    }
}
