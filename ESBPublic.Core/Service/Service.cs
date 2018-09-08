using ESBPublic.Core.Repository;
using System;
using System.Data.Entity;
using System.Linq.Expressions;

namespace ESBPublic.Core.Service
{
    public class Service<T, TContext> : IService<T> where T : class where TContext : DbContext, new()
    {

        #region Fields and Properties 

        /// <summary>
        ///     The _repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Service{T, TResault}" /> class.
        /// </summary>
        public Service()
        {
            _repository = new Repository<TContext>();
        }


        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
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
                _repository?.Dispose();
            }
        }


        #endregion

        #region Methods

        /// <summary>
        ///     Selects the one.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns></returns>
        public T SelectOne(Expression<Func<T, bool>> filterExpression)
        {
            return _repository.SelectOne(filterExpression);
        }

        #endregion

    }
}