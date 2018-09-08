namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_ProgramBEstablishments
    {
		[DataMember]
        public int ID { get; set; }
		[DataMember]
        public long? EstablishmentID { get; set; }
		[DataMember]
        public bool? Active { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
    }
}
