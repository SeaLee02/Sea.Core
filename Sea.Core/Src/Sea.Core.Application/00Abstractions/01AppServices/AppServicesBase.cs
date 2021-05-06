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
    public class AppServicesBase<TEntity, TPrimaryKey, TEntityDto, TCreateInput, TUpdateInput, TView> :
        IAppServicesBase<TEntity, TPrimaryKey, TEntityDto, TCreateInput, TUpdateInput, TView>
      where TEntity : class, IEntity<TPrimaryKey>
      where TEntityDto : class, IEntity<TPrimaryKey>
      where TCreateInput : class, IEntity<TPrimaryKey>
      where TUpdateInput : class, IEntity<TPrimaryKey>
      where TView : class, IEntity<TPrimaryKey>
    {



        public virtual Task BatchDelete(DeleteDto deleteDto)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntityDto> CreateByDto(TCreateInput input)
        {
            throw new NotImplementedException();
        }

        public virtual Task Delete(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<TEntityDto>> GetAllListDto()
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntityDto> GetDto(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<MyPagedResult<TEntityDto>> GetPage(PagedInputDto pagedInputDto)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TView> GetViewDto(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<MyPagedResult<TView>> GetViewPage(PagedInputDto pagedInputDto)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntityDto> UpdateByDto(TUpdateInput input)
        {
            throw new NotImplementedException();
        }


        public virtual Task<IQueryable<TEntity>> Queryable(Expression<Func<TEntity, bool>> expression) 
        {
            throw new NotImplementedException();
        }

        public virtual Task<IQueryable<TEntity>> Queryable()
        {
            throw new NotImplementedException();
        }
    }
}
