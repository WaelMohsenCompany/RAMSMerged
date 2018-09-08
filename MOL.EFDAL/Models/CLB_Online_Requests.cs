namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class CLB_Online_Requests
    {
		[DataMember]
        public int? p_lab_off { get; set; }
		[DataMember]
        public int? p_nat_flg { get; set; }
		[DataMember]
        public long? p_lab_ser { get; set; }
		[DataMember]
        public int? o_lab_off_cmpy { get; set; }
		[DataMember]
        public long? o_cmpy_no { get; set; }
		[DataMember]
        public int? p_lab_off_cmpy { get; set; }
		[DataMember]
        public long? p_cmpy_no { get; set; }
		[DataMember]
        public System.DateTime? TimeStamp { get; set; }
		[DataMember]
        public System.DateTime? createdon { get; set; }
		[DataMember]
        public long PK_Online_Requests { get; set; }
		[DataMember]
        public long? LaborerIdNo { get; set; }
		[DataMember]
        public short? Filler_3 { get; set; }
    }
}
