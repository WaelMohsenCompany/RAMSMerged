namespace MOL.EFDAL.Models
{
    using System;

    public partial class MOL_VwLaborer_Audit_GetEstablishmentsHistory
    {
        public Nullable<long> PK_LaborerId { get; set; }
        public Nullable<long> FK_EstablishmentId { get; set; }
        public int FK_LaborOfficeId { get; set; }
        public long SequenceNumber { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> ServiceStartDate { get; set; }
    }
}