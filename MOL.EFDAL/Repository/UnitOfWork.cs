namespace MOL.EFDAL.Repository
{
    using System;

    public partial class UnitOfWork : IDisposable
    {
        #region [ Fields ]

        private readonly MOLEFEntities _context = new MOLEFEntities();
        private Active_Program_Establishment_Repository _active_Program_Establishment_Repository;
        private Channels_Repository _channels_Repository;
        private CJD_Online_Requests_Repository _cJD_Online_Requests_Repository;
        private CLB_Online_Requests_Repository _cLB_Online_Requests_Repository;
        private Enum_AccomodationStatus_Repository _enum_AccomodationStatus_Repository;
        private Enum_AccountManagerType_Repository _enum_AccountManagerType_Repository;
        private Enum_AgentType_Repository _enum_AgentType_Repository;
        private Enum_ChangeEstablishmentActivityRequestAction_Repository _enum_ChangeEstablishmentActivityRequestAction_Repository;
        private Enum_ChangeEstablishmentActivityRequestStatus_Repository _enum_ChangeEstablishmentActivityRequestStatus_Repository;
        private Enum_ChangeJobDescriptionCommentType_Repository _enum_ChangeJobDescriptionCommentType_Repository;
        private Enum_ChangeJobDescriptionRequestAction_Repository _enum_ChangeJobDescriptionRequestAction_Repository;
        private Enum_ChangeWorkerStatusCommentType_Repository _enum_ChangeWorkerStatusCommentType_Repository;
        private Enum_CommissionerType_Repository _enum_CommissionerType_Repository;
        private Enum_CounterItemType_Repository _enum_CounterItemType_Repository;
        private Enum_DrivingLicenseSecondaryType_Repository _enum_DrivingLicenseSecondaryType_Repository;
        private Enum_DrivingLicenseType_Repository _enum_DrivingLicenseType_Repository;
        private Enum_EmailLanguage_Repository _enum_EmailLanguage_Repository;
        private Enum_EmployeeAccountStatus_Repository _enum_EmployeeAccountStatus_Repository;
        private Enum_EmployeeType_Repository _enum_EmployeeType_Repository;
        private Enum_EstablishmentStatus_Repository _enum_EstablishmentStatus_Repository;
        private Enum_EstablishmentType_Repository _enum_EstablishmentType_Repository;
        private Enum_Gender_Repository _enum_Gender_Repository;
        private Enum_IndividualProfileRequestStatus_Repository _enum_IndividualProfileRequestStatus_Repository;
        private Enum_InspectionBillStatus_Repository _enum_InspectionBillStatus_Repository;
        private Enum_JobApplicationRequesterType_Repository _enum_JobApplicationRequesterType_Repository;
        private Enum_JobApplicationStatus_Repository _enum_JobApplicationStatus_Repository;
        private Enum_JobAvailability_Repository _enum_JobAvailability_Repository;
        private Enum_JobVacancyStatus_Repository _enum_JobVacancyStatus_Repository;
        private Enum_LaborerRejectionReason_Repository _enum_LaborerRejectionReason_Repository;
        private Enum_LaborerStatus_Repository _enum_LaborerStatus_Repository;
        private Enum_LaborerType_Repository _enum_LaborerType_Repository;
        private Enum_MessageMediaType_Repository _enum_MessageMediaType_Repository;
        private Enum_NoteApplicability_Repository _enum_NoteApplicability_Repository;
        private Enum_NoteSource_Repository _enum_NoteSource_Repository;
        private Enum_NoteStatus_Repository _enum_NoteStatus_Repository;
        private Enum_NoteType_Repository _enum_NoteType_Repository;
        private Enum_NotificationMessageCreator_Repository _enum_NotificationMessageCreator_Repository;
        private Enum_NotificationMessageStatus_Repository _enum_NotificationMessageStatus_Repository;
        private Enum_PayementType_Repository _enum_PayementType_Repository;
        private Enum_PrivilegeLevel_Repository _enum_PrivilegeLevel_Repository;
        private Enum_RequesterType_Repository _enum_RequesterType_Repository;
        private Enum_SaudiCertificateApprovalStatus_Repository _enum_SaudiCertificateApprovalStatus_Repository;
        private Enum_SaudiFlag_Repository _enum_SaudiFlag_Repository;
        private Enum_SequenceEntity_Repository _enum_SequenceEntity_Repository;
        private Enum_Service_Repository _enum_Service_Repository;
        private Enum_ServiceOfficeType_Repository _enum_ServiceOfficeType_Repository;
        private Enum_SponsorTransferCommentType_Repository _enum_SponsorTransferCommentType_Repository;
        private Enum_SponsorTransferRequestAction_Repository _enum_SponsorTransferRequestAction_Repository;
        private Enum_Srv_RequestType_Repository _enum_Srv_RequestType_Repository;
        private Enum_Srv_Status_Repository _enum_Srv_Status_Repository;
        private Enum_Srv_Validation_Repository _enum_Srv_Validation_Repository;
        private Enum_STLaborerSource_Repository _enum_STLaborerSource_Repository;
        private Enum_UserType_Repository _enum_UserType_Repository;
        private Enum_VacancyStatus_Repository _enum_VacancyStatus_Repository;
        private Enum_VisaRequestDecisionFlag_Repository _enum_VisaRequestDecisionFlag_Repository;
        private Enum_VisaRequestStatuses_Repository _enum_VisaRequestStatuses_Repository;
        private Enum_WorkingHoursPreference_Repository _enum_WorkingHoursPreference_Repository;
        private Enum_WorkPermitReason_Repository _enum_WorkPermitReason_Repository;
        private Establishment_Type_Repository _establishment_Type_Repository;
        private EWV_Online_Requests_Repository _eWV_Online_Requests_Repository;
        private Gov_Agency_Repository _gov_Agency_Repository;
        private InstanceState_Repository _instanceState_Repository;
        private IST_Online_Appoval_Repository _iST_Online_Appoval_Repository;
        private IST_Online_Requests_Repository _iST_Online_Requests_Repository;


        private Joining_Rule_Repository _joining_Rule_Repository;
        private Joining_Rule_Establishment_Type_Repository _joining_Rule_Establishment_Type_Repository;
        private Joining_Rules_Validation_Log_Repository _joining_Rules_Validation_Log_Repository;
        private Joining_Status_Repository _joining_Status_Repository;
        private Lookup_AgeRange_Repository _lookup_AgeRange_Repository;
        private Lookup_Bank_Repository _lookup_Bank_Repository;
        private Lookup_ChangeEstablishmentActivityReason_Repository _lookup_ChangeEstablishmentActivityReason_Repository;
        private Lookup_ChangeEstablishmentActivityRejectionReason_Repository _lookup_ChangeEstablishmentActivityRejectionReason_Repository;
        private Lookup_City_Repository _lookup_City_Repository;
        private Lookup_ComputerSkill_Repository _lookup_ComputerSkill_Repository;
        private Lookup_Country_Repository _lookup_Country_Repository;
        private Lookup_DisabilityType_Repository _lookup_DisabilityType_Repository;
        private Lookup_EconomicActivity_Repository _lookup_EconomicActivity_Repository;
        private Lookup_EducationalStatus_Repository _lookup_EducationalStatus_Repository;
        private Lookup_EstablishmentVisaCreditServiceConsumers_Repository _lookup_EstablishmentVisaCreditServiceConsumers_Repository;
        private Lookup_GPASystem_Repository _lookup_GPASystem_Repository;
        private Lookup_Job_Repository _lookup_Job_Repository;
        private Lookup_JobField_Repository _lookup_JobField_Repository;
        private Lookup_LawRepresentation_Repository _lookup_LawRepresentation_Repository;
        private Lookup_Municipality_Repository _lookup_Municipality_Repository;
        private Lookup_Nationality_Repository _lookup_Nationality_Repository;
        private Lookup_NewEconomicActivity_Repository _lookup_NewEconomicActivity_Repository;
        private Lookup_OpenId_Consumer_Repository _lookup_OpenId_Consumer_Repository;
        private Lookup_Origins_Repository _lookup_Origins_Repository;
        private Lookup_ProficiencyLevel_Repository _lookup_ProficiencyLevel_Repository;
        private Lookup_Qualification_Repository _lookup_Qualification_Repository;
        private Lookup_Religion_Repository _lookup_Religion_Repository;
        private Lookup_SaudiCertificateDirectedTo_Repository _lookup_SaudiCertificateDirectedTo_Repository;
        private Lookup_SaudiCertificatePurpose_Repository _lookup_SaudiCertificatePurpose_Repository;
        private Lookup_SecurableEntityType_Repository _lookup_SecurableEntityType_Repository;
        private Lookup_ServiceEndReason_Repository _lookup_ServiceEndReason_Repository;
        private Lookup_StatementsType_Repository _lookup_StatementsType_Repository;
        private Lookup_ViewerScope_Repository _lookup_ViewerScope_Repository;
        private Lookup_Zone_Repository _lookup_Zone_Repository;
        private MOL_AccountManager_Repository _mOL_AccountManager_Repository;
        private MOL_Agent_Repository _mOL_Agent_Repository;
        private MOL_AuditTrails_Repository _mOL_AuditTrails_Repository;
        private MOL_CancelVisaRequest_Repository _mOL_CancelVisaRequest_Repository;
        private MOL_CEAInbox_Repository _mOL_CEAInbox_Repository;
        private MOL_CEAReferenceSequence_Repository _mOL_CEAReferenceSequence_Repository;
        private MOL_CEAUserService_Repository _mOL_CEAUserService_Repository;
        private MOL_ChangeEstablishmentActivityRequest_Repository _mOL_ChangeEstablishmentActivityRequest_Repository;
        private MOL_Download_Repository _mOL_Download_Repository;
        private MOL_EconomicActivityStatement_Repository _mOL_EconomicActivityStatement_Repository;
        private MOL_Establishment_Repository _mOL_Establishment_Repository;
        private Mol_EstablishmentActivityCorrection_Repository _mol_EstablishmentActivityCorrection_Repository;
        private MOL_EstablishmentAgent_Repository _mOL_EstablishmentAgent_Repository;
        private MOL_EstablishmentAgentService_Repository _mOL_EstablishmentAgentService_Repository;
        private MOL_EstablishmentChangeStatus_Repository _mOL_EstablishmentChangeStatus_Repository;
        private MOL_EstablishmentCommissioner_Repository _mOL_EstablishmentCommissioner_Repository;
        private MOL_EstablishmentCommissionerService_Repository _mOL_EstablishmentCommissionerService_Repository;
        private MOL_EstablishmentEconomicActivity_Repository _mOL_EstablishmentEconomicActivity_Repository;
        private MOL_EstablishmentExceptionalWP_Repository _mOL_EstablishmentExceptionalWP_Repository;
        private MOL_EstablishmentNote_Repository _mOL_EstablishmentNote_Repository;
        private MOL_EstablishmentNoteService_Repository _mOL_EstablishmentNoteService_Repository;
        private MOL_EstablishmentProfile_Repository _mOL_EstablishmentProfile_Repository;
        private MOL_EstablishmentSaudiCertificate_Repository _mOL_EstablishmentSaudiCertificate_Repository;
        private MOL_EstablishmentSelectLog_Repository _mOL_EstablishmentSelectLog_Repository;
        private MOL_EstablishmentStatement_Repository _mOL_EstablishmentStatement_Repository;
        private MOL_EstablishmentVisaCredit_Repository _mOL_EstablishmentVisaCredit_Repository;
        private MOL_EstablishmnetEligibleToTakeAppointment_Repository _mOL_EstablishmnetEligibleToTakeAppointment_Repository;
        private MOL_FakeEmploymentReport_Repository _mOL_FakeEmploymentReport_Repository;
        private MOL_FakeEmploymentReportCommentOwner_Repository _mOL_FakeEmploymentReportCommentOwner_Repository;
        private MOL_FakeEmploymentReportComments_Repository _mOL_FakeEmploymentReportComments_Repository;
        private MOL_FakeEmploymentReportStatus_Repository _mOL_FakeEmploymentReportStatus_Repository;
        private MOL_GC_AssentJobs_Repository _mOL_GC_AssentJobs_Repository;
        private MOL_GC_Assents_Repository _mOL_GC_Assents_Repository;
        private MOL_GC_AssentTrackingLog_Repository _mOL_GC_AssentTrackingLog_Repository;
        private MOL_GC_ContractEstablishments_Repository _mOL_GC_ContractEstablishments_Repository;
        private MOL_GC_Contracts_Repository _mOL_GC_Contracts_Repository;
        private MOL_GenderActivityNationalityJobMatrix_Repository _mOL_GenderActivityNationalityJobMatrix_Repository;
        private MOL_HajOmraTransferRequests_Repository _mOL_HajOmraTransferRequests_Repository;
        private MOL_IssuedVisas_Repository _mOL_IssuedVisas_Repository;
        private MOL_Laborer_Repository _mOL_Laborer_Repository;
        private MOL_LaborerExceptionalWP_Repository _mOL_LaborerExceptionalWP_Repository;
        private MOL_LaborerMOIRunaway_Repository _mOL_LaborerMOIRunaway_Repository;
        private MOL_LaborerStatusServiceEndReason_Repository _mOL_LaborerStatusServiceEndReason_Repository;
        private MOL_LaborOffice_Repository _mOL_LaborOffice_Repository;
        private MOL_NotificationMessage_Repository _mOL_NotificationMessage_Repository;
        private MOL_NotificationMessageReceiver_Repository _mOL_NotificationMessageReceiver_Repository;
        private MOL_OpenIDLogs_Repository _mOL_OpenIDLogs_Repository;
        private MOL_OracleTransactionLog_Repository _mOL_OracleTransactionLog_Repository;
        private MOL_Owner_Repository _mOL_Owner_Repository;
        private MOL_ProgramBEstablishments_Repository _mOL_ProgramBEstablishments_Repository;
        private MOL_RunAwayCancelRequests_Repository _mOL_RunAwayCancelRequests_Repository;
        private MOL_Sec_Group_Repository _mOL_Sec_Group_Repository;
        private MOL_Sec_Privilege_Repository _mOL_Sec_Privilege_Repository;
        private MOL_Sec_Role_Repository _mOL_Sec_Role_Repository;
        private MOL_Sec_RolePrivilege_Repository _mOL_Sec_RolePrivilege_Repository;
        private MOL_Sec_SecurableEntity_Repository _mOL_Sec_SecurableEntity_Repository;
        private MOL_Sec_UserEntityPrivilege_Repository _mOL_Sec_UserEntityPrivilege_Repository;
        private MOL_Sec_UserRevokePrivilege_Repository _mOL_Sec_UserRevokePrivilege_Repository;
        private MOL_Sec_UserRole_Repository _mOL_Sec_UserRole_Repository;
        private MOL_Service_Log_Repository _mOL_Service_Log_Repository;
        private MOL_Service_Log_Extension_Repository _mOL_Service_Log_Extension_Repository;
        private MOL_Srv_Transaction_Repository _mOL_Srv_Transaction_Repository;
        private MOL_TransferRequest_Repository _mOL_TransferRequest_Repository;
        private MOL_UnifiedNumber_Repository _mOL_UnifiedNumber_Repository;
        private MOL_User_Repository _mOL_User_Repository;
        private MOL_VisaBalanceRejectReason_Repository _mOL_VisaBalanceRejectReason_Repository;
        private MOL_VisaIssuePrivateContract_Repository _mOL_VisaIssuePrivateContract_Repository;
        private MOL_VisaIssueRejectReasons_Repository _mOL_VisaIssueRejectReasons_Repository;
        private MOL_VisaIssueRequestDetails_Repository _mOL_VisaIssueRequestDetails_Repository;
        private MOL_VisaIssueRequests_Repository _mOL_VisaIssueRequests_Repository;
        private MOL_VisaPrerequisitesDocs_Repository _mOL_VisaPrerequisitesDocs_Repository;
        private MOL_VisaRequestDetails_Repository _mOL_VisaRequestDetails_Repository;
        private MOL_VisaRequestImmediateApproveDetails_Repository _mOL_VisaRequestImmediateApproveDetails_Repository;
        private MOL_VisaRequestImmediateApproveInfo_Repository _mOL_VisaRequestImmediateApproveInfo_Repository;
        private MOL_VisaRequests_Repository _mOL_VisaRequests_Repository;
        private MOL_VwAccountManager_Repository _mOL_VwAccountManager_Repository;
        private MOL_VwCEAEstablishmentDetails_Repository _mOL_VwCEAEstablishmentDetails_Repository;
        private MOL_VwCEAInbox_Repository _mOL_VwCEAInbox_Repository;
        private MOL_VwCEAJobLaborersCount_Repository _mOL_VwCEAJobLaborersCount_Repository;
        private MOL_VwCEARequestViewDetails_Repository _mOL_VwCEARequestViewDetails_Repository;
        private MOL_VwChangeEstablishmentActivityApprovalUsers_Repository _mOL_VwChangeEstablishmentActivityApprovalUsers_Repository;
        private MOL_VwOEFElectronicInquiries_Repository _mOL_VwOEFElectronicInquiries_Repository;
        private MOL_VwUnpaidWP200Violations_Repository _mOL_VwUnpaidWP200Violations_Repository;
        private MOL_VwUserEstablishments_Repository _mOL_VwUserEstablishments_Repository;
        private MOL_VwUserEstablishmentsNotes_Repository _mOL_VwUserEstablishmentsNotes_Repository;
        private MOL_WorkPermit_Repository _mOL_WorkPermit_Repository;
        private MOL_WP200ViolatedUnifiedNumbers_Repository _mOL_WP200ViolatedUnifiedNumbers_Repository;
        private MOL_WP200ViolationsCorrections_Repository _mOL_WP200ViolationsCorrections_Repository;
        private NitaqatActivity_Establishment_Repository _nitaqatActivity_Establishment_Repository;
        private OEF_Online_Requests_Repository _oEF_Online_Requests_Repository;
        private OpenId_Association_Repository _openId_Association_Repository;
        private OpenId_AuthToken_Repository _openId_AuthToken_Repository;
        private OpenId_Nonce_Repository _openId_Nonce_Repository;
        private OpenId_User_Repository _openId_User_Repository;
        private Overdue_Establishment_Repository _overdue_Establishment_Repository;
        private Periodic_Bill_Repository _periodic_Bill_Repository;
        private Program_Establishment_Repository _program_Establishment_Repository;
        private Program_Status_Repository _program_Status_Repository;

        private ST_Online_Approval_Repository _sT_Online_Approval_Repository;
        private ST_Online_Requests_Repository _sT_Online_Requests_Repository;
        private UnifiedNumber_NitaqatActivity_Establishment_Repository _unifiedNumber_NitaqatActivity_Establishment_Repository;
        private Unrejected_Joining_Request_Repository _unrejected_Joining_Request_Repository;
        private VW_EstablishmentActivityCorrection_Repository _vW_EstablishmentActivityCorrection_Repository;

        private VwManpowerMenu_Repository _vwManpowerMenu_Repository;
        private MOL_CancelFinalExitWorkPermit_Repository _MOL_CancelFinalExitWorkPermit_Repository;
        private MOL_OpenEstablishmentFileFromMCI_Repository _MOL_OpenEstablishmentFileFromMCI_Repository;
        private MOL_OpenEstablishmentFileFromSD_Repository _MOL_OpenEstablishmentFileFromSD_Repository;
        private MOL_EstablishmentMCIActivities_Repository _MOL_EstablishmentMCIActivities_Repository;
        private MOL_EstablishmentMCIParties_Repository _MOL_EstablishmentMCIParties_Repository;
        private MOL_EEF_OnlineRequests_Repository _MOL_EEF_OnlineRequests_Repository;
        private MOL_ChangeLaborerBranchInMOI_Repository _MOL_ChangeLaborerBranchInMOI_Repository;
        private MOL_ZATNoteConfirmationLog_Repository _MOL_ZATNoteConfirmationLog_Repository;

        private MOL_MonitoredUsersActivity_Repository _MOL_MonitoredUsersActivity_Repository;
        private MOL_UserLoginHistory_Repository _MOL_UserLoginHistory_Repository;

        #region " RAMS Unit of Work "

        private Lookup_RAMS_ComplaintTimes_Repository _Lookup_RAMS_ComplaintTimes_Repository;

        private MOL_RAMS_Complaint_Files_Repository _MOL_RAMS_Complaint_Files_Repository;

        private MOL_RAMS_ComplaintNotes_Repository _MOL_RAMS_ComplaintNotes_Repository;

        private MOL_RAMS_ComplaintTransactionsLog_Repository _MOL_RAMS_ComplaintTransactionsLog_Repository;

        private MOL_RAMS_CancelRunAway_Files_Repository _molRamsCancelRunAwayFilesRepository;

        private MOL_RAMS_RunAway_Files_Repository _MOL_RAMS_RunAway_Files_Repository;

        private MOL_RAMS_RunAwayTransactionsLog_Repository _MOL_RAMS_RunAwayTransactionsLog_Repository;

        private MOL_RunAwayComplaints_Repository _MOL_RunAwayComplaints_Repository;

        private MOL_Srv_ServiceConfiguration_Repository _MOL_Srv_ServiceConfiguration_Repository;


        #endregion

        #endregion

        #region [ Properties ]

        public Active_Program_Establishment_Repository Active_Program_Establishment_Repository
        {
            get { return this._active_Program_Establishment_Repository ?? (this._active_Program_Establishment_Repository = new Active_Program_Establishment_Repository(_context)); }
        }

        public Channels_Repository Channels_Repository
        {
            get { return this._channels_Repository ?? (this._channels_Repository = new Channels_Repository(_context)); }
        }

        public CJD_Online_Requests_Repository CJD_Online_Requests_Repository
        {
            get { return this._cJD_Online_Requests_Repository ?? (this._cJD_Online_Requests_Repository = new CJD_Online_Requests_Repository(_context)); }
        }

        public CLB_Online_Requests_Repository CLB_Online_Requests_Repository
        {
            get { return this._cLB_Online_Requests_Repository ?? (this._cLB_Online_Requests_Repository = new CLB_Online_Requests_Repository(_context)); }
        }

        public Enum_AccomodationStatus_Repository Enum_AccomodationStatus_Repository
        {
            get { return this._enum_AccomodationStatus_Repository ?? (this._enum_AccomodationStatus_Repository = new Enum_AccomodationStatus_Repository(_context)); }
        }

        public Enum_AccountManagerType_Repository Enum_AccountManagerType_Repository
        {
            get { return this._enum_AccountManagerType_Repository ?? (this._enum_AccountManagerType_Repository = new Enum_AccountManagerType_Repository(_context)); }
        }

        public Enum_AgentType_Repository Enum_AgentType_Repository
        {
            get { return this._enum_AgentType_Repository ?? (this._enum_AgentType_Repository = new Enum_AgentType_Repository(_context)); }
        }

        public Enum_ChangeEstablishmentActivityRequestAction_Repository Enum_ChangeEstablishmentActivityRequestAction_Repository
        {
            get { return this._enum_ChangeEstablishmentActivityRequestAction_Repository ?? (this._enum_ChangeEstablishmentActivityRequestAction_Repository = new Enum_ChangeEstablishmentActivityRequestAction_Repository(_context)); }
        }

        public Enum_ChangeEstablishmentActivityRequestStatus_Repository Enum_ChangeEstablishmentActivityRequestStatus_Repository
        {
            get { return this._enum_ChangeEstablishmentActivityRequestStatus_Repository ?? (this._enum_ChangeEstablishmentActivityRequestStatus_Repository = new Enum_ChangeEstablishmentActivityRequestStatus_Repository(_context)); }
        }

        public Enum_ChangeJobDescriptionCommentType_Repository Enum_ChangeJobDescriptionCommentType_Repository
        {
            get { return this._enum_ChangeJobDescriptionCommentType_Repository ?? (this._enum_ChangeJobDescriptionCommentType_Repository = new Enum_ChangeJobDescriptionCommentType_Repository(_context)); }
        }

        public Enum_ChangeJobDescriptionRequestAction_Repository Enum_ChangeJobDescriptionRequestAction_Repository
        {
            get { return this._enum_ChangeJobDescriptionRequestAction_Repository ?? (this._enum_ChangeJobDescriptionRequestAction_Repository = new Enum_ChangeJobDescriptionRequestAction_Repository(_context)); }
        }

        public Enum_ChangeWorkerStatusCommentType_Repository Enum_ChangeWorkerStatusCommentType_Repository
        {
            get { return this._enum_ChangeWorkerStatusCommentType_Repository ?? (this._enum_ChangeWorkerStatusCommentType_Repository = new Enum_ChangeWorkerStatusCommentType_Repository(_context)); }
        }

        public Enum_CommissionerType_Repository Enum_CommissionerType_Repository
        {
            get { return this._enum_CommissionerType_Repository ?? (this._enum_CommissionerType_Repository = new Enum_CommissionerType_Repository(_context)); }
        }

        public Enum_CounterItemType_Repository Enum_CounterItemType_Repository
        {
            get { return this._enum_CounterItemType_Repository ?? (this._enum_CounterItemType_Repository = new Enum_CounterItemType_Repository(_context)); }
        }

        public Enum_DrivingLicenseSecondaryType_Repository Enum_DrivingLicenseSecondaryType_Repository
        {
            get { return this._enum_DrivingLicenseSecondaryType_Repository ?? (this._enum_DrivingLicenseSecondaryType_Repository = new Enum_DrivingLicenseSecondaryType_Repository(_context)); }
        }

        public Enum_DrivingLicenseType_Repository Enum_DrivingLicenseType_Repository
        {
            get { return this._enum_DrivingLicenseType_Repository ?? (this._enum_DrivingLicenseType_Repository = new Enum_DrivingLicenseType_Repository(_context)); }
        }

        public Enum_EmailLanguage_Repository Enum_EmailLanguage_Repository
        {
            get { return this._enum_EmailLanguage_Repository ?? (this._enum_EmailLanguage_Repository = new Enum_EmailLanguage_Repository(_context)); }
        }

        public Enum_EmployeeAccountStatus_Repository Enum_EmployeeAccountStatus_Repository
        {
            get { return this._enum_EmployeeAccountStatus_Repository ?? (this._enum_EmployeeAccountStatus_Repository = new Enum_EmployeeAccountStatus_Repository(_context)); }
        }

        public Enum_EmployeeType_Repository Enum_EmployeeType_Repository
        {
            get { return this._enum_EmployeeType_Repository ?? (this._enum_EmployeeType_Repository = new Enum_EmployeeType_Repository(_context)); }
        }

        public Enum_EstablishmentStatus_Repository Enum_EstablishmentStatus_Repository
        {
            get { return this._enum_EstablishmentStatus_Repository ?? (this._enum_EstablishmentStatus_Repository = new Enum_EstablishmentStatus_Repository(_context)); }
        }

        public Enum_EstablishmentType_Repository Enum_EstablishmentType_Repository
        {
            get { return this._enum_EstablishmentType_Repository ?? (this._enum_EstablishmentType_Repository = new Enum_EstablishmentType_Repository(_context)); }
        }

        public Enum_Gender_Repository Enum_Gender_Repository
        {
            get { return this._enum_Gender_Repository ?? (this._enum_Gender_Repository = new Enum_Gender_Repository(_context)); }
        }

        public Enum_IndividualProfileRequestStatus_Repository Enum_IndividualProfileRequestStatus_Repository
        {
            get { return this._enum_IndividualProfileRequestStatus_Repository ?? (this._enum_IndividualProfileRequestStatus_Repository = new Enum_IndividualProfileRequestStatus_Repository(_context)); }
        }

        public Enum_InspectionBillStatus_Repository Enum_InspectionBillStatus_Repository
        {
            get { return this._enum_InspectionBillStatus_Repository ?? (this._enum_InspectionBillStatus_Repository = new Enum_InspectionBillStatus_Repository(_context)); }
        }

        public Enum_JobApplicationRequesterType_Repository Enum_JobApplicationRequesterType_Repository
        {
            get { return this._enum_JobApplicationRequesterType_Repository ?? (this._enum_JobApplicationRequesterType_Repository = new Enum_JobApplicationRequesterType_Repository(_context)); }
        }

        public Enum_JobApplicationStatus_Repository Enum_JobApplicationStatus_Repository
        {
            get { return this._enum_JobApplicationStatus_Repository ?? (this._enum_JobApplicationStatus_Repository = new Enum_JobApplicationStatus_Repository(_context)); }
        }

        public Enum_JobAvailability_Repository Enum_JobAvailability_Repository
        {
            get { return this._enum_JobAvailability_Repository ?? (this._enum_JobAvailability_Repository = new Enum_JobAvailability_Repository(_context)); }
        }

        public Enum_JobVacancyStatus_Repository Enum_JobVacancyStatus_Repository
        {
            get { return this._enum_JobVacancyStatus_Repository ?? (this._enum_JobVacancyStatus_Repository = new Enum_JobVacancyStatus_Repository(_context)); }
        }

        public Enum_LaborerRejectionReason_Repository Enum_LaborerRejectionReason_Repository
        {
            get { return this._enum_LaborerRejectionReason_Repository ?? (this._enum_LaborerRejectionReason_Repository = new Enum_LaborerRejectionReason_Repository(_context)); }
        }

        public Enum_LaborerStatus_Repository Enum_LaborerStatus_Repository
        {
            get { return this._enum_LaborerStatus_Repository ?? (this._enum_LaborerStatus_Repository = new Enum_LaborerStatus_Repository(_context)); }
        }

        public Enum_LaborerType_Repository Enum_LaborerType_Repository
        {
            get { return this._enum_LaborerType_Repository ?? (this._enum_LaborerType_Repository = new Enum_LaborerType_Repository(_context)); }
        }

        public Enum_MessageMediaType_Repository Enum_MessageMediaType_Repository
        {
            get { return this._enum_MessageMediaType_Repository ?? (this._enum_MessageMediaType_Repository = new Enum_MessageMediaType_Repository(_context)); }
        }

        public Enum_NoteApplicability_Repository Enum_NoteApplicability_Repository
        {
            get { return this._enum_NoteApplicability_Repository ?? (this._enum_NoteApplicability_Repository = new Enum_NoteApplicability_Repository(_context)); }
        }

        public Enum_NoteSource_Repository Enum_NoteSource_Repository
        {
            get { return this._enum_NoteSource_Repository ?? (this._enum_NoteSource_Repository = new Enum_NoteSource_Repository(_context)); }
        }

        public Enum_NoteStatus_Repository Enum_NoteStatus_Repository
        {
            get { return this._enum_NoteStatus_Repository ?? (this._enum_NoteStatus_Repository = new Enum_NoteStatus_Repository(_context)); }
        }

        public Enum_NoteType_Repository Enum_NoteType_Repository
        {
            get { return this._enum_NoteType_Repository ?? (this._enum_NoteType_Repository = new Enum_NoteType_Repository(_context)); }
        }

        public Enum_NotificationMessageCreator_Repository Enum_NotificationMessageCreator_Repository
        {
            get { return this._enum_NotificationMessageCreator_Repository ?? (this._enum_NotificationMessageCreator_Repository = new Enum_NotificationMessageCreator_Repository(_context)); }
        }

        public Enum_NotificationMessageStatus_Repository Enum_NotificationMessageStatus_Repository
        {
            get { return this._enum_NotificationMessageStatus_Repository ?? (this._enum_NotificationMessageStatus_Repository = new Enum_NotificationMessageStatus_Repository(_context)); }
        }

        public Enum_PayementType_Repository Enum_PayementType_Repository
        {
            get { return this._enum_PayementType_Repository ?? (this._enum_PayementType_Repository = new Enum_PayementType_Repository(_context)); }
        }

        public Enum_PrivilegeLevel_Repository Enum_PrivilegeLevel_Repository
        {
            get { return this._enum_PrivilegeLevel_Repository ?? (this._enum_PrivilegeLevel_Repository = new Enum_PrivilegeLevel_Repository(_context)); }
        }

        public Enum_RequesterType_Repository Enum_RequesterType_Repository
        {
            get { return this._enum_RequesterType_Repository ?? (this._enum_RequesterType_Repository = new Enum_RequesterType_Repository(_context)); }
        }

        public Enum_SaudiCertificateApprovalStatus_Repository Enum_SaudiCertificateApprovalStatus_Repository
        {
            get { return this._enum_SaudiCertificateApprovalStatus_Repository ?? (this._enum_SaudiCertificateApprovalStatus_Repository = new Enum_SaudiCertificateApprovalStatus_Repository(_context)); }
        }

        public Enum_SaudiFlag_Repository Enum_SaudiFlag_Repository
        {
            get { return this._enum_SaudiFlag_Repository ?? (this._enum_SaudiFlag_Repository = new Enum_SaudiFlag_Repository(_context)); }
        }

        public Enum_SequenceEntity_Repository Enum_SequenceEntity_Repository
        {
            get { return this._enum_SequenceEntity_Repository ?? (this._enum_SequenceEntity_Repository = new Enum_SequenceEntity_Repository(_context)); }
        }

        public Enum_Service_Repository Enum_Service_Repository
        {
            get { return this._enum_Service_Repository ?? (this._enum_Service_Repository = new Enum_Service_Repository(_context)); }
        }

        public Enum_ServiceOfficeType_Repository Enum_ServiceOfficeType_Repository
        {
            get { return this._enum_ServiceOfficeType_Repository ?? (this._enum_ServiceOfficeType_Repository = new Enum_ServiceOfficeType_Repository(_context)); }
        }

        public Enum_SponsorTransferCommentType_Repository Enum_SponsorTransferCommentType_Repository
        {
            get { return this._enum_SponsorTransferCommentType_Repository ?? (this._enum_SponsorTransferCommentType_Repository = new Enum_SponsorTransferCommentType_Repository(_context)); }
        }

        public Enum_SponsorTransferRequestAction_Repository Enum_SponsorTransferRequestAction_Repository
        {
            get { return this._enum_SponsorTransferRequestAction_Repository ?? (this._enum_SponsorTransferRequestAction_Repository = new Enum_SponsorTransferRequestAction_Repository(_context)); }
        }

        public Enum_Srv_RequestType_Repository Enum_Srv_RequestType_Repository
        {
            get { return this._enum_Srv_RequestType_Repository ?? (this._enum_Srv_RequestType_Repository = new Enum_Srv_RequestType_Repository(_context)); }
        }

        public Enum_Srv_Status_Repository Enum_Srv_Status_Repository
        {
            get { return this._enum_Srv_Status_Repository ?? (this._enum_Srv_Status_Repository = new Enum_Srv_Status_Repository(_context)); }
        }

        public Enum_Srv_Validation_Repository Enum_Srv_Validation_Repository
        {
            get { return this._enum_Srv_Validation_Repository ?? (this._enum_Srv_Validation_Repository = new Enum_Srv_Validation_Repository(_context)); }
        }

        public Enum_STLaborerSource_Repository Enum_STLaborerSource_Repository
        {
            get { return this._enum_STLaborerSource_Repository ?? (this._enum_STLaborerSource_Repository = new Enum_STLaborerSource_Repository(_context)); }
        }

        public Enum_UserType_Repository Enum_UserType_Repository
        {
            get { return this._enum_UserType_Repository ?? (this._enum_UserType_Repository = new Enum_UserType_Repository(_context)); }
        }

        public Enum_VacancyStatus_Repository Enum_VacancyStatus_Repository
        {
            get { return this._enum_VacancyStatus_Repository ?? (this._enum_VacancyStatus_Repository = new Enum_VacancyStatus_Repository(_context)); }
        }

        public Enum_VisaRequestDecisionFlag_Repository Enum_VisaRequestDecisionFlag_Repository
        {
            get { return this._enum_VisaRequestDecisionFlag_Repository ?? (this._enum_VisaRequestDecisionFlag_Repository = new Enum_VisaRequestDecisionFlag_Repository(_context)); }
        }

        public Enum_VisaRequestStatuses_Repository Enum_VisaRequestStatuses_Repository
        {
            get { return this._enum_VisaRequestStatuses_Repository ?? (this._enum_VisaRequestStatuses_Repository = new Enum_VisaRequestStatuses_Repository(_context)); }
        }

        public Enum_WorkingHoursPreference_Repository Enum_WorkingHoursPreference_Repository
        {
            get { return this._enum_WorkingHoursPreference_Repository ?? (this._enum_WorkingHoursPreference_Repository = new Enum_WorkingHoursPreference_Repository(_context)); }
        }

        public Enum_WorkPermitReason_Repository Enum_WorkPermitReason_Repository
        {
            get { return this._enum_WorkPermitReason_Repository ?? (this._enum_WorkPermitReason_Repository = new Enum_WorkPermitReason_Repository(_context)); }
        }

        public Establishment_Type_Repository Establishment_Type_Repository
        {
            get { return this._establishment_Type_Repository ?? (this._establishment_Type_Repository = new Establishment_Type_Repository(_context)); }
        }

        public EWV_Online_Requests_Repository EWV_Online_Requests_Repository
        {
            get { return this._eWV_Online_Requests_Repository ?? (this._eWV_Online_Requests_Repository = new EWV_Online_Requests_Repository(_context)); }
        }

        public Gov_Agency_Repository Gov_Agency_Repository
        {
            get { return this._gov_Agency_Repository ?? (this._gov_Agency_Repository = new Gov_Agency_Repository(_context)); }
        }

        public InstanceState_Repository InstanceState_Repository
        {
            get { return this._instanceState_Repository ?? (this._instanceState_Repository = new InstanceState_Repository(_context)); }
        }

        public IST_Online_Appoval_Repository IST_Online_Appoval_Repository
        {
            get { return this._iST_Online_Appoval_Repository ?? (this._iST_Online_Appoval_Repository = new IST_Online_Appoval_Repository(_context)); }
        }

        public IST_Online_Requests_Repository IST_Online_Requests_Repository
        {
            get { return this._iST_Online_Requests_Repository ?? (this._iST_Online_Requests_Repository = new IST_Online_Requests_Repository(_context)); }
        }




        public Joining_Rule_Repository Joining_Rule_Repository
        {
            get { return this._joining_Rule_Repository ?? (this._joining_Rule_Repository = new Joining_Rule_Repository(_context)); }
        }

        public Joining_Rule_Establishment_Type_Repository Joining_Rule_Establishment_Type_Repository
        {
            get { return this._joining_Rule_Establishment_Type_Repository ?? (this._joining_Rule_Establishment_Type_Repository = new Joining_Rule_Establishment_Type_Repository(_context)); }
        }

        public Joining_Rules_Validation_Log_Repository Joining_Rules_Validation_Log_Repository
        {
            get { return this._joining_Rules_Validation_Log_Repository ?? (this._joining_Rules_Validation_Log_Repository = new Joining_Rules_Validation_Log_Repository(_context)); }
        }

        public Joining_Status_Repository Joining_Status_Repository
        {
            get { return this._joining_Status_Repository ?? (this._joining_Status_Repository = new Joining_Status_Repository(_context)); }
        }

        public Lookup_AgeRange_Repository Lookup_AgeRange_Repository
        {
            get { return this._lookup_AgeRange_Repository ?? (this._lookup_AgeRange_Repository = new Lookup_AgeRange_Repository(_context)); }
        }

        public Lookup_Bank_Repository Lookup_Bank_Repository
        {
            get { return this._lookup_Bank_Repository ?? (this._lookup_Bank_Repository = new Lookup_Bank_Repository(_context)); }
        }

        public Lookup_ChangeEstablishmentActivityReason_Repository Lookup_ChangeEstablishmentActivityReason_Repository
        {
            get { return this._lookup_ChangeEstablishmentActivityReason_Repository ?? (this._lookup_ChangeEstablishmentActivityReason_Repository = new Lookup_ChangeEstablishmentActivityReason_Repository(_context)); }
        }

        public Lookup_ChangeEstablishmentActivityRejectionReason_Repository Lookup_ChangeEstablishmentActivityRejectionReason_Repository
        {
            get { return this._lookup_ChangeEstablishmentActivityRejectionReason_Repository ?? (this._lookup_ChangeEstablishmentActivityRejectionReason_Repository = new Lookup_ChangeEstablishmentActivityRejectionReason_Repository(_context)); }
        }

        public Lookup_City_Repository Lookup_City_Repository
        {
            get { return this._lookup_City_Repository ?? (this._lookup_City_Repository = new Lookup_City_Repository(_context)); }
        }

        public Lookup_ComputerSkill_Repository Lookup_ComputerSkill_Repository
        {
            get { return this._lookup_ComputerSkill_Repository ?? (this._lookup_ComputerSkill_Repository = new Lookup_ComputerSkill_Repository(_context)); }
        }

        public Lookup_Country_Repository Lookup_Country_Repository
        {
            get { return this._lookup_Country_Repository ?? (this._lookup_Country_Repository = new Lookup_Country_Repository(_context)); }
        }

        public Lookup_DisabilityType_Repository Lookup_DisabilityType_Repository
        {
            get { return this._lookup_DisabilityType_Repository ?? (this._lookup_DisabilityType_Repository = new Lookup_DisabilityType_Repository(_context)); }
        }

        public Lookup_EconomicActivity_Repository Lookup_EconomicActivity_Repository
        {
            get { return this._lookup_EconomicActivity_Repository ?? (this._lookup_EconomicActivity_Repository = new Lookup_EconomicActivity_Repository(_context)); }
        }

        public Lookup_EducationalStatus_Repository Lookup_EducationalStatus_Repository
        {
            get { return this._lookup_EducationalStatus_Repository ?? (this._lookup_EducationalStatus_Repository = new Lookup_EducationalStatus_Repository(_context)); }
        }

        public Lookup_EstablishmentVisaCreditServiceConsumers_Repository Lookup_EstablishmentVisaCreditServiceConsumers_Repository
        {
            get { return this._lookup_EstablishmentVisaCreditServiceConsumers_Repository ?? (this._lookup_EstablishmentVisaCreditServiceConsumers_Repository = new Lookup_EstablishmentVisaCreditServiceConsumers_Repository(_context)); }
        }

        public Lookup_GPASystem_Repository Lookup_GPASystem_Repository
        {
            get { return this._lookup_GPASystem_Repository ?? (this._lookup_GPASystem_Repository = new Lookup_GPASystem_Repository(_context)); }
        }

        public Lookup_Job_Repository Lookup_Job_Repository
        {
            get { return this._lookup_Job_Repository ?? (this._lookup_Job_Repository = new Lookup_Job_Repository(_context)); }
        }

        public Lookup_JobField_Repository Lookup_JobField_Repository
        {
            get { return this._lookup_JobField_Repository ?? (this._lookup_JobField_Repository = new Lookup_JobField_Repository(_context)); }
        }

        public Lookup_LawRepresentation_Repository Lookup_LawRepresentation_Repository
        {
            get { return this._lookup_LawRepresentation_Repository ?? (this._lookup_LawRepresentation_Repository = new Lookup_LawRepresentation_Repository(_context)); }
        }

        public Lookup_Municipality_Repository Lookup_Municipality_Repository
        {
            get { return this._lookup_Municipality_Repository ?? (this._lookup_Municipality_Repository = new Lookup_Municipality_Repository(_context)); }
        }

        public Lookup_Nationality_Repository Lookup_Nationality_Repository
        {
            get { return this._lookup_Nationality_Repository ?? (this._lookup_Nationality_Repository = new Lookup_Nationality_Repository(_context)); }
        }

        public Lookup_NewEconomicActivity_Repository Lookup_NewEconomicActivity_Repository
        {
            get { return this._lookup_NewEconomicActivity_Repository ?? (this._lookup_NewEconomicActivity_Repository = new Lookup_NewEconomicActivity_Repository(_context)); }
        }

        public Lookup_OpenId_Consumer_Repository Lookup_OpenId_Consumer_Repository
        {
            get { return this._lookup_OpenId_Consumer_Repository ?? (this._lookup_OpenId_Consumer_Repository = new Lookup_OpenId_Consumer_Repository(_context)); }
        }

        public Lookup_Origins_Repository Lookup_Origins_Repository
        {
            get { return this._lookup_Origins_Repository ?? (this._lookup_Origins_Repository = new Lookup_Origins_Repository(_context)); }
        }

        public Lookup_ProficiencyLevel_Repository Lookup_ProficiencyLevel_Repository
        {
            get { return this._lookup_ProficiencyLevel_Repository ?? (this._lookup_ProficiencyLevel_Repository = new Lookup_ProficiencyLevel_Repository(_context)); }
        }

        public Lookup_Qualification_Repository Lookup_Qualification_Repository
        {
            get { return this._lookup_Qualification_Repository ?? (this._lookup_Qualification_Repository = new Lookup_Qualification_Repository(_context)); }
        }

        public Lookup_Religion_Repository Lookup_Religion_Repository
        {
            get { return this._lookup_Religion_Repository ?? (this._lookup_Religion_Repository = new Lookup_Religion_Repository(_context)); }
        }

        public Lookup_SaudiCertificateDirectedTo_Repository Lookup_SaudiCertificateDirectedTo_Repository
        {
            get { return this._lookup_SaudiCertificateDirectedTo_Repository ?? (this._lookup_SaudiCertificateDirectedTo_Repository = new Lookup_SaudiCertificateDirectedTo_Repository(_context)); }
        }

        public Lookup_SaudiCertificatePurpose_Repository Lookup_SaudiCertificatePurpose_Repository
        {
            get { return this._lookup_SaudiCertificatePurpose_Repository ?? (this._lookup_SaudiCertificatePurpose_Repository = new Lookup_SaudiCertificatePurpose_Repository(_context)); }
        }

        public Lookup_SecurableEntityType_Repository Lookup_SecurableEntityType_Repository
        {
            get { return this._lookup_SecurableEntityType_Repository ?? (this._lookup_SecurableEntityType_Repository = new Lookup_SecurableEntityType_Repository(_context)); }
        }

        public Lookup_ServiceEndReason_Repository Lookup_ServiceEndReason_Repository
        {
            get { return this._lookup_ServiceEndReason_Repository ?? (this._lookup_ServiceEndReason_Repository = new Lookup_ServiceEndReason_Repository(_context)); }
        }

        public Lookup_StatementsType_Repository Lookup_StatementsType_Repository
        {
            get { return this._lookup_StatementsType_Repository ?? (this._lookup_StatementsType_Repository = new Lookup_StatementsType_Repository(_context)); }
        }

        public Lookup_ViewerScope_Repository Lookup_ViewerScope_Repository
        {
            get { return this._lookup_ViewerScope_Repository ?? (this._lookup_ViewerScope_Repository = new Lookup_ViewerScope_Repository(_context)); }
        }

        public Lookup_Zone_Repository Lookup_Zone_Repository
        {
            get { return this._lookup_Zone_Repository ?? (this._lookup_Zone_Repository = new Lookup_Zone_Repository(_context)); }
        }

        public MOL_AccountManager_Repository MOL_AccountManager_Repository
        {
            get { return this._mOL_AccountManager_Repository ?? (this._mOL_AccountManager_Repository = new MOL_AccountManager_Repository(_context)); }
        }

        public MOL_Agent_Repository MOL_Agent_Repository
        {
            get { return this._mOL_Agent_Repository ?? (this._mOL_Agent_Repository = new MOL_Agent_Repository(_context)); }
        }

        public MOL_AuditTrails_Repository MOL_AuditTrails_Repository
        {
            get { return this._mOL_AuditTrails_Repository ?? (this._mOL_AuditTrails_Repository = new MOL_AuditTrails_Repository(_context)); }
        }

        public MOL_CancelVisaRequest_Repository MOL_CancelVisaRequest_Repository
        {
            get { return this._mOL_CancelVisaRequest_Repository ?? (this._mOL_CancelVisaRequest_Repository = new MOL_CancelVisaRequest_Repository(_context)); }
        }

        public MOL_CEAInbox_Repository MOL_CEAInbox_Repository
        {
            get { return this._mOL_CEAInbox_Repository ?? (this._mOL_CEAInbox_Repository = new MOL_CEAInbox_Repository(_context)); }
        }

        public MOL_CEAReferenceSequence_Repository MOL_CEAReferenceSequence_Repository
        {
            get { return this._mOL_CEAReferenceSequence_Repository ?? (this._mOL_CEAReferenceSequence_Repository = new MOL_CEAReferenceSequence_Repository(_context)); }
        }

        public MOL_CEAUserService_Repository MOL_CEAUserService_Repository
        {
            get { return this._mOL_CEAUserService_Repository ?? (this._mOL_CEAUserService_Repository = new MOL_CEAUserService_Repository(_context)); }
        }

        public MOL_ChangeEstablishmentActivityRequest_Repository MOL_ChangeEstablishmentActivityRequest_Repository
        {
            get { return this._mOL_ChangeEstablishmentActivityRequest_Repository ?? (this._mOL_ChangeEstablishmentActivityRequest_Repository = new MOL_ChangeEstablishmentActivityRequest_Repository(_context)); }
        }

        public MOL_Download_Repository MOL_Download_Repository
        {
            get { return this._mOL_Download_Repository ?? (this._mOL_Download_Repository = new MOL_Download_Repository(_context)); }
        }

        public MOL_EconomicActivityStatement_Repository MOL_EconomicActivityStatement_Repository
        {
            get { return this._mOL_EconomicActivityStatement_Repository ?? (this._mOL_EconomicActivityStatement_Repository = new MOL_EconomicActivityStatement_Repository(_context)); }
        }

        public MOL_Establishment_Repository MOL_Establishment_Repository
        {
            get { return this._mOL_Establishment_Repository ?? (this._mOL_Establishment_Repository = new MOL_Establishment_Repository(_context)); }
        }

        public Mol_EstablishmentActivityCorrection_Repository Mol_EstablishmentActivityCorrection_Repository
        {
            get { return this._mol_EstablishmentActivityCorrection_Repository ?? (this._mol_EstablishmentActivityCorrection_Repository = new Mol_EstablishmentActivityCorrection_Repository(_context)); }
        }

        public MOL_EstablishmentAgent_Repository MOL_EstablishmentAgent_Repository
        {
            get { return this._mOL_EstablishmentAgent_Repository ?? (this._mOL_EstablishmentAgent_Repository = new MOL_EstablishmentAgent_Repository(_context)); }
        }

        public MOL_EstablishmentAgentService_Repository MOL_EstablishmentAgentService_Repository
        {
            get { return this._mOL_EstablishmentAgentService_Repository ?? (this._mOL_EstablishmentAgentService_Repository = new MOL_EstablishmentAgentService_Repository(_context)); }
        }

        public MOL_EstablishmentChangeStatus_Repository MOL_EstablishmentChangeStatus_Repository
        {
            get { return this._mOL_EstablishmentChangeStatus_Repository ?? (this._mOL_EstablishmentChangeStatus_Repository = new MOL_EstablishmentChangeStatus_Repository(_context)); }
        }

        public MOL_EstablishmentCommissioner_Repository MOL_EstablishmentCommissioner_Repository
        {
            get { return this._mOL_EstablishmentCommissioner_Repository ?? (this._mOL_EstablishmentCommissioner_Repository = new MOL_EstablishmentCommissioner_Repository(_context)); }
        }

        public MOL_EstablishmentCommissionerService_Repository MOL_EstablishmentCommissionerService_Repository
        {
            get { return this._mOL_EstablishmentCommissionerService_Repository ?? (this._mOL_EstablishmentCommissionerService_Repository = new MOL_EstablishmentCommissionerService_Repository(_context)); }
        }

        public MOL_EstablishmentEconomicActivity_Repository MOL_EstablishmentEconomicActivity_Repository
        {
            get { return this._mOL_EstablishmentEconomicActivity_Repository ?? (this._mOL_EstablishmentEconomicActivity_Repository = new MOL_EstablishmentEconomicActivity_Repository(_context)); }
        }

        public MOL_EstablishmentExceptionalWP_Repository MOL_EstablishmentExceptionalWP_Repository
        {
            get { return this._mOL_EstablishmentExceptionalWP_Repository ?? (this._mOL_EstablishmentExceptionalWP_Repository = new MOL_EstablishmentExceptionalWP_Repository(_context)); }
        }

        public MOL_EstablishmentNote_Repository MOL_EstablishmentNote_Repository
        {
            get { return this._mOL_EstablishmentNote_Repository ?? (this._mOL_EstablishmentNote_Repository = new MOL_EstablishmentNote_Repository(_context)); }
        }

        public MOL_EstablishmentNoteService_Repository MOL_EstablishmentNoteService_Repository
        {
            get { return this._mOL_EstablishmentNoteService_Repository ?? (this._mOL_EstablishmentNoteService_Repository = new MOL_EstablishmentNoteService_Repository(_context)); }
        }

        public MOL_EstablishmentProfile_Repository MOL_EstablishmentProfile_Repository
        {
            get { return this._mOL_EstablishmentProfile_Repository ?? (this._mOL_EstablishmentProfile_Repository = new MOL_EstablishmentProfile_Repository(_context)); }
        }

        public MOL_EstablishmentSaudiCertificate_Repository MOL_EstablishmentSaudiCertificate_Repository
        {
            get { return this._mOL_EstablishmentSaudiCertificate_Repository ?? (this._mOL_EstablishmentSaudiCertificate_Repository = new MOL_EstablishmentSaudiCertificate_Repository(_context)); }
        }

        public MOL_EstablishmentSelectLog_Repository MOL_EstablishmentSelectLog_Repository
        {
            get { return this._mOL_EstablishmentSelectLog_Repository ?? (this._mOL_EstablishmentSelectLog_Repository = new MOL_EstablishmentSelectLog_Repository(_context)); }
        }

        public MOL_EstablishmentStatement_Repository MOL_EstablishmentStatement_Repository
        {
            get { return this._mOL_EstablishmentStatement_Repository ?? (this._mOL_EstablishmentStatement_Repository = new MOL_EstablishmentStatement_Repository(_context)); }
        }

        public MOL_EstablishmentVisaCredit_Repository MOL_EstablishmentVisaCredit_Repository
        {
            get { return this._mOL_EstablishmentVisaCredit_Repository ?? (this._mOL_EstablishmentVisaCredit_Repository = new MOL_EstablishmentVisaCredit_Repository(_context)); }
        }

        public MOL_EstablishmnetEligibleToTakeAppointment_Repository MOL_EstablishmnetEligibleToTakeAppointment_Repository
        {
            get { return this._mOL_EstablishmnetEligibleToTakeAppointment_Repository ?? (this._mOL_EstablishmnetEligibleToTakeAppointment_Repository = new MOL_EstablishmnetEligibleToTakeAppointment_Repository(_context)); }
        }

        public MOL_FakeEmploymentReport_Repository MOL_FakeEmploymentReport_Repository
        {
            get { return this._mOL_FakeEmploymentReport_Repository ?? (this._mOL_FakeEmploymentReport_Repository = new MOL_FakeEmploymentReport_Repository(_context)); }
        }

        public MOL_FakeEmploymentReportCommentOwner_Repository MOL_FakeEmploymentReportCommentOwner_Repository
        {
            get { return this._mOL_FakeEmploymentReportCommentOwner_Repository ?? (this._mOL_FakeEmploymentReportCommentOwner_Repository = new MOL_FakeEmploymentReportCommentOwner_Repository(_context)); }
        }

        public MOL_FakeEmploymentReportComments_Repository MOL_FakeEmploymentReportComments_Repository
        {
            get { return this._mOL_FakeEmploymentReportComments_Repository ?? (this._mOL_FakeEmploymentReportComments_Repository = new MOL_FakeEmploymentReportComments_Repository(_context)); }
        }

        public MOL_FakeEmploymentReportStatus_Repository MOL_FakeEmploymentReportStatus_Repository
        {
            get { return this._mOL_FakeEmploymentReportStatus_Repository ?? (this._mOL_FakeEmploymentReportStatus_Repository = new MOL_FakeEmploymentReportStatus_Repository(_context)); }
        }

        public MOL_GC_AssentJobs_Repository MOL_GC_AssentJobs_Repository
        {
            get { return this._mOL_GC_AssentJobs_Repository ?? (this._mOL_GC_AssentJobs_Repository = new MOL_GC_AssentJobs_Repository(_context)); }
        }

        public MOL_GC_Assents_Repository MOL_GC_Assents_Repository
        {
            get { return this._mOL_GC_Assents_Repository ?? (this._mOL_GC_Assents_Repository = new MOL_GC_Assents_Repository(_context)); }
        }

        public MOL_GC_AssentTrackingLog_Repository MOL_GC_AssentTrackingLog_Repository
        {
            get { return this._mOL_GC_AssentTrackingLog_Repository ?? (this._mOL_GC_AssentTrackingLog_Repository = new MOL_GC_AssentTrackingLog_Repository(_context)); }
        }

        public MOL_GC_ContractEstablishments_Repository MOL_GC_ContractEstablishments_Repository
        {
            get { return this._mOL_GC_ContractEstablishments_Repository ?? (this._mOL_GC_ContractEstablishments_Repository = new MOL_GC_ContractEstablishments_Repository(_context)); }
        }

        public MOL_GC_Contracts_Repository MOL_GC_Contracts_Repository
        {
            get { return this._mOL_GC_Contracts_Repository ?? (this._mOL_GC_Contracts_Repository = new MOL_GC_Contracts_Repository(_context)); }
        }

        public MOL_GenderActivityNationalityJobMatrix_Repository MOL_GenderActivityNationalityJobMatrix_Repository
        {
            get { return this._mOL_GenderActivityNationalityJobMatrix_Repository ?? (this._mOL_GenderActivityNationalityJobMatrix_Repository = new MOL_GenderActivityNationalityJobMatrix_Repository(_context)); }
        }

        public MOL_HajOmraTransferRequests_Repository MOL_HajOmraTransferRequests_Repository
        {
            get { return this._mOL_HajOmraTransferRequests_Repository ?? (this._mOL_HajOmraTransferRequests_Repository = new MOL_HajOmraTransferRequests_Repository(_context)); }
        }

        public MOL_IssuedVisas_Repository MOL_IssuedVisas_Repository
        {
            get { return this._mOL_IssuedVisas_Repository ?? (this._mOL_IssuedVisas_Repository = new MOL_IssuedVisas_Repository(_context)); }
        }

        public MOL_Laborer_Repository MOL_Laborer_Repository
        {
            get { return this._mOL_Laborer_Repository ?? (this._mOL_Laborer_Repository = new MOL_Laborer_Repository(_context)); }
        }

        public MOL_LaborerExceptionalWP_Repository MOL_LaborerExceptionalWP_Repository
        {
            get { return this._mOL_LaborerExceptionalWP_Repository ?? (this._mOL_LaborerExceptionalWP_Repository = new MOL_LaborerExceptionalWP_Repository(_context)); }
        }

        public MOL_LaborerMOIRunaway_Repository MOL_LaborerMOIRunaway_Repository
        {
            get { return this._mOL_LaborerMOIRunaway_Repository ?? (this._mOL_LaborerMOIRunaway_Repository = new MOL_LaborerMOIRunaway_Repository(_context)); }
        }

        public MOL_LaborerStatusServiceEndReason_Repository MOL_LaborerStatusServiceEndReason_Repository
        {
            get { return this._mOL_LaborerStatusServiceEndReason_Repository ?? (this._mOL_LaborerStatusServiceEndReason_Repository = new MOL_LaborerStatusServiceEndReason_Repository(_context)); }
        }

        public MOL_LaborOffice_Repository MOL_LaborOffice_Repository
        {
            get { return this._mOL_LaborOffice_Repository ?? (this._mOL_LaborOffice_Repository = new MOL_LaborOffice_Repository(_context)); }
        }

        public MOL_NotificationMessage_Repository MOL_NotificationMessage_Repository
        {
            get { return this._mOL_NotificationMessage_Repository ?? (this._mOL_NotificationMessage_Repository = new MOL_NotificationMessage_Repository(_context)); }
        }

        public MOL_NotificationMessageReceiver_Repository MOL_NotificationMessageReceiver_Repository
        {
            get { return this._mOL_NotificationMessageReceiver_Repository ?? (this._mOL_NotificationMessageReceiver_Repository = new MOL_NotificationMessageReceiver_Repository(_context)); }
        }

        public MOL_OpenIDLogs_Repository MOL_OpenIDLogs_Repository
        {
            get { return this._mOL_OpenIDLogs_Repository ?? (this._mOL_OpenIDLogs_Repository = new MOL_OpenIDLogs_Repository(_context)); }
        }

        public MOL_OracleTransactionLog_Repository MOL_OracleTransactionLog_Repository
        {
            get { return this._mOL_OracleTransactionLog_Repository ?? (this._mOL_OracleTransactionLog_Repository = new MOL_OracleTransactionLog_Repository(_context)); }
        }

        public MOL_Owner_Repository MOL_Owner_Repository
        {
            get { return this._mOL_Owner_Repository ?? (this._mOL_Owner_Repository = new MOL_Owner_Repository(_context)); }
        }

        public MOL_ProgramBEstablishments_Repository MOL_ProgramBEstablishments_Repository
        {
            get { return this._mOL_ProgramBEstablishments_Repository ?? (this._mOL_ProgramBEstablishments_Repository = new MOL_ProgramBEstablishments_Repository(_context)); }
        }

        public MOL_RunAwayCancelRequests_Repository MOL_RunAwayCancelRequests_Repository
        {
            get { return this._mOL_RunAwayCancelRequests_Repository ?? (this._mOL_RunAwayCancelRequests_Repository = new MOL_RunAwayCancelRequests_Repository(_context)); }
        }

        public MOL_Sec_Group_Repository MOL_Sec_Group_Repository
        {
            get { return this._mOL_Sec_Group_Repository ?? (this._mOL_Sec_Group_Repository = new MOL_Sec_Group_Repository(_context)); }
        }

        public MOL_Sec_Privilege_Repository MOL_Sec_Privilege_Repository
        {
            get { return this._mOL_Sec_Privilege_Repository ?? (this._mOL_Sec_Privilege_Repository = new MOL_Sec_Privilege_Repository(_context)); }
        }

        public MOL_Sec_Role_Repository MOL_Sec_Role_Repository
        {
            get { return this._mOL_Sec_Role_Repository ?? (this._mOL_Sec_Role_Repository = new MOL_Sec_Role_Repository(_context)); }
        }

        public MOL_Sec_RolePrivilege_Repository MOL_Sec_RolePrivilege_Repository
        {
            get { return this._mOL_Sec_RolePrivilege_Repository ?? (this._mOL_Sec_RolePrivilege_Repository = new MOL_Sec_RolePrivilege_Repository(_context)); }
        }

        public MOL_Sec_SecurableEntity_Repository MOL_Sec_SecurableEntity_Repository
        {
            get { return this._mOL_Sec_SecurableEntity_Repository ?? (this._mOL_Sec_SecurableEntity_Repository = new MOL_Sec_SecurableEntity_Repository(_context)); }
        }

        public MOL_Sec_UserEntityPrivilege_Repository MOL_Sec_UserEntityPrivilege_Repository
        {
            get { return this._mOL_Sec_UserEntityPrivilege_Repository ?? (this._mOL_Sec_UserEntityPrivilege_Repository = new MOL_Sec_UserEntityPrivilege_Repository(_context)); }
        }

        public MOL_Sec_UserRevokePrivilege_Repository MOL_Sec_UserRevokePrivilege_Repository
        {
            get { return this._mOL_Sec_UserRevokePrivilege_Repository ?? (this._mOL_Sec_UserRevokePrivilege_Repository = new MOL_Sec_UserRevokePrivilege_Repository(_context)); }
        }

        public MOL_Sec_UserRole_Repository MOL_Sec_UserRole_Repository
        {
            get { return this._mOL_Sec_UserRole_Repository ?? (this._mOL_Sec_UserRole_Repository = new MOL_Sec_UserRole_Repository(_context)); }
        }

        public MOL_Service_Log_Repository MOL_Service_Log_Repository
        {
            get { return this._mOL_Service_Log_Repository ?? (this._mOL_Service_Log_Repository = new MOL_Service_Log_Repository(_context)); }
        }

        public MOL_Service_Log_Extension_Repository MOL_Service_Log_Extension_Repository
        {
            get { return this._mOL_Service_Log_Extension_Repository ?? (this._mOL_Service_Log_Extension_Repository = new MOL_Service_Log_Extension_Repository(_context)); }
        }

        public MOL_Srv_Transaction_Repository MOL_Srv_Transaction_Repository
        {
            get { return this._mOL_Srv_Transaction_Repository ?? (this._mOL_Srv_Transaction_Repository = new MOL_Srv_Transaction_Repository(_context)); }
        }

        public MOL_TransferRequest_Repository MOL_TransferRequest_Repository
        {
            get { return this._mOL_TransferRequest_Repository ?? (this._mOL_TransferRequest_Repository = new MOL_TransferRequest_Repository(_context)); }
        }

        public MOL_UnifiedNumber_Repository MOL_UnifiedNumber_Repository
        {
            get { return this._mOL_UnifiedNumber_Repository ?? (this._mOL_UnifiedNumber_Repository = new MOL_UnifiedNumber_Repository(_context)); }
        }

        public MOL_User_Repository MOL_User_Repository
        {
            get { return this._mOL_User_Repository ?? (this._mOL_User_Repository = new MOL_User_Repository(_context)); }
        }

        public MOL_VisaBalanceRejectReason_Repository MOL_VisaBalanceRejectReason_Repository
        {
            get { return this._mOL_VisaBalanceRejectReason_Repository ?? (this._mOL_VisaBalanceRejectReason_Repository = new MOL_VisaBalanceRejectReason_Repository(_context)); }
        }

        public MOL_VisaIssuePrivateContract_Repository MOL_VisaIssuePrivateContract_Repository
        {
            get { return this._mOL_VisaIssuePrivateContract_Repository ?? (this._mOL_VisaIssuePrivateContract_Repository = new MOL_VisaIssuePrivateContract_Repository(_context)); }
        }

        public MOL_VisaIssueRejectReasons_Repository MOL_VisaIssueRejectReasons_Repository
        {
            get { return this._mOL_VisaIssueRejectReasons_Repository ?? (this._mOL_VisaIssueRejectReasons_Repository = new MOL_VisaIssueRejectReasons_Repository(_context)); }
        }

        public MOL_VisaIssueRequestDetails_Repository MOL_VisaIssueRequestDetails_Repository
        {
            get { return this._mOL_VisaIssueRequestDetails_Repository ?? (this._mOL_VisaIssueRequestDetails_Repository = new MOL_VisaIssueRequestDetails_Repository(_context)); }
        }

        public MOL_VisaIssueRequests_Repository MOL_VisaIssueRequests_Repository
        {
            get { return this._mOL_VisaIssueRequests_Repository ?? (this._mOL_VisaIssueRequests_Repository = new MOL_VisaIssueRequests_Repository(_context)); }
        }

        public MOL_VisaPrerequisitesDocs_Repository MOL_VisaPrerequisitesDocs_Repository
        {
            get { return this._mOL_VisaPrerequisitesDocs_Repository ?? (this._mOL_VisaPrerequisitesDocs_Repository = new MOL_VisaPrerequisitesDocs_Repository(_context)); }
        }

        public MOL_VisaRequestDetails_Repository MOL_VisaRequestDetails_Repository
        {
            get { return this._mOL_VisaRequestDetails_Repository ?? (this._mOL_VisaRequestDetails_Repository = new MOL_VisaRequestDetails_Repository(_context)); }
        }

        public MOL_VisaRequestImmediateApproveDetails_Repository MOL_VisaRequestImmediateApproveDetails_Repository
        {
            get { return this._mOL_VisaRequestImmediateApproveDetails_Repository ?? (this._mOL_VisaRequestImmediateApproveDetails_Repository = new MOL_VisaRequestImmediateApproveDetails_Repository(_context)); }
        }

        public MOL_VisaRequestImmediateApproveInfo_Repository MOL_VisaRequestImmediateApproveInfo_Repository
        {
            get { return this._mOL_VisaRequestImmediateApproveInfo_Repository ?? (this._mOL_VisaRequestImmediateApproveInfo_Repository = new MOL_VisaRequestImmediateApproveInfo_Repository(_context)); }
        }

        public MOL_VisaRequests_Repository MOL_VisaRequests_Repository
        {
            get { return this._mOL_VisaRequests_Repository ?? (this._mOL_VisaRequests_Repository = new MOL_VisaRequests_Repository(_context)); }
        }

        public MOL_VwAccountManager_Repository MOL_VwAccountManager_Repository
        {
            get { return this._mOL_VwAccountManager_Repository ?? (this._mOL_VwAccountManager_Repository = new MOL_VwAccountManager_Repository(_context)); }
        }

        public MOL_VwCEAEstablishmentDetails_Repository MOL_VwCEAEstablishmentDetails_Repository
        {
            get { return this._mOL_VwCEAEstablishmentDetails_Repository ?? (this._mOL_VwCEAEstablishmentDetails_Repository = new MOL_VwCEAEstablishmentDetails_Repository(_context)); }
        }

        public MOL_VwCEAInbox_Repository MOL_VwCEAInbox_Repository
        {
            get { return this._mOL_VwCEAInbox_Repository ?? (this._mOL_VwCEAInbox_Repository = new MOL_VwCEAInbox_Repository(_context)); }
        }

        public MOL_VwCEAJobLaborersCount_Repository MOL_VwCEAJobLaborersCount_Repository
        {
            get { return this._mOL_VwCEAJobLaborersCount_Repository ?? (this._mOL_VwCEAJobLaborersCount_Repository = new MOL_VwCEAJobLaborersCount_Repository(_context)); }
        }

        public MOL_VwCEARequestViewDetails_Repository MOL_VwCEARequestViewDetails_Repository
        {
            get { return this._mOL_VwCEARequestViewDetails_Repository ?? (this._mOL_VwCEARequestViewDetails_Repository = new MOL_VwCEARequestViewDetails_Repository(_context)); }
        }

        public MOL_VwChangeEstablishmentActivityApprovalUsers_Repository MOL_VwChangeEstablishmentActivityApprovalUsers_Repository
        {
            get { return this._mOL_VwChangeEstablishmentActivityApprovalUsers_Repository ?? (this._mOL_VwChangeEstablishmentActivityApprovalUsers_Repository = new MOL_VwChangeEstablishmentActivityApprovalUsers_Repository(_context)); }
        }

        public MOL_VwOEFElectronicInquiries_Repository MOL_VwOEFElectronicInquiries_Repository
        {
            get { return this._mOL_VwOEFElectronicInquiries_Repository ?? (this._mOL_VwOEFElectronicInquiries_Repository = new MOL_VwOEFElectronicInquiries_Repository(_context)); }
        }

        public MOL_VwUnpaidWP200Violations_Repository MOL_VwUnpaidWP200Violations_Repository
        {
            get { return this._mOL_VwUnpaidWP200Violations_Repository ?? (this._mOL_VwUnpaidWP200Violations_Repository = new MOL_VwUnpaidWP200Violations_Repository(_context)); }
        }

        public MOL_VwUserEstablishments_Repository MOL_VwUserEstablishments_Repository
        {
            get { return this._mOL_VwUserEstablishments_Repository ?? (this._mOL_VwUserEstablishments_Repository = new MOL_VwUserEstablishments_Repository(_context)); }
        }

        public MOL_VwUserEstablishmentsNotes_Repository MOL_VwUserEstablishmentsNotes_Repository
        {
            get { return this._mOL_VwUserEstablishmentsNotes_Repository ?? (this._mOL_VwUserEstablishmentsNotes_Repository = new MOL_VwUserEstablishmentsNotes_Repository(_context)); }
        }

        public MOL_WorkPermit_Repository MOL_WorkPermit_Repository
        {
            get { return this._mOL_WorkPermit_Repository ?? (this._mOL_WorkPermit_Repository = new MOL_WorkPermit_Repository(_context)); }
        }

        public MOL_WP200ViolatedUnifiedNumbers_Repository MOL_WP200ViolatedUnifiedNumbers_Repository
        {
            get { return this._mOL_WP200ViolatedUnifiedNumbers_Repository ?? (this._mOL_WP200ViolatedUnifiedNumbers_Repository = new MOL_WP200ViolatedUnifiedNumbers_Repository(_context)); }
        }

        public MOL_WP200ViolationsCorrections_Repository MOL_WP200ViolationsCorrections_Repository
        {
            get { return this._mOL_WP200ViolationsCorrections_Repository ?? (this._mOL_WP200ViolationsCorrections_Repository = new MOL_WP200ViolationsCorrections_Repository(_context)); }
        }

        public NitaqatActivity_Establishment_Repository NitaqatActivity_Establishment_Repository
        {
            get { return this._nitaqatActivity_Establishment_Repository ?? (this._nitaqatActivity_Establishment_Repository = new NitaqatActivity_Establishment_Repository(_context)); }
        }

        public OEF_Online_Requests_Repository OEF_Online_Requests_Repository
        {
            get { return this._oEF_Online_Requests_Repository ?? (this._oEF_Online_Requests_Repository = new OEF_Online_Requests_Repository(_context)); }
        }

        public OpenId_Association_Repository OpenId_Association_Repository
        {
            get { return this._openId_Association_Repository ?? (this._openId_Association_Repository = new OpenId_Association_Repository(_context)); }
        }

        public OpenId_AuthToken_Repository OpenId_AuthToken_Repository
        {
            get { return this._openId_AuthToken_Repository ?? (this._openId_AuthToken_Repository = new OpenId_AuthToken_Repository(_context)); }
        }

        public OpenId_Nonce_Repository OpenId_Nonce_Repository
        {
            get { return this._openId_Nonce_Repository ?? (this._openId_Nonce_Repository = new OpenId_Nonce_Repository(_context)); }
        }

        public OpenId_User_Repository OpenId_User_Repository
        {
            get { return this._openId_User_Repository ?? (this._openId_User_Repository = new OpenId_User_Repository(_context)); }
        }

        public Overdue_Establishment_Repository Overdue_Establishment_Repository
        {
            get { return this._overdue_Establishment_Repository ?? (this._overdue_Establishment_Repository = new Overdue_Establishment_Repository(_context)); }
        }

        public Periodic_Bill_Repository Periodic_Bill_Repository
        {
            get { return this._periodic_Bill_Repository ?? (this._periodic_Bill_Repository = new Periodic_Bill_Repository(_context)); }
        }

        public Program_Establishment_Repository Program_Establishment_Repository
        {
            get { return this._program_Establishment_Repository ?? (this._program_Establishment_Repository = new Program_Establishment_Repository(_context)); }
        }

        public Program_Status_Repository Program_Status_Repository
        {
            get { return this._program_Status_Repository ?? (this._program_Status_Repository = new Program_Status_Repository(_context)); }
        }


        public ST_Online_Approval_Repository ST_Online_Approval_Repository
        {
            get { return this._sT_Online_Approval_Repository ?? (this._sT_Online_Approval_Repository = new ST_Online_Approval_Repository(_context)); }
        }

        public ST_Online_Requests_Repository ST_Online_Requests_Repository
        {
            get { return this._sT_Online_Requests_Repository ?? (this._sT_Online_Requests_Repository = new ST_Online_Requests_Repository(_context)); }
        }

        public UnifiedNumber_NitaqatActivity_Establishment_Repository UnifiedNumber_NitaqatActivity_Establishment_Repository
        {
            get { return this._unifiedNumber_NitaqatActivity_Establishment_Repository ?? (this._unifiedNumber_NitaqatActivity_Establishment_Repository = new UnifiedNumber_NitaqatActivity_Establishment_Repository(_context)); }
        }

        public Unrejected_Joining_Request_Repository Unrejected_Joining_Request_Repository
        {
            get { return this._unrejected_Joining_Request_Repository ?? (this._unrejected_Joining_Request_Repository = new Unrejected_Joining_Request_Repository(_context)); }
        }

        public VW_EstablishmentActivityCorrection_Repository VW_EstablishmentActivityCorrection_Repository
        {
            get { return this._vW_EstablishmentActivityCorrection_Repository ?? (this._vW_EstablishmentActivityCorrection_Repository = new VW_EstablishmentActivityCorrection_Repository(_context)); }
        }





        public VwManpowerMenu_Repository VwManpowerMenu_Repository
        {
            get { return this._vwManpowerMenu_Repository ?? (this._vwManpowerMenu_Repository = new VwManpowerMenu_Repository(_context)); }
        }
        public MOL_OpenEstablishmentFileFromMCI_Repository MOL_OpenEstablishmentFileFromMCI_Repository => this._MOL_OpenEstablishmentFileFromMCI_Repository ?? (this._MOL_OpenEstablishmentFileFromMCI_Repository = new MOL_OpenEstablishmentFileFromMCI_Repository(_context));
        public MOL_OpenEstablishmentFileFromSD_Repository MOL_OpenEstablishmentFileFromSD_Repository => this._MOL_OpenEstablishmentFileFromSD_Repository ?? (this._MOL_OpenEstablishmentFileFromSD_Repository = new MOL_OpenEstablishmentFileFromSD_Repository(_context));

        public MOL_EstablishmentMCIActivities_Repository MOL_EstablishmentMCIActivities_Repository => this._MOL_EstablishmentMCIActivities_Repository ?? (this._MOL_EstablishmentMCIActivities_Repository = new MOL_EstablishmentMCIActivities_Repository(_context));
        public MOL_EstablishmentMCIParties_Repository MOL_EstablishmentMCIParties_Repository => this._MOL_EstablishmentMCIParties_Repository ?? (this._MOL_EstablishmentMCIParties_Repository = new MOL_EstablishmentMCIParties_Repository(_context));
        public MOL_EEF_OnlineRequests_Repository MOL_EEF_OnlineRequests_Repository => this._MOL_EEF_OnlineRequests_Repository ?? (this._MOL_EEF_OnlineRequests_Repository = new MOL_EEF_OnlineRequests_Repository(_context));
        public MOL_ChangeLaborerBranchInMOI_Repository MOL_ChangeLaborerBranchInMOI_Repository => this._MOL_ChangeLaborerBranchInMOI_Repository ?? (this._MOL_ChangeLaborerBranchInMOI_Repository = new MOL_ChangeLaborerBranchInMOI_Repository(_context));

        public MOL_ZATNoteConfirmationLog_Repository MOL_ZATNoteConfirmationLog_Repository => this._MOL_ZATNoteConfirmationLog_Repository ?? (this._MOL_ZATNoteConfirmationLog_Repository = new MOL_ZATNoteConfirmationLog_Repository(_context));

        public MOL_CancelFinalExitWorkPermit_Repository MOL_CancelFinalExitWorkPermit_Repository
        {
            get { return this._MOL_CancelFinalExitWorkPermit_Repository ?? (this._MOL_CancelFinalExitWorkPermit_Repository = new MOL_CancelFinalExitWorkPermit_Repository(_context)); }
        }

        public MOL_MonitoredUsersActivity_Repository MOL_MonitoredUsersActivity_Repository => this._MOL_MonitoredUsersActivity_Repository ?? (this._MOL_MonitoredUsersActivity_Repository = new MOL_MonitoredUsersActivity_Repository(_context));
        public MOL_UserLoginHistory_Repository MOL_UserLoginHistory_Repository =>
            this._MOL_UserLoginHistory_Repository ?? (this._MOL_UserLoginHistory_Repository = new MOL_UserLoginHistory_Repository(_context));


        #region " RAMS added Values "

        public Lookup_RAMS_ComplaintTimes_Repository Lookup_RAMS_ComplaintTimes_Repository =>
            this._Lookup_RAMS_ComplaintTimes_Repository ?? (this._Lookup_RAMS_ComplaintTimes_Repository =
            new Lookup_RAMS_ComplaintTimes_Repository(_context));

        public MOL_RAMS_Complaint_Files_Repository MOL_RAMS_Complaint_Files_Repository =>
            this._MOL_RAMS_Complaint_Files_Repository ?? (this._MOL_RAMS_Complaint_Files_Repository =
            new MOL_RAMS_Complaint_Files_Repository(_context));

        public MOL_RAMS_ComplaintNotes_Repository MOL_RAMS_ComplaintNotes_Repository =>
            this._MOL_RAMS_ComplaintNotes_Repository ?? (this._MOL_RAMS_ComplaintNotes_Repository =
            new MOL_RAMS_ComplaintNotes_Repository(_context));

        public MOL_RAMS_ComplaintTransactionsLog_Repository MOL_RAMS_ComplaintTransactionsLog_Repository =>
            this._MOL_RAMS_ComplaintTransactionsLog_Repository ?? (this._MOL_RAMS_ComplaintTransactionsLog_Repository =
            new MOL_RAMS_ComplaintTransactionsLog_Repository(_context));

        public MOL_RAMS_CancelRunAway_Files_Repository MolRamsCancelRunAwayFilesRepository =>
            this._molRamsCancelRunAwayFilesRepository ?? (this._molRamsCancelRunAwayFilesRepository =
            new MOL_RAMS_CancelRunAway_Files_Repository(_context));

        public MOL_RAMS_RunAway_Files_Repository MOL_RAMS_RunAway_Files_Repository =>
            this._MOL_RAMS_RunAway_Files_Repository ?? (this._MOL_RAMS_RunAway_Files_Repository =
            new MOL_RAMS_RunAway_Files_Repository(_context));

        public MOL_RAMS_RunAwayTransactionsLog_Repository MOL_RAMS_RunAwayTransactionsLog_Repository =>
            this._MOL_RAMS_RunAwayTransactionsLog_Repository ?? (this._MOL_RAMS_RunAwayTransactionsLog_Repository =
            new MOL_RAMS_RunAwayTransactionsLog_Repository(_context));

        public MOL_RunAwayComplaints_Repository MOL_RunAwayComplaints_Repository =>
            this._MOL_RunAwayComplaints_Repository ?? (this._MOL_RunAwayComplaints_Repository =
            new MOL_RunAwayComplaints_Repository(_context));

        public MOL_Srv_ServiceConfiguration_Repository MOL_Srv_ServiceConfiguration_Repository =>
            this._MOL_Srv_ServiceConfiguration_Repository ?? (this._MOL_Srv_ServiceConfiguration_Repository =
            new MOL_Srv_ServiceConfiguration_Repository(_context));

        #endregion

        #endregion

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
