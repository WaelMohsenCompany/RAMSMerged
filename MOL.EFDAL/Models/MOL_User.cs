namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_User : IAuditable
    {
        public MOL_User()
        {
        }

        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string First_Name { get; set; }
        [DataMember]
        public string Second_Name { get; set; }
        [DataMember]
        public string Third_Name { get; set; }
        [DataMember]
        public string Fourth_Name { get; set; }
        [DataMember]
        public short? Nationality { get; set; }
        [DataMember]
        public System.DateTime? Birth_Date { get; set; }
        [DataMember]
        public int? User_Type_Id { get; set; }
        [DataMember]
        public int? UserId { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public System.DateTime? LastLoggedIn { get; set; }
        [DataMember]
        public int? FK_LaborOfficeId { get; set; }
        [DataMember]
        public int? GenderID { get; set; }
        [DataMember]
        public int? MaritalStatusID { get; set; }
        [DataMember]
        public long? Id_Number { get; set; }
        [DataMember]
        public System.DateTime? Id_ExpiryDate { get; set; }
        [DataMember]
        public long? Iqama_Number { get; set; }
        [DataMember]
        public System.DateTime? Iqama_ExpiryDate { get; set; }
        [DataMember]
        public int? EmailLangID { get; set; }
        [DataMember]
        public bool? IsUserDeleted { get; set; }
        [DataMember]
        public string PlaceofBirth { get; set; }
        [DataMember]
        public bool? IsActivated { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public bool IsSystem { get; set; }
        [DataMember]
        public string TwitterAccount { get; set; }
        [DataMember]
        public string POBox { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public System.DateTime? Created { get; set; }
        [DataMember]
        public bool? FromHafiz { get; set; }
        [DataMember]
        public System.DateTime? CreatedOn { get; set; }
        [DataMember]
        public System.DateTime? ModifiedOn { get; set; }
        [DataMember]
        public long? CreatedBy { get; set; }
        [DataMember]
        public bool IsEmailVerified { get; set; }
        [DataMember]
        public short EmailVerificationCount { get; set; }
        [DataMember]
        public System.DateTime? EmailLastVerificationDate { get; set; }
        [DataMember]
        public bool IsMobileVerified { get; set; }
        [DataMember]
        public short MobileVerificationCount { get; set; }
        [DataMember]
        public System.DateTime? MobileLastVerificationDate { get; set; }
        [DataMember]
        public bool IsDataVerified { get; set; }
        [DataMember]
        public virtual Enum_EmailLanguage Enum_EmailLanguage { get; set; }
        [DataMember]
        public virtual Enum_Gender Enum_Gender { get; set; }
        [DataMember]
        public virtual Enum_UserType Enum_UserType { get; set; }
        [DataMember]
        public virtual Lookup_Nationality Lookup_Nationality { get; set; }
        [DataMember]
        public virtual ICollection<MOL_AccountManager> MOL_AccountManager { get; set; } = new List<MOL_AccountManager>();

        [DataMember]
        public virtual ICollection<MOL_CancelVisaRequest> MOL_CancelVisaRequest { get; set; } = new List<MOL_CancelVisaRequest>();

        [DataMember]
        public virtual ICollection<MOL_CEAUserService> MOL_CEAUserService { get; set; } = new List<MOL_CEAUserService>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentProfile> MOL_EstablishmentProfile { get; set; } = new List<MOL_EstablishmentProfile>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentProfile> MOL_EstablishmentProfile1 { get; set; } = new List<MOL_EstablishmentProfile>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentVisaCredit> MOL_EstablishmentVisaCredit { get; set; } = new List<MOL_EstablishmentVisaCredit>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentVisaCredit> MOL_EstablishmentVisaCredit1 { get; set; } = new List<MOL_EstablishmentVisaCredit>();

        [DataMember]
        public virtual ICollection<MOL_Laborer> MOL_Laborer { get; set; } = new List<MOL_Laborer>();

        [DataMember]
        public virtual MOL_LaborOffice MOL_LaborOffice { get; set; }

        [DataMember]
        public virtual ICollection<MOL_OracleTransactionLog> MOL_OracleTransactionLog { get; set; } = new List<MOL_OracleTransactionLog>();

        [DataMember]
        public virtual ICollection<MOL_Sec_UserEntityPrivilege> MOL_Sec_UserEntityPrivilege { get; set; } = new List<MOL_Sec_UserEntityPrivilege>();

        [DataMember]
        public virtual ICollection<MOL_Sec_UserRevokePrivilege> MOL_Sec_UserRevokePrivilege { get; set; } = new List<MOL_Sec_UserRevokePrivilege>();

        [DataMember]
        public virtual ICollection<MOL_Sec_UserRole> MOL_Sec_UserRole { get; set; } = new List<MOL_Sec_UserRole>();

        [DataMember]
        public virtual ICollection<MOL_Srv_Transaction> MOL_Srv_Transaction { get; set; } = new List<MOL_Srv_Transaction>();

        [DataMember]
        public virtual ICollection<MOL_Srv_Transaction> MOL_Srv_Transaction1 { get; set; } = new List<MOL_Srv_Transaction>();

        [DataMember]
        public virtual ICollection<MOL_WorkPermit> MOL_WorkPermit { get; set; } = new List<MOL_WorkPermit>();

        [DataMember]
        public virtual ICollection<MOL_Sec_Privilege> MOL_Sec_Privilege { get; set; } = new List<MOL_Sec_Privilege>();
        [DataMember]
        public virtual ICollection<CJD_Online_Requests> CJD_Online_Requests { get; set; } = new List<CJD_Online_Requests>();
        [DataMember]
        public virtual ICollection<ST_Online_Requests> ST_Online_Requests { get; set; } = new List<ST_Online_Requests>();

        [DataMember]
        public virtual ICollection<MOL_GC_Contracts> MOL_GC_Contracts { get; set; } = new List<MOL_GC_Contracts>();
        [DataMember]
        public virtual ICollection<MOL_GC_Contracts> MOL_GC_Contracts1 { get; set; } = new List<MOL_GC_Contracts>();
        [DataMember]
        public virtual ICollection<MOL_GC_Contracts> MOL_GC_Contracts2 { get; set; } = new List<MOL_GC_Contracts>();
        [DataMember]
        public virtual ICollection<MOL_GC_AssentTrackingLog> MOL_GC_AssentTrackingLog { get; set; } = new List<MOL_GC_AssentTrackingLog>();
        [DataMember]
        public virtual ICollection<MOL_EstablishmentVisaCreditJobs> MOL_EstablishmentVisaCreditJobs { get; set; } = new List<MOL_EstablishmentVisaCreditJobs>();
        [DataMember]
        public virtual ICollection<MOL_EstablishmentVisaCreditJobs> MOL_EstablishmentVisaCreditJobs1 { get; set; } = new List<MOL_EstablishmentVisaCreditJobs>();
        [DataMember]
        public virtual ICollection<MOL_EstablishmentVisaCreditJobsHistory> MOL_EstablishmentVisaCreditJobsHistory { get; set; } = new List<MOL_EstablishmentVisaCreditJobsHistory>();

        [DataMember]
        public virtual ICollection<MOL_CancelFinalExitWorkPermit> MOL_CancelFinalExitWorkPermit { get; set; } = new List<MOL_CancelFinalExitWorkPermit>();

        [DataMember]
        public virtual ICollection<MOL_EEF_OnlineRequests> MOL_EEF_OnlineRequests { get; set; } = new List<MOL_EEF_OnlineRequests>();
        [DataMember]
        public virtual ICollection<OEF_Online_Requests> OEF_Online_Requests { get; set; } = new List<OEF_Online_Requests>();

        [DataMember]
        public virtual ICollection<MOL_ChangeLaborerBranchInMOI> MOL_ChangeLaborerBranchInMOI { get; set; } = new List<MOL_ChangeLaborerBranchInMOI>();

        [DataMember]
        public virtual ICollection<MOL_UserLoginHistory> MOL_UserLoginHistory { get; set; } = new List<MOL_UserLoginHistory>();

        #region [ IAuditable ]
        public long CurrentUserID { get; set; }
        public string DBTableName => "MOL_User";

        private AuditExtraFieldCollection mExtraFields = new AuditExtraFieldCollection();
        public AuditExtraFieldCollection ExtraFields { get { return mExtraFields; } }

        #endregion
    }
}
