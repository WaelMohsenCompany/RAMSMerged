namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_FakeEmploymentReportStatus
    {
        public MOL_FakeEmploymentReportStatus()
        {
        }

		[DataMember]
        public int PK_FakeEmploymentReportStatusId { get; set; }
		[DataMember]
        public string StatusDescription { get; set; }
		[DataMember]
        public virtual ICollection<MOL_FakeEmploymentReport> MOL_FakeEmploymentReport { get; set; } = new List<MOL_FakeEmploymentReport>();

	    [DataMember]
        public virtual ICollection<MOL_FakeEmploymentReportComments> MOL_FakeEmploymentReportComments { get; set; } = new List<MOL_FakeEmploymentReportComments>();
    }
}
