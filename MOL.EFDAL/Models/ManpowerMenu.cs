namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class ManpowerMenu
    {
		[DataMember]
        public long ID { get; set; }
		[DataMember]
        public int Order { get; set; }
		[DataMember]
        public string URL { get; set; }
		[DataMember]
        public bool IsActive { get; set; }
		[DataMember]
        public virtual MOL_Sec_Privilege MOL_Sec_Privilege { get; set; }
    }
}
