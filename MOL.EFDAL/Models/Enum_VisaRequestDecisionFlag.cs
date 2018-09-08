namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_VisaRequestDecisionFlag
    {
		[DataMember]
        public int PK_DecisionFlagID { get; set; }
		[DataMember]
        public string Description { get; set; }
    }
}
