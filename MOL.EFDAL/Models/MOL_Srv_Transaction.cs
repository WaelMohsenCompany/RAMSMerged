namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Srv_Transaction
    {
        public MOL_Srv_Transaction()
        {
        }

		[DataMember]
        public long PK_Service_TransactionId { get; set; }
		[DataMember]
        public int FK_Service_ServiceId { get; set; }
		[DataMember]
        public string TransactionNumber { get; set; }
		[DataMember]
        public System.DateTime TransactionDate { get; set; }
		[DataMember]
        public decimal TransactionFees { get; set; }
		[DataMember]
        public long? FK_EstablishmentId { get; set; }
		[DataMember]
        public int? FK_LaborOfficeId { get; set; }
		[DataMember]
        public long? FK_RequesterId { get; set; }
		[DataMember]
        public int? Fk_RequesterTypeId { get; set; }
		[DataMember]
        public string OtherRequester { get; set; }
		[DataMember]
        public decimal? BillNumber { get; set; }
		[DataMember]
        public int? FK_Service_LastServiceStatusId { get; set; }
		[DataMember]
        public System.DateTime? StatusLastModificationDate { get; set; }
		[DataMember]
        public long? FK_UserID { get; set; }
		[DataMember]
        public int? FK_PayementTypeID { get; set; }
		[DataMember]
        public string RecieptNumber { get; set; }
		[DataMember]
        public long? FK_CreatedByUserId { get; set; }
		[DataMember]
        public virtual Enum_PayementType Enum_PayementType { get; set; }
		[DataMember]
        public virtual Enum_RequesterType Enum_RequesterType { get; set; }
		[DataMember]
        public virtual Enum_Service Enum_Service { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
		[DataMember]
        public virtual MOL_LaborOffice MOL_LaborOffice { get; set; }
		[DataMember]
        public virtual MOL_User MOL_User { get; set; }
		[DataMember]
        public virtual MOL_User MOL_User1 { get; set; }
		[DataMember]
        public virtual ICollection<MOL_WorkPermit> MOL_WorkPermit { get; set; } = new List<MOL_WorkPermit>();

	    [DataMember]
        public virtual ICollection<MOL_WorkPermit> MOL_WorkPermit1 { get; set; } = new List<MOL_WorkPermit>();
    }
}
