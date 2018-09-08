namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Laborer
    {
        public MOL_Laborer()
        {
        }

		[DataMember]
        public long PK_LaborerId { get; set; }
		[DataMember]
        public int FK_LaborOfficeId { get; set; }
		[DataMember]
        public int FK_SaudiFlagId { get; set; }
		[DataMember]
        public long SequenceNumber { get; set; }
		[DataMember]
        public System.DateTime? InsertDate { get; set; }
		[DataMember]
        public string FirstName { get; set; }
		[DataMember]
        public string SecondName { get; set; }
		[DataMember]
        public string ThirdName { get; set; }
		[DataMember]
        public string FourthName { get; set; }
		[DataMember]
        public int FK_AccomodationStatusId { get; set; }
		[DataMember]
        public string IdNo { get; set; }
		[DataMember]
        public string IdSource { get; set; }
		[DataMember]
        public System.DateTime? IdReleaseDate { get; set; }
		[DataMember]
        public int? FK_LaborerTypeId { get; set; }
		[DataMember]
        public short FK_NationalityId { get; set; }
		[DataMember]
        public short FK_ReligionId { get; set; }
		[DataMember]
        public string PassportNo { get; set; }
		[DataMember]
        public string PassportSource { get; set; }
		[DataMember]
        public System.DateTime? PassportReleaseDate { get; set; }
		[DataMember]
        public System.DateTime? VisaExpiryDate { get; set; }
		[DataMember]
        public int FK_GenderId { get; set; }
		[DataMember]
        public int YearOfBirth { get; set; }
		[DataMember]
        public int FK_JobId { get; set; }
		[DataMember]
        public int FK_EducationalStatusId { get; set; }
		[DataMember]
        public int? FK_QualificationId { get; set; }
		[DataMember]
        public System.DateTime? KingdomEntryDate { get; set; }
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public float? Salary { get; set; }
		[DataMember]
        public System.DateTime ServiceStartDate { get; set; }
		[DataMember]
        public int? FK_LaborerStatusId { get; set; }
		[DataMember]
        public System.DateTime? ServiceEndDate { get; set; }
		[DataMember]
        public int? FK_ServiceEndReasonId { get; set; }
		[DataMember]
        public int FK_CurrentLaborOfficeId { get; set; }
		[DataMember]
        public string BorderNo { get; set; }
		[DataMember]
        public int? FK_Service_LastServiceStatusId { get; set; }
		[DataMember]
        public long? FK_WPId { get; set; }
		[DataMember]
        public long? FK_LastWPId { get; set; }
		[DataMember]
        public long? EstablishmentSequenceNumber { get; set; }
		[DataMember]
        public string EstablishmentName { get; set; }
		[DataMember]
        public int? EstablishmentStatusId { get; set; }
		[DataMember]
        public System.DateTime? LastWPStartDate { get; set; }
		[DataMember]
        public System.DateTime? LastWPExpirationDate { get; set; }
		[DataMember]
        public int UpdateStatus { get; set; }
		[DataMember]
        public System.DateTime? LaborerStatusModificationDate { get; set; }
		[DataMember]
        public bool? ModifiedByMOI { get; set; }
		[DataMember]
        public long? FK_BatchUserId { get; set; }
		[DataMember]
        public long? BatchTransactionNumber { get; set; }
		[DataMember]
        public long? FK_Service_TransactionId { get; set; }
		[DataMember]
        public System.DateTime? StatusLastModificationDate { get; set; }
		[DataMember]
        public bool? isUpdatedToOracle { get; set; }
		[DataMember]
        public bool? isSpecialExpatriate { get; set; }
		[DataMember]
        public int? FK_SpecialExpatriateTypeId { get; set; }
		[DataMember]
        public int? CameByCompensationVISA { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
		[DataMember]
        public System.DateTime? ModifiedOn { get; set; }
		[DataMember]
        public string Mobile { get; set; }
		[DataMember]
        public System.DateTime? ComplaintDate { get; set; }
		[DataMember]
        public long? CreditID { get; set; }
		[DataMember]
        public int? CreditType { get; set; }
		[DataMember]
        public System.DateTime? NIC_LastSyncDate { get; set; }
		[DataMember]
        public int? NIC_SyncStatus { get; set; }
		[DataMember]
        public virtual Enum_AccomodationStatus Enum_AccomodationStatus { get; set; }
		[DataMember]
        public virtual Enum_Gender Enum_Gender { get; set; }
		[DataMember]
        public virtual Enum_LaborerStatus Enum_LaborerStatus { get; set; }
		[DataMember]
        public virtual Enum_LaborerType Enum_LaborerType { get; set; }
		[DataMember]
        public virtual Enum_SaudiFlag Enum_SaudiFlag { get; set; }
		[DataMember]
        public virtual Lookup_EducationalStatus Lookup_EducationalStatus { get; set; }
		[DataMember]
        public virtual Lookup_Job Lookup_Job { get; set; }
		[DataMember]
        public virtual Lookup_Nationality Lookup_Nationality { get; set; }
		[DataMember]
        public virtual Lookup_Qualification Lookup_Qualification { get; set; }
		[DataMember]
        public virtual Lookup_Religion Lookup_Religion { get; set; }
		[DataMember]
        public virtual Lookup_ServiceEndReason Lookup_ServiceEndReason { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
		[DataMember]
        public virtual ICollection<MOL_EstablishmentCommissioner> MOL_EstablishmentCommissioner { get; set; } = new List<MOL_EstablishmentCommissioner>();

	    [DataMember]
        public virtual ICollection<MOL_FakeEmploymentReport> MOL_FakeEmploymentReport { get; set; } = new List<MOL_FakeEmploymentReport>();

	    [DataMember]
        public virtual MOL_LaborOffice MOL_LaborOffice { get; set; }
		[DataMember]
        public virtual MOL_LaborOffice MOL_LaborOffice1 { get; set; }
		[DataMember]
        public virtual MOL_User MOL_User { get; set; }
		[DataMember]
        public virtual ICollection<MOL_TransferRequest> MOL_TransferRequest { get; set; } = new List<MOL_TransferRequest>();

	    [DataMember]
        public virtual ICollection<MOL_WorkPermit> MOL_WorkPermit { get; set; } = new List<MOL_WorkPermit>();

	    [DataMember]
        public virtual ICollection<MOL_WorkPermit> MOL_WorkPermit1 { get; set; } = new List<MOL_WorkPermit>();

        [DataMember]
        public virtual ICollection<MOL_CancelFinalExitWorkPermit> MOL_CancelFinalExitWorkPermit { get; set; } = new List<MOL_CancelFinalExitWorkPermit>();

        [DataMember]
        public virtual ICollection<MOL_ChangeLaborerBranchInMOI> MOL_ChangeLaborerBranchInMOI { get; set; } = new List<MOL_ChangeLaborerBranchInMOI>();

        /// <summary>
        /// Gets the full name.
        /// Added Property
        /// </summary>
        [DataMember]
        public string FullName
        {
            get
            {
                var fullName = new System.Text.StringBuilder();

                fullName.Append(this.FirstName.Trim());
                fullName.Append(" ");

                if (this.SecondName != null)
                {
                    fullName.Append(this.SecondName.Trim());
                    fullName.Append(" ");
                }

                if (this.ThirdName != null)
                {
                    fullName.Append(this.ThirdName.Trim());
                    fullName.Append(" ");
                }

                fullName.Append(this.FourthName.Trim());

                return fullName.ToString();
            }
        }
    }
}
