namespace MOL.EFDAL.Models
{
    using System;
    using System.Runtime.Serialization;
    [DataContract]
    public partial class MOL_OpenEstablishmentFileFromMCI
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public long FK_EstablishmentID { get; set; }
        [DataMember]
        public Guid ReferenceNumber { get; set; }
        [DataMember]
        public System.DateTime TimeStamp { get; set; }
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public int MCI_Status { get; set; }
        [DataMember]
        public string MCI_Body { get; set; }

        [DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
    }
}
