using System.Collections.Generic;

namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_EstablishmentVisaCreditJobOperationType
    {
        public Enum_EstablishmentVisaCreditJobOperationType()
        {
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }

        public virtual ICollection<MOL_EstablishmentVisaCreditJobsHistory> MOL_EstablishmentVisaCreditJobsHistory { get; set; } = new List<MOL_EstablishmentVisaCreditJobsHistory>();
    }
}
