using Microsoft.EntityFrameworkCore;
using Sea.Core.Application.Abstractions.Repositories.Base;
using Sea.Core.Entity.Framework.Entity.Abstractions;
using Sea.Core.Util.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sea.Core.Application.Abstractions.Repositories
{

    public class EFCoreRepositoryBase<TDbContext, TEntity, TPrimaryKey> :  //一个类用来继承IRepositories
        Repository<TEntity, TPrimaryKey>
          where TEntity : class, IEntity<TPrimaryKey>
           where TDbContext : DbContext
    {
        private readonly TDbContext _db;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext"></param>
        public EFCoreRepositoryBase(TDbContext db)
        {
            _db = db;
        }

        public virtual DbSet<TEntity> Table => _db.Set<TEntity>();

        /// <summary>
        /// 获取该表的所有数据
        /// </summary>
        /// <returns></returns>
        public override IQueryable<TEntity> GetAll()
        {
            return this.GetAllIncluding(Array.Empty<Expression<Func<TEntity, object>>>());
        }

        public override IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            IQueryable<TEntity> queryable = ((IEnumerable<TEntity>)Table).AsQueryable();
            if (!CollectionEx.IsNullOrEmpty<Expression<Func<TEntity, object>>>(propertySelectors))
            {
                foreach (Expression<Func<TEntity, object>> expression in propertySelectors)
                {
                    queryable = queryable.Include<TEntity, object>(expression);
                }
            }
            return queryable;
        }


        public override async Task<List<TEntity>> GetAllListAsync()
        {
            //return await Task.FromResult(GetAllList());

            return await EntityFrameworkQueryableExtensions.ToListAsync<TEntity>(this.GetAll(), default(CancellationToken));
        }

        public override async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            //return await Task.FromResult(GetAllList(predicate));
            return await EntityFrameworkQueryableExtensions.ToListAsync<TEntity>(this.GetAll().Where(predicate), default(CancellationToken));
        }


        public override async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().SingleAsync(predicate);
        }

        public override async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await GetAll().FirstOrDefaultAsync(CreateEqualityExpressionForId(id));
        }

        public override async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().FirstOrDefaultAsync(predicate);
        }

        public override TEntity Insert(TEntity entity)
        {
            return Table.Add(entity).Entity;
        }

        public override Task<TEntity> InsertAsync(TEntity entity)
        {
            return Task.FromResult(Insert(entity));
        }

        public override TPrimaryKey InsertAndGetId(TEntity entity)
        {
            entity = Insert(entity);

            if (entity.IsTransient())
            {
                _db.SaveChanges();
            }

            return entity.Id;
        }

        public override async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            entity = await InsertAsync(entity);

            if (entity.IsTransient())
            {
                await _db.SaveChangesAsync();
            }

            return entity.Id;
        }

        public override TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            entity = InsertOrUpdate(entity);

            if (entity.IsTransient())
            {
                _db.SaveChanges();
            }

            return entity.Id;
        }

        public override async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            entity = await InsertOrUpdateAsync(entity);

            if (entity.IsTransient())
            {
                await _db.SaveChangesAsync();
            }

            return entity.Id;
        }


        public override TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            _db.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public override Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity = Update(entity);
            return Task.FromResult(entity);
        }




        public override void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
        }

        public override void Delete(TPrimaryKey id)
        {
            var entity = GetFromChangeTrackerOrNull(id);
            if (entity != null)
            {
                Delete(entity);
                return;
            }
            entity = FirstOrDefault(id);
            if (entity != null)
            {
                Delete(entity);
                return;
            }
        }

        public override async Task<int> CountAsync()
        {
            return await GetAll().CountAsync();
        }

        public override async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).CountAsync();
        }

        public override async Task<long> LongCountAsync()
        {
            return await GetAll().LongCountAsync();
        }

        public override async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).LongCountAsync();
        }


        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = _db.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            Table.Attach(entity);
        }

        private TEntity GetFromChangeTrackerOrNull(TPrimaryKey id)
        {
            var entry = _db.ChangeTracker.Entries()
                .FirstOrDefault(
                    ent =>
                        ent.Entity is TEntity &&
                        EqualityComparer<TPrimaryKey>.Default.Equals(id, (ent.Entity as TEntity).Id)
                );

            return entry?.Entity as TEntity;
        }
    }
}
