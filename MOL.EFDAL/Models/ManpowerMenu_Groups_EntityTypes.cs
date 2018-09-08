namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class ManpowerMenu_Groups_EntityTypes
    {
		[DataMember]
        public int ID { get; set; }
		[DataMember]
        public int ManpowerGroupID { get; set; }
		[DataMember]
        public long SecurableEntityTypeID { get; set; }
		[DataMember]
        public int Order { get; set; }
		[DataMember]
        public virtual Lookup_SecurableEntityType Lookup_SecurableEntityType { get; set; }
		[DataMember]
        public virtual ManpowerMenu_Groups ManpowerMenu_Groups { get; set; }
    }
}
