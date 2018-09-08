namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_SaudiCertificateDirectedTo
    {
        public Lookup_SaudiCertificateDirectedTo()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public int? FK_SubDirectedTo { get; set; }
		[DataMember]
        public string Code { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public bool? IsActive { get; set; }
		[DataMember]
        public virtual ICollection<Lookup_SaudiCertificateDirectedTo> Lookup_SaudiCertificateDirectedTo1 { get; set; } = new List<Lookup_SaudiCertificateDirectedTo>();

	    [DataMember]
        public virtual Lookup_SaudiCertificateDirectedTo Lookup_SaudiCertificateDirectedTo2 { get; set; }
		[DataMember]
        public virtual ICollection<MOL_EstablishmentSaudiCertificate> MOL_EstablishmentSaudiCertificate { get; set; } = new List<MOL_EstablishmentSaudiCertificate>();
    }
}
