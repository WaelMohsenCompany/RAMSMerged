namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_SaudiCertificatePurpose
    {
        public Lookup_SaudiCertificatePurpose()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public bool? IsActive { get; set; }
		[DataMember]
        public virtual ICollection<MOL_EstablishmentSaudiCertificate> MOL_EstablishmentSaudiCertificate { get; set; } = new List<MOL_EstablishmentSaudiCertificate>();
    }
}
