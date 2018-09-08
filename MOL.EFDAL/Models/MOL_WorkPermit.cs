namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_WorkPermit
    {
		[DataMember]
        public long PK_WPId { get; set; }
		[DataMember]
        public long FK_Service_TransactionId { get; set; }
		[DataMember]
        public long FK_LaborId { get; set; }
		[DataMember]
        public int FK_Servcie_ServiceRequestTypeId { get; set; }
		[DataMember]
        public System.DateTime StartDate { get; set; }
		[DataMember]
        public System.DateTime ExpirationDate { get; set; }
		[DataMember]
        public string FK_WP_ReasonId { get; set; }
		[DataMember]
        public int Period { get; set; }
		[DataMember]
        public System.DateTime? LastPrintingDate { get; set; }
		[DataMember]
        public long? FK_PrintedBy { get; set; }
		[DataMember]
        public bool? IsSynchronized { get; set; }
		[DataMember]
        public int? NOT_ISSUED_WP { get; set; }
		[DataMember]
        public int? ExtraFees { get; set; }
		[DataMember]
        public int? PenalityExtraFees { get; set; }
		[DataMember]
        public virtual MOL_Laborer MOL_Laborer { get; set; }
		[DataMember]
        public virtual MOL_Laborer MOL_Laborer1 { get; set; }
		[DataMember]
        public virtual MOL_Srv_Transaction MOL_Srv_Transaction { get; set; }
		[DataMember]
        public virtual MOL_Srv_Transaction MOL_Srv_Transaction1 { get; set; }
		[DataMember]
        public virtual MOL_User MOL_User { get; set; }
    }
}
