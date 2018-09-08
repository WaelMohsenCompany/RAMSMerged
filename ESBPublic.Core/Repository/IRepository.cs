using System;
using System.Linq.Expressions;

namespace ESBPublic.Core.Repository
{
    public interface IRepository : IDisposable
    {
        #region Select

        /// <summary>
        ///     Selects the one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns></returns>
        T SelectOne<T>(Expression<Func<T, bool>> filterExpression) where T : class;

        #endregion
    } 
}