namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_EmployeeType
    {
        public Enum_EmployeeType()
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
    }
}
