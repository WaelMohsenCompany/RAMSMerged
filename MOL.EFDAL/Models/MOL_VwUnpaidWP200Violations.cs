namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VwUnpaidWP200Violations
    {
		[DataMember]
        public long FK_UnifiedNumberId { get; set; }
		[DataMember]
        public long TotalDueUnits { get; set; }
    }
}
