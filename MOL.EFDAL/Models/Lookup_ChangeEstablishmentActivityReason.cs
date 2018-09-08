namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_ChangeEstablishmentActivityReason
    {
        public Lookup_ChangeEstablishmentActivityReason()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public virtual ICollection<MOL_ChangeEstablishmentActivityRequest> MOL_ChangeEstablishmentActivityRequest { get; set; } = new List<MOL_ChangeEstablishmentActivityRequest>();
    }
}
