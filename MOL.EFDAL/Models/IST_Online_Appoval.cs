namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class IST_Online_Appoval
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
        public int? p_trs_stus { get; set; }
		[DataMember]
        public int? FK_UseId { get; set; }
		[DataMember]
        public string returnParam { get; set; }
		[DataMember]
        public System.DateTime? createdon { get; set; }
		[DataMember]
        public long PK_IST_Online_Appoval { get; set; }
    }
}
