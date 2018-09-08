namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VisaIssueRejectReasons
    {
		[DataMember]
        public int PK_ReasonID { get; set; }
		[DataMember]
        public string ReasonDescription { get; set; }
    }
}
