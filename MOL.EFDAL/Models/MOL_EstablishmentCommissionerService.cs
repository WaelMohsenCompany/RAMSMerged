namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentCommissionerService
    {
		[DataMember]
        public long PK_EstablishmentCommissionerServiceId { get; set; }
		[DataMember]
        public long FK_EstablishmentCommissionerId { get; set; }
		[DataMember]
        public int FK_ServiceId { get; set; }
		[DataMember]
        public virtual Enum_Service Enum_Service { get; set; }
		[DataMember]
        public virtual MOL_EstablishmentCommissioner MOL_EstablishmentCommissioner { get; set; }
    }
}
