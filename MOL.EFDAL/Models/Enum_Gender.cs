namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_Gender
    {
        public Enum_Gender()
        {
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
        public virtual ICollection<MOL_Laborer> MOL_Laborer { get; set; } = new List<MOL_Laborer>();
        [DataMember]
        public virtual ICollection<MOL_EstablishmentVisaCreditJobs> MOL_EstablishmentVisaCreditJobs { get; set; } = new List<MOL_EstablishmentVisaCreditJobs>();
        [DataMember]
        public virtual ICollection<MOL_Owner> MOL_Owner { get; set; } = new List<MOL_Owner>();
        [DataMember]
        public virtual ICollection<MOL_User> MOL_User { get; set; } = new List<MOL_User>();
        [DataMember]
        public virtual ICollection<MOL_EstablishmentVisaCreditJobsHistory> MOL_EstablishmentVisaCreditJobsHistory { get; set; } = new List<MOL_EstablishmentVisaCreditJobsHistory>();
    }
}
