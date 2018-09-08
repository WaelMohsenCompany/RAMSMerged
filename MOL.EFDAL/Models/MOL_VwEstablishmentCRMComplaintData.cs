namespace MOL.EFDAL.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    [Serializable]
    public partial class MOL_VwEstablishmentCRMComplaintData
    {
        [DataMember]
        public long PK_EstablishmentId { get; set; }

        [DataMember]
        public int FK_LaborOfficeId { get; set; }

        [DataMember]
        public long SequenceNumber { get; set; }

        [DataMember]
        public string EstablishmentNumber { get; set; }

        [DataMember]
        public string UnifiedNumber { get; set; }

        [DataMember]
        public string SevenHundredNumberOrOwnerID { get; set; }

        [DataMember]
        public short ZoneID { get; set; }

        [DataMember]
        public string ZoneName { get; set; }
    }
}
