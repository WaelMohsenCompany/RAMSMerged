// ***********************************************************************
// Assembly         : RAMS.EnterpriseServices
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-04-2018
// ***********************************************************************
// <copyright file="GetEstablishment.svc.cs" company="Tasleem IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.Repository;
using RAMS.CrossCutting;
using System;
using System.Collections.Generic;

namespace RAMS.EnterpriseServices.Establishment.Get
{
    /// <inheritdoc />
    /// <summary>
    /// Class GetEstablishment.
    /// </summary>
    /// <seealso cref="!:RAMS.EnterpriseServices.Establishment.Get.IGetEstablishment" />
    public class GetEstablishment : BaseDisposeClass
    {
        #region "Private Members"

        /// <summary>
        /// Message Center instance
        /// </summary>
        /// <value>The message client instance.</value>
        private InfrastructureService.Get.GetSystemMessages MessageClientInstance { get; set; }

        /// <summary>
        /// Establishment Local Business Rules Instance
        /// </summary>
        /// <value>The get establishment business rules instance.</value>
        private ApplicationServices.Establishment.Get.GetEstablishment GetEstablishmentInstance { get; set; }

        /// <summary>
        /// Runaway Instance
        /// </summary>
        /// <value>The get Runaway business rules / data instance.</value>
        private ApplicationServices.RunAwayRequest.Get.GetRunAwayRequest GetRunAwayRequestInstance { get; set; }

        #endregion

        #region" Public ESB Functions "

        #region "Check Business Rules"

        /// <summary>
        /// Check Establishment Business Rules (تقديم بلاغ تغيب عامل)
        /// Code Review (Done)
        /// </summary>
        /// <param name="laborOfficeId">The labor office identifier.</param>
        /// <param name="sequenceNumber">The sequence number.</param>
        /// <returns>HashSet&lt;ResponseMsg&gt;.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public HashSet<ResponseMsg> CheckCreateRunAwayBusinessRules(int laborOfficeId, long sequenceNumber)
        {
            //Check input parameters is valid
            if (laborOfficeId <= 0 || sequenceNumber <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //==================================================================================
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (MessageClientInstance = new InfrastructureService.Get.GetSystemMessages())
            using (GetEstablishmentInstance = new ApplicationServices.Establishment.Get.GetEstablishment())
            {
                var resultsList = new HashSet<ResponseMsg>();

                ResponseMsg currentResponseMsg;

                //==================================================================================
                //Get Startup Data for destination
                var establishmentInfo =
                    GetEstablishmentInstance.GetEstablishmentByLaborOfficeAndSequenceNumber(
                        laborOfficeId, sequenceNumber, dbUnitOfWork);

                //==================================================================================         
                //if Source Establishment is Null, therefor error happened
                if (establishmentInfo == null)
                {
                    //Check Rules for Subordinate or HouseHold
                    return new HashSet<ResponseMsg>
                    {
                    new ResponseMsg
                    {
                        IsSuccess =false,
                        ResponseText = MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG00)
                    }
                };
                }

                //==================================================================================
                //حالة المنشأة تساوي "قائمة"
                //==================================================================================          
                if (GetEstablishmentInstance.IsEstablishmentStatusExist(establishmentInfo.EstablishmentStatusId))
                {
                    currentResponseMsg = new ResponseMsg
                    {
                        RuleTypeId = "IsEstablishmentStatusExist",
                        IsSuccess = true,
                    };

                    resultsList.Add(currentResponseMsg);
                }
                else
                {
                    currentResponseMsg = new ResponseMsg
                    {
                        RuleTypeId = "IsEstablishmentStatusExist",
                        IsSuccess = false,
                        ResponseText =
                            MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG11)
                    };
                    resultsList.Add(currentResponseMsg);
                }

                //==================================================================================
                //نشاط المنشأة من الأنشطة المستثناة
                //==================================================================================
                if (establishmentInfo.SubEconomicActivityId != null &&
                    GetEstablishmentInstance.IsActivityEligibleForRunAwayRequest(
                        establishmentInfo.SubEconomicActivityId.Value, dbUnitOfWork))
                {
                    currentResponseMsg = new ResponseMsg
                    {
                        RuleTypeId = "IsEstablishmentActivityAllowed",
                        IsSuccess = true,
                    };
                    resultsList.Add(currentResponseMsg);
                }
                else
                {
                    currentResponseMsg = new ResponseMsg
                    {
                        RuleTypeId = "IsEstablishmentActivityAllowed",
                        IsSuccess = false,
                        ResponseText =
                            MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG08)
                    };
                    resultsList.Add(currentResponseMsg);
                }

