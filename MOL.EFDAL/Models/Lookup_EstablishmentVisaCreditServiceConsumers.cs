using System.Collections.Generic;

namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_EstablishmentVisaCreditServiceConsumers
    {
        public Lookup_EstablishmentVisaCreditServiceConsumers()
        {
        }

		[DataMember]
        public int ID { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public string Password { get; set; }
		[DataMember]
        public bool IsActive { get; set; }

        public virtual ICollection<MOL_EstablishmentVisaCreditJobsHistory> MOL_EstablishmentVisaCreditJobsHistory { get; set; } = new List<MOL_EstablishmentVisaCreditJobsHistory>();
    }
}
