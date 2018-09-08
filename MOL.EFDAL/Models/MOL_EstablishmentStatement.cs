namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentStatement
    {
		[DataMember]
        public long PK_EstablishmentStatementId { get; set; }
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public short FK_StatementTypeId { get; set; }
		[DataMember]
        public string StatementNumber { get; set; }
		[DataMember]
        public System.DateTime ReleaseDate { get; set; }
		[DataMember]
        public System.DateTime EndDate { get; set; }
		[DataMember]
        public string Source { get; set; }
		[DataMember]
        public string CancellationNo { get; set; }
		[DataMember]
        public System.DateTime? CancellationDate { get; set; }
		[DataMember]
        public System.DateTime? ConfirmationDate { get; set; }
		[DataMember]
        public virtual Lookup_StatementsType Lookup_StatementsType { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
    }
}
