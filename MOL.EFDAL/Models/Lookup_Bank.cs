namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_Bank
    {
        public Lookup_Bank()
        {
        }

		[DataMember]
        public short Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public virtual ICollection<MOL_LaborOffice> MOL_LaborOffice { get; set; } = new List<MOL_LaborOffice>();
    }
}
