namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_LaborerExceptionalWP
    {
		[DataMember]
        public long Id { get; set; }
		[DataMember]
        public byte[] FK_EstablishmentId { get; set; }
		[DataMember]
        public byte[] FK_LaborerId { get; set; }
		[DataMember]
        public byte[] IdNo { get; set; }
		[DataMember]
        public bool IsActive { get; set; }
		[DataMember]
        public string IdNo_Dec { get; set; }
    }
}
