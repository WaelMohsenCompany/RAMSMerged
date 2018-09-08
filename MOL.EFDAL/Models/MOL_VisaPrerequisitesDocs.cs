namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VisaPrerequisitesDocs
    {
		[DataMember]
        public int PreRequisitID { get; set; }
		[DataMember]
        public int Sequence { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public int FK_ServiceID { get; set; }
    }
}
