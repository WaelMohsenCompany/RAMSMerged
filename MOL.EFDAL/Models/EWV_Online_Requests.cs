namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class EWV_Online_Requests
    {
		[DataMember]
        public long PK_Online_Requests { get; set; }
		[DataMember]
        public string TransactionNumber { get; set; }
		[DataMember]
        public long? FK_UserId { get; set; }
		[DataMember]
        public long? FK_PrivilegeId { get; set; }
		[DataMember]
        public int? FK_RequesterTypeId { get; set; }
		[DataMember]
        public long? RequesterIdNo { get; set; }
		[DataMember]
        public System.DateTime? TimeStamp { get; set; }
		[DataMember]
        public string p_lab_off_cmpy { get; set; }
		[DataMember]
        public string p_cmpy_no { get; set; }
		[DataMember]
        public string p_appl_typ { get; set; }
		[DataMember]
        public string p_agn_ser_no { get; set; }
		[DataMember]
        public string p_tot_labores { get; set; }
		[DataMember]
        public string p_law_name { get; set; }
		[DataMember]
        public string p_law_id { get; set; }
    }
}
