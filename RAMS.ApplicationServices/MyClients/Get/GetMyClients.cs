// ***********************************************************************
// Assembly         : RAMS.ApplicationServices
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-12-2018
// ***********************************************************************
// <copyright file="GetMyClients.svc.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.Repository;
using RAMS.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RAMS.ApplicationServices.MyClients.Get
{
    /// <inheritdoc />
    /// <summary>
    /// Class GetMyClients.
    /// </summary>
    /// <seealso cref="T:RAMS.CrossCutting.BaseDisposeClass" />
    public class GetMyClients : BaseDisposeClass
    {
        #region " Public ESB Functions "

        #region "CRUD DB Operations"

        /// <summary>Gets laborer office list.</summary>
        /// <remarks>Wael Mohsen, 2018-05-03.</remarks>
        /// <exception cref="ArgumentException">Thrown when one or more arguments have unsupported or illegal values.</exception>
        /// <param name="userLaborerOffice">The user laborer office.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern.</param>
        /// <returns>The laborer office list.</returns>
        public HashSet<LaborOfficeInfo> GetRegionLaborerOfficeList(int? userLaborerOffice, UnitOfWork dbUnitOfWork)
        {
            //===================================================================================
            //Check input parameters is valid
            if (userLaborerOffice <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //====================================================================================
            // Get Data from DB
            var results = dbUnitOfWork.Lookup_Zone_Repository.GetZoneLaborerOffices(userLaborerOffice);

            //====================================================================================
            //Check if there is returned values
            if (results == null || !results.Any())
                return null;

            var returnResults = new HashSet<LaborOfficeInfo>();
            foreach (var currentRow in results)
                returnResults.Add(new LaborOfficeInfo { Id = currentRow.Id, Name = currentRow.Name });

            return returnResults;
        }

        /// <summary>
        /// Function returns list of Establishment RunAway requests based on Status (البت في بلاغ التغيب)
        /// </summary>
        /// <param name="filterType">Mandatory. Search filter type.</param>
        /// <param name="searchLaborerOfficeId">Optional. Search Laborer Office</param>
        /// <param name="establishmentLaborerOfficeId">Optional. Establishment Laborer Office Id</param>
        /// <param name="establishmentSequenceNumber">Optional. Establishment Sequence Number</param>
        /// <param name="queryRecordsCount">Mandatory. Number of records per query</param>
        /// <param name="currentPageIndex">Mandatory. Current OPage Index</param>
        /// <param name="numberOfDays">Allowed Number Of Days To Take Initial Action</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>List of available Requests</returns>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        /// <exception cref="System.ArgumentException"></exception>
        public HashSet<RunAwayApprovalRequestInfo> GetForApprovalRunAwayRequestsList(
            TypedObjects.ComplaintRequestStatus filterType,
            int? searchLaborerOfficeId, int? establishmentLaborerOfficeId, long? establishmentSequenceNumber,
            int queryRecordsCount, int currentPageIndex, int numberOfDays, UnitOfWork dbUnitOfWork)
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

            //====================================================================================
            long? establishmentId = null;
            if (establishmentLaborerOfficeId.HasValue)
            {
                //Get Establishment Info to search using it
                establishmentId =
                    dbUnitOfWork.MOL_Establishment_Repository.GetEstablishmentByLaborOfficeAndSequenceNumber(
                        establishmentLaborerOfficeId.Value, establishmentSequenceNumber.Value).EstablishmentId;
            }
            //====================================================================================
            //Read data value from DB 
            var results =
                dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.
                   GetForApprovalRunAwayRequestsList(
                     filterType.GetHashCode(),
                     searchLaborerOfficeId, establishmentId,
                     queryRecordsCount, currentPageIndex);

            //====================================================================================
            //Check if there is returned values
            if (results != null && results.Any())
            {
                var returnResults = new HashSet<RunAwayApprovalRequestInfo>();
                foreach (var currentRow in results)
                {
                    //Fill Object RunAway Info
                    returnResults.Add(
                        new RunAwayApprovalRequestInfo
                        {
                            RunAwayRequestId = Convert.ToInt32(currentRow.RunAwayRequestId),
                            RunAwayRequestNumber = currentRow.RunAwayRequestNumber,
                            EstablishmentTitle = currentRow.EstablishmentTitle,
                            RunAwayRequestDate = currentRow.RunAwayRequestDate,
                            RunAwayRequestStatusId = currentRow.RunAwayRequestStatusId,
                            RunAwayRequestStatusName =
                                TypedObjects.GetStatusName(
                                    TypedObjects.StatusType.RunAwayRequestStatus, currentRow.RunAwayRequestStatusId),
                            ComplaintRequestId = currentRow.ComplaintRequestId,
                            ComplaintRequestDate = currentRow.ComplaintRequestDate,
                            LaborOfficeReplyDetails = currentRow.LaborOfficeReplyDetails,
                            RejectReason = currentRow.RejectReason,
                            ComplaintRequestStatusId = currentRow.ComplaintRequestStatusId,
                            RunAwayFilesPaths = currentRow.RunAwayFilesPaths.ToHashSet(),
                            ComplaintFilesPaths = currentRow.ComplaintFilesPaths.ToHashSet(),
                            ComplaintRequestStatusName = TypedObjects.GetStatusName(
                                TypedObjects.StatusType.ComplaintRequestStatus, currentRow.ComplaintRequestStatusId),
                            LaborOfficeId = currentRow.LaborOfficeId,
                            SequenceNumber = currentRow.SequenceNumber,
                            LaborerBorderNumber = currentRow.LaborerBorderNumber,
                            LaborerFullName = currentRow.LaborerFullName,
                            LaborerIdNumber = currentRow.LaborerIdNumber,

                            RunAwayQuestion1 = currentRow.RunAwayQuestion1,
                            RunAwayQuestion2 = currentRow.RunAwayQuestion2,
                            RunAwayQuestion3 = currentRow.RunAwayQuestion3,
                            RunAwayQuestion4 = currentRow.RunAwayQuestion4,

                            ComplaintQuestion1 = currentRow.ComplaintQuestion1,
                            ComplaintQuestion2 = currentRow.ComplaintQuestion2,
                            ComplaintQuestion3 = currentRow.ComplaintQuestion3,
                            ComplaintQuestion4 = currentRow.ComplaintQuestion4,

                            IsBeyondInitialActionPeriod =
                                currentRow.ComplaintRequestDate.AddDays(numberOfDays) < DateTime.Now,
                            TotalRowsCount = currentRow.TotalRowsCount
                        });
                }

                //Return Object to Caller
                return returnResults;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Function returns list of Laborer Office RunAway requests (تدقيق بلاغ التغيب بمكتب العمل)
        /// </summary>
        /// <param name="userLaborOfficeId">The user labor office identifier.</param>
        /// <param name="filterStatusType">Type of the filter status.</param>
        /// <param name="establishmentLaborerOfficeId">The establishment laborer office identifier.</param>
        /// <param name="establishmentSequenceNumber">The establishment sequence number.</param>
        /// <param name="searchLaborerIdNumber">The search laborer identifier number.</param>
        /// <param name="searchLaborerBorderNumber">The search laborer border number.</param>
        /// <param name="searchRequestNumber">The search request number.</param>
        /// <param name="queryRecordsCount">The query records count.</param>
        /// <param name="currentPageIndex">Index of the current page.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>List of available Requests</returns>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        /// <exception cref="System.ArgumentException"></exception>
        public HashSet<RunAwayReviewRequestsInfo> GetForReviewRunAwayRequestsList(
            int userLaborOfficeId, TypedObjects.ComplaintRequestStatus filterStatusType,
            int? establishmentLaborerOfficeId, long? establishmentSequenceNumber,
            long? searchLaborerIdNumber, long? searchLaborerBorderNumber, string searchRequestNumber,
            int queryRecordsCount, int currentPageIndex, UnitOfWork dbUnitOfWork)
        {
            //=========================================================================
            //Check input parameters is valid
            if (dbUnitOfWork == null ||
                (searchLaborerIdNumber.HasValue && searchLaborerBorderNumber.HasValue) ||
                (queryRecordsCount <= 0 || currentPageIndex < 0 || userLaborOfficeId <= 0) ||
                (establishmentSequenceNumber > 0 && establishmentLaborerOfficeId <= 0))
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //=========================================================================
            long? searchEstablishmentId = null;
            if (establishmentLaborerOfficeId.HasValue && establishmentSequenceNumber.HasValue)
            {
                //Get Establishment Info to search using it
                searchEstablishmentId =
                    dbUnitOfWork.MOL_Establishment_Repository.GetEstablishmentByLaborOfficeAndSequenceNumber(
                        establishmentLaborerOfficeId.Value, establishmentSequenceNumber.Value).EstablishmentId;
            }

            //Read setting value from DB 

            var results =
                dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.GetForReviewRunAwayRequestsList(
                    userLaborOfficeId, filterStatusType.GetHashCode(), searchEstablishmentId,
                    searchLaborerIdNumber, searchLaborerBorderNumber, searchRequestNumber,
                    queryRecordsCount, currentPageIndex, out var totalRowsCount);

            //Check if there is returned values
            if (results != null && results.Any())
            {
                var returnResults = new HashSet<RunAwayReviewRequestsInfo>();
                foreach (var currentRow in results)
                {
                    //Fill Object RunAway Info
                    returnResults.Add(
                        new RunAwayReviewRequestsInfo
                        {
                            RunAwayRequestId = Convert.ToInt32(currentRow.RunAwayRequestId),
                            RunAwayRequestNumber = currentRow.RunAwayRequestNumber,
                            EstablishmentTitle = currentRow.EstablishmentTitle,
                            RunAwayRequestDate = currentRow.RunAwayRequestDate,
                            RunAwayRequestStatusId = currentRow.RunAwayRequestStatusId,
                            RunAwayRequestStatusName =
                                TypedObjects.GetStatusName(
                                    TypedObjects.StatusType.RunAwayRequestStatus, currentRow.RunAwayRequestStatusId),
                            ComplaintRequestId = currentRow.ComplaintRequestId,
                            ComplaintRequestDate = currentRow.ComplaintRequestDate,
                            LaborOfficeReplyDetails = currentRow.LaborOfficeReplyDetails,
                            ComplaintRequestStatusId = currentRow.ComplaintRequestStatusId,
                            RunAwayFilesPaths = currentRow.RunAwayFilesPaths.ToHashSet(),
                            ComplaintFilesPaths = currentRow.ComplaintFilesPaths.ToHashSet(),
                            ComplaintRequestStatusName = TypedObjects.GetStatusName(
                                TypedObjects.StatusType.ComplaintRequestStatus, currentRow.ComplaintRequestStatusId),
                            LaborOfficeId = currentRow.LaborOfficeId,
                            SequenceNumber = currentRow.SequenceNumber,
                            LaborerBorderNumber = currentRow.LaborerBorderNumber,
                            LaborerFullName = currentRow.LaborerFullName,
                            LaborerIdNumber = currentRow.LaborerIdNumber,

                            RunAwayQuestion1 = currentRow.RunAwayQuestion1,
                            RunAwayQuestion2 = currentRow.RunAwayQuestion2,
                            RunAwayQuestion3 = currentRow.RunAwayQuestion3,
                            RunAwayQuestion4 = currentRow.RunAwayQuestion4,

                            ComplaintQuestion1 = currentRow.ComplaintQuestion1,
                            ComplaintQuestion2 = currentRow.ComplaintQuestion2,
                            ComplaintQuestion3 = currentRow.ComplaintQuestion3,
                            ComplaintQuestion4 = currentRow.ComplaintQuestion4,

                            TotalRowsCount = totalRowsCount
                        });
                }

                //Return Object to Caller
                return returnResults;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #endregion
    }
}
