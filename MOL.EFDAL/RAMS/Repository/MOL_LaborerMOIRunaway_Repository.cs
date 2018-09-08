
// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-04-2018
// ***********************************************************************
// <copyright file="MOL_LaborerMOIRunaway_Repository.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.ComplexTypes;
using MOL.EFDAL.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    /// <summary>
    /// Class MOL_LaborerMOIRunaway_Repository.
    /// </summary>
    /// <seealso cref="MOL_LaborerMOIRunaway" />
    public partial class MOL_LaborerMOIRunaway_Repository
    {
        #region "Select Methods"

        /// <summary>
        /// Function returns list of Establishment RunAway requests for specific Establishment agent
        /// </summary>
        /// <param name="applicantUserIdNumber">The user identifier ID.</param>
        /// <param name="laborOfficeId">The establishment laborer office number.</param>
        /// <param name="sequenceNumber">The establishment sequence number.</param>
        /// <param name="numberOfMonths">Number of months allowed to get data for</param>
        /// <param name="queryRecordsCount">The query records count.</param>
        /// <param name="currentPageIndex">Index of the current page.</param>
        /// <returns>List of available Appointments</returns>
        public IQueryable<RunAwayRetrieveRequestInfo> GetAllRunAwayRequestsList(
            long applicantUserIdNumber, int laborOfficeId, long sequenceNumber, int numberOfMonths,
            int queryRecordsCount, int currentPageIndex)
        {
            var fetchingMonths = DateTime.Now.AddMonths(-numberOfMonths);

            //===================================================================================
            //Select total number of row
            var rowsCount =
                Select(rows => rows)
                    .Count(r =>
                        (r.CreatedByIdNumber == applicantUserIdNumber || r.ApplicantUserIdNumber == applicantUserIdNumber) &&
                        (r.LaborerOfficeId == laborOfficeId && r.SequenceNumber == sequenceNumber) &&
                        r.CreatedOn > fetchingMonths);

            if (rowsCount == 0)
                return null;

            //===================================================================================
            //Select target rows form database
            //Eager Loading for File paths
            //Eager loading means that the related data is loaded from the database as part of the initial query
            return
                 this.Context.MOL_LaborerMOIRunaway
                    .GroupJoin(Context.MOL_RunAwayComplaints, runawayRequests => new { runawayRequests.ID },
                        MOL_RunAwayComplaints => new { ID = MOL_RunAwayComplaints.RunAwayRequestId.Value },
                        (runawayRequests, MOL_RunAwayComplaints_join) =>
                            new { runawayRequests, MOL_RunAwayComplaints_join })

                        .SelectMany(@t => @t.MOL_RunAwayComplaints_join.DefaultIfEmpty(),
                            (@t, complaintsRequests) => new { @t, complaintsRequests })

                        .Where(@t =>
                        (@t.@t.runawayRequests.CreatedByIdNumber == applicantUserIdNumber ||
                          @t.@t.runawayRequests.ApplicantUserIdNumber == applicantUserIdNumber) &&
                        (@t.@t.runawayRequests.LaborerOfficeId == laborOfficeId &&
                          @t.@t.runawayRequests.SequenceNumber == sequenceNumber) &&
                             @t.@t.runawayRequests.CreatedOn > fetchingMonths)

                    .Select(@t => (new RunAwayRetrieveRequestInfo
                    {
                        RequestId = @t.@t.runawayRequests.ID,
                        RequestNumber = @t.@t.runawayRequests.RequestNumber,

                        EstablishmentTitle = @t.@t.runawayRequests.EstablishmentTitle,
                        EstablishmentId = @t.@t.runawayRequests.EstablishmentId,
                        LaborerOfficeId = @t.@t.runawayRequests.LaborerOfficeId.Value,
                        SequenceNumber = @t.@t.runawayRequests.SequenceNumber.Value,

                        LaborerIdNumber = @t.@t.runawayRequests.IDNumber,
                        LaborerBorderNumber = @t.@t.runawayRequests.LaborerBorderNumber.Value,
                        LaborerFullName = @t.@t.runawayRequests.LaborerFullName,

                        CreationQuestion1 = @t.@t.runawayRequests.CreationQuestion1,
                        CreationQuestion2 = @t.@t.runawayRequests.CreationQuestion2,
                        CreationQuestion3 = @t.@t.runawayRequests.CreationQuestion3,
                        CreationQuestion4 = @t.@t.runawayRequests.CreationQuestion4,

                        RequestDate = @t.@t.runawayRequests.CreatedOn,
                        RunAwayRequestStatusId = @t.@t.runawayRequests.RequestStatusId.Value,
                        FilesPaths =
                           @t.@t.runawayRequests.MOL_RAMS_RunAway_Files.Select(files => files.FileName).ToList(),
                        ComplaintRequestId = @t.complaintsRequests.ComplaintID,
                        TotalRowsCount = rowsCount
                    }))
                    .OrderByDescending(row => row.RequestId)
                    .Skip(queryRecordsCount * currentPageIndex)
                    .Take(queryRecordsCount);
        }

        /// <summary>
        /// Function returns Establishment RunAway request by IdNumber or BorderNumber
        /// </summary>
        /// <param name="applicantUserIdNumber">The user identifier number.</param>
        /// <param name="laborOfficeId">The establishment laborer office number.</param>
        /// <param name="sequenceNumber">The establishment sequence number.</param>
        /// <param name="laborerIdNumber">Laborer ID Number</param>
        /// <param name="borderNumber">Laborer Border Number</param>
        /// <returns>Target RunAway Request</returns>
        public RunAwayRetrieveRequestInfo GetRunAwayRequestInfo(
            long applicantUserIdNumber, int laborOfficeId, long sequenceNumber,
            long? laborerIdNumber, long? borderNumber)
        {
            //Define target laborer identifier value
            var laborerIdentifier = laborerIdNumber ?? borderNumber;

            //===================================================================================
            //Select target rows form database
            //Eager Loading for File paths
            //Eager loading means that the related data is loaded from the database as part of the initial query
            return
                this.Context.MOL_LaborerMOIRunaway
                    .GroupJoin(Context.MOL_RunAwayComplaints, runawayRequests => new { runawayRequests.ID },
                        MOL_RunAwayComplaints => new { ID = MOL_RunAwayComplaints.RunAwayRequestId.Value },
                        (runawayRequests, MOL_RunAwayComplaints_join) =>
                            new { runawayRequests, MOL_RunAwayComplaints_join })

                    .SelectMany(@t => @t.MOL_RunAwayComplaints_join.DefaultIfEmpty(),
                        (@t, complaintsRequests) => new { @t, complaintsRequests })

                    .Where(@t =>
                        (@t.@t.runawayRequests.CreatedByIdNumber == applicantUserIdNumber ||
                         @t.@t.runawayRequests.ApplicantUserIdNumber == applicantUserIdNumber) &&
                        (@t.@t.runawayRequests.LaborerOfficeId == laborOfficeId &&
                         @t.@t.runawayRequests.SequenceNumber == sequenceNumber) &&
                        (@t.@t.runawayRequests.IDNumber == laborerIdentifier ||
                         @t.@t.runawayRequests.LaborerBorderNumber == laborerIdentifier))

                    .OrderByDescending(@joinedTable => @joinedTable.t.runawayRequests.ID)
                    .Take(1)

                    .Select(@t => new RunAwayRetrieveRequestInfo
                    {
                        RequestId = @t.@t.runawayRequests.ID,
                        RequestNumber = @t.@t.runawayRequests.RequestNumber,

                        EstablishmentTitle = @t.@t.runawayRequests.EstablishmentTitle,
                        EstablishmentId = @t.@t.runawayRequests.EstablishmentId,
                        LaborerOfficeId = @t.@t.runawayRequests.LaborerOfficeId.Value,
                        SequenceNumber = @t.@t.runawayRequests.SequenceNumber.Value,

                        LaborerIdNumber = @t.@t.runawayRequests.IDNumber,
                        LaborerBorderNumber = @t.@t.runawayRequests.LaborerBorderNumber.Value,
                        LaborerFullName = @t.@t.runawayRequests.LaborerFullName,

                        CreationQuestion1 = @t.@t.runawayRequests.CreationQuestion1,
                        CreationQuestion2 = @t.@t.runawayRequests.CreationQuestion2,
                        CreationQuestion3 = @t.@t.runawayRequests.CreationQuestion3,
                        CreationQuestion4 = @t.@t.runawayRequests.CreationQuestion4,

                        RequestDate = @t.@t.runawayRequests.CreatedOn,
                        RunAwayRequestStatusId = @t.@t.runawayRequests.RequestStatusId.Value,
                        FilesPaths =
                            @t.@t.runawayRequests.MOL_RAMS_RunAway_Files.Select(files => files.FileName).ToList(),

                        ComplaintRequestId = @t.complaintsRequests.ComplaintID
                    }).SingleOrDefault();
        }

        /// <summary>
        /// Function returns Establishment RunAway request by Request Primary Key (Id)
        /// GetRunAwayRequestByNumber
        /// </summary>
        /// <param name="requestId">The user identifier number.</param>
        /// <returns>Target RunAway Request</returns>
        public RunAwayRetrieveRequestInfo GetRunAwayRequestInfo(int requestId)
        {
            //Select target rows form database
            //Eager Loading for File paths
            //Eager loading means that the related data is loaded from the database as part of the initial query
            return
                this.Context.MOL_LaborerMOIRunaway
                    .GroupJoin(Context.MOL_RunAwayComplaints, runawayRequests => new { runawayRequests.ID },
                        MOL_RunAwayComplaints => new { ID = MOL_RunAwayComplaints.RunAwayRequestId.Value },
                        (runawayRequests, MOL_RunAwayComplaints_join) =>
                            new { runawayRequests, MOL_RunAwayComplaints_join })

                    .SelectMany(@t => @t.MOL_RunAwayComplaints_join.DefaultIfEmpty(),
                        (@t, complaintsRequests) => new { @t, complaintsRequests })

                    .Where(@t => @t.@t.runawayRequests.ID == requestId)

                    .OrderByDescending(@joinedTable => @joinedTable.t.runawayRequests.ID)
                    .Take(1)

                    .Select(@t => new RunAwayRetrieveRequestInfo
                    {
                        RequestId = @t.@t.runawayRequests.ID,
                        RequestNumber = @t.@t.runawayRequests.RequestNumber,

                        EstablishmentTitle = @t.@t.runawayRequests.EstablishmentTitle,
                        EstablishmentId = @t.@t.runawayRequests.EstablishmentId,
                        LaborerOfficeId = @t.@t.runawayRequests.LaborerOfficeId.Value,
                        SequenceNumber = @t.@t.runawayRequests.SequenceNumber.Value,

                        LaborerIdNumber = @t.@t.runawayRequests.IDNumber,
                        LaborerBorderNumber = @t.@t.runawayRequests.LaborerBorderNumber.Value,
                        LaborerFullName = @t.@t.runawayRequests.LaborerFullName,

                        CreationQuestion1 = @t.@t.runawayRequests.CreationQuestion1,
                        CreationQuestion2 = @t.@t.runawayRequests.CreationQuestion2,
                        CreationQuestion3 = @t.@t.runawayRequests.CreationQuestion3,
                        CreationQuestion4 = @t.@t.runawayRequests.CreationQuestion4,

                        RequestDate = @t.@t.runawayRequests.CreatedOn,
                        RunAwayRequestStatusId = @t.@t.runawayRequests.RequestStatusId.Value,
                        FilesPaths =
                            @t.@t.runawayRequests.MOL_RAMS_RunAway_Files.Select(files => files.FileName).ToList(),

                        ComplaintRequestId = @t.complaintsRequests.ComplaintID
                    }).SingleOrDefault();
        }

        /// <summary>
        /// Function get Latest Laborer Runaway request along with it Complaint request
        /// using left outer join between tables
        /// </summary>
        /// <param name="laborerIdNumber">Laborer Id Number</param>
        /// <param name="borderNumber">Laborer Boarder Number</param>
        /// <param name="systemNumberOfDays">Number of allowed days to create complaint request</param>
        /// <returns>ComplaintRetrieveRequestInfo.</returns>
        public ComplaintRetrieveRequestInfo GetLatestRunAwayOrComplaintRequest(
            long? laborerIdNumber, long? borderNumber, int systemNumberOfDays)
        {
            //Define target laborer identifier value
            var laborerIdentifier = laborerIdNumber ?? borderNumber;

            //===================================================================================
            //Check if laborer has a Runaway request 
            var rowsCount =
                Select(rows => rows).Count(r =>
                    ((r.IDNumber == laborerIdentifier || r.LaborerBorderNumber == laborerIdentifier) &&
                    DbFunctions.AddDays(r.CreatedOn, systemNumberOfDays) > DateTime.Now));

            if (rowsCount == 0)
                return null;

            //===================================================================================
            // Get Data from DB
            return
                    this.Context.MOL_LaborerMOIRunaway
                    .GroupJoin(Context.MOL_RunAwayComplaints, runawayRequests => new { runawayRequests.ID },
                        MOL_RunAwayComplaints => new { ID = MOL_RunAwayComplaints.RunAwayRequestId.Value },
                        (runawayRequests, MOL_RunAwayComplaints_join) =>
                            new { runawayRequests, MOL_RunAwayComplaints_join })

                        .SelectMany(@t => @t.MOL_RunAwayComplaints_join.DefaultIfEmpty(),
                            (@t, complaintsRequests) => new { @t, complaintsRequests })

                        .Where(@t => @t.@t.runawayRequests.IDNumber == laborerIdentifier ||
                                     @t.@t.runawayRequests.LaborerBorderNumber == laborerIdentifier)

                        .OrderByDescending(@t => @t.@t.runawayRequests.ID)
                        .Take(1)

                        .Select(@t => (new ComplaintRetrieveRequestInfo
                        {
                            RunAwayRequestId = @t.@t.runawayRequests.ID,
                            RunAwayRequestNumber = @t.@t.runawayRequests.RequestNumber,
                            EstablishmentTitle = @t.@t.runawayRequests.EstablishmentTitle,
                            RunAwayRequestDate = @t.@t.runawayRequests.CreatedOn,
                            RunAwayRequestStatusId = @t.@t.runawayRequests.RequestStatusId.Value,

                            ComplaintRequestId = @t.complaintsRequests.ComplaintID,
                            ComplaintRequestDate = @t.complaintsRequests.ComplaintDate,
                            RejectReason = @t.complaintsRequests.RejectReason,
                            ComplaintRequestStatusId = @t.complaintsRequests.Status,
                            ComplaintQuestion1 = @t.complaintsRequests.ComplaintQuestion1,
                            ComplaintQuestion2 = @t.complaintsRequests.ComplaintQuestion2,
                            ComplaintQuestion3 = @t.complaintsRequests.ComplaintQuestion3,
                            ComplaintQuestion4 = @t.complaintsRequests.ComplaintQuestion4,
                            LaborerMobileNo = @t.complaintsRequests.LaborerMobileNo,

                            FilesPaths =
                                @t.complaintsRequests.MOL_RAMS_Complaint_Files.Select(files => files.FileName).ToList()
                        })).SingleOrDefault();
        }

        /// <summary>
        /// Function returns list of Establishment RunAway requests based on Status (البت في بلاغ التغيب)
        /// </summary>
        /// <param name="filterStatusType">Mandatory. Search filter type.</param>
        /// <param name="searchLaborerOfficeId">Optional. Search Laborer Office</param>
        /// <param name="establishmentId">Optional. Establishment Id</param>
        /// <param name="queryRecordsCount">Mandatory. Number of records per query</param>
        /// <param name="currentPageIndex">Mandatory. Current OPage Index</param>
        /// <returns>List of available Requests</returns>
        public IQueryable<RunAwayApprovalRequestInfo> GetForApprovalRunAwayRequestsList(
            int filterStatusType, int? searchLaborerOfficeId, long? establishmentId,
            int queryRecordsCount, int currentPageIndex)
        {
            var totalRowsCount = 0;
            //===================================================================================
            //Select target rows form database
            if (searchLaborerOfficeId.HasValue && establishmentId.HasValue)
            {
                #region "Both values are NOT NULL"

                //Select total rows count for paging
                totalRowsCount =
                    Context.MOL_LaborerMOIRunaway.GroupJoin(Context.MOL_RunAwayComplaints,
                        runawayRequests => new { ID = runawayRequests.ID },
                        complaintsRequests => new { ID = complaintsRequests.RunAwayRequestId.Value },
                        (runawayRequests, MOL_RunAwayComplaints_join) =>
                            new { runawayRequests, MOL_RunAwayComplaints_join })
                        .SelectMany(@t => @t.MOL_RunAwayComplaints_join.DefaultIfEmpty(),
                            (@t, complaintsRequests) => new { @t, complaintsRequests })

                         .Count(@t => @t.@t.runawayRequests.IsCancelRunaway == false &&
                                @t.complaintsRequests.Status == filterStatusType &&
                                @t.@t.runawayRequests.LaborerOfficeId == searchLaborerOfficeId &&
                                 @t.@t.runawayRequests.EstablishmentId == establishmentId);

                //Select data from DB
                return
                   (from runawayRequests in Context.MOL_LaborerMOIRunaway
                    join complaintRequests in Context.MOL_RunAwayComplaints on new { ID = runawayRequests.ID }
                        equals new { ID = complaintRequests.RunAwayRequestId.Value } into
                        MOL_RunAwayComplaints_join

                    from complaintsRequests in MOL_RunAwayComplaints_join.DefaultIfEmpty()
                    where
                        runawayRequests.IsCancelRunaway == false &&
                        complaintsRequests.Status == filterStatusType &&
                        runawayRequests.LaborerOfficeId == searchLaborerOfficeId &&
                        runawayRequests.EstablishmentId == establishmentId

                    orderby runawayRequests.ID ascending

                    select new RunAwayApprovalRequestInfo
                    {
                        RunAwayRequestId = runawayRequests.ID,
                        RunAwayRequestNumber = runawayRequests.RequestNumber,
                        EstablishmentTitle = runawayRequests.EstablishmentTitle,
                        LaborOfficeId = runawayRequests.LaborerOfficeId.Value,
                        SequenceNumber = runawayRequests.SequenceNumber.Value,
                        LaborerIdNumber = runawayRequests.IDNumber,
                        LaborerBorderNumber = runawayRequests.LaborerBorderNumber.Value,
                        LaborerFullName = runawayRequests.LaborerFullName,
                        RunAwayRequestDate = runawayRequests.CreatedOn,
                        RunAwayRequestStatusId = runawayRequests.RequestStatusId.Value,
                        RunAwayFilesPaths =
                            runawayRequests.MOL_RAMS_RunAway_Files.Select(files => files.FileName).ToList(),

                        ComplaintRequestId = complaintsRequests.ComplaintID,
                        ComplaintRequestDate = complaintsRequests.ComplaintDate,
                        LaborOfficeReplyDetails = complaintsRequests.LaborOfficeReplyDetails,
                        RejectReason = complaintsRequests.RejectReason,
                        ComplaintFilesPaths =
                            complaintsRequests.MOL_RAMS_Complaint_Files.Select(files => files.FileName).ToList(),
                        ComplaintRequestStatusId = complaintsRequests.Status,

                        RunAwayQuestion1 = runawayRequests.CreationQuestion1,
                        RunAwayQuestion2 = runawayRequests.CreationQuestion2,
                        RunAwayQuestion3 = runawayRequests.CreationQuestion3,
                        RunAwayQuestion4 = runawayRequests.CreationQuestion4,

                        ComplaintQuestion1 = complaintsRequests.ComplaintQuestion1,
                        ComplaintQuestion2 = complaintsRequests.ComplaintQuestion2,
                        ComplaintQuestion3 = complaintsRequests.ComplaintQuestion3,
                        ComplaintQuestion4 = complaintsRequests.ComplaintQuestion4,

                        TotalRowsCount = totalRowsCount
                    })
                     .Skip(queryRecordsCount * currentPageIndex)
                     .Take(queryRecordsCount);

                #endregion
            }

            if (searchLaborerOfficeId.HasValue)
            {
                #region "One Value is Null"

                //Select total rows count for paging
                totalRowsCount =
                    Context.MOL_LaborerMOIRunaway.GroupJoin(Context.MOL_RunAwayComplaints,
                        runawayRequests => new { ID = runawayRequests.ID },
                        complaintsRequests => new { ID = complaintsRequests.RunAwayRequestId.Value },
                        (runawayRequests, MOL_RunAwayComplaints_join) =>
                            new { runawayRequests, MOL_RunAwayComplaints_join })
                        .SelectMany(@t => @t.MOL_RunAwayComplaints_join.DefaultIfEmpty(),
                            (@t, complaintsRequests) => new { @t, complaintsRequests })

                         .Count(@t => @t.@t.runawayRequests.IsCancelRunaway == false &&
                                @t.complaintsRequests.Status == filterStatusType &&
                                @t.@t.runawayRequests.LaborerOfficeId == searchLaborerOfficeId);

                //Select data from DB
                return
                   (from runawayRequests in Context.MOL_LaborerMOIRunaway
                    join complaintsRequests in Context.MOL_RunAwayComplaints on new { ID = runawayRequests.ID }
                        equals new { ID = complaintsRequests.RunAwayRequestId.Value } into
                        MOL_RunAwayComplaints_join

                    from complaintsRequests in MOL_RunAwayComplaints_join.DefaultIfEmpty()
                    where
                        runawayRequests.IsCancelRunaway == false &&
                        complaintsRequests.Status == filterStatusType &&
                        runawayRequests.LaborerOfficeId == searchLaborerOfficeId

                    orderby runawayRequests.ID ascending

                    select new RunAwayApprovalRequestInfo
                    {
                        RunAwayRequestId = runawayRequests.ID,
                        RunAwayRequestNumber = runawayRequests.RequestNumber,
                        EstablishmentTitle = runawayRequests.EstablishmentTitle,
                        LaborOfficeId = runawayRequests.LaborerOfficeId.Value,
                        SequenceNumber = runawayRequests.SequenceNumber.Value,
                        LaborerIdNumber = runawayRequests.IDNumber,
                        LaborerBorderNumber = runawayRequests.LaborerBorderNumber.Value,
                        LaborerFullName = runawayRequests.LaborerFullName,
                        RunAwayRequestDate = runawayRequests.CreatedOn,
                        RunAwayRequestStatusId = runawayRequests.RequestStatusId.Value,
                        RunAwayFilesPaths =
                            runawayRequests.MOL_RAMS_RunAway_Files.Select(files => files.FileName).ToList(),

                        ComplaintRequestId = complaintsRequests.ComplaintID,
                        ComplaintRequestDate = complaintsRequests.ComplaintDate,
                        LaborOfficeReplyDetails = complaintsRequests.LaborOfficeReplyDetails,
                        RejectReason = complaintsRequests.RejectReason,
                        ComplaintFilesPaths =
                            complaintsRequests.MOL_RAMS_Complaint_Files.Select(files => files.FileName).ToList(),
                        ComplaintRequestStatusId = complaintsRequests.Status,

                        RunAwayQuestion1 = runawayRequests.CreationQuestion1,
                        RunAwayQuestion2 = runawayRequests.CreationQuestion2,
                        RunAwayQuestion3 = runawayRequests.CreationQuestion3,
                        RunAwayQuestion4 = runawayRequests.CreationQuestion4,

                        ComplaintQuestion1 = complaintsRequests.ComplaintQuestion1,
                        ComplaintQuestion2 = complaintsRequests.ComplaintQuestion2,
                        ComplaintQuestion3 = complaintsRequests.ComplaintQuestion3,
                        ComplaintQuestion4 = complaintsRequests.ComplaintQuestion4,

                        TotalRowsCount = totalRowsCount
                    })
                     .Skip(queryRecordsCount * currentPageIndex)
                     .Take(queryRecordsCount);

                #endregion
            }

            if (establishmentId.HasValue)
            {
                #region "Both values are NOT NULL"

                //Select total rows count for paging
                totalRowsCount =
                    Context.MOL_LaborerMOIRunaway.GroupJoin(Context.MOL_RunAwayComplaints,
                        runawayRequests => new { ID = runawayRequests.ID },
                        complaintsRequests => new { ID = complaintsRequests.RunAwayRequestId.Value },
                        (runawayRequests, MOL_RunAwayComplaints_join) =>
                            new { runawayRequests, MOL_RunAwayComplaints_join })
                        .SelectMany(@t => @t.MOL_RunAwayComplaints_join.DefaultIfEmpty(),
                            (@t, complaintsRequests) => new { @t, complaintsRequests })

                         .Count(@t => @t.@t.runawayRequests.IsCancelRunaway == false &&
                                @t.complaintsRequests.Status == filterStatusType &&
                                 @t.@t.runawayRequests.EstablishmentId == establishmentId);

                //Select data from DB
                return
                   (from runawayRequests in Context.MOL_LaborerMOIRunaway
                    join complaintsRequests in Context.MOL_RunAwayComplaints on new { ID = runawayRequests.ID }
                        equals new { ID = complaintsRequests.RunAwayRequestId.Value } into
                        MOL_RunAwayComplaints_join

                    from complaintsRequests in MOL_RunAwayComplaints_join.DefaultIfEmpty()
                    where
                        runawayRequests.IsCancelRunaway == false &&
                        complaintsRequests.Status == filterStatusType &&
                        runawayRequests.EstablishmentId == establishmentId

                    orderby runawayRequests.ID ascending

                    select new RunAwayApprovalRequestInfo
                    {
                        RunAwayRequestId = runawayRequests.ID,
                        RunAwayRequestNumber = runawayRequests.RequestNumber,
                        EstablishmentTitle = runawayRequests.EstablishmentTitle,
                        LaborOfficeId = runawayRequests.LaborerOfficeId.Value,
                        SequenceNumber = runawayRequests.SequenceNumber.Value,
                        LaborerIdNumber = runawayRequests.IDNumber,
                        LaborerBorderNumber = runawayRequests.LaborerBorderNumber.Value,
                        LaborerFullName = runawayRequests.LaborerFullName,
                        RunAwayRequestDate = runawayRequests.CreatedOn,
                        RunAwayRequestStatusId = runawayRequests.RequestStatusId.Value,
                        RunAwayFilesPaths =
                            runawayRequests.MOL_RAMS_RunAway_Files.Select(files => files.FileName).ToList(),

                        ComplaintRequestId = complaintsRequests.ComplaintID,
                        ComplaintRequestDate = complaintsRequests.ComplaintDate,
                        LaborOfficeReplyDetails = complaintsRequests.LaborOfficeReplyDetails,
                        RejectReason = complaintsRequests.RejectReason,
                        ComplaintFilesPaths =
                            complaintsRequests.MOL_RAMS_Complaint_Files.Select(files => files.FileName).ToList(),
                        ComplaintRequestStatusId = complaintsRequests.Status,

                        RunAwayQuestion1 = runawayRequests.CreationQuestion1,
                        RunAwayQuestion2 = runawayRequests.CreationQuestion2,
                        RunAwayQuestion3 = runawayRequests.CreationQuestion3,
                        RunAwayQuestion4 = runawayRequests.CreationQuestion4,

                        ComplaintQuestion1 = complaintsRequests.ComplaintQuestion1,
                        ComplaintQuestion2 = complaintsRequests.ComplaintQuestion2,
                        ComplaintQuestion3 = complaintsRequests.ComplaintQuestion3,
                        ComplaintQuestion4 = complaintsRequests.ComplaintQuestion4,

                        TotalRowsCount = totalRowsCount
                    })
                     .Skip(queryRecordsCount * currentPageIndex)
                     .Take(queryRecordsCount);

                #endregion
            }

            #region "Both values are NULL"

            //Select total rows count for paging
            totalRowsCount =
                Context.MOL_LaborerMOIRunaway.GroupJoin(Context.MOL_RunAwayComplaints,
                    runawayRequests => new { ID = runawayRequests.ID },
                    complaintsRequests => new { ID = complaintsRequests.RunAwayRequestId.Value },
                    (runawayRequests, MOL_RunAwayComplaints_join) =>
                        new { runawayRequests, MOL_RunAwayComplaints_join })
                    .SelectMany(@t => @t.MOL_RunAwayComplaints_join.DefaultIfEmpty(),
                        (@t, complaintsRequests) => new { @t, complaintsRequests })

                     .Count(@t => @t.@t.runawayRequests.IsCancelRunaway == false &&
                            @t.complaintsRequests.Status == filterStatusType);

            //Select data from DB
            return
               (from runawayRequests in Context.MOL_LaborerMOIRunaway
                join complaintsRequests in Context.MOL_RunAwayComplaints on new { ID = runawayRequests.ID }
                    equals new { ID = complaintsRequests.RunAwayRequestId.Value } into
                    MOL_RunAwayComplaints_join

                from complaintsRequests in MOL_RunAwayComplaints_join.DefaultIfEmpty()
                where
                    runawayRequests.IsCancelRunaway == false &&
                    complaintsRequests.Status == filterStatusType

                orderby runawayRequests.ID ascending

                select new RunAwayApprovalRequestInfo
                {
                    RunAwayRequestId = runawayRequests.ID,
                    RunAwayRequestNumber = runawayRequests.RequestNumber,
                    EstablishmentTitle = runawayRequests.EstablishmentTitle,
                    LaborOfficeId = runawayRequests.LaborerOfficeId.Value,
                    SequenceNumber = runawayRequests.SequenceNumber.Value,
                    LaborerIdNumber = runawayRequests.IDNumber,
                    LaborerBorderNumber = runawayRequests.LaborerBorderNumber.Value,
                    LaborerFullName = runawayRequests.LaborerFullName,
                    RunAwayRequestDate = runawayRequests.CreatedOn,
                    RunAwayRequestStatusId = runawayRequests.RequestStatusId.Value,
                    RunAwayFilesPaths =
                        runawayRequests.MOL_RAMS_RunAway_Files.Select(files => files.FileName).ToList(),

                    ComplaintRequestId = complaintsRequests.ComplaintID,
                    ComplaintRequestDate = complaintsRequests.ComplaintDate,
                    LaborOfficeReplyDetails = complaintsRequests.LaborOfficeReplyDetails,
                    RejectReason = complaintsRequests.RejectReason,
                    ComplaintFilesPaths =
                        complaintsRequests.MOL_RAMS_Complaint_Files.Select(files => files.FileName).ToList(),
                    ComplaintRequestStatusId = complaintsRequests.Status,

                    RunAwayQuestion1 = runawayRequests.CreationQuestion1,
                    RunAwayQuestion2 = runawayRequests.CreationQuestion2,
                    RunAwayQuestion3 = runawayRequests.CreationQuestion3,
                    RunAwayQuestion4 = runawayRequests.CreationQuestion4,

                    ComplaintQuestion1 = complaintsRequests.ComplaintQuestion1,
                    ComplaintQuestion2 = complaintsRequests.ComplaintQuestion2,
                    ComplaintQuestion3 = complaintsRequests.ComplaintQuestion3,
                    ComplaintQuestion4 = complaintsRequests.ComplaintQuestion4,

                    TotalRowsCount = totalRowsCount
                })
                 .Skip(queryRecordsCount * currentPageIndex)
                 .Take(queryRecordsCount);

            #endregion
        }

        /// <summary>
        /// Function returns list of Laborer Office RunAway requests (تدقيق بلاغ التغيب بمكتب العمل)
        /// </summary>
        /// <param name="userLaborOfficeId">The user labor office identifier.</param>
        /// <param name="filterStatusType">Type of the filter status.</param>
        /// <param name="searchEstablishmentId">The search establishment identifier.</param>
        /// <param name="searchLaborerIdNumber">The search laborer identifier number.</param>
        /// <param name="searchLaborerBorderNumber">The search laborer border number.</param>
        /// <param name="searchRequestNumber">The search request number.</param>
        /// <param name="queryRecordsCount">The query records count.</param>
        /// <param name="currentPageIndex">Index of the current page.</param>
        /// <returns>List of available Requests</returns>
        public IQueryable<RunAwayReviewRequestsInfo> GetForReviewRunAwayRequestsList(
            int userLaborOfficeId, int filterStatusType, long? searchEstablishmentId,
            long? searchLaborerIdNumber, long? searchLaborerBorderNumber, string searchRequestNumber,
            int queryRecordsCount, int currentPageIndex, out int totalRowsCount)
        {
            //===================================================================================
            //Select target rows form database
            //Eager Loading for File paths
            //Eager loading means that the related data is loaded from the database as part of the initial query
            var results =
                Context.MOL_LaborerMOIRunaway.GroupJoin(Context.MOL_RunAwayComplaints,
                    runawayRequests => new { ID = runawayRequests.ID },
                    MOL_RunAwayComplaints => new { ID = MOL_RunAwayComplaints.RunAwayRequestId.Value },
                    (runawayRequests, MOL_RunAwayComplaints_join) => new { runawayRequests, MOL_RunAwayComplaints_join })
                    .SelectMany(@t => @t.MOL_RunAwayComplaints_join.DefaultIfEmpty(),
                        (@t, complaintsRequests) => new { @t, complaintsRequests })
                    .Where(@t => @t.@t.runawayRequests.IsCancelRunaway == false &&
                                 @t.@t.runawayRequests.LaborerOfficeId == userLaborOfficeId &&
                                 @t.complaintsRequests.Status == filterStatusType)
                    .Select(@t => new RunAwayReviewRequestsInfo
                    {
                        RunAwayRequestId = @t.@t.runawayRequests.ID,
                        RunAwayRequestNumber = @t.@t.runawayRequests.RequestNumber,
                        EstablishmentId = @t.@t.runawayRequests.EstablishmentId,
                        EstablishmentTitle = @t.@t.runawayRequests.EstablishmentTitle,
                        LaborOfficeId = @t.@t.runawayRequests.LaborerOfficeId.Value,
                        SequenceNumber = @t.@t.runawayRequests.SequenceNumber.Value,
                        LaborerIdNumber = @t.@t.runawayRequests.IDNumber,
                        LaborerBorderNumber = @t.@t.runawayRequests.LaborerBorderNumber.Value,
                        LaborerFullName = @t.@t.runawayRequests.LaborerFullName,
                        RunAwayRequestDate = @t.@t.runawayRequests.CreatedOn,
                        RunAwayRequestStatusId = @t.@t.runawayRequests.RequestStatusId.Value,
                        RunAwayFilesPaths =
                            @t.@t.runawayRequests.MOL_RAMS_RunAway_Files.Select(files => files.FileName).ToList(),
                        ComplaintRequestId = @t.complaintsRequests.ComplaintID,
                        ComplaintRequestDate = @t.complaintsRequests.ComplaintDate,
                        LaborOfficeReplyDetails = @t.complaintsRequests.LaborOfficeReplyDetails,
                        ComplaintFilesPaths =
                            @t.complaintsRequests.MOL_RAMS_Complaint_Files.Select(files => files.FileName).ToList(),
                        ComplaintRequestStatusId = @t.complaintsRequests.Status,
                        RunAwayQuestion1 = @t.@t.runawayRequests.CreationQuestion1,
                        RunAwayQuestion2 = @t.@t.runawayRequests.CreationQuestion2,
                        RunAwayQuestion3 = @t.@t.runawayRequests.CreationQuestion3,
                        RunAwayQuestion4 = @t.@t.runawayRequests.CreationQuestion4,
                        ComplaintQuestion1 = @t.complaintsRequests.ComplaintQuestion1,
                        ComplaintQuestion2 = @t.complaintsRequests.ComplaintQuestion2,
                        ComplaintQuestion3 = @t.complaintsRequests.ComplaintQuestion3,
                        ComplaintQuestion4 = @t.complaintsRequests.ComplaintQuestion4
                    });

            if (searchLaborerIdNumber.HasValue)
                results = results.Where(info => info.LaborerIdNumber == searchLaborerIdNumber);

            if (searchLaborerBorderNumber.HasValue)
                results = results.Where(info => info.LaborerBorderNumber == searchLaborerBorderNumber);

            if (searchEstablishmentId.HasValue)
                results = results.Where(info => info.EstablishmentId == searchEstablishmentId);

            if (searchRequestNumber != null && searchRequestNumber.Trim().Length > 0)
                results = results.Where(info => info.RunAwayRequestNumber == searchRequestNumber);

            totalRowsCount = results.Count();

            return results
                    .OrderBy(row => row.RunAwayRequestId)
                    .Skip(queryRecordsCount * currentPageIndex)
                    .Take(queryRecordsCount);
        }

        /// <summary>
        /// Function returns Establishment RunAway request by IdNumber or BorderNumber for (مقبول ، تحت الدراسة)
        /// </summary>
        /// <param name="laborerId">The laborer Primary Key</param>
        /// <param name="laborOfficeId">The establishment laborer office number.</param>
        /// <param name="sequenceNumber">The establishment sequence number.</param>
        /// <returns>Target RunAway Request</returns>
        public int GetRunAwayRequestsCount(long laborerId, int laborOfficeId, long sequenceNumber)
        {
            //===================================================================================
            //Select target rows form database
            //Eager Loading for File paths
            //Eager loading means that the related data is loaded from the database as part of the initial query
            return
                Where(
                    runawayRequests =>
                        (runawayRequests.LaborerOfficeId == laborOfficeId && runawayRequests.SequenceNumber == sequenceNumber) &&
                        runawayRequests.LaborerId == laborerId &&
                        (runawayRequests.RequestStatusId == 2 || runawayRequests.RequestStatusId == 3)).Count();
            //مقبول ، تحت الدراسة
        }

        /// <summary>Function return total number of RunAway Requests count regard less of request status</summary>
        /// <remarks>Wael Mohsen, 2018-04-29.</remarks>
        /// <param name="laborerIdNumber">Laborer ID Number.</param>
        /// <param name="borderNumber">Laborer Border Number.</param>
        /// <param name="establishmentLaborOfficeId">Identifier for the establishment labor office.</param>
        /// <param name="establishmentSequenceNumber">The establishment sequence number.</param>
        /// <returns>The total run away requests count.</returns>
        public int GetTotalRunAwayRequestsCount(long? laborerIdNumber, long? borderNumber,
            int establishmentLaborOfficeId, long establishmentSequenceNumber)
        {
            //Define target laborer identifier value
            var laborerIdentifier = laborerIdNumber ?? borderNumber;

            //===================================================================================
            //Select total number of row
            return
                  Select(rows => rows).
                      Count(r =>
                          (r.IDNumber == laborerIdentifier || r.LaborerBorderNumber == laborerIdentifier) &&
                          (r.LaborerOfficeId == establishmentLaborOfficeId && r.SequenceNumber == establishmentSequenceNumber));
        }

        /// <summary>
        /// Gets the total canceled runaway requests count.
        /// </summary>
        /// <param name="runAwayRequestNumber">The run away request number.</param>
        /// <returns>System.Int32.</returns>
        public int GetTotalCanceledRunAwayRequestsCount(string runAwayRequestNumber)
        {
            //===================================================================================
            //Get Target request Object
            var requestId = Convert.ToInt32(runAwayRequestNumber.Split('-')[2]);

            var runAwayRequestInfo = Context.MOL_LaborerMOIRunaway.SingleOrDefault(targetRunAway =>
                targetRunAway.ID == requestId);

            if (runAwayRequestInfo == null)
                throw new ArgumentException("Invalid RunAway Request Number");

            //===================================================================================
            //Get Laborer Identifier
            var laborerIdentifier = runAwayRequestInfo.IDNumber ?? runAwayRequestInfo.LaborerBorderNumber;

            //===================================================================================
            //Select total number of row
            return
                Select(rows => rows).
                    Count(r =>
                            (r.IDNumber == laborerIdentifier || r.LaborerBorderNumber == laborerIdentifier) &&
                            r.IsCancelRunaway);
        }

        /// <summary>
        /// Function returns the Id Number of Establishment Agent that created the request
        /// </summary>
        /// <param name="runAwayRequestId">Target request Id Number</param>
        /// <returns></returns>
        public long? GetApplicantUserIdNumber(int runAwayRequestId)
        {
            return Where(request => request.ID == runAwayRequestId).Select(request => request.ApplicantUserIdNumber).FirstOrDefault();
        }

        /// <summary>
        /// Function returns the contact info for Runaway/Complaint info
        /// </summary>
        /// <param name="runAwayRequestId">Target runaway request Info</param>
        public RequestContactInfo GetRequestContactInfo(int runAwayRequestId)
        {
            return this.Context.MOL_LaborerMOIRunaway
                .GroupJoin(Context.MOL_RunAwayComplaints, runawayRequests => new { runawayRequests.ID },
                    MOL_RunAwayComplaints => new { ID = MOL_RunAwayComplaints.RunAwayRequestId.Value },
                    (runawayRequests, MOL_RunAwayComplaints_join) =>
                        new { runawayRequests, MOL_RunAwayComplaints_join })

                .SelectMany(@t => @t.MOL_RunAwayComplaints_join.DefaultIfEmpty(),
                    (@t, complaintsRequests) => new { @t, complaintsRequests })

                .Where(@t => @t.@t.runawayRequests.ID == runAwayRequestId)

                .Select(@t => (new RequestContactInfo
                {
                    RequestNumber = @t.@t.runawayRequests.RequestNumber,
                    RunAwayApplicantUserId = @t.@t.runawayRequests.ApplicantUserIdNumber,
                    LaborerMobileNo = @t.complaintsRequests.LaborerMobileNo,
                    ComplaintApplicantUserId = @t.complaintsRequests.ApplicantUserIdNumber,
                    CreatedOn = @t.complaintsRequests.ComplaintDate
                })).SingleOrDefault();
        }

        #endregion

        #region "Insert/Update Methods"

        /// <summary>
        /// Function creates new request Number
        /// </summary>
        /// <param name="requestLaborOffice"></param>
        /// <param name="requestId"></param>
        /// <returns></returns>
        private static string GetRequestNumber(string requestLaborOffice, string requestId)
        {
            return string.Format("{0}-{1}-{2}",
                new System.Globalization.UmAlQuraCalendar().GetYear(DateTime.Now),
                requestLaborOffice, requestId);
        }

        /// <summary>
        /// Function Creates RunAway request at MoL database (تقديم بلاغ تغيب عامل)
        /// </summary>
        /// <param name="requestInfo">The request information.</param>
        /// <param name="requestStatusId">The request status identifier.</param>
        /// <returns>System.String.</returns>
        public string CreateRunAwayRequest(RunAwayCreateRequestInfo requestInfo, int requestStatusId)
        {
            //========================================================================
            //Get laborer information
            var laborerInfo =
                new MOL_Laborer_Repository().GetNonSaudiLaborerByIdNoOrBorderForEstablishmentID(
                    Convert.ToInt64(requestInfo.EstablishmentId), requestInfo.LaborerIdNumber.ToString(),
                    requestInfo.LaborerBorderNumber.ToString());

            if (laborerInfo == null)
                return string.Empty;

            //========================================================================
            //Get Establishment information - MyClients Control Bug
            EstablishmentInfo establishmentInfo = null;

            if (!requestInfo.IsRequestByEstablishmentAgent)
            {
                establishmentInfo = new MOL_Establishment_Repository().GetEstablishmentByLaborOfficeAndSequenceNumber(
                     requestInfo.LaborerOfficeId, requestInfo.SequenceNumber);

                if (establishmentInfo == null)
                    return string.Empty;
            }
            //====================================================================
            //1- Fill repository Object
            var newRequest = new MOL_LaborerMOIRunaway
            {
                LaborerOfficeId = requestInfo.LaborerOfficeId,
                SequenceNumber = requestInfo.SequenceNumber,
                EstablishmentId = Convert.ToInt64(requestInfo.EstablishmentId),
                EstablishmentTitle =
                    requestInfo.IsRequestByEstablishmentAgent ? requestInfo.EstablishmentTitle : establishmentInfo.Name,
                IDNumber = requestInfo.LaborerIdNumber,
                LaborerBorderNumber = requestInfo.LaborerBorderNumber,
                LaborerFullName = laborerInfo.FullName,
                IsRequestByEstablishmentAgent = requestInfo.IsRequestByEstablishmentAgent,
                ApplicantUserIdNumber = requestInfo.ApplicantUserIdNumber,
                CreatedByIdNumber = requestInfo.CreatedByIdNumber,
                LaborerId = laborerInfo.PK_LaborerId,

                CreationQuestion1 = requestInfo.Question1,
                CreationQuestion2 = requestInfo.Question2,
                CreationQuestion3 = requestInfo.Question3,
                CreationQuestion4 = requestInfo.Question4,

                RequestStatusId = requestStatusId,
                IsCancelRunaway = false
            };

            //Add new request to DB
            Context.MOL_LaborerMOIRunaway.Add(newRequest);
            Context.SaveChanges();

            //Set Request Number
            newRequest.RequestNumber = GetRequestNumber(
                newRequest.LaborerOfficeId.ToString(),
                newRequest.ID.ToString());

            Context.MOL_LaborerMOIRunaway.AddOrUpdate(newRequest);
            Context.SaveChanges();
            //====================================================================
            //2- Create transaction log
            var newRequestLog = new MOL_RAMS_RunAwayTransactionsLog
            {
                RequestStatusId = newRequest.RequestStatusId.Value,
                RunAwayRequestId = newRequest.ID,
                CreatedByIdNumber = newRequest.CreatedByIdNumber.Value,
                ApplicantUserIdNumber = newRequest.ApplicantUserIdNumber.Value,
                ClientIPAddress = requestInfo.ClientIPAddress
            };

            //Add new request log to DB
            Context.MOL_RAMS_RunAwayTransactionsLog.Add(newRequestLog);
            Context.SaveChanges();

            return newRequest.RequestNumber;
        }

        /// <summary>
        /// Function Cancels RunAway request at MoL database (إلغاء بلاغ تغيب عامل)
        /// </summary>
        /// <param name="requestInfo">The request information.</param>
        /// <param name="requestStatusId">The request status identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CancelRunAwayRequest(RunAwayCancelRequestInfo requestInfo, int requestStatusId)
        {
            //===================================================================================
            //Get Target request Object
            var requestId = Convert.ToInt32(requestInfo.RequestNumber.Split('-')[2]);

            var runAwayRequest = Context.MOL_LaborerMOIRunaway.SingleOrDefault(targetRunAway =>
                targetRunAway.ID == requestId &&
                targetRunAway.IsCancelRunaway == false);

            //===================================================================================
            //Update request Info to cancel the request
            if (runAwayRequest == null)
                return false;

            var runAwayRequestId = runAwayRequest.ID;
            runAwayRequest.IsCancelRunaway = true;
            runAwayRequest.CancelReason = requestInfo.CancelReason;
            runAwayRequest.RequestStatusId = requestStatusId;
            runAwayRequest.CancelQuestion1 = requestInfo.CancelQuestion1;

            runAwayRequest.ModifiedByIdNumber = requestInfo.CreatedByIdNumber;
            runAwayRequest.ModifiedByApplicantUserIdNumber = requestInfo.ApplicantUserIdNumber;
            runAwayRequest.ModifiedOn = DateTime.Now;
            runAwayRequest.CancellationDate = DateTime.Now;

            Context.MOL_LaborerMOIRunaway.AddOrUpdate(runAwayRequest);
            //====================================================================
            //Create transaction log
            var newRunAwayLog = new MOL_RAMS_RunAwayTransactionsLog
            {
                RequestStatusId = requestStatusId,
                RunAwayRequestId = requestId,
                CreatedByIdNumber = requestInfo.CreatedByIdNumber,
                ApplicantUserIdNumber = requestInfo.ApplicantUserIdNumber,
                ClientIPAddress = requestInfo.ClientIPAddress
            };

            //Add new request log to DB
            Context.MOL_RAMS_RunAwayTransactionsLog.Add(newRunAwayLog);

            if (Context.SaveChanges() <= 0)
                return false;

            //===================================================================================
            //Check if request has a Complaint request to cancel it too
            return new MOL_RunAwayComplaints_Repository()
                .UpdateRunAwayComplaintStatus(runAwayRequestId, requestStatusId, string.Empty, requestInfo.CreatedByIdNumber,
                    requestInfo.ApplicantUserIdNumber, requestInfo.ClientIPAddress);
        }

        /// <summary>Change run away request status.</summary>
        /// <remarks>Wael Mohsen, 2018-04-29.</remarks>
        /// <param name="runAwayRequestId">Identifier for the run away request.</param>
        /// <param name="requestStatusId">The request status identifier.</param>
        /// <param name="createdByIdNumber">Amount to created by.</param>
        /// <param name="applicantUserIdNumber">Identifier for the applicant user.</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        public bool ChangeRunAwayRequestStatus(
            int runAwayRequestId, int requestStatusId, long createdByIdNumber, long applicantUserIdNumber, string clientIPAddress)
        {
            //===================================================================================
            //Select row form DB
            var runAwayRequest = Context.MOL_LaborerMOIRunaway.SingleOrDefault(targetRunAway =>
                 targetRunAway.ID == runAwayRequestId);

            //===================================================================================
            //Update request Info to input status
            if (runAwayRequest == null)
                return false;

            runAwayRequest.RequestStatusId = requestStatusId;
            Context.MOL_LaborerMOIRunaway.AddOrUpdate(runAwayRequest);

            //===================================================================================
            //Create transaction log
            var newRunAwayLog = new MOL_RAMS_RunAwayTransactionsLog
            {
                RequestStatusId = requestStatusId,
                RunAwayRequestId = runAwayRequestId,
                CreatedByIdNumber = createdByIdNumber,
                ApplicantUserIdNumber = applicantUserIdNumber,
                ClientIPAddress = clientIPAddress
            };

            //Add new request log to DB
            Context.MOL_RAMS_RunAwayTransactionsLog.Add(newRunAwayLog);

            return Context.SaveChanges() > 0;
        }

        /// <summary>Updates the run away request with note information.</summary>
        /// <remarks>Wael Mohsen, 2018-05-09.</remarks>
        /// <param name="runAwayRequestId">The user identifier number.</param>
        /// <param name="noteId">Identifier for the note.</param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        public bool UpdateRunAwayRequestWithNoteInfo(int runAwayRequestId, int noteId)
        {
            //===================================================================================
            //Select row form DB
            var runAwayRequest = Context.MOL_LaborerMOIRunaway.SingleOrDefault(targetRunAway =>
                 targetRunAway.ID == runAwayRequestId);

            //===================================================================================
            //Update request Info to input status
            if (runAwayRequest == null)
                return false;

            runAwayRequest.NoteId = noteId;
            Context.MOL_LaborerMOIRunaway.AddOrUpdate(runAwayRequest);

            return Context.SaveChanges() > 0;
        }

        #endregion
    }
}
