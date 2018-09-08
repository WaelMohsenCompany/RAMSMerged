namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentNote
    {
		[DataMember]
        public long PK_EstablishmentNoteId { get; set; }
		[DataMember]
        public long FK_EstablishmentId { get; set; }
		[DataMember]
        public int? FK_NoteTypeId { get; set; }
		[DataMember]
        public long? NoteNumber { get; set; }
		[DataMember]
        public int FK_NoteSourceId { get; set; }
		[DataMember]
        public string NoteText { get; set; }
		[DataMember]
        public int FK_NoteStatusId { get; set; }
		[DataMember]
        public System.DateTime? InsertDate { get; set; }
		[DataMember]
        public string InsertLaborerName { get; set; }
		[DataMember]
        public System.DateTime? EndDate { get; set; }
		[DataMember]
        public string EndLaborerName { get; set; }
		[DataMember]
        public string EndReason { get; set; }
		[DataMember]
        public int? FK_NoteApplicabilityId { get; set; }
		[DataMember]
        public virtual Enum_NoteApplicability Enum_NoteApplicability { get; set; }
		[DataMember]
        public virtual Enum_NoteSource Enum_NoteSource { get; set; }
		[DataMember]
        public virtual Enum_NoteStatus Enum_NoteStatus { get; set; }
		[DataMember]
        public virtual Enum_NoteType Enum_NoteType { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
    }
}
