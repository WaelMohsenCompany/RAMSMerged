namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_LaborerMOIRunaway
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long LaborerId { get; set; }
        [DataMember]
        public long EstablishmentId { get; set; }
        [DataMember]
        public long? IDNumber { get; set; }
        [DataMember]
        public System.DateTime CreatedOn { get; set; }
        [DataMember]
        public bool IsCancelRunaway { get; set; }
    }
}
