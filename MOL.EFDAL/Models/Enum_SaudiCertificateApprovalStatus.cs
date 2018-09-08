namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_SaudiCertificateApprovalStatus
    {
        public Enum_SaudiCertificateApprovalStatus()
        {
        }

		[DataMember]
        public short Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public virtual ICollection<MOL_EstablishmentSaudiCertificate> MOL_EstablishmentSaudiCertificate { get; set; } = new List<MOL_EstablishmentSaudiCertificate>();
    }
}
