namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_EstablishmentVisaCreditTerminationReason
    {
        public Enum_EstablishmentVisaCreditTerminationReason()
        {
        }

		[DataMember]
        public int ID { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public virtual ICollection<MOL_EstablishmentVisaCredit> MOL_EstablishmentVisaCredit { get; set; } = new List<MOL_EstablishmentVisaCredit>();
    }
}
