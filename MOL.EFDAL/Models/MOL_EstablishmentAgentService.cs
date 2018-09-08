namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentAgentService
    {
		[DataMember]
        public int PK_EstablishmentAgentServiceId { get; set; }
		[DataMember]
        public long FK_EstablishmentAgentId { get; set; }
		[DataMember]
        public int FK_ServiceId { get; set; }
		[DataMember]
        public virtual Enum_Service Enum_Service { get; set; }
		[DataMember]
        public virtual MOL_EstablishmentAgent MOL_EstablishmentAgent { get; set; }
    }
}
