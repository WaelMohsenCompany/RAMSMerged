namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_ChangeEstablishmentActivityRequestStatus
    {
        public Enum_ChangeEstablishmentActivityRequestStatus()
        {
            this.MOL_ChangeEstablishmentActivityRequest = new List<MOL_ChangeEstablishmentActivityRequest>();
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
		[DataMember]
        public System.DateTime? ModifiedOn { get; set; }
		[DataMember]
        public virtual ICollection<MOL_ChangeEstablishmentActivityRequest> MOL_ChangeEstablishmentActivityRequest { get; set; }
    }
}
