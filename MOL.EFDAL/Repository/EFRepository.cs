using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MOL.EFDAL.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        #region [ Properties ]

        public MOLEFEntities Context;

        public readonly DbSet<TEntity> Table;

        #endregion

        #region [ Members ]

        public EFRepository()
        {
            this.Context = new MOLEFEntities();
            this.Table = Context.Set<TEntity>();
        }

        public EFRepository(MOLEFEntities context)
        {
            this.Context = context;
            this.Table = context.Set<TEntity>();
        }

        #endregion

        #region IRepository<TEntity> Members

        public IQueryable<TEntity> GetAll()
        {
            return this.Table;
        }

        public IQueryable<TEntity> Select(Expression<Func<TEntity, TEntity>> selector)
        {
            return this.Table.Select(selector);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter)
        {
            return this.Table.Where(filter).Select(s => s);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> filter)
        {
            return this.Table.Single(filter);
        }
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return this.Table.SingleOrDefault(filter);
        }

        public virtual TEntity GetById(long entityId)
        {
            return this.Table.Find(entityId);
        }

        public void Insert(TEntity entity)
        {
            this.Table.Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            this.Table.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            this.Table.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(long entityId)
        {
            var entity = this.GetById(entityId);
            if (entity != null)
            {
                this.Table.Remove(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            this.Table.Remove(entity);
        }
        public void Delete(IEnumerable<TEntity> entities)
        {
            this.Table.RemoveRange(entities);
        }

        public int Save()
        {
            return this.Context.SaveChanges();
        }

        #endregion

        #region IDisposable Members

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
