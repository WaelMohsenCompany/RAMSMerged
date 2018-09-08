namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_AuditAction
    {
		[DataMember]
        public short PK_AudiActionId { get; set; }
		[DataMember]
        public string AuditAction { get; set; }
    }
}
