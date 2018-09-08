using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ESBPublic.Core.Repository
{
    /// <summary>
    /// Repository Class 
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public class Repository<TContext> : IRepository where TContext : DbContext, new()
    {

        #region Fields And Properties 

        /// <summary>
        /// The _entities
        /// </summary>
        private readonly DbContext _entities;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Repository{TResault}" /> class.
        /// </summary>
        public Repository()
        {
            _entities = new TContext();
        }


        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///   <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _entities?.Dispose();
            }
        }

        #endregion

        #region Select

        /// <summary>
        ///     Selects the one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns></returns>
        public T SelectOne<T>(Expression<Func<T, bool>> filterExpression) where T : class
        {
            var result = _entities.Set<T>().Where(filterExpression).FirstOrDefault();
            return result;
        }

        #endregion

    }
}