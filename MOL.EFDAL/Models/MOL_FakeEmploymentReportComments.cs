namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_FakeEmploymentReportComments
    {
		[DataMember]
        public long PK_CommentId { get; set; }
		[DataMember]
        public int FK_CommentOwner { get; set; }
		[DataMember]
        public string FK_CreatedUserId { get; set; }
		[DataMember]
        public System.DateTime CreationDate { get; set; }
		[DataMember]
        public System.DateTime? ModificationDate { get; set; }
		[DataMember]
        public string Comment { get; set; }
		[DataMember]
        public long FK_FakeEmploymentReportId { get; set; }
		[DataMember]
        public int? fk_FakeEmploymentReportStatusId { get; set; }
		[DataMember]
        public virtual MOL_FakeEmploymentReport MOL_FakeEmploymentReport { get; set; }
		[DataMember]
        public virtual MOL_FakeEmploymentReportCommentOwner MOL_FakeEmploymentReportCommentOwner { get; set; }
		[DataMember]
        public virtual MOL_FakeEmploymentReportStatus MOL_FakeEmploymentReportStatus { get; set; }
    }
}
