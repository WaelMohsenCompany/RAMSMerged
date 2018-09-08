namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class ST_Online_Approval
    {
		[DataMember]
        public int? p_lab_off { get; set; }
		[DataMember]
        public int? p_ser_yy { get; set; }
		[DataMember]
        public int? p_ser_no { get; set; }
		[DataMember]
        public long? p_id_no { get; set; }
		[DataMember]
        public string TimeStamp { get; set; }
		[DataMember]
        public int? FK_UserId { get; set; }
		[DataMember]
        public System.DateTime? createdon { get; set; }
		[DataMember]
        public decimal PK_Online_Approval { get; set; }
		[DataMember]
        public int? ST_STATUS { get; set; }
		[DataMember]
        public string Reason { get; set; }
    }
}
