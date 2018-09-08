// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="Extensions.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace RAMS.CrossCutting
{
    /// <summary>
    /// Class Extensions.
    /// </summary>
    public static class Extensions
    {
        #region "Entity Framework Extensions"

        /// <summary>
        /// To the hash set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>HashSet&lt;T&gt;.</returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            return source != null ? new HashSet<T>(source) : new HashSet<T>();
        }

        /// <summary>
        /// Gets the value or null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valueAsString">The value as string.</param>
        /// <returns>System.Nullable&lt;T&gt;.</returns>
        public static T? GetValueOrNull<T>(this string valueAsString) where T : struct
        {
            if (string.IsNullOrEmpty(valueAsString))
                return null;
            return (T)Convert.ChangeType(valueAsString, typeof(T));
        }

        #endregion

        #region "Public Functions"

        /// <summary>
        /// Gets the elementary request code.
        /// </summary>
        /// <param name="requestCode">The request code.</param>
        /// <returns>System.String[].</returns>
        public static string[] GetElementaryRequestCode(string requestCode)
        {
            return requestCode.Split(new char[1] { '-' });
        }

        /// <summary>
        /// Gets the request code.
        /// </summary>
        /// <param name="requestYear">The request year.</param>
        /// <param name="requestLaborOffice">The request labor office.</param>
        /// <param name="requestId">The request identifier.</param>
        /// <returns>System.String.</returns>
        public static string GetRequestCode(string requestYear, string requestLaborOffice, string requestId)
        {
            return $"{requestYear}-{requestLaborOffice}-{requestId}";
        }

        /// <summary>
        /// Gets the elementary request code.
        /// </summary>
        /// <param name="requestCode">The request code.</param>
        /// <param name="requestYear">The request year.</param>
        /// <param name="requestLaborOffice">The request labor office.</param>
        /// <param name="requestNumber">The request number.</param>
        public static void GetElementaryRequestCode(string requestCode,
            ref int requestYear, ref int requestLaborOffice, ref int requestNumber)
        {
            var results = requestCode.Split(new char[1] { '-' });
            if (results.Length == 3)
            {
                try
                {
                    requestYear = Convert.ToInt32(results[0]);
                    requestLaborOffice = Convert.ToInt32(results[1]);
                    requestNumber = Convert.ToInt32(results[2]);
                }
                catch
                {
                    //Request code is wrong
                    requestYear = requestLaborOffice = requestNumber = 0;
                }
            }
            else
            {
                //Request code is wrong
                requestYear = requestLaborOffice = requestNumber = 0;
            }
        }

        #endregion

    }
}
