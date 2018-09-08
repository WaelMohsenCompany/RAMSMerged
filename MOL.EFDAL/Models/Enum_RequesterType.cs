namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_RequesterType
    {
        public Enum_RequesterType()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public virtual ICollection<MOL_Srv_Transaction> MOL_Srv_Transaction { get; set; } = new List<MOL_Srv_Transaction>();
    }
}
