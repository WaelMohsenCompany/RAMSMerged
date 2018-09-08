namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VwCEAJobLaborersCount
    {
		[DataMember]
        public long EstablishmentId { get; set; }
		[DataMember]
        public int JobId { get; set; }
		[DataMember]
        public string Job { get; set; }
		[DataMember]
        public int? LaborersCount { get; set; }
    }
}
