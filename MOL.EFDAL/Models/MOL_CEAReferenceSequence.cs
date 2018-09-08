namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_CEAReferenceSequence
    {
		[DataMember]
        public int Year { get; set; }
		[DataMember]
        public int Month { get; set; }
		[DataMember]
        public int Sequence { get; set; }
    }
}
