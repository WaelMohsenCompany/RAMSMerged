namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_ComputerSkill
    {
        public Lookup_ComputerSkill()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
    }
}
