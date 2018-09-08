// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 02-21-2018
// ***********************************************************************
// <copyright file="MOL_RunAwayComplaints_Repository.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************

using MOL.EFDAL.ComplexTypes;
using MOL.EFDAL.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    /// <summary>
    /// Class MOL_RunAwayComplaints_Repository.
    /// </summary>
    /// <seealso cref="MOL.EFDAL.Repository.EFRepository{MOL.EFDAL.Models.MOL_RunAwayComplaints}" />
    public partial class MOL_RunAwayComplaints_Repository : EFRepository<MOL_RunAwayComplaints>
    {
        #region "Constructor"

        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RunAwayComplaints_Repository" /> class.
        /// </summary>
        public MOL_RunAwayComplaints_Repository()
        {
            Context = new MOLEFEntities();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RunAwayComplaints_Repository" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MOL_RunAwayComplaints_Repository(MOLEFEntities context) : base(context)
        { }

        #endregion

        #region "Select Methods"

        /// <summary> لا يمكن تقديم أكثر من طلب إثبات كيدية لنفس البلاغ
        /// Function Checks if laborer already created a Complaint request for the RunAway request
        /// </summary>
        /// <remarks>Wael Mohsen, 2018-04-29.</remarks>
        /// <param name="requestId">Identifier for the request.</param>
        /// <returns>True if request has complaint, false if not.</returns>
        public bool IsRequestHasComplaint(int requestId)
        {
            return Context.MOL_RunAwayComplaints.Count(x => x.RunAwayRequestId == requestId) > 0;
        }

        /// <summary>
        /// Function returns the laborer Mobile number for current complaint request
        /// </summary>
        /// <param name="complaintId">Target complaint Id</param>
        /// <returns></returns>
        public string GetLaborerMobileNumberByComplaintId(int complaintId)
        {
            //========================================================================
            //Select request mobile number of this laborer
            return
              Context.MOL_RunAwayComplaints.Where(complaintRequests => complaintRequests.ComplaintID == complaintId)
                    .Select(complaintRequests => complaintRequests.LaborerMobileNo)
                    .FirstOrDefault();
        }

        /// <summary>
        /// Function returns the laborer Mobile number for current runAwayId request
        /// </summary>
        /// <param name="runAwayId">Target runAwayId Id</param>
        /// <returns></returns>
        public string GetLaborerMobileNumberByRunAwayId(int runAwayId)
        {
            //========================================================================
            //Select request mobile number of this laborer
            return
              Context.MOL_RunAwayComplaints.Where(complaintRequests => complaintRequests.RunAwayRequestId == runAwayId)
                    .Select(complaintRequests => complaintRequests.LaborerMobileNo)
                    .FirstOrDefault();
        }
        #endregion

        #region "Create/Update Methods"

        /// <summary>Creates run away complaint request.</summary>
        /// <remarks>Wael Mohsen, 2018-04-29.</remarks>
        /// <param name="requestInfo">Information describing the request.</param>
        /// <param name="requestStatusId">Target Status.</param>
        /// <returns>The new run away complaint request.</returns>
        public int CreateRunAwayComplaintRequest(ComplaintCreateRequestInfo requestInfo, int requestStatusId)
        {
            //====================================================================
            //1- Fill repository Object
            var newRequest = new MOL_RunAwayComplaints
            {
                RunAwayRequestId = requestInfo.RunAwayRequestId,
                Status = requestStatusId,

                ComplaintQuestion1 = requestInfo.ComplaintQuestion1,
                ComplaintQuestion2 = requestInfo.ComplaintQuestion2,
                ComplaintQuestion3 = requestInfo.ComplaintQuestion3,
                ComplaintQuestion4 = requestInfo.ComplaintQuestion4,

                IsRequestByLaborer = requestInfo.IsRequestByLaborer,
                ApplicantUserIdNumber = requestInfo.ApplicantUserIdNumber,
                CreatedByUserIdNumber = requestInfo.CreatedByIdNumber,

                LaborerMobileNo = requestInfo.LaborerMobileNo
            };

            //Add new request to DB
            Context.MOL_RunAwayComplaints.Add(newRequest);
            if (Context.SaveChanges() <= 0)
                return 0;

            //====================================================================
            //2- Create transaction log
            var newRequestLog = new MOL_RAMS_ComplaintTransactionsLog
            {
                ComplaintRequestId = newRequest.ComplaintID,
                RequestStatusId = requestStatusId,
                CreatedByIdNumber = newRequest.CreatedByUserIdNumber,
                ApplicantUserIdNumber = newRequest.ApplicantUserIdNumber.Value,
                ClientIPAddress = requestInfo.ClientIPAddress
            };

            //Add new request log to DB
            Context.MOL_RAMS_ComplaintTransactionsLog.Add(newRequestLog);
            return Context.SaveChanges() > 0 ? newRequest.ComplaintID : 0;
        }

        /// <summary>
        /// Function updates the status of the Complaint request to target status
        /// </summary>
        /// <param name="runAwayRequestId">Main RunAway Request</param>
        /// <param name="requestStatusId">Target Status</param>
        /// <param name="rejectionReason"></param>
        /// <param name="modifiedByIdNumber">User Id Number</param>
        /// <param name="modifiedByApplicantUserIdNumber">Session user Id Number</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool UpdateRunAwayComplaintStatus(
            long runAwayRequestId, int requestStatusId, string rejectionReason,
            long modifiedByIdNumber, long modifiedByApplicantUserIdNumber,
            string clientIPAddress)
        {
            //===================================================================================
            //Check if request has a Complaint request to cancel it too
            var complaintInfo = Context.MOL_RunAwayComplaints.SingleOrDefault(targetComplaint =>
                targetComplaint.RunAwayRequestId == runAwayRequestId);

            if (complaintInfo == null)
                return true;

            complaintInfo.Status = requestStatusId;
            if (rejectionReason.Trim().Length > 0)
                complaintInfo.RejectReason = rejectionReason;

            complaintInfo.ModifiedByIdNumber = modifiedByIdNumber;
            complaintInfo.ModifiedByApplicantUserIdNumber = modifiedByApplicantUserIdNumber;
            complaintInfo.ModifiedOn = DateTime.Now;

            Context.MOL_RunAwayComplaints.AddOrUpdate(complaintInfo);
            //====================================================================
            //Create transaction log
            var newComplaintLog = new MOL_RAMS_ComplaintTransactionsLog
            {
                ComplaintRequestId = complaintInfo.ComplaintID,
                RequestStatusId = requestStatusId,
                CreatedByIdNumber = modifiedByIdNumber,
                ApplicantUserIdNumber = modifiedByApplicantUserIdNumber,
                ClientIPAddress = clientIPAddress
            };

            //Add new request log to DB
            Context.MOL_RAMS_ComplaintTransactionsLog.Add(newComplaintLog);

            return Context.SaveChanges() > 0;
        }

        /// <summary>Updates the complaint with review results.</summary>
        /// <remarks>Wael Mohsen, 2018-05-10.</remarks>
        /// <param name="runAwayRequestId">Main RunAway Request.</param>
        /// <param name="requestStatusId">Target Status.</param>
        /// <param name="reviewResults">The review results.</param>
        /// <param name="modifiedByApplicantUserIdNumber">Session user Id Number.</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        public bool UpdateComplaintWithReviewResults(int runAwayRequestId, int? requestStatusId,
            string reviewResults, long modifiedByApplicantUserIdNumber, string clientIPAddress)
        {
            //========================================================================
            //Check if request has a Complaint request to cancel it too
            var complaintInfo = Context.MOL_RunAwayComplaints.SingleOrDefault(targetComplaint =>
                targetComplaint.RunAwayRequestId == runAwayRequestId);

            if (complaintInfo == null)
                return true;

            if (requestStatusId.HasValue)
                complaintInfo.Status = requestStatusId.Value;

            complaintInfo.LaborOfficeReplyDetails = reviewResults;

            complaintInfo.ModifiedByIdNumber = modifiedByApplicantUserIdNumber;
            complaintInfo.ModifiedByApplicantUserIdNumber = modifiedByApplicantUserIdNumber;
            complaintInfo.ModifiedOn = DateTime.Now;

            Context.MOL_RunAwayComplaints.AddOrUpdate(complaintInfo);
            //====================================================================
            //Create transaction log
            if (requestStatusId.HasValue)
            {
                var newComplaintLog = new MOL_RAMS_ComplaintTransactionsLog
                {
                    ComplaintRequestId = complaintInfo.ComplaintID,
                    RequestStatusId = requestStatusId.Value,
                    CreatedByIdNumber = modifiedByApplicantUserIdNumber,
                    ApplicantUserIdNumber = modifiedByApplicantUserIdNumber,
                    ClientIPAddress = clientIPAddress
                };

                //Add new request log to DB
                Context.MOL_RAMS_ComplaintTransactionsLog.Add(newComplaintLog);
            }

            return Context.SaveChanges() > 0;
        }

        #endregion
    }
}
