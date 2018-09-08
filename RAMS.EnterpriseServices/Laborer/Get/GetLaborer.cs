// ***********************************************************************
// Assembly         : RAMS.EnterpriseServices
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-04-2018
// ***********************************************************************
// <copyright file="GetLaborer.svc.cs" company="Tasleem IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.Repository;
using RAMS.ApplicationServices.Common;
using RAMS.CrossCutting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RAMS.EnterpriseServices.Laborer.Get
{
    /// <inheritdoc />
    /// <summary>
    /// Class GetLaborer.
    /// </summary>
    public class GetLaborer : BaseDisposeClass
    {
        #region "Private Members"

        /// <summary>
        /// Message Center instance
        /// </summary>
        /// <value>The message client instance.</value>
        private InfrastructureService.Get.GetSystemMessages MessageClientInstance { get; set; }

        /// <summary>
        /// Get Laborer Business Rules and Data property
        /// </summary>
        /// <value>As get laborer instance.</value>
        private ApplicationServices.Laborer.Get.GetLaborer ASGetLaborerInstance { get; set; }

        /// <summary>
        /// Get Laborer Case Info
        /// </summary>
        /// <value>As get laborer case instance.</value>
        private OracleIntegrationServices.CaseManagement.GetCase ASGetLaborerCaseInstance { get; set; }

        /// <summary>
        /// Get RunAway Info
        /// </summary>
        /// <value>As get run away instance.</value>
        private ApplicationServices.RunAwayRequest.Get.GetRunAwayRequest ASGetRunAwayInstance { get; set; }

        /// <summary>
        /// Get Common System Settings
        /// </summary>
        /// <value>The get common instance.</value>
        private GetCommon GetCommonInstance { get; set; }

        #endregion

        #region " Public ESB Functions "

        #region "Check Business Rules"

        /// <summary>
        /// Checks the create run away business rules.
        /// </summary>
        /// <param name="laborerIdNumber">The laborer identifier number.</param>
        /// <param name="borderNumber">The border number.</param>
        /// <param name="isRequestByEstablishmentAgent">if set to <c>true</c> [is request by establishment agent].</param>
        /// <param name="establishmentLaborOfficeId">The establishment labor office identifier.</param>
        /// <param name="establishmentSequenceNumber">The establishment sequence number.</param>
        /// <param name="isConfirmed">Check if Warning Business Rules is confirmed</param>
        /// <returns>HashSet&lt;ResponseMsg&gt;.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public HashSet<ResponseMsg> CheckCreateRunAwayBusinessRules(long? laborerIdNumber,
            long? borderNumber, bool isRequestByEstablishmentAgent,
            int establishmentLaborOfficeId, long establishmentSequenceNumber, bool isConfirmed = false)
        {
            //==================================================================================
            //Check input parameters is valid
            if ((laborerIdNumber.HasValue && borderNumber.HasValue) ||
                (!laborerIdNumber.HasValue && !borderNumber.HasValue) ||
                (laborerIdNumber.HasValue && laborerIdNumber.Value <= 0) ||
                (borderNumber.HasValue && borderNumber.Value <= 0) ||
                establishmentLaborOfficeId <= 0 || establishmentSequenceNumber <= 0)
                throw new ArgumentException(MethodBase.GetCurrentMethod().Name);

            if (laborerIdNumber > 0 &&
                     (!Utilities.IsLaborerBorderOrIdNumberValid(laborerIdNumber.ToString()) ||
                      Utilities.IsSaudiIdNumberValid(laborerIdNumber.ToString())) ||
                     (borderNumber > 0 && !Utilities.IsLaborerBorderOrIdNumberValid(borderNumber.ToString())))
            {
                return new HashSet<ResponseMsg>
                    {
                        new ResponseMsg
                        {
                            IsSuccess = false,
                            ResponseText =TypedObjects.RAMSInternalMSG01
                        }
                    };
            }
            //====================================================================================
            //Get Laborer Startup Data for laborer
            //Initialize Unit Of Work
            using (ASGetLaborerInstance = new ApplicationServices.Laborer.Get.GetLaborer())
            using (var dbUnitOfWork = new UnitOfWork())
            {
                var laborerDetails = ASGetLaborerInstance.GetLaborerDetailsFromMoL(laborerIdNumber, borderNumber, dbUnitOfWork);
                if (laborerDetails == null)
                {
                    return new HashSet<ResponseMsg>
                        {
                            new ResponseMsg
                            {
                               ResponseText = TypedObjects.RAMSInternalMSG01,
                               RuleTypeId = "GetLaborerDetailsFromMoL",
                               IsSuccess = false
                            }
                        };
                }

                //==================================================================================
                //Initialize Service Object(s)
                var resultsList = new HashSet<ResponseMsg>();

                //Add Laborer Name to output list
                resultsList.Add(
                    new ResponseMsg
                    {
                        ResponseText = laborerDetails.FullName,
                        RuleTypeId = "Laborer Full Name",
                        IsSuccess = true
                    });

                using (ASGetLaborerInstance = new ApplicationServices.Laborer.Get.GetLaborer())
                using (ASGetLaborerCaseInstance = new OracleIntegrationServices.CaseManagement.GetCase())
                using (MessageClientInstance = new InfrastructureService.Get.GetSystemMessages())
                {
                    ResponseMsg currentResponseMsg;
                    //==================================================================================
                    //العامل المطلوب يتبع المنشأة التي يمثلها المستخدم
                    //==================================================================================
                    if (laborerDetails.EstablishmentLaborOfficeId == establishmentLaborOfficeId &&
                        laborerDetails.EstablishmentSequenceNumber == establishmentSequenceNumber)
                    {
                        currentResponseMsg = new ResponseMsg
                        {
                            ResponseText = laborerDetails.FullName,
                            RuleTypeId = "IsLaborerBelongToEstablishment",
                            IsSuccess = true,
                        };

                        resultsList.Add(currentResponseMsg);
                    }
                    else
                    {
                        currentResponseMsg = new ResponseMsg
                        {
                            RuleTypeId = "IsLaborerBelongToEstablishment",
                            IsSuccess = false,
                            ResponseText =
                                MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG04)
                        };
                        resultsList.Add(currentResponseMsg);

                        return resultsList;
                    }
                    //==================================================================================
                    //العامل ليس على رأس العمل أو تمت الموافقة على نقل خدمته
                    //==================================================================================
                    if (ASGetLaborerInstance.IsStatusWorking(laborerDetails.LaborerStatusId))
                    {
                        currentResponseMsg = new ResponseMsg
                        {
                            RuleTypeId = "IsStatusWorking",
                            IsSuccess = true,
                        };

                        resultsList.Add(currentResponseMsg);
                    }
                    else
                    {
                        currentResponseMsg = new ResponseMsg
                        {
                            RuleTypeId = "IsStatusWorking",
                            IsSuccess = false,
                            ResponseText =
                                MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG05, laborerDetails.FullName)

                        };
                        resultsList.Add(currentResponseMsg);
                    }
                    //==================================================================================
                    //العامل المطلوب ليس لديه بلاغ تغيب قائم
                    //==================================================================================
                    if (ASGetLaborerInstance.HaveOpenRunAwayRequest(laborerDetails.Id, establishmentLaborOfficeId,
                        establishmentSequenceNumber, dbUnitOfWork))
                    {
                        currentResponseMsg = new ResponseMsg
                        {
                            RuleTypeId = "HaveOpenRunAwayRequest",
                            IsSuccess = false,
                            ResponseText =
                                MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG23)
                        };
                        resultsList.Add(currentResponseMsg);

                        return resultsList;
                    }
                    else
                    {
                        currentResponseMsg = new ResponseMsg
                        {
                            RuleTypeId = "HaveOpenRunAwayRequest",
                            IsSuccess = true,
                        };

                        resultsList.Add(currentResponseMsg);
                    }
                    //==================================================================================
                    //للعامل دعوى على المنشأة
                    //==================================================================================
                    if (laborerDetails.LaborerSequenceNumber != null &&
                        ASGetLaborerCaseInstance.IsLaborerHasCase(
                            establishmentLaborOfficeId, (int)establishmentSequenceNumber,
                            (int)TypedObjects.SaudiFlags.NonSaudi,
                            laborerDetails.LaborerOfficeId,
                            (int)laborerDetails.LaborerSequenceNumber.Value).IsSuccess)
                    {
                        currentResponseMsg = new ResponseMsg
                        {
                            RuleTypeId = "IsLaborerHasCase",
                            IsSuccess = false,
                            ResponseText =
                               MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG13)

                        };
                        resultsList.Add(currentResponseMsg);
                    }
                    else
                    {
                        currentResponseMsg = new ResponseMsg
                        {
                            IsSuccess = true,
                            RuleTypeId = "IsLaborerHasCase",
                        };

                        resultsList.Add(currentResponseMsg);
                    }

                    //==================================================================================
                    //قاعدة رخصة العمل والإقامة غير متحققة
                    //==================================================================================
                    var resultMsg = ASGetLaborerInstance.HasValidLaborerWorkPermitAndIqamma(
                        laborerIdNumber, borderNumber, isRequestByEstablishmentAgent, dbUnitOfWork);
                    if (resultMsg.IsSuccess)
                    {
                        currentResponseMsg = new ResponseMsg
                        {
                            RuleTypeId = resultMsg.RuleTypeId == TypedObjects.HasInvalidLaborerWorkPermitAndIqammaRule2 ?
                                TypedObjects.HasInvalidLaborerWorkPermitAndIqammaRule2 : "HasValidLaborerWorkPermitAndIqamma",
                            IsSuccess = true,
                        };

                        resultsList.Add(currentResponseMsg);
                    }
                    else
                    {
                        currentResponseMsg = new ResponseMsg
                        {
                            RuleTypeId = "HasValidLaborerWorkPermitAndIqamma",
                            IsSuccess = false,
                            ResponseText =
                                MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG14)
                        };
                        resultsList.Add(currentResponseMsg);
                    }
                    //==================================================================================
                    //عدد مرات تقديم بلاغ التغيب على عامل معين في فرع منشاة معين من خلال بوابة الخدمات الإلكترونية
                    // للمنشآت على عدد متغير من المرات (القيمة الافتراضية مرتان فقط). 
                    //==================================================================================
                    if (ASGetLaborerInstance.HaveOverNumberOfRunAwayRequest(
                        laborerIdNumber, borderNumber,
                        establishmentLaborOfficeId, establishmentSequenceNumber, dbUnitOfWork))
                    {
                        if (isRequestByEstablishmentAgent)
                        {
                            //Establishment agent cannot make extra Runaway request
                            currentResponseMsg = new ResponseMsg
                            {
                                RuleTypeId = TypedObjects.HaveOverNumberOfRunAwayRequest,
                                IsSuccess = false,
                                ResponseText =
                                    MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG25)
                            };
                        }
                        else if (!isConfirmed)
                        {
                            //MyClients user can make extra Runaway requests with Warning
                            currentResponseMsg = new ResponseMsg
                            {
                                RuleTypeId = TypedObjects.HaveOverNumberOfRunAwayRequest,
                                IsSuccess = false,
                                ResponseText =
                                    MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG26)
                            };
                        }

                        resultsList.Add(currentResponseMsg);
                    }
                    else
                    {
                        currentResponseMsg = new ResponseMsg
                        {
                            RuleTypeId = TypedObjects.HaveOverNumberOfRunAwayRequest,
                            IsSuccess = true
                        };
                        resultsList.Add(currentResponseMsg);
                    }

                    return resultsList;
                }
            }
        }

        /// <summary>
        /// Checks the cancel run away business rules.
        /// </summary>
        /// <param name="runAwayRequestNumber">The run away request number.</param>
        /// <param name="isRequestByEstablishmentAgent">if set to <c>true</c> [is request by establishment agent].</param>
        /// <returns>ActionResults&lt;ResponseMsg&gt;.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public ActionResults<HashSet<ResponseMsg>> CheckCancelRunAwayBusinessRules(
            string runAwayRequestNumber, bool isRequestByEstablishmentAgent)
        {
            //==================================================================================
            //Check input parameters is valid
            if (string.IsNullOrEmpty(runAwayRequestNumber))
                throw new ArgumentException(MethodBase.GetCurrentMethod().Name);

            //====================================================================================
            //Initialize Unit Of Work
            using (var dbUnitOfWork = new UnitOfWork())
            using (ASGetLaborerInstance = new ApplicationServices.Laborer.Get.GetLaborer())
            using (MessageClientInstance = new InfrastructureService.Get.GetSystemMessages())
            {
                //==================================================================================
                //عدد مرات تقديم بلاغ التغيب على عامل معين في فرع منشاة معين من خلال بوابة الخدمات الإلكترونية
                // للمنشآت على عدد متغير من المرات (القيمة الافتراضية مرتان فقط). 
                //==================================================================================
                if (ASGetLaborerInstance.HaveOverNumberOfRunAwayCancelRequest(runAwayRequestNumber, dbUnitOfWork))
                {
                    if (isRequestByEstablishmentAgent)
                    {
                        //Establishment agent cannot make extra Cancel Runaway requests
                        return new ActionResults<HashSet<ResponseMsg>>
                        {
                            IsSuccess = false,
                            ResultsCode = ResultsCodes.BusinessRulesViolationError,
                            Description = MethodBase.GetCurrentMethod().Name,

                            ResultsList = new HashSet<ResponseMsg>
                            {
                                new ResponseMsg
                                {
                                    IsSuccess = false,
                                    ResponseText = MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG34)
                                }
                            }
                        };
                    }
                    else
                    {
                        //MyClients user can make extra Runaway requests with Warning
                        return new ActionResults<HashSet<ResponseMsg>>
                        {
                            IsSuccess = false,
                            ResultsCode = ResultsCodes.BusinessRulesViolationWarning,
                            Description = MethodBase.GetCurrentMethod().Name,

                            ResultsList = new HashSet<ResponseMsg>
                            {
                                new ResponseMsg
                                {
                                    IsSuccess = false,
                                    ResponseText = MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG35)
                                }
                            }
                        };
                    }
                }
                else
                {
                    return new ActionResults<HashSet<ResponseMsg>>
                    {
                        IsSuccess = true,
                        Description = MethodBase.GetCurrentMethod().Name,
                        ResultsCode = ResultsCodes.BusinessRulesSucceeded,
                        ResultsList = new HashSet<ResponseMsg>
                        {
                            new ResponseMsg
                            {
                                IsSuccess = true,
                                ResponseText = MethodBase.GetCurrentMethod().Name
                            }
                        }
                    };
                }
            }
        }


        /// <summary>
        /// Check Laborer Business Rules (طلب إثبات كيدية بلاغ تغيب )
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <returns>HashSet&lt;ResponseMsg&gt;.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public HashSet<ResponseMsg> CheckCreateComplaintBusinessRules(int runAwayRequestId)
        {
            //==================================================================================
            //Check input parameters is valid
            if (runAwayRequestId <= 0)
            {
                throw new ArgumentException(MethodBase.GetCurrentMethod().Name);
            }

            //====================================================================================
            //Get RunAway Startup Data for laborer
            using (ASGetRunAwayInstance = new ApplicationServices.RunAwayRequest.Get.GetRunAwayRequest())
            using (MessageClientInstance = new InfrastructureService.Get.GetSystemMessages())
            using (var dbUnitOfWork = new UnitOfWork())
            {
                var runAwayRequestInfo = ASGetRunAwayInstance.GetRunAwayRequestInfo(runAwayRequestId, dbUnitOfWork);
                if (runAwayRequestInfo == null)
                {
                    return new HashSet<ResponseMsg>
                    {
                        new ResponseMsg
                        {
                            RuleTypeId = "GetRunAwayRequestById",
                            IsSuccess = false,
                            ResponseText =
                                MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG01)
                        }
                    };
                }

                //==================================================================================
                //Initialize Service Object(s)
                var resultsList = new HashSet<ResponseMsg>();
                ResponseMsg currentResponseMsg;

                //==================================================================================
                //لا يمكن تقديم طلب إثبات كيدية بلاغ تغيب بعد مرور عام 
                // على تقديمه من المنشأة ضد العامل، وهذه المدة يمكن تغييرها في إعدادات النظام            
                //==================================================================================
                if (ASGetRunAwayInstance.IsRequestBeyondComplaintPeriod(runAwayRequestInfo.RequestDate, dbUnitOfWork))
                {
                    currentResponseMsg = new ResponseMsg
                    {
                        RuleTypeId = "IsRequestBeyondComplaintPeriod",
                        IsSuccess = false,
                        ResponseText =
                            MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG09)
                    };
                    resultsList.Add(currentResponseMsg);
                }
                else
                {
                    currentResponseMsg = new ResponseMsg
                    {
                        RuleTypeId = "IsRequestBeyondComplaintPeriod",
                        IsSuccess = true,
                    };

                    resultsList.Add(currentResponseMsg);
                }
                //==================================================================================
                // لا يمكن تقديم طلب إثبات كيدية بلاغ تغيب تم رفضه سابقا من قبل إدارة بلاغات التغيب.
                //==================================================================================
                if (runAwayRequestInfo.RunAwayRequestStatusId == TypedObjects.RunAwayRequestStatus.Rejected.GetHashCode())
                {
                    currentResponseMsg = new ResponseMsg
                    {
                        RuleTypeId = "RunAwayRequestStatusIsRejected",
                        IsSuccess = false,
                        ResponseText =
                            MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG15)
                    };
                    resultsList.Add(currentResponseMsg);
                }
                else
                {
                    currentResponseMsg = new ResponseMsg
                    {
                        RuleTypeId = "RunAwayRequestStatusIsRejected",
                        IsSuccess = true,
                    };

                    resultsList.Add(currentResponseMsg);
                }

                //==================================================================================
                // لا يمكن تقديم أكثر من طلب إثبات كيدية لنفس البلاغ
                //==================================================================================
                if (ASGetRunAwayInstance.IsRequestHasComplaint(runAwayRequestInfo.RequestId, dbUnitOfWork))
                {
                    currentResponseMsg = new ResponseMsg
                    {
                        RuleTypeId = "IsRequestHasAComplaint",
                        IsSuccess = false,
                        ResponseText = MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG16)
                    };

                    resultsList.Add(currentResponseMsg);
                }
                else
                {
                    currentResponseMsg = new ResponseMsg
                    {
                        RuleTypeId = "IsRequestHasAComplaint",
                        IsSuccess = true

                    };
                    resultsList.Add(currentResponseMsg);
                }
                return resultsList;
            }
        }

        #endregion

        #region "CRUD DB Operations"

        /// <summary>
        /// Function returns Laborer RunAway request by IdNumber (طلب إثبات كيدية بلاغ تغيب)
        /// </summary>
        /// <param name="laborerIdNumber">Laborer ID Number</param>
        /// <param name="borderNumber">Laborer Border Number</param>
        /// <returns>List of available Appointments</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ComplaintRetrieveRequestInfo GetLatestRunAwayOrComplaintRequest(long? laborerIdNumber, long? borderNumber)
        {
            //==================================================================================
            //Check input parameters is valid
            if ((laborerIdNumber.HasValue && borderNumber.HasValue) ||
                (!laborerIdNumber.HasValue && !borderNumber.HasValue) ||
                (laborerIdNumber.HasValue && laborerIdNumber.Value <= 0) ||
                (borderNumber.HasValue && borderNumber.Value <= 0))
                throw new ArgumentException(MethodBase.GetCurrentMethod().Name);

            //==================================================================================
            //Initialize Service Object(s)          
            using (ASGetLaborerInstance = new ApplicationServices.Laborer.Get.GetLaborer())
            using (var dbUnitOfWork = new UnitOfWork())
            using (GetCommonInstance = new GetCommon())
            {
                //Read setting value from DB 
                var systemNumberOfDays =
                        GetCommonInstance.GetSystemSettings(TypedObjects.SystemSettings.AllowedDaysToComplaintRequest,
                            dbUnitOfWork);
                //====================================================================================
                //Get Laborer Startup Data for laborer
                return ASGetLaborerInstance.GetLatestRunAwayOrComplaintRequest(laborerIdNumber, borderNumber, systemNumberOfDays, dbUnitOfWork);

            }
        }

        #endregion

        #endregion
    }
}
