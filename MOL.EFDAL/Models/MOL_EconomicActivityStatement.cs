namespace MOL.EFDAL.Models
{
    using System;

    public partial class MOL_EconomicActivityStatement
    {
        public int Id { get; set; }
        public Nullable<int> FK_EconomicActivityId { get; set; }
        public Nullable<int> FK_StatementsTypeId { get; set; }
        public Nullable<bool> IsRequired { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
    }
}
