namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;
    [DataContract]
    public partial class MOL_OpenEstablishmentFileFromSD
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public long FK_EstablishmentID { get; set; }
        [DataMember]
        public System.DateTime TimeStamp { get; set; }
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public string RequesterIdNo { get; set; }
        [DataMember]
        public string RepresentativeIdNo { get; set; }
        [DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
    }
}
