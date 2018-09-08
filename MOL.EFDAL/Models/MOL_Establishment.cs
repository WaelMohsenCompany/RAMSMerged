namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Establishment
    {
        public MOL_Establishment()
        {
        }

        [DataMember]
        public long PK_EstablishmentId { get; set; }
        [DataMember]
        public long FK_UnifiedNumberId { get; set; }
        [DataMember]
        public int FK_LaborOfficeId { get; set; }
        [DataMember]
        public long SequenceNumber { get; set; }
        [DataMember]
        public System.DateTime? CreationDate { get; set; }
        [DataMember]
        public System.DateTime? InsertDate { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ZakatRegisterationNumber { get; set; }
        [DataMember]
        public int? FK_MainEconomicActivityId { get; set; }
        [DataMember]
        public int? FK_SubEconomicActivityId { get; set; }
        [DataMember]
        public string EconomicActivityText { get; set; }
        [DataMember]
        public int? RequiredLaborCount { get; set; }
        [DataMember]
        public int? FK_EstablishmentStatusId { get; set; }
        [DataMember]
        public System.DateTime? StatusModificationDate { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public System.DateTime? LaborCountLastModificationDate { get; set; }
        [DataMember]
        public string CommercialRecordNumber { get; set; }
        [DataMember]
        public System.DateTime? CommercialRecordReleaseDate { get; set; }
        [DataMember]
        public System.DateTime? CommercialRecordEndDate { get; set; }
        [DataMember]
        public string CommercialRecordSource { get; set; }
        [DataMember]
        public string CommercialRecordCancellationNo { get; set; }
        [DataMember]
        public System.DateTime? CommercialRecordCancellationDt { get; set; }
        [DataMember]
        public string MunicipalLicenseNumber { get; set; }
        [DataMember]
        public System.DateTime? MunicipalLicenseReleaseDate { get; set; }
        [DataMember]
        public System.DateTime? MunicipalLicenseEndDate { get; set; }
        [DataMember]
        public string MunicipalLicenseSource { get; set; }
        [DataMember]
        public string MunicipalLicenseCancellationNo { get; set; }
        [DataMember]
        public System.DateTime? MunicipalLicenseCancellationDt { get; set; }
        [DataMember]
        public string AreaForMunicipalLicense { get; set; }
        [DataMember]
        public string SocialInsuranceRegisterationNo { get; set; }
        [DataMember]
        public System.DateTime? SocialInsuranceRegEndDate { get; set; }
        [DataMember]
        public string ZakatCertificateNumber { get; set; }
        [DataMember]
        public System.DateTime? ZakatCertificateDate { get; set; }
        [DataMember]
        public int FK_CityId { get; set; }
        [DataMember]
        public string District { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public string Telephone1 { get; set; }
        [DataMember]
        public string Telephone2 { get; set; }
        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public int? ConcessionsCount { get; set; }
        [DataMember]
        public int? DeparturesCount { get; set; }
        [DataMember]
        public int? RunnersCount { get; set; }
        [DataMember]
        public bool? IsMainBranch { get; set; }
        [DataMember]
        public string ManagerName { get; set; }
        [DataMember]
        public string NationalEnterpriseId { get; set; }
        [DataMember]
        public System.DateTime? CommercialRecordConfirmationDate { get; set; }
        [DataMember]
        public System.DateTime? MunicipalLicenseConfirmationDate { get; set; }
        [DataMember]
        public System.DateTime? SocialInsuranceConfirmationDate { get; set; }
        [DataMember]
        public System.DateTime? ZakatCertificateConfirmationDate { get; set; }
        [DataMember]
        public int? SaudiLaborCountAtRegistration { get; set; }
        [DataMember]
        public int? NonSaudiLaborCountAtRegistration { get; set; }
        [DataMember]
        public int? FK_MunicipalityId { get; set; }
        [DataMember]
        public int? Fk_NewEconomicActivityId { get; set; }
        [DataMember]
        public System.DateTime? CreatedOn { get; set; }
        [DataMember]
        public System.DateTime? ModifiedOn { get; set; }
        [DataMember]
        public int? WASELStatus { get; set; }
        [DataMember]
        public string WASELZipCode { get; set; }
        [DataMember]
        public string WASELPrimary { get; set; }
        [DataMember]
        public string WASELSecondary { get; set; }
        [DataMember]
        public string WASELUnitNo { get; set; }
        [DataMember]
        public string WASELCity { get; set; }
        [DataMember]
        public string WASELArea { get; set; }
        [DataMember]
        public string WASELStreet { get; set; }
        [DataMember]
        public System.DateTime? WASELExpiryDate { get; set; }
        [DataMember]
        public bool? MOCIUpdate { get; set; }
        [DataMember]
        public System.DateTime? MOCIUpdateTimeStamp { get; set; }
        [DataMember]
        public string SevenHundred { get; set; }
        [DataMember]
        public int? FK_CRStatusId { get; set; }
        [DataMember]
        public bool? IsGregorian { get; set; }
        [DataMember]
        public virtual Enum_EstablishmentStatus Enum_EstablishmentStatus { get; set; }
        [DataMember]
        public virtual Lookup_EconomicActivity Lookup_EconomicActivity { get; set; }

        [DataMember]
        public virtual ICollection<MOL_CancelVisaRequest> MOL_CancelVisaRequest { get; set; } = new List<MOL_CancelVisaRequest>();

        [DataMember]
        public virtual ICollection<MOL_ChangeEstablishmentActivityRequest> MOL_ChangeEstablishmentActivityRequest { get; set; } = new List<MOL_ChangeEstablishmentActivityRequest>();

        [DataMember]
        public virtual MOL_UnifiedNumber MOL_UnifiedNumber { get; set; }
        [DataMember]
        public virtual ICollection<MOL_EstablishmentAgent> MOL_EstablishmentAgent { get; set; } = new List<MOL_EstablishmentAgent>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentCommissioner> MOL_EstablishmentCommissioner { get; set; } = new List<MOL_EstablishmentCommissioner>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentNote> MOL_EstablishmentNote { get; set; } = new List<MOL_EstablishmentNote>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentProfile> MOL_EstablishmentProfile { get; set; } = new List<MOL_EstablishmentProfile>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentStatement> MOL_EstablishmentStatement { get; set; } = new List<MOL_EstablishmentStatement>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentChangeStatus> MOL_EstablishmentChangeStatus { get; set; } = new List<MOL_EstablishmentChangeStatus>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentVisaCredit> MOL_EstablishmentVisaCredit { get; set; } = new List<MOL_EstablishmentVisaCredit>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmnetEligibleToTakeAppointment> MOL_EstablishmnetEligibleToTakeAppointment { get; set; } = new List<MOL_EstablishmnetEligibleToTakeAppointment>();

        [DataMember]
        public virtual ICollection<MOL_FakeEmploymentReport> MOL_FakeEmploymentReport { get; set; } = new List<MOL_FakeEmploymentReport>();

        [DataMember]
        public virtual ICollection<MOL_Laborer> MOL_Laborer { get; set; } = new List<MOL_Laborer>();

        [DataMember]
        public virtual ICollection<MOL_NotificationMessage> MOL_NotificationMessage { get; set; } = new List<MOL_NotificationMessage>();

        [DataMember]
        public virtual ICollection<MOL_OracleTransactionLog> MOL_OracleTransactionLog { get; set; } = new List<MOL_OracleTransactionLog>();

        [DataMember]
        public virtual ICollection<MOL_ProgramBEstablishments> MOL_ProgramBEstablishments { get; set; } = new List<MOL_ProgramBEstablishments>();

        [DataMember]
        public virtual ICollection<MOL_Srv_Transaction> MOL_Srv_Transaction { get; set; } = new List<MOL_Srv_Transaction>();
        
        [DataMember]
        public virtual ICollection<MOL_GC_ContractEstablishments> MOL_GC_ContractEstablishments { get; set; } = new List<MOL_GC_ContractEstablishments>();
        [DataMember]
        public virtual ICollection<MOL_OpenEstablishmentFileFromMCI> MOL_OpenEstablishmentFileFromMCI { get; set; } = new List<MOL_OpenEstablishmentFileFromMCI>();
        [DataMember]
        public virtual ICollection<MOL_OpenEstablishmentFileFromSD> MOL_OpenEstablishmentFileFromSD { get; set; } = new List<MOL_OpenEstablishmentFileFromSD>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentMCIActivities> MOL_EstablishmentMCIActivities { get; set; } = new List<MOL_EstablishmentMCIActivities>();
        [DataMember]
        public virtual ICollection<MOL_EstablishmentMCIParties> MOL_EstablishmentMCIParties { get; set; } = new List<MOL_EstablishmentMCIParties>();

        [DataMember]
        public virtual ICollection<MOL_EEF_OnlineRequests> MOL_EEF_OnlineRequests { get; set; } = new List<MOL_EEF_OnlineRequests>();

        [DataMember]
        public virtual ICollection<OEF_Online_Requests> OEF_Online_Requests { get; set; } = new List<OEF_Online_Requests>();

        [DataMember]
        public virtual ICollection<MOL_ChangeLaborerBranchInMOI> MOL_ChangeLaborerBranchInMOI { get; set; } = new List<MOL_ChangeLaborerBranchInMOI>();

    }
}
