namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_StatementsType
    {
        public Lookup_StatementsType()
        {
        }

		[DataMember]
        public short Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public virtual ICollection<MOL_EstablishmentStatement> MOL_EstablishmentStatement { get; set; } = new List<MOL_EstablishmentStatement>();
    }
}
