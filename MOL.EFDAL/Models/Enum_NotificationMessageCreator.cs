namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_NotificationMessageCreator
    {
        public Enum_NotificationMessageCreator()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public virtual ICollection<MOL_NotificationMessage> MOL_NotificationMessage { get; set; } = new List<MOL_NotificationMessage>();
    }
}
