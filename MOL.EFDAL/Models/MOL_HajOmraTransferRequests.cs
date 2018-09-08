namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_HajOmraTransferRequests
    {
		[DataMember]
        public int ID { get; set; }
		[DataMember]
        public long? RequesterID { get; set; }
		[DataMember]
        public System.DateTime? OldKingdomEntryDate { get; set; }
		[DataMember]
        public System.DateTime? NewKingdomEntryDate { get; set; }
		[DataMember]
        public int? EstablishmentID { get; set; }
		[DataMember]
        public string BorderNo { get; set; }
		[DataMember]
        public System.DateTime? RequestDate { get; set; }
		[DataMember]
        public string Temp1 { get; set; }
		[DataMember]
        public string Temp2 { get; set; }
		[DataMember]
        public string Temp3 { get; set; }
    }
}
