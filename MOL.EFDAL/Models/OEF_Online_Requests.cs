namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class OEF_Online_Requests
    {
		[DataMember]
        public int? Fk_LaborOfficeId { get; set; }
		[DataMember]
        public int? HijriYear { get; set; }
		[DataMember]
        public int SequenceNumber { get; set; }
		[DataMember]
        public long? Fk_EstablishmentId { get; set; }
		[DataMember]
        public long? Fk_UserId { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
        
        public virtual MOL_Establishment MOL_Establishment { get; set; }
        public virtual MOL_User MOL_User { get; set; }
    }
}
