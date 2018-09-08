namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentExceptionalWP
    {
		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public byte[] FK_UnifiedNumberId { get; set; }
		[DataMember]
        public byte[] FK_LaborOfficeId { get; set; }
		[DataMember]
        public byte[] SequenceNumber { get; set; }
		[DataMember]
        public bool IsActive { get; set; }
    }
}
