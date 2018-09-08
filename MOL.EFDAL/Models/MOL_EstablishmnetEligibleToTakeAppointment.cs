namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmnetEligibleToTakeAppointment
    {
		[DataMember]
        public long PK_EstablishmentAppointment { get; set; }
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public bool EligibleToTakeAppointment { get; set; }
		[DataMember]
        public System.DateTime TimeStamp { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
    }
}
