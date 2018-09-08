namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_AdviceMessages
    {
		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string AdviceText { get; set; }
    }
}
