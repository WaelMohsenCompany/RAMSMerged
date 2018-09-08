namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentAgent
    {
        public MOL_EstablishmentAgent()
        {
        }

		[DataMember]
        public long PK_EstablishmentAgentId { get; set; }
		[DataMember]
        public int FK_AgentTypeId { get; set; }
		[DataMember]
        public long? FK_EstablishmentId { get; set; }
		[DataMember]
        public long? FK_UnifiedNumberId { get; set; }
		[DataMember]
        public int FK_AgentId { get; set; }
		[DataMember]
        public string AgencyNo { get; set; }
		[DataMember]
        public string AgencySource { get; set; }
		[DataMember]
        public System.DateTime AgencyReleaseDate { get; set; }
		[DataMember]
        public System.DateTime? AgencyEndDate { get; set; }
		[DataMember]
        public string AgencyDescription { get; set; }
		[DataMember]
        public bool? StopAgency { get; set; }
		[DataMember]
        public System.DateTime? StopAgencyDate { get; set; }
		[DataMember]
        public string StopAgencyReason { get; set; }
		[DataMember]
        public bool? IsVerified { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
		[DataMember]
        public System.DateTime? ModifiedOn { get; set; }
		[DataMember]
        public virtual Enum_AgentType Enum_AgentType { get; set; }
		[DataMember]
        public virtual MOL_Agent MOL_Agent { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
		[DataMember]
        public virtual MOL_UnifiedNumber MOL_UnifiedNumber { get; set; }
		[DataMember]
        public virtual ICollection<MOL_EstablishmentAgentService> MOL_EstablishmentAgentService { get; set; } = new List<MOL_EstablishmentAgentService>();
    }
}
