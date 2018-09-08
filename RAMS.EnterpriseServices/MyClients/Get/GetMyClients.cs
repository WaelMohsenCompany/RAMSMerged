// ***********************************************************************
// Assembly         : RAMS.EnterpriseServices
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-15-2018
// ***********************************************************************
// <copyright file="GetMyClients.svc.cs" company="Tasleem IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.Repository;
using RAMS.ApplicationServices.Common;
using RAMS.CrossCutting;
using System;
using System.Collections.Generic;

namespace RAMS.EnterpriseServices.MyClients.Get
{
    /// <inheritdoc />
    /// <summary>
    /// Class GetMyClients.
    /// </summary>
    /// <seealso cref="T:RAMS.CrossCutting.BaseDisposeClass" />
    public class GetMyClients : BaseDisposeClass
    {
        #region "Private Members"

        /// <summary>
        /// Get Laborer Business Rules and Data property
        /// </summary>
        /// <value>As get my clients instance.</value>
        private ApplicationServices.MyClients.Get.GetMyClients ASGetMyClientsInstance { get; set; }

        /// <summary>Gets or sets as get common instance.</summary>
        /// <value>as get common instance.</value>
        private GetCommon ASGetCommonInstance { get; set; }

        #endregion

        #region " Public ESB Functions "

        #region "CRUD DB Operations"

        /// <summary>Gets laborer office list.</summary>
        /// <remarks>Wael Mohsen, 2018-05-03.</remarks>
        /// <exception cref="ArgumentException">Thrown when one or more arguments have unsupported or illegal values.</exception>
        /// <param name="userLaborerOffice">The user laborer office.</param>
        /// <returns>The laborer office list.</returns>
        public HashSet<LaborOfficeInfo> GetRegionLaborerOfficeList(int? userLaborerOffice)
        {
            //===================================================================================
            //Check input parameters is valid
            if (userLaborerOffice <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //==================================================================================
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (ASGetMyClientsInstance = new ApplicationServices.MyClients.Get.GetMyClients())
            {
                return ASGetMyClientsInstance.GetRegionLaborerOfficeList(userLaborerOffice, dbUnitOfWork);
            }
        }

        /// <summary>
        /// Function returns list of Establishment RunAway requests based on Status (البت في بلاغ التغيب)
        /// </summary>
        /// <param name="filterType">Mandatory. Search filter type.</param>
        /// <param name="searchLaborerOfficeId">Optional. Search Laborer Office</param>
        /// <param name="establishmentLaborerOfficeId">Optional. Establishment Laborer Office Id</param>
        /// <param name="establishmentSequenceNumber">Optional. Establishment Sequence Number</param>
        /// <param name="queryRecordsCount">Mandatory. Number of records per query</param>
        /// <param name="currentPageIndex">Mandatory. Current Page Index</param>
        /// <returns>List of available Requests</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public HashSet<RunAwayApprovalRequestInfo> GetForApprovalRunAwayRequestsList(
            TypedObjects.ComplaintRequestStatus filterType,
            int? searchLaborerOfficeId, int? establishmentLaborerOfficeId, long? establishmentSequenceNumber,
            int queryRecordsCount, int currentPageIndex)
        {
            //=========================================================================
            //Check input parameters is valid
            if (queryRecordsCount <= 0 || currentPageIndex < 0 ||
                (searchLaborerOfficeId.HasValue && searchLaborerOfficeId.Value < 0) ||

                (establishmentLaborerOfficeId.HasValue && !establishmentSequenceNumber.HasValue) ||
                (establishmentSequenceNumber.HasValue && !establishmentLaborerOfficeId.HasValue) ||

                (establishmentLaborerOfficeId.HasValue && establishmentLaborerOfficeId <= 0) ||
                (establishmentSequenceNumber.HasValue && establishmentSequenceNumber <= 0))

                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //==================================================================================
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (ASGetMyClientsInstance = new ApplicationServices.MyClients.Get.GetMyClients())
            using (ASGetCommonInstance = new GetCommon())
            {
                //====================================================================================
                var numberOfDays = ASGetCommonInstance.GetSystemSettings(
                    TypedObjects.SystemSettings.AllowedNumberOfDaysToTakeInitialAction, dbUnitOfWork);

                //Get For Approval RunAway Requests List
                return
                    ASGetMyClientsInstance.GetForApprovalRunAwayRequestsList(filterType,
                        searchLaborerOfficeId, establishmentLaborerOfficeId, establishmentSequenceNumber,
                        queryRecordsCount, currentPageIndex, numberOfDays, dbUnitOfWork);
            }
        }

        /// <summary>
        /// Function returns list of Laborer Office RunAway requests (تدقيق بلاغ التغيب بمكتب العمل)
        /// </summary>
        /// <param name="userLaborOfficeId">Mandatory. User laborer Office.</param>
        /// <param name="filterType">Mandatory. Search filter type.</param>
        /// <param name="establishmentLaborerOfficeId">Optional. Establishment Laborer OfficeId</param>
        /// <param name="establishmentSequenceNumber">Optional. Establishment Laborer Office Sequence Number</param>
        /// <param name="laborerIdNumber">&gt;Optional. Laborer ID Number</param>
        /// <param name="laborerBorderNumber">&gt;Optional. Laborer border Number</param>
        /// <param name="requestCode">&gt;Optional. Request Code</param>
        /// <param name="queryRecordsCount">Mandatory. Number of records per query</param>
        /// <param name="currentPageIndex">Mandatory. Current Page Index</param>
        /// <returns>HashSet&lt;RunAwayReviewRequestsInfo&gt;.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public HashSet<RunAwayReviewRequestsInfo> GetForReviewRunAwayRequestsList(
            int userLaborOfficeId, TypedObjects.ComplaintRequestStatus filterType,
            int? establishmentLaborerOfficeId, long? establishmentSequenceNumber,
            long? laborerIdNumber, long? laborerBorderNumber, string requestCode,
            int queryRecordsCount, int currentPageIndex)
        {
            //=========================================================================
            //Check input parameters is valid
            if (queryRecordsCount <= 0 || currentPageIndex < 0 ||
                (establishmentSequenceNumber.HasValue && !establishmentLaborerOfficeId.HasValue) ||
                (establishmentLaborerOfficeId.HasValue && establishmentLaborerOfficeId <= 0) ||
                (establishmentSequenceNumber.HasValue && establishmentSequenceNumber <= 0) ||

                (laborerIdNumber.HasValue && laborerBorderNumber.HasValue) ||
                (laborerIdNumber.HasValue && laborerIdNumber.Value <= 0) ||
                (laborerBorderNumber.HasValue && laborerBorderNumber.Value <= 0))

                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //==================================================================================
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (ASGetMyClientsInstance = new ApplicationServices.MyClients.Get.GetMyClients())
            {
                //====================================================================================
                //Get For Review RunAway Requests List
                return
                    ASGetMyClientsInstance.GetForReviewRunAwayRequestsList(
                        userLaborOfficeId, filterType, establishmentLaborerOfficeId, establishmentSequenceNumber,
                        laborerIdNumber, laborerBorderNumber, requestCode, queryRecordsCount, currentPageIndex - 1, dbUnitOfWork);
            }
        }

        #endregion

        #endregion
    }
}
