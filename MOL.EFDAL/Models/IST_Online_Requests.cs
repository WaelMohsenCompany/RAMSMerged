namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class IST_Online_Requests
    {
		[DataMember]
        public int? p_lab_off_cmpy { get; set; }
		[DataMember]
        public long? p_cmpy_no { get; set; }
		[DataMember]
        public string p_SPONNAME { get; set; }
		[DataMember]
        public long? p_id_no { get; set; }
		[DataMember]
        public int? p_appl_typ { get; set; }
		[DataMember]
        public long? p_agn_ser_no { get; set; }
		[DataMember]
        public string p_law_name { get; set; }
		[DataMember]
        public long? p_law_id { get; set; }
		[DataMember]
        public int? FK_ColorId { get; set; }
		[DataMember]
        public int? FK_UserId { get; set; }
		[DataMember]
        public System.DateTime? createdon { get; set; }
		[DataMember]
        public long PK_Online_Requests { get; set; }
    }
}
