namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_CommissionerType
    {
        public Enum_CommissionerType()
        {
            this.MOL_EstablishmentCommissioner = new List<MOL_EstablishmentCommissioner>();
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public virtual ICollection<MOL_EstablishmentCommissioner> MOL_EstablishmentCommissioner { get; set; }
    }
}
