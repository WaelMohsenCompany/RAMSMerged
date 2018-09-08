namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class CJD_Online_Requests
    {
		[DataMember]
        public int? p_lab_off { get; set; }
		[DataMember]
        public int? p_nat_flg { get; set; }
		[DataMember]
        public int? p_lab_ser { get; set; }
		[DataMember]
        public int? p_old_job { get; set; }
		[DataMember]
        public int? p_new_job { get; set; }
		[DataMember]
        public int? p_lab_off_cmpy { get; set; }
		[DataMember]
        public long? p_cmpy_no { get; set; }
		[DataMember]
        public int? p_appl_typ { get; set; }
		[DataMember]
        public int? p_agn_ser_no { get; set; }
		[DataMember]
        public string p_law_name { get; set; }
		[DataMember]
        public int? p_law_id { get; set; }
		[DataMember]
        public int? FK_ColorId { get; set; }
		[DataMember]
        public string TimeStamp { get; set; }
		[DataMember]
        public long? Fk_UserId { get; set; }
		[DataMember]
        public System.DateTime? createdon { get; set; }
		[DataMember]
        public long PK_Online_Requests { get; set; }
        [DataMember]
        public virtual ICollection<MOL_OracleTransactionLog> MOL_OracleTransactionLog { get; set; } = new List<MOL_OracleTransactionLog>();
        [DataMember]
        public virtual MOL_User MOL_User { get; set; }
    }
}
