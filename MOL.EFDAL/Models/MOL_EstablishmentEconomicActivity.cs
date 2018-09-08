namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentEconomicActivity
    {
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public int FK_EconomicId { get; set; }
    }
}
