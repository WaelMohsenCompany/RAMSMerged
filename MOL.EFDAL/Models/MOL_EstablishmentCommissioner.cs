namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentCommissioner
    {
        public MOL_EstablishmentCommissioner()
        {
        }

		[DataMember]
        public long PK_EstablishmentCommissionerId { get; set; }
		[DataMember]
        public int FK_CommissionerTypeId { get; set; }
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public long? FK_LaborerId { get; set; }
		[DataMember]
        public int? FK_ServiceOfficeId { get; set; }
		[DataMember]
        public string AuthorizationNumber { get; set; }
		[DataMember]
        public string Source { get; set; }
		[DataMember]
        public System.DateTime? ReleaseDate { get; set; }
		[DataMember]
        public System.DateTime CommissionStartDate { get; set; }
		[DataMember]
        public System.DateTime CommissionEndDate { get; set; }
		[DataMember]
        public string CommissionReason { get; set; }
		[DataMember]
        public bool? StopCommission { get; set; }
		[DataMember]
        public System.DateTime? StopCommissionDate { get; set; }
		[DataMember]
        public string StopCommissionReason { get; set; }
		[DataMember]
        public long? SequenceNumber { get; set; }
		[DataMember]
        public bool? IsVerified { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
		[DataMember]
        public System.DateTime? ModifiedOn { get; set; }
		[DataMember]
        public virtual Enum_CommissionerType Enum_CommissionerType { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
		[DataMember]
        public virtual MOL_Laborer MOL_Laborer { get; set; }
		[DataMember]
        public virtual ICollection<MOL_EstablishmentCommissionerService> MOL_EstablishmentCommissionerService { get; set; } = new List<MOL_EstablishmentCommissionerService>();
    }
}
