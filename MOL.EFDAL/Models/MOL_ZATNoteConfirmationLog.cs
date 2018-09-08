namespace MOL.EFDAL.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class MOL_ZATNoteConfirmationLog
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long FK_LaborOfficeId { get; set; }

        [DataMember]
        public long SequenceNumber { get; set; }

        [DataMember]
        public long UserID { get; set; }

        [DataMember]
        public DateTime InsertDate { get; set; }

    }
}
