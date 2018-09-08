namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_TransferRequest
    {
		[DataMember]
        public long PK_TransferRequestId { get; set; }
		[DataMember]
        public long SequenceNumber { get; set; }
		[DataMember]
        public long FK_LaborerId { get; set; }
		[DataMember]
        public int FK_SourceLaborOfficeId { get; set; }
		[DataMember]
        public int FK_DestinationLaborOfficeId { get; set; }
		[DataMember]
        public string TransferReason { get; set; }
		[DataMember]
        public System.DateTime TransferDate { get; set; }
		[DataMember]
        public virtual MOL_Laborer MOL_Laborer { get; set; }
		[DataMember]
        public virtual MOL_LaborOffice MOL_LaborOffice { get; set; }
		[DataMember]
        public virtual MOL_LaborOffice MOL_LaborOffice1 { get; set; }
    }
}
