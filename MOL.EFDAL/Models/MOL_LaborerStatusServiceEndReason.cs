namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_LaborerStatusServiceEndReason
    {
        public MOL_LaborerStatusServiceEndReason()
        {
        }

		[DataMember]
        public int PK_LaborerStatusServiceEndReasonId { get; set; }
		[DataMember]
        public int FK_LaborerStatusId { get; set; }
		[DataMember]
        public int FK_ServiceEndReasonId { get; set; }
		[DataMember]
        public virtual Enum_LaborerStatus Enum_LaborerStatus { get; set; }
		[DataMember]
        public virtual Lookup_ServiceEndReason Lookup_ServiceEndReason { get; set; }
    }
}
