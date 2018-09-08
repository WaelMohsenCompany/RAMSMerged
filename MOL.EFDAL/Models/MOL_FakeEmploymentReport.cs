namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_FakeEmploymentReport
    {
        public MOL_FakeEmploymentReport()
        {
        }

		[DataMember]
        public long PK_FakeEmploymentReportId { get; set; }
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public System.DateTime FakeEmploymentReportDate { get; set; }
		[DataMember]
        public int FK_FakeEmploymentReportStatusId { get; set; }
		[DataMember]
        public long FK_LaborerId { get; set; }
		[DataMember]
        public string MobileNumber { get; set; }
		[DataMember]
        public string Email { get; set; }
		[DataMember]
        public string ReportBody { get; set; }
		[DataMember]
        public int Fk_LaborOfficeId { get; set; }
		[DataMember]
        public int HijriYear { get; set; }
		[DataMember]
        public long SequenceNumber { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
		[DataMember]
        public virtual MOL_FakeEmploymentReportStatus MOL_FakeEmploymentReportStatus { get; set; }
		[DataMember]
        public virtual MOL_Laborer MOL_Laborer { get; set; }
		[DataMember]
        public virtual ICollection<MOL_FakeEmploymentReportComments> MOL_FakeEmploymentReportComments { get; set; } = new List<MOL_FakeEmploymentReportComments>();
    }
}
