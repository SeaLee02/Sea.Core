using Sea.Core.Entity.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.Abstractions.Repositories.Base
{
    /// <summary>
    /// 基本仓储接口,基本的方法
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 获取数量
        /// </summary>
        /// <returns>数量</returns>
        int Count();

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <returns>数量</returns>
        Task<int> CountAsync();

        /// <summary>
        /// 过滤条件获取数量
        /// </summary>
        /// <param name="predicate">表达树</param>
        /// <returns>数量</returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 过滤条件获取数量
        /// </summary>
        /// <param name="predicate">表达树</param>
        /// <returns>数量</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取长类型数量
        /// </summary>
        /// <returns>long类型数量</returns>
        long LongCount();

        /// <summary>
        /// 获取长类型数量
        /// </summary>
        /// <returns>long类型数量</returns>
        Task<long> LongCountAsync();

        /// <summary>
        /// 获取长类型数量
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>long类型数量</returns>
        long LongCount(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取长类型数量
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>long类型数量</returns>
        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="id">id值</param>
        /// <returns>实体对象</returns>
        TEntity Get(TPrimaryKey id);

        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="id">id值</param>
        /// <returns>实体对象</returns>
        Task<TEntity> GetAsync(TPrimaryKey id);

        /// <summary>
        /// 更据条件获取第一个实体或默认
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>实体对象</returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据Id获取第一个实体或者默认
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns>实体对象</returns>
        TEntity FirstOrDefault(TPrimaryKey id);

        /// <summary>
        /// 更据条件获取第一个实体或默认
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>task实体对象</returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据Id获取第一个实体或者默认
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns>task实体对象</returns>
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>实体对象</returns>
        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>实体对象</returns>
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取IQueryable集合
        /// </summary>
        /// <returns>IQueryable集合</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// 根据条件获取IQueryable集合
        /// </summary>
        /// <param name="propertySelectors">条件</param>
        /// <returns>IQueryable集合</returns>
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

        /// <summary>
        /// 根据条件获取list集合
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>list集合</returns>
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取list集合
        /// </summary>
        /// <returns>list集合</returns>
        List<TEntity> GetAllList();

        /// <summary>
        /// 根据条件获取list集合
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>list集合</returns>
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取list集合
        /// </summary>
        /// <returns>list集合</returns>
        Task<List<TEntity>> GetAllListAsync();

        /// <summary>
        /// 根据主键加载实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体对象</returns>
        TEntity Load(TPrimaryKey id);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryMethod"></param>
        /// <returns></returns>
        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象</returns>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象</returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体主键</returns>
        TPrimaryKey InsertAndGetId(TEntity entity);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体主键</returns>
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);

        /// <summary>
        /// 添加或者更新实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象</returns>
        TEntity InsertOrUpdate(TEntity entity);

        /// <summary>
        /// 添加或者更新实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象</returns>
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);

        /// <summary>
        /// 添加或者更新实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体主键</returns>
        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);

        /// <summary>
        /// 添加或者更新实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体主键</returns>
        Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);


        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        ///  根据id删除实体
        /// </summary>
        /// <param name="id">主键ID</param>
        void Delete(TPrimaryKey id);

        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <param name="predicate">表达树</param>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据id删除实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>task</returns>
        Task DeleteAsync(TPrimaryKey id);

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>task</returns>
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>task</returns>
        Task DeleteAsync(TEntity entity);


        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="id">需要更新的实体主键</param>
        /// <param name="updateAction"></param>
        /// <returns>实体对象</returns>
        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="id">需要更新的实体主键</param>
        /// <param name="updateAction"></param>
        /// <returns>实体对象</returns>
        Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);
    }
}
