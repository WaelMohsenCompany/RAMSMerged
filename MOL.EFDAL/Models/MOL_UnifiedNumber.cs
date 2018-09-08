namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_UnifiedNumber
    {
        public MOL_UnifiedNumber()
        {
        }

        [DataMember]
        public long PK_UnifiedNumberId { get; set; }
        [DataMember]
        public int FK_LaborOfficeId { get; set; }
        [DataMember]
        public long SequenceNumber { get; set; }
        [DataMember]
        public int? FK_EstablishmentTypeId { get; set; }
        [DataMember]
        public short FK_NationalityId { get; set; }
        [DataMember]
        public int? FK_LawRepresentationId { get; set; }
        [DataMember]
        public string SevenHundredNumber { get; set; }
        [DataMember]
        public int? FK_OwnerId { get; set; }
        [DataMember]
        public long? CommercialRecordSequenceNumber { get; set; }
        [DataMember]
        public long? FK_FirstEstablishment { get; set; }
        [DataMember]
        public System.DateTime? CreatedOn { get; set; }
        [DataMember]
        public System.DateTime? ModifiedOn { get; set; }
        [DataMember]
        public int? MCI700UsageStatus { get; set; }
        [DataMember]
        public virtual Enum_EstablishmentType Enum_EstablishmentType { get; set; }
        [DataMember]
        public virtual Lookup_LawRepresentation Lookup_LawRepresentation { get; set; }
        [DataMember]
        public virtual Lookup_Nationality Lookup_Nationality { get; set; }
        [DataMember]
        public virtual ICollection<MOL_Establishment> MOL_Establishment { get; set; } = new List<MOL_Establishment>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentAgent> MOL_EstablishmentAgent { get; set; } = new List<MOL_EstablishmentAgent>();

        [DataMember]
        public virtual MOL_LaborOffice MOL_LaborOffice { get; set; }
        [DataMember]
        public virtual MOL_Owner MOL_Owner { get; set; }
    }
}
