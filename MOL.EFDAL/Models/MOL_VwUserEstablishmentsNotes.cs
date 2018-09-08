namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VwUserEstablishmentsNotes
    {
		[DataMember]
        public long? FK_UserId { get; set; }
		[DataMember]
        public long? NoteNumber { get; set; }
		[DataMember]
        public string NoteSource { get; set; }
		[DataMember]
        public System.DateTime? InsertDate { get; set; }
		[DataMember]
        public System.DateTime? EndDate { get; set; }
		[DataMember]
        public string EstablishmentName { get; set; }
		[DataMember]
        public long PK_EstablishmentNoteId { get; set; }
		[DataMember]
        public long EstablishmentId { get; set; }
    }
}