                //==================================================================================
                //اشتراك خدمة واصل غير ساري
                //Removed by UAT SRS Comments
                //==================================================================================
                ////if (establishmentInfo.WASELStatus != null && (establishmentInfo.WASELExpiryDate != null &&
                ////    GetEstablishmentInstance.IsWASLValidAndNotExpired(
                ////        establishmentInfo.WASELExpiryDate.Value, establishmentInfo.WASELStatus.Value)))
                ////{
                ////    currentResponseMsg = new ResponseMsg
                ////    {
                ////        RuleTypeId = "IsWASLValidAndNotExpired",
                ////        IsSuccess = true,
                ////    };
                ////    resultsList.Add(currentResponseMsg);
                ////}
                ////else
                ////{
                ////    currentResponseMsg = new ResponseMsg
                ////    {
                ////        RuleTypeId = "IsWASLValidAndNotExpired",
                ////        IsSuccess = false,
                ////        ResponseText =
                ////            MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG12)
                ////    };
                ////    resultsList.Add(currentResponseMsg);
                ////}

                return resultsList;
            }
        }

        /// <summary>
        /// Check RunAway Business Rules (إلغاء بلاغ تغيب عامل)
        /// Code Review (Done)
        /// </summary>
        /// <param name="requestNumber">The request number.</param>
        /// <returns>HashSet&lt;ResponseMsg&gt;.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        /// <exception cref="System.ArgumentException"></exception>
        public HashSet<ResponseMsg> CheckCancelRunAwayBusinessRules(string requestNumber)
        {
            //Check input parameters is valid
            if (requestNumber.Trim().Equals(string.Empty))
            {
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            //==================================================================================
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (MessageClientInstance = new InfrastructureService.Get.GetSystemMessages())
            using (GetRunAwayRequestInstance = new ApplicationServices.RunAwayRequest.Get.GetRunAwayRequest())
            {
                var resultsList = new HashSet<ResponseMsg>();

                //==================================================================================
                //Get Startup Data
                var fullRequestInfo = GetRunAwayRequestInstance.GetRunAwayRequestInfo(requestNumber, dbUnitOfWork);

                if (fullRequestInfo == null)
                    throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

                //==================================================================================
                // Check id runaway request Is Eligible To be Canceled or not
                if (GetRunAwayRequestInstance.IsEligibleToCancel(fullRequestInfo.RequestId, fullRequestInfo.RunAwayRequestStatusId, dbUnitOfWork))
                {
                    resultsList.Add
                        (
                             new ResponseMsg
                             {
                                 RuleTypeId = "IsEligibleToCancel",
                                 IsSuccess = true
                             }
                         );
                }
                else
                {
                    resultsList.Add
                        (
                            new ResponseMsg
                            {
                                RuleTypeId = "IsEligibleToCancel",
                                IsSuccess = false,
                                ResponseText =
                                    MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG27)
                            }
                        );

                    return resultsList;
                }

                //==================================================================================
                //مضى 15 يوم على تقديم البلاغ
                //==================================================================================         
                if (!GetRunAwayRequestInstance.IsRequestBeyondCancelPeriod(fullRequestInfo.RequestDate, dbUnitOfWork))
                {
                    resultsList.Add
                        (
                            new ResponseMsg
                            {
                                RuleTypeId = "IsRequestBeyondCancelPeriod",
                                IsSuccess = true
                            }
                        );
                }
                else
                {
                    resultsList.Add
                        (
                            new ResponseMsg
                            {
                                RuleTypeId = "IsRequestBeyondCancelPeriod",
                                IsSuccess = false,
                                ResponseText =
                                    MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG07)
                            }
                        );
                }

                return resultsList;
            }
        }

        #endregion

        #region "CRUD DB Operations"

        /// <summary>
        /// Function returns list of Establishment RunAway requests (إدارة بلاغات التغيب)
        /// Code Review (Done)
        /// </summary>
        /// <param name="applicantUserIdNumber">The user identifier Id Number.</param>
        /// <param name="laborOfficeId">The establishment laborer office number.</param>
        /// <param name="sequenceNumber">The establishment sequence number.</param>
        /// <param name="queryRecordsCount">The query records count.</param>
        /// <param name="currentPageIndex">Index of the current page.</param>
        /// <returns>List of available Appointments</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public HashSet<RunAwayRetrieveRequestInfo> GetAllRunAwayRequestsList(
          long applicantUserIdNumber, int laborOfficeId, long sequenceNumber,
          int queryRecordsCount, int currentPageIndex)
        {
            //Check input parameters is valid
            if (applicantUserIdNumber <= 0 || laborOfficeId <= 0 ||
                sequenceNumber <= 0 || queryRecordsCount <= 0 || currentPageIndex < 0)
            {
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            //==================================================================================
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (GetRunAwayRequestInstance = new ApplicationServices.RunAwayRequest.Get.GetRunAwayRequest())
            {
                //==================================================================================
                //Call Application Service to retrieve the list
                var results =
                     GetRunAwayRequestInstance.GetAllRunAwayRequestsList(
                             applicantUserIdNumber, laborOfficeId, sequenceNumber,
                             queryRecordsCount, currentPageIndex, dbUnitOfWork);

                if (results != null && results.Count > 0)
                    return results;
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Function returns Establishment RunAway request by IdNumber or BorderNumber (إدارة بلاغات التغيب)
        /// Code Review (Done)
        /// </summary>
        /// <param name="applicantUserIdNumber">The user identifier Id Number.</param>
        /// <param name="laborOfficeId">The establishment laborer office number.</param>
        /// <param name="sequenceNumber">The establishment sequence number.</param>
        /// <param name="laborerIdNumber">Laborer ID Number</param>
        /// <param name="borderNumber">Laborer Border Number</param>
        /// <returns>List of available Appointments</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public RunAwayRetrieveRequestInfo GetRunAwayRequest(
          long applicantUserIdNumber, int laborOfficeId, long sequenceNumber,
            long? laborerIdNumber, long? borderNumber)
        {
            //Check input parameters is valid
            if (applicantUserIdNumber <= 0 || laborOfficeId <= 0 || sequenceNumber <= 0 ||
               (laborerIdNumber.HasValue && borderNumber.HasValue) ||
                (!laborerIdNumber.HasValue && !borderNumber.HasValue) ||
                (laborerIdNumber.HasValue && laborerIdNumber.Value <= 0) ||
                (borderNumber.HasValue && borderNumber.Value <= 0))
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //==================================================================================
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (GetRunAwayRequestInstance = new ApplicationServices.RunAwayRequest.Get.GetRunAwayRequest())
            {
                //==================================================================================
                //Call Application Service to retrieve the list
                //==================================================================================
                return GetRunAwayRequestInstance.GetRunAwayRequestInfo(
                            applicantUserIdNumber, laborOfficeId, sequenceNumber,
                            laborerIdNumber, borderNumber, dbUnitOfWork);
            }
        }

        #endregion

        #endregion
    }
}
