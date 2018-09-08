namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentNoteService
    {
		[DataMember]
        public long PK_EstablishmentNoteServiceId { get; set; }
		[DataMember]
        public long FK_EstablishmentNoteId { get; set; }
		[DataMember]
        public int FK_ServiceId { get; set; }
		[DataMember]
        public virtual Enum_Service Enum_Service { get; set; }
    }
}
