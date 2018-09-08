namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_WP200ViolatedUnifiedNumbers
    {
		[DataMember]
        public int PK_WP200ViolatedUNId { get; set; }
		[DataMember]
        public long FK_UnifiedNumberId { get; set; }
		[DataMember]
        public long TotalDueUnits { get; set; }
    }
}
