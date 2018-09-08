namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_Country
    {
        public Lookup_Country()
        {
        }

		[DataMember]
        public short Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Local_Name { get; set; }
		[DataMember]
        public short? Code { get; set; }
		[DataMember]
        public string Nationality { get; set; }
		[DataMember]
        public string Local_Nationality { get; set; }
    }
}
