namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_ChangeWorkerStatusCommentType
    {
        public Enum_ChangeWorkerStatusCommentType()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
    }
}
