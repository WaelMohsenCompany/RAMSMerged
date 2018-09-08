namespace MOL.EFDAL
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Transactions;

    public partial class MOLEFEntities : DbContext
    {
        static MOLEFEntities()
        {
            Database.SetInitializer<MOLEFEntities>(null);
        }

        public MOLEFEntities()
            : base("Name=MOLEFEntities")
        {
        }

        #region [DbSets]
        public virtual DbSet<CJD_Online_Requests> CJD_Online_Requests { get; set; }
        public virtual DbSet<CLB_Online_Requests> CLB_Online_Requests { get; set; }
        public virtual DbSet<Enum_AccomodationStatus> Enum_AccomodationStatus { get; set; }
        public virtual DbSet<Enum_AccountManagerType> Enum_AccountManagerType { get; set; }
        public virtual DbSet<Enum_AgentType> Enum_AgentType { get; set; }
        public virtual DbSet<Enum_AuditAction> Enum_AuditAction { get; set; }
        public virtual DbSet<Enum_ChangeEstablishmentActivityRequestAction> Enum_ChangeEstablishmentActivityRequestAction { get; set; }
        public virtual DbSet<Enum_ChangeEstablishmentActivityRequestStatus> Enum_ChangeEstablishmentActivityRequestStatus { get; set; }
        public virtual DbSet<Enum_ChangeJobDescriptionCommentType> Enum_ChangeJobDescriptionCommentType { get; set; }
        public virtual DbSet<Enum_ChangeJobDescriptionRequestAction> Enum_ChangeJobDescriptionRequestAction { get; set; }
        public virtual DbSet<Enum_ChangeWorkerStatusCommentType> Enum_ChangeWorkerStatusCommentType { get; set; }
        public virtual DbSet<Enum_CommissionerType> Enum_CommissionerType { get; set; }
        public virtual DbSet<Enum_CounterItemType> Enum_CounterItemType { get; set; }
        public virtual DbSet<Enum_CRStatus> Enum_CRStatus { get; set; }
        public virtual DbSet<Enum_DrivingLicenseSecondaryType> Enum_DrivingLicenseSecondaryType { get; set; }
        public virtual DbSet<Enum_DrivingLicenseType> Enum_DrivingLicenseType { get; set; }
        public virtual DbSet<Enum_EmailLanguage> Enum_EmailLanguage { get; set; }
        public virtual DbSet<Enum_EmployeeAccountStatus> Enum_EmployeeAccountStatus { get; set; }
        public virtual DbSet<Enum_EmployeeType> Enum_EmployeeType { get; set; }
        public virtual DbSet<Enum_EstablishmentStatus> Enum_EstablishmentStatus { get; set; }
        public virtual DbSet<Enum_EstablishmentType> Enum_EstablishmentType { get; set; }
        public virtual DbSet<Enum_EstablishmentVisaCreditJobOperationType> Enum_EstablishmentVisaCreditJobOperationType { get; set; }
        public virtual DbSet<Enum_EstablishmentVisaCreditOperationType> Enum_EstablishmentVisaCreditOperationType { get; set; }
        public virtual DbSet<Enum_EstablishmentVisaCreditTerminationReason> Enum_EstablishmentVisaCreditTerminationReason { get; set; }
        public virtual DbSet<Enum_EstablishmentVisaCreditType> Enum_EstablishmentVisaCreditType { get; set; }
        public virtual DbSet<Enum_Gender> Enum_Gender { get; set; }
        public virtual DbSet<Enum_IndividualProfileRequestStatus> Enum_IndividualProfileRequestStatus { get; set; }
        public virtual DbSet<Enum_InspectionBillStatus> Enum_InspectionBillStatus { get; set; }
        public virtual DbSet<Enum_JobApplicationRequesterType> Enum_JobApplicationRequesterType { get; set; }
        public virtual DbSet<Enum_JobApplicationStatus> Enum_JobApplicationStatus { get; set; }
        public virtual DbSet<Enum_JobAvailability> Enum_JobAvailability { get; set; }
        public virtual DbSet<Enum_JobVacancyStatus> Enum_JobVacancyStatus { get; set; }
        public virtual DbSet<Enum_LaborerRejectionReason> Enum_LaborerRejectionReason { get; set; }
        public virtual DbSet<Enum_LaborerStatus> Enum_LaborerStatus { get; set; }
        public virtual DbSet<Enum_LaborerType> Enum_LaborerType { get; set; }
        public virtual DbSet<Enum_MessageMediaType> Enum_MessageMediaType { get; set; }
        public virtual DbSet<Enum_NoteApplicability> Enum_NoteApplicability { get; set; }
        public virtual DbSet<Enum_NoteSource> Enum_NoteSource { get; set; }
        public virtual DbSet<Enum_NoteStatus> Enum_NoteStatus { get; set; }
        public virtual DbSet<Enum_NoteType> Enum_NoteType { get; set; }
        public virtual DbSet<Enum_NotificationMessageCreator> Enum_NotificationMessageCreator { get; set; }
        public virtual DbSet<Enum_NotificationMessageStatus> Enum_NotificationMessageStatus { get; set; }
        public virtual DbSet<Enum_PayementType> Enum_PayementType { get; set; }
        public virtual DbSet<Enum_PrivilegeLevel> Enum_PrivilegeLevel { get; set; }
        public virtual DbSet<Enum_RequesterType> Enum_RequesterType { get; set; }
        public virtual DbSet<Enum_SaudiCertificateApprovalStatus> Enum_SaudiCertificateApprovalStatus { get; set; }
        public virtual DbSet<Enum_SaudiFlag> Enum_SaudiFlag { get; set; }
        public virtual DbSet<Enum_SequenceEntity> Enum_SequenceEntity { get; set; }
        public virtual DbSet<Enum_Service> Enum_Service { get; set; }
        public virtual DbSet<Enum_ServiceOfficeType> Enum_ServiceOfficeType { get; set; }
        public virtual DbSet<Enum_SponsorTransferCommentType> Enum_SponsorTransferCommentType { get; set; }
        public virtual DbSet<Enum_SponsorTransferRequestAction> Enum_SponsorTransferRequestAction { get; set; }
        public virtual DbSet<Enum_Srv_RequestType> Enum_Srv_RequestType { get; set; }
        public virtual DbSet<Enum_Srv_Status> Enum_Srv_Status { get; set; }
        public virtual DbSet<Enum_Srv_Validation> Enum_Srv_Validation { get; set; }
        public virtual DbSet<Enum_STLaborerSource> Enum_STLaborerSource { get; set; }
        public virtual DbSet<Enum_UserType> Enum_UserType { get; set; }
        public virtual DbSet<Enum_VacancyStatus> Enum_VacancyStatus { get; set; }
        public virtual DbSet<Enum_VisaRequestDecisionFlag> Enum_VisaRequestDecisionFlag { get; set; }
        public virtual DbSet<Enum_VisaRequestStatuses> Enum_VisaRequestStatuses { get; set; }
        public virtual DbSet<Enum_WorkingHoursPreference> Enum_WorkingHoursPreference { get; set; }
        public virtual DbSet<Enum_WorkPermitReason> Enum_WorkPermitReason { get; set; }
        public virtual DbSet<EWV_Online_Requests> EWV_Online_Requests { get; set; }
        public virtual DbSet<InstanceState> InstanceStates { get; set; }
        public virtual DbSet<IST_Online_Appoval> IST_Online_Appoval { get; set; }
        public virtual DbSet<IST_Online_Requests> IST_Online_Requests { get; set; }
        public virtual DbSet<IstikdamRequestRejectionReason> IstikdamRequestRejectionReasons { get; set; }
        public virtual DbSet<Lookup_AdviceMessages> Lookup_AdviceMessages { get; set; }
        public virtual DbSet<Lookup_AgeRange> Lookup_AgeRange { get; set; }
        public virtual DbSet<Lookup_Bank> Lookup_Bank { get; set; }
        public virtual DbSet<Lookup_ChangeEstablishmentActivityReason> Lookup_ChangeEstablishmentActivityReason { get; set; }
        public virtual DbSet<Lookup_ChangeEstablishmentActivityRejectionReason> Lookup_ChangeEstablishmentActivityRejectionReason { get; set; }
        public virtual DbSet<Lookup_City> Lookup_City { get; set; }
        public virtual DbSet<Lookup_ComputerSkill> Lookup_ComputerSkill { get; set; }
        public virtual DbSet<Lookup_Country> Lookup_Country { get; set; }
        public virtual DbSet<Lookup_DisabilityType> Lookup_DisabilityType { get; set; }
        public virtual DbSet<Lookup_EconomicActivity> Lookup_EconomicActivity { get; set; }
        public virtual DbSet<Lookup_EducationalStatus> Lookup_EducationalStatus { get; set; }
        public virtual DbSet<Lookup_EstablishmentVisaCreditServiceConsumers> Lookup_EstablishmentVisaCreditServiceConsumers { get; set; }
        public virtual DbSet<Lookup_GPASystem> Lookup_GPASystem { get; set; }
        public virtual DbSet<Lookup_JobField> Lookup_JobField { get; set; }
        public virtual DbSet<Lookup_LawRepresentation> Lookup_LawRepresentation { get; set; }
        public virtual DbSet<Lookup_Municipality> Lookup_Municipality { get; set; }
        public virtual DbSet<Lookup_Nationality> Lookup_Nationality { get; set; }
        public virtual DbSet<Lookup_NewEconomicActivity> Lookup_NewEconomicActivity { get; set; }
        public virtual DbSet<Lookup_OpenId_Consumer> Lookup_OpenId_Consumer { get; set; }
        public virtual DbSet<Lookup_Origins> Lookup_Origins { get; set; }
        public virtual DbSet<Lookup_ProficiencyLevel> Lookup_ProficiencyLevel { get; set; }
        public virtual DbSet<Lookup_Qualification> Lookup_Qualification { get; set; }
        public virtual DbSet<Lookup_Religion> Lookup_Religion { get; set; }
        public virtual DbSet<Lookup_SaudiCertificateDirectedTo> Lookup_SaudiCertificateDirectedTo { get; set; }
        public virtual DbSet<Lookup_SaudiCertificatePurpose> Lookup_SaudiCertificatePurpose { get; set; }
        public virtual DbSet<Lookup_SecurableEntityType> Lookup_SecurableEntityType { get; set; }
        public virtual DbSet<Lookup_ServiceEndReason> Lookup_ServiceEndReason { get; set; }
        public virtual DbSet<Lookup_StatementsType> Lookup_StatementsType { get; set; }
        public virtual DbSet<Lookup_ViewerScope> Lookup_ViewerScope { get; set; }
        public virtual DbSet<Lookup_Zone> Lookup_Zone { get; set; }
        public virtual DbSet<MOL_AccountManager> MOL_AccountManager { get; set; }
        public virtual DbSet<MOL_Agent> MOL_Agent { get; set; }
        public virtual DbSet<MOL_AuditTrails> MOL_AuditTrails { get; set; }
        public virtual DbSet<MOL_CancelVisaRequest> MOL_CancelVisaRequest { get; set; }
        public virtual DbSet<MOL_CEAInbox> MOL_CEAInbox { get; set; }
        public virtual DbSet<MOL_CEAReferenceSequence> MOL_CEAReferenceSequence { get; set; }
        public virtual DbSet<MOL_CEAUserService> MOL_CEAUserService { get; set; }
        public virtual DbSet<MOL_ChangeEstablishmentActivityRequest> MOL_ChangeEstablishmentActivityRequest { get; set; }
        public virtual DbSet<MOL_Download> MOL_Download { get; set; }
        public virtual DbSet<MOL_EconomicActivityStatement> MOL_EconomicActivityStatement { get; set; }
        public virtual DbSet<MOL_Establishment> MOL_Establishment { get; set; }
        public virtual DbSet<Mol_EstablishmentActivityCorrection> Mol_EstablishmentActivityCorrection { get; set; }
        public virtual DbSet<MOL_EstablishmentAgent> MOL_EstablishmentAgent { get; set; }
        public virtual DbSet<MOL_EstablishmentAgentService> MOL_EstablishmentAgentService { get; set; }
        public virtual DbSet<MOL_EstablishmentChangeStatus> MOL_EstablishmentChangeStatus { get; set; }
        public virtual DbSet<MOL_EstablishmentCommissioner> MOL_EstablishmentCommissioner { get; set; }
        public virtual DbSet<MOL_EstablishmentCommissionerService> MOL_EstablishmentCommissionerService { get; set; }
        public virtual DbSet<MOL_EstablishmentEconomicActivity> MOL_EstablishmentEconomicActivity { get; set; }
        public virtual DbSet<MOL_EstablishmentExceptionalWP> MOL_EstablishmentExceptionalWP { get; set; }
        public virtual DbSet<MOL_EstablishmentNote> MOL_EstablishmentNote { get; set; }
        public virtual DbSet<MOL_EstablishmentNoteService> MOL_EstablishmentNoteService { get; set; }
        public virtual DbSet<MOL_EstablishmentProfile> MOL_EstablishmentProfile { get; set; }
        public virtual DbSet<MOL_EstablishmentSaudiCertificate> MOL_EstablishmentSaudiCertificate { get; set; }
        public virtual DbSet<MOL_EstablishmentSelectLog> MOL_EstablishmentSelectLog { get; set; }
        public virtual DbSet<MOL_EstablishmentStatement> MOL_EstablishmentStatement { get; set; }
        public virtual DbSet<MOL_EstablishmentVisaCredit> MOL_EstablishmentVisaCredit { get; set; }
        public virtual DbSet<MOL_EstablishmnetEligibleToTakeAppointment> MOL_EstablishmnetEligibleToTakeAppointment { get; set; }
        public virtual DbSet<MOL_FakeEmploymentReport> MOL_FakeEmploymentReport { get; set; }
        public virtual DbSet<MOL_FakeEmploymentReportCommentOwner> MOL_FakeEmploymentReportCommentOwner { get; set; }
        public virtual DbSet<MOL_FakeEmploymentReportComments> MOL_FakeEmploymentReportComments { get; set; }
        public virtual DbSet<MOL_FakeEmploymentReportStatus> MOL_FakeEmploymentReportStatus { get; set; }
        public virtual DbSet<MOL_GenderActivityNationalityJobMatrix> MOL_GenderActivityNationalityJobMatrix { get; set; }
        public virtual DbSet<MOL_HajOmraTransferRequests> MOL_HajOmraTransferRequests { get; set; }
        public virtual DbSet<MOL_IssuedVisas> MOL_IssuedVisas { get; set; }
        public virtual DbSet<MOL_Laborer> MOL_Laborer { get; set; }
        public virtual DbSet<MOL_LaborerExceptionalWP> MOL_LaborerExceptionalWP { get; set; }
        public virtual DbSet<MOL_LaborerMOIRunaway> MOL_LaborerMOIRunaway { get; set; }
        public virtual DbSet<MOL_LaborerStatusServiceEndReason> MOL_LaborerStatusServiceEndReason { get; set; }
        public virtual DbSet<MOL_LaborOffice> MOL_LaborOffice { get; set; }
        public virtual DbSet<MOL_NotificationMessage> MOL_NotificationMessage { get; set; }
        public virtual DbSet<MOL_NotificationMessageReceiver> MOL_NotificationMessageReceiver { get; set; }
        public virtual DbSet<MOL_OpenIDLogs> MOL_OpenIDLogs { get; set; }
        public virtual DbSet<MOL_OracleTransactionLog> MOL_OracleTransactionLog { get; set; }
        public virtual DbSet<MOL_Owner> MOL_Owner { get; set; }
        public virtual DbSet<MOL_ProgramBEstablishments> MOL_ProgramBEstablishments { get; set; }
        public virtual DbSet<MOL_RunAwayCancelRequests> MOL_RunAwayCancelRequests { get; set; }
        public virtual DbSet<MOL_Sec_Group> MOL_Sec_Group { get; set; }
        public virtual DbSet<MOL_Sec_Privilege> MOL_Sec_Privilege { get; set; }
        public virtual DbSet<MOL_Sec_Role> MOL_Sec_Role { get; set; }
        public virtual DbSet<MOL_Sec_RolePrivilege> MOL_Sec_RolePrivilege { get; set; }
        public virtual DbSet<MOL_Sec_SecurableEntity> MOL_Sec_SecurableEntity { get; set; }
        public virtual DbSet<MOL_Sec_UserEntityPrivilege> MOL_Sec_UserEntityPrivilege { get; set; }
        public virtual DbSet<MOL_Sec_UserRevokePrivilege> MOL_Sec_UserRevokePrivilege { get; set; }
        public virtual DbSet<MOL_Sec_UserRole> MOL_Sec_UserRole { get; set; }
        public virtual DbSet<MOL_Service_Log> MOL_Service_Log { get; set; }
        public virtual DbSet<MOL_Srv_Transaction> MOL_Srv_Transaction { get; set; }
        public virtual DbSet<MOL_TransferRequest> MOL_TransferRequest { get; set; }
        public virtual DbSet<MOL_UnifiedNumber> MOL_UnifiedNumber { get; set; }
        public virtual DbSet<MOL_User> MOL_User { get; set; }
        public virtual DbSet<MOL_VisaActivityPeriod> MOL_VisaActivityPeriod { get; set; }
        public virtual DbSet<MOL_VisaBalanceRejectReason> MOL_VisaBalanceRejectReason { get; set; }
        public virtual DbSet<MOL_VisaIssuePrivateContract> MOL_VisaIssuePrivateContract { get; set; }
        public virtual DbSet<MOL_VisaIssueRejectReasons> MOL_VisaIssueRejectReasons { get; set; }
        public virtual DbSet<MOL_VisaIssueRequestDetails> MOL_VisaIssueRequestDetails { get; set; }
        public virtual DbSet<MOL_VisaIssueRequests> MOL_VisaIssueRequests { get; set; }
        public virtual DbSet<MOL_VisaPrerequisitesDocs> MOL_VisaPrerequisitesDocs { get; set; }
        public virtual DbSet<MOL_VisaRequestDetails> MOL_VisaRequestDetails { get; set; }
        public virtual DbSet<MOL_VisaRequestImmediateApproveDetails> MOL_VisaRequestImmediateApproveDetails { get; set; }
        public virtual DbSet<MOL_VisaRequestImmediateApproveInfo> MOL_VisaRequestImmediateApproveInfo { get; set; }
        public virtual DbSet<MOL_VisaRequests> MOL_VisaRequests { get; set; }
        public virtual DbSet<MOL_WorkPermit> MOL_WorkPermit { get; set; }
        public virtual DbSet<MOL_WP200ViolatedUnifiedNumbers> MOL_WP200ViolatedUnifiedNumbers { get; set; }
        public virtual DbSet<MOL_WP200ViolationsCorrections> MOL_WP200ViolationsCorrections { get; set; }
        public virtual DbSet<OEF_Online_Requests> OEF_Online_Requests { get; set; }
        public virtual DbSet<OpenId_Association> OpenId_Association { get; set; }
        public virtual DbSet<OpenId_AuthToken> OpenId_AuthToken { get; set; }
        public virtual DbSet<OpenId_Nonce> OpenId_Nonce { get; set; }
        public virtual DbSet<OpenId_User> OpenId_User { get; set; }
        public virtual DbSet<ST_Online_Approval> ST_Online_Approval { get; set; }
        public virtual DbSet<ST_Online_Requests> ST_Online_Requests { get; set; }
        public virtual DbSet<ManpowerMenu> ManpowerMenus { get; set; }
        public virtual DbSet<ManpowerMenu_Groups> ManpowerMenu_Groups { get; set; }
        public virtual DbSet<ManpowerMenu_Groups_EntityTypes> ManpowerMenu_Groups_EntityTypes { get; set; }
        public virtual DbSet<ManpowerMenu_Sections> ManpowerMenu_Sections { get; set; }
        public virtual DbSet<MOL_Sec_VwUserRole> MOL_Sec_VwUserRole { get; set; }
        public virtual DbSet<MOL_VwAccountManager> MOL_VwAccountManager { get; set; }
        public virtual DbSet<MOL_VwCEAEstablishmentDetails> MOL_VwCEAEstablishmentDetails { get; set; }
        public virtual DbSet<MOL_VwCEAInbox> MOL_VwCEAInbox { get; set; }
        public virtual DbSet<MOL_VwCEAJobLaborersCount> MOL_VwCEAJobLaborersCount { get; set; }
        public virtual DbSet<MOL_VwCEARequestViewDetails> MOL_VwCEARequestViewDetails { get; set; }
        public virtual DbSet<MOL_VwChangeEstablishmentActivityApprovalUsers> MOL_VwChangeEstablishmentActivityApprovalUsers { get; set; }
        public virtual DbSet<MOL_VwOEFElectronicInquiries> MOL_VwOEFElectronicInquiries { get; set; }
        public virtual DbSet<MOL_VwUnpaidWP200Violations> MOL_VwUnpaidWP200Violations { get; set; }
        public virtual DbSet<MOL_VwUserEstablishments> MOL_VwUserEstablishments { get; set; }
        public virtual DbSet<MOL_VwUserEstablishmentsNotes> MOL_VwUserEstablishmentsNotes { get; set; }
        public virtual DbSet<VW_EstablishmentActivityCorrection> VW_EstablishmentActivityCorrection { get; set; }
        public virtual DbSet<MOL_GC_Assents> MOL_GC_Assents { get; set; }
        public virtual DbSet<Lookup_Job> Lookup_Job { get; set; }
        public virtual DbSet<MOL_VwLaborer_Audit_GetEstablishmentsHistory> MOL_VwLaborer_Audit_GetEstablishmentsHistory { get; set; }
        public DbSet<Vw_UNPaidExtraFeesUnites> Vw_UNPaidExtraFeesUnites { get; set; }
        public DbSet<MOL_Service_Log_Extension> MOL_Service_Log_Extension { get; set; }
        public DbSet<MOL_Laborer_MOI_Audit> MOL_Laborer_MOI_Audit { get; set; }
        public DbSet<Unrejected_Joining_Request> Unrejected_Joining_Request { get; set; }
        public DbSet<NitaqatActivity_Establishment> NitaqatActivity_Establishment { get; set; }



        public DbSet<Joining_Rule> Joining_Rule { get; set; }
        public DbSet<Joining_Rules_Validation_Log> Joining_Rules_Validation_Log { get; set; }
        public DbSet<MOL_EconomicActivity_Jobs_Gender> MOL_EconomicActivity_Jobs_Gender { get; set; }
        public DbSet<MOL_GC_ContractEstablishments> MOL_GC_ContractEstablishments { get; set; }
        public DbSet<MOL_GC_Contracts> MOL_GC_Contracts { get; set; }
        public DbSet<Overdue_Establishment> Overdue_Establishment { get; set; }
        public DbSet<Active_Program_Establishment> Active_Program_Establishment { get; set; }

        public DbSet<Gov_Agency> Gov_Agency { get; set; }
        public DbSet<Program_Establishment> Program_Establishment { get; set; }
        public DbSet<MOL_EstablishmentModifiedJobsHistory> MOL_EstablishmentModifiedJobsHistory { get; set; }
        public DbSet<MOL_EstablishmentVisaCreditJobs> MOL_EstablishmentVisaCreditJobs { get; set; }
        public DbSet<MOL_EstablishmentVisaCreditJobsHistory> MOL_EstablishmentVisaCreditJobsHistory { get; set; }
        public DbSet<RejectionReason> RejectionReasons { get; set; }
        public DbSet<Mol_VwLaborersHasUnusedWP> Mol_VwLaborersHasUnusedWP { get; set; }
        public DbSet<VwManpowerMenu> VwManpowerMenu { get; set; }
        public DbSet<Channels> Channels { get; set; }
        public DbSet<MOL_CancelFinalExitWorkPermit> MOL_CancelFinalExitWorkPermit { get; set; }

        //public DbSet<MOL_EstablishmentRepresentativeIVR> MOL_EstablishmentRepresentativeIVR { get; set; }

        public DbSet<MOL_EstablishmentMCIActivities> MOL_EstablishmentMCIActivities { get; set; }
        public DbSet<MOL_OpenEstablishmentFileFromMCI> MOL_OpenEstablishmentFileFromMCI { get; set; }

        public DbSet<MOL_OpenEstablishmentFileFromSD> MOL_OpenEstablishmentFileFromSD { get; set; }
        public DbSet<MOL_EstablishmentMCIParties> MOL_EstablishmentMCIParties { get; set; }

        public DbSet<MOL_MonitoredUsersActivity> MOL_MonitoredUsersActivity { get; set; }

        public DbSet<MOL_UserLoginHistory> MOL_UserLoginHistory { get; set; }

        public DbSet<Periodic_Bill> Periodic_Bill { get; set; }
        public DbSet<Periodic_Bill_History> Periodic_Bill_History { get; set; }

        public DbSet<MOL_ChangeLaborerBranchInMOI> MOL_ChangeLaborerBranchInMOI { get; set; }

        public DbSet<MOL_VwEstablishmentCRMComplaintData> MOL_VwEstablishmentCRMComplaintData { get; set; }

        public DbSet<MOL_ZATNoteConfirmationLog> MOL_ZATNoteConfirmationLog { get; set; }


        #region "RAMS Data Contexts"

        public DbSet<Lookup_RAMS_ComplaintTimes> Lookup_RAMS_ComplaintTimes { get; set; }
        public DbSet<MOL_RAMS_Complaint_Files> MOL_RAMS_Complaint_Files { get; set; }
        public DbSet<MOL_RAMS_ComplaintNotes> MOL_RAMS_ComplaintNotes { get; set; }
        public DbSet<MOL_RAMS_ComplaintTransactionsLog> MOL_RAMS_ComplaintTransactionsLog { get; set; }
        public DbSet<MOL_RAMS_CancelRunAway_Files> MOL_RAMS_CancelRunAway_Files { get; set; }
        public DbSet<MOL_RAMS_RunAway_Files> MOL_RAMS_RunAway_Files { get; set; }
        public DbSet<MOL_RAMS_RunAwayTransactionsLog> MOL_RAMS_RunAwayTransactionsLog { get; set; }
        public DbSet<MOL_RunAwayComplaints> MOL_RunAwayComplaints { get; set; }

        #endregion


        #endregion

        #region [ Stored Procedure ]

        #region [ ExecuteStoreQuery ]
        //public virtual List<NICIntegrationWorkPermitDetails> GetNICIntegrationWorkPermitDetails(int wpLaborOfficeId, long WpNumber)
        //{
        //    var wpLaborOfficeIdParameter = new SqlParameter("@wpLaborOfficeId", wpLaborOfficeId);
        //    var WpNumberParameter = new SqlParameter("@WpNumber", WpNumber);

        //    return this.Database.SqlQuery<NICIntegrationWorkPermitDetails>("GetNICIntegrationWorkPermitDetails @wpLaborOfficeId, @WpNumber", wpLaborOfficeIdParameter, WpNumberParameter).ToList();
        //}

        public virtual List<LaborerLatestStatus> GetLaborerLatestStatusByIdAndDate(DateTime auditDate, string laborerIdNumber)
        {
            var auditDateParameter = new SqlParameter("@auditDate", auditDate);
            var laborerIdNumberParameter = new SqlParameter("@laborerIdNumber", laborerIdNumber);

            return this.Database.SqlQuery<LaborerLatestStatus>("GetLaborerLatestStatusByIdAndDate @auditDate, @laborerIdNumber", auditDateParameter, laborerIdNumberParameter).ToList();
        }

        public virtual List<SP_CUST_MOL_Sec_Privilege_GetAuthorizedUserServices_Result> SP_CUST_MOL_Sec_Privilege_GetAuthorizedUserServices(long userId, long establishmentId, long? serviceId, long? privilegeId, int? authorizationLevel)
        {
            var userIdParameter = new SqlParameter("@PK_UserID", userId);
            var establishmentIdParameter = new SqlParameter("@PK_EstablishmentId", establishmentId);

            var serviceIdParameter = serviceId.HasValue ?
                new SqlParameter("@PK_ServiceId", serviceId) :
                new SqlParameter("@PK_ServiceId", DBNull.Value);

            var privilegeIdParameter = privilegeId.HasValue ?
                new SqlParameter("@PK_PrivilegeID", privilegeId) :
                new SqlParameter("@PK_PrivilegeID", DBNull.Value);

            var authorizationLevelParameter = authorizationLevel.HasValue ?
                new SqlParameter("@AuthorizationLevel", authorizationLevel) :
                new SqlParameter("@AuthorizationLevel", DBNull.Value);

            return this.Database.SqlQuery<SP_CUST_MOL_Sec_Privilege_GetAuthorizedUserServices_Result>("SP_CUST_MOL_Sec_Privilege_GetAuthorizedUserServices @PK_UserID, @PK_EstablishmentId, @PK_ServiceId, @PK_PrivilegeID, @AuthorizationLevel",
                     userIdParameter, establishmentIdParameter, serviceIdParameter, privilegeIdParameter, authorizationLevelParameter).ToList();
        }

        public virtual List<GetEstablishment_Bills_Result> GetEstablishment_Bills(long establishmentId)
        {
            var establishmentIdParameter = new SqlParameter("@Establishment_Id", establishmentId);
            return this.Database.SqlQuery<GetEstablishment_Bills_Result>("FN.GetEstablishment_Bills @Establishment_Id", establishmentIdParameter).ToList();
        }
        public virtual List<Periodic_Bill> GetAllUnpaidBills()
        {
            return this.Database.SqlQuery<Periodic_Bill>("FN.Get_All_Unpaid_Bills").ToList();
        }
        public virtual int SP_CUST_GetEstablishmentRunawayRequests(long establishmentId, DateTime fromDate)
        {
            var establishmentIdParameter = new SqlParameter("@EstablishmentId", establishmentId);
            var fromDateParameter = new SqlParameter("@FromDate", fromDate);

            return this.Database.SqlQuery<int>("SP_CUST_GetEstablishmentRunawayRequests @EstablishmentId, @FromDate", establishmentIdParameter, fromDateParameter).Single();
        }

        public virtual int SP_CUST_GetPendingNICVisasCountByEstablishmentID(long establishmentId)
        {
            var establishmentIdParameter = new SqlParameter("@EstablishmentID", establishmentId);
            return this.Database.SqlQuery<int>("SP_CUST_GetPendingNICVisasCountByEstablishmentID @EstablishmentID", establishmentIdParameter).Single();
        }

        #endregion

        #region [ ExecuteSqlCommand ]

        public virtual int SP_MOL_RunAwayCancelRequest_Insert(long currentUserId, string runawayId, string currentUserIdNo, long establishmentId, SqlParameter result)
        {
            var currentUserIdParameter = new SqlParameter("@CurrentUser_ID", currentUserId);
            var runAwayIDParameter = new SqlParameter("@RunAwayID", runawayId);
            var currentUserIDNoParameter = new SqlParameter("@CurrentUserIDNo", currentUserIdNo);
            var establishmentIdParameter = new SqlParameter("@Fk_EstablishmentID", establishmentId);

            return this.Database.ExecuteSqlCommand("SP_MOL_RunAwayCancelRequest_Insert @CurrentUser_ID, @RunAwayID, @CurrentUserIDNo, @Fk_EstablishmentID, @Result Out", currentUserIdParameter, runAwayIDParameter, currentUserIDNoParameter, establishmentIdParameter, result);
        }

        public virtual int usp_MOL_IstikdamRequestRejectionReason_Insert(int istikdamBalanceRequestId, int rejectionReasonId, SqlParameter istikdamRequestRejectionReasonId)
        {
            var istikdamBalanceRequestIdParameter = new SqlParameter("@IstikdamBalanceRequestId", istikdamBalanceRequestId);
            var rejectionReasonIdParameter = new SqlParameter("@RejectionReasonId", rejectionReasonId);

            return this.Database.ExecuteSqlCommand("usp_MOL_IstikdamRequestRejectionReason_Insert @IstikdamBalanceRequestId, @RejectionReasonId, @IstikdamRequestRejectionReasonId Out", istikdamBalanceRequestIdParameter, rejectionReasonIdParameter, istikdamRequestRejectionReasonId);
        }

        #endregion

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }

        #region [ Account Manager Modifications ]
        public override int SaveChanges()
        {
            TransactionOptions transOptions = new TransactionOptions();
            transOptions.IsolationLevel = IsolationLevel.ReadCommitted;
            // Creates transaction only if there is no current transaction.
            using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, transOptions))
            {
                // AutoDetectChangesEnabled Gets or sets a value indicating whether the DetectChanges() method is called automatically 
                // by methods of DbContext and related classes. The default value is true.
                // ObjectContext.SaveChanges is not affected by AutoDetectChangesEnabled configuration.
                int saveFlag = ((IObjectContextAdapter)this).ObjectContext.SaveChanges(SaveOptions.DetectChangesBeforeSave);

                IEnumerable<IAuditable> auditableEntities = null;

                auditableEntities = this.ChangeTracker.Entries<IAuditable>()
                    .Where(en => en.State == EntityState.Modified || en.State == EntityState.Added)
                    .Select(en => en.Entity).ToList(); // The ChangeTracker did not reset entities yet, and PKs are loaded from DB, but EntityKey is not updated

                List<MOL_AuditTrails> lstAuditTrail = null;

                if (auditableEntities != null && auditableEntities.Count() > 0)
                {
                    lstAuditTrail = GetAuditList(auditableEntities); // Create the Audit including ObjectId (PK)
                }

                ((IObjectContextAdapter)this).ObjectContext.AcceptAllChanges(); // Avoid saving non-audit entities again.  Reset entities state.  

                if (lstAuditTrail != null && lstAuditTrail.Count > 0)
                {
                    this.MOL_AuditTrails.AddRange(lstAuditTrail);  // Now ready to save the audit.
                    saveFlag += base.SaveChanges(); // Saving audit in another transaction
                }

                transScope.Complete();
                return saveFlag;
            }
        }

        private EntityKeyMember GetPrimaryKey(DbEntityEntry<IAuditable> entity)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity.Entity);

            if (objectStateEntry.EntityKey == null)
            {
                return null;
            }

            if (entity.State == EntityState.Modified)
            {
                if (objectStateEntry.EntityKey.EntityKeyValues != null && objectStateEntry.EntityKey.EntityKeyValues.Length == 1)
                {
                    return objectStateEntry.EntityKey.EntityKeyValues[0];
                }
                else
                {
                    return null;
                }
            }
            else if (entity.State == EntityState.Added && objectStateEntry.EntitySet.ElementType.KeyMembers.Count == 1)
            {
                foreach (string propertyName in entity.CurrentValues.PropertyNames) // Usually ID is the first property, but cannot depend on that.
                {
                    var property = entity.Property(propertyName);
                    if (property == null)
                    {
                        continue;
                    }
                    string keyName = objectStateEntry.EntitySet.ElementType.KeyMembers[0].Name;
                    string currentValue = property.CurrentValue == null ? null : property.CurrentValue.ToString(); //Convert.ToString(property.CurrentValue); convert causes issue

                    if (propertyName == keyName)
                    {
                        long objIdValue;
                        if (long.TryParse(currentValue, out objIdValue))
                        {
                            return new EntityKeyMember(keyName, objIdValue);
                        }
                        else
                        {
                            break;
                        }
                    }

                }
            }

            return null;
        }

        private List<MOL_AuditTrails> GetAuditList(IEnumerable<IAuditable> auditableEntities)
        {
            List<MOL_AuditTrails> lstAuditTrail = new List<MOL_AuditTrails>();
            DateTime currentDateTime = DateTime.Now;

            foreach (var entry in auditableEntities)
            {
                DbEntityEntry<IAuditable> entity = this.Entry(entry);

                // entry is just dynamic proxy.  Convert it to DbEntityEntry<IAuditable>
                IAuditable auditableEntity = ((IAuditable)entity.Entity);
                var auditedTableName = auditableEntity.DBTableName;
                long? operatorID = auditableEntity.CurrentUserID <= 0 ? null : (long?)auditableEntity.CurrentUserID;

                var key = GetPrimaryKey(entity);
                string pkName = null;
                long? pkValue = null;
                if (key != null)
                {
                    pkName = key.Key;
                    // fix this case the long int alwas returnes null
                    try
                    {
                        pkValue = Convert.ToInt64(key.Value);
                    }
                    catch { }
                }

                foreach (string propertyName in entity.CurrentValues.PropertyNames)
                {
                    var property = entity.Property(propertyName);
                    if (property == null)
                    {
                        continue;
                    }

                    string currentValue = property.CurrentValue == null ? null : property.CurrentValue.ToString(); //Convert.ToString(property.CurrentValue); convert causes issue

                    if (entity.State == EntityState.Modified)
                    {
                        string originalValue = property.OriginalValue == null ? null : property.OriginalValue.ToString(); // OriginalValue cannot be used in case of Addion

                        if (currentValue != originalValue) // add audit for only changed properties
                        {
                            var auditTrail = CreateAuditTrail(currentDateTime, auditedTableName, operatorID, pkValue, propertyName, originalValue, currentValue, entity.State);
                            //this.MOL_AuditTrails.Add(auditTrail);
                            lstAuditTrail.Add(auditTrail);
                        }
                    }
                    else if (entity.State == EntityState.Added)
                    {
                        var auditTrail = CreateAuditTrail(currentDateTime, auditedTableName, operatorID, pkValue, propertyName, null, currentValue, entity.State);
                        //this.MOL_AuditTrails.Add(auditTrail);
                        lstAuditTrail.Add(auditTrail);
                    }
                }
                if (auditableEntity.ExtraFields != null && auditableEntity.ExtraFields.Count > 0)
                {
                    List<KeyValuePair<string, string>> extraFieldsCol = auditableEntity.ExtraFields.ToList();
                    foreach (var field in extraFieldsCol)
                    {
                        if ((entity.State == EntityState.Modified) || (entity.State == EntityState.Added))
                        {
                            var auditTrail = CreateAuditTrail(currentDateTime, auditedTableName, operatorID, pkValue, field.Key, null, field.Value, entity.State);
                            lstAuditTrail.Add(auditTrail);
                        }
                    }
                }


            }
            return lstAuditTrail;
        }

        private MOL_AuditTrails CreateAuditTrail(DateTime currentDateTime, string auditedTableName, long? operatorID
            , long? objectID, string fieldName, string oldValue, string newValue, EntityState enityState)
        {
            MOL_AuditTrails auditTrail = new MOL_AuditTrails();
            auditTrail.AuditId = Guid.NewGuid();
            auditTrail.UserId = operatorID;
            auditTrail.FK_AuditActionId = (short?)(enityState == EntityState.Added ? 1 : 2);
            auditTrail.AuditedTableName = auditedTableName;
            auditTrail.FieldName = fieldName;
            auditTrail.OldValue = oldValue;
            auditTrail.NewValue = newValue;
            auditTrail.AuditDateTime = currentDateTime;
            auditTrail.ObjectName = auditedTableName;
            auditTrail.ObjectId = objectID;
            return auditTrail;
        }
        #endregion

    }

}