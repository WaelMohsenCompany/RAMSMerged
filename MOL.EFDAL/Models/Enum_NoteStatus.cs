namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_NoteStatus
    {
        public Enum_NoteStatus()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Description { get; set; }
		[DataMember]
        public virtual ICollection<MOL_EstablishmentNote> MOL_EstablishmentNote { get; set; } = new List<MOL_EstablishmentNote>();
    }
}
