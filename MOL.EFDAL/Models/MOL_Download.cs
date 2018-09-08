namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Download
    {
		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public System.Guid DownloadGuid { get; set; }
		[DataMember]
        public string ContentType { get; set; }
		[DataMember]
        public string Filename { get; set; }
		[DataMember]
        public string Extension { get; set; }
		[DataMember]
        public string Path { get; set; }
		[DataMember]
        public bool Deleted { get; set; }
		[DataMember]
        public System.DateTime CreatedOn { get; set; }
    }
}
