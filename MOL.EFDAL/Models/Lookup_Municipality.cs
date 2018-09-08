namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_Municipality
    {
		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public int FK_LaborOfficeId { get; set; }
		[DataMember]
        public virtual MOL_LaborOffice MOL_LaborOffice { get; set; }
    }
}
