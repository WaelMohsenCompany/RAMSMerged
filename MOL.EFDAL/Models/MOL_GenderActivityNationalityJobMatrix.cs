namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_GenderActivityNationalityJobMatrix
    {
		[DataMember]
        public int ID { get; set; }
		[DataMember]
        public int? NationalityId { get; set; }
		[DataMember]
        public int? GenderId { get; set; }
		[DataMember]
        public int? ActivityId { get; set; }
		[DataMember]
        public int? JobId { get; set; }
		[DataMember]
        public bool? IsValidRule { get; set; }
		[DataMember]
        public bool? ValidForCompensationVisas { get; set; }
		[DataMember]
        public bool? ValidForInstantVisas { get; set; }
		[DataMember]
        public bool? ValidForEServicesSystem { get; set; }
		[DataMember]
        public bool? ValidForMPSystem { get; set; }
    }
}
