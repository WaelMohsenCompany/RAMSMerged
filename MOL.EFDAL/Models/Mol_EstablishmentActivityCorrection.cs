namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Mol_EstablishmentActivityCorrection
    {
		[DataMember]
        public long PK_EstablishmentActivityCorrection { get; set; }
		[DataMember]
        public int? FK_LaborOfficeId { get; set; }
		[DataMember]
        public long? SequenceNumber { get; set; }
		[DataMember]
        public string EconomicActivityText { get; set; }
		[DataMember]
        public int? FK_MainEconomicActivityId { get; set; }
		[DataMember]
        public int? FK_SubEconomicActivityId { get; set; }
		[DataMember]
        public bool? IsDeleted { get; set; }
		[DataMember]
        public string Comment { get; set; }
		[DataMember]
        public System.DateTime? ExpDate { get; set; }
		[DataMember]
        public string FK_CreatedUserId { get; set; }
		[DataMember]
        public System.DateTime? ModificationDate { get; set; }
    }
}
