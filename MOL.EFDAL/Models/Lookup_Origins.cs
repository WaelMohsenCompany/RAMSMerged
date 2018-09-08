namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_Origins
    {
        public Lookup_Origins()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public bool? IsIncludedForEWV { get; set; }
		[DataMember]
        public short? FK_NationalityId { get; set; }
		[DataMember]
        public virtual Lookup_Nationality Lookup_Nationality { get; set; }
    }
}
