namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_AgeRange
    {
		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public short? LowerLimit { get; set; }
		[DataMember]
        public short? UpperLimit { get; set; }
    }
}
