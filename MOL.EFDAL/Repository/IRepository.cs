using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MOL.EFDAL.Repository
{
    interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter);

        TEntity Single(Expression<Func<TEntity, bool>> filter);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter);

        TEntity GetById(long entityId);

        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Delete(long entityId);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        int Save();
    }
}
