using System;
using System.Linq.Expressions;

namespace ESBPublic.Core.Service
{
    public interface IService<T> : IDisposable
    {
        #region Select

        /// <summary>
        ///     Selects the one.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns></returns>
        T SelectOne(Expression<Func<T, bool>> filterExpression);

        #endregion

    }
}