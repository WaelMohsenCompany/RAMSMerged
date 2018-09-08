namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_AccountManagerType
    {
        public Enum_AccountManagerType()
        {
            this.MOL_AccountManager = new List<MOL_AccountManager>();
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public virtual ICollection<MOL_AccountManager> MOL_AccountManager { get; set; }
    }
}
