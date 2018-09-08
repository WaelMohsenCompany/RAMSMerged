namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_EstablishmentVisaCreditType
    {
        public Enum_EstablishmentVisaCreditType()
        {
        }

		[DataMember]
        public int ID { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public int? GroupID { get; set; }
		[DataMember]
        public virtual ICollection<MOL_EstablishmentVisaCredit> MOL_EstablishmentVisaCredit { get; set; } = new List<MOL_EstablishmentVisaCredit>();
    }
}
