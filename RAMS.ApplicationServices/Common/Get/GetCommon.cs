// ***********************************************************************
// Assembly         : RAMS.ApplicationServices
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-12-2018
// ***********************************************************************
// <copyright file="GetCommon.svc.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.Repository;
using RAMS.CrossCutting;
using System;
namespace RAMS.ApplicationServices.Common
{
    /// <inheritdoc />
    /// <summary>
    /// Class GetCommon.
    /// </summary>
    /// <seealso cref="T:RAMS.CrossCutting.BaseDisposeClass" />
    /// <seealso cref="T:System.IDisposable" />
    public class GetCommon : BaseDisposeClass
    {
        /// <summary>
        /// Function returns system setting value
        /// Code Review (Done)
        /// </summary>
        /// <param name="targetSetting">The target setting.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>System.Int32</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public int GetSystemSettings(TypedObjects.SystemSettings targetSetting, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Read setting value from DB 
            var targetSystemSetting =
                    dbUnitOfWork.MOL_Srv_ServiceConfiguration_Repository.GetById(targetSetting.GetHashCode());

            //Return value to caller
            return Convert.ToInt32(targetSystemSetting.ConfigValue);
        }
    }
}
