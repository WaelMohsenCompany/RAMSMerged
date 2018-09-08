namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_FakeEmploymentReportCommentOwner
    {
        public MOL_FakeEmploymentReportCommentOwner()
        {
        }

		[DataMember]
        public int PK_FakeEmploymentReportCommentOwnerId { get; set; }
		[DataMember]
        public string OwnerType { get; set; }
		[DataMember]
        public virtual ICollection<MOL_FakeEmploymentReportComments> MOL_FakeEmploymentReportComments { get; set; } = new List<MOL_FakeEmploymentReportComments>();
    }
}
