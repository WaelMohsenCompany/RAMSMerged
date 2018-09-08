namespace MOL.EFDAL.Models
{
    using System;

    public partial class MOL_AuditTrails
    {
        public System.Guid AuditId { get; set; }
        public Nullable<long> UserId { get; set; }
        public Nullable<short> FK_AuditActionId { get; set; }
        public string AuditedTableName { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public Nullable<System.DateTime> AuditDateTime { get; set; }
        public string ObjectName { get; set; }
        public Nullable<long> ObjectId { get; set; }
    }
}
