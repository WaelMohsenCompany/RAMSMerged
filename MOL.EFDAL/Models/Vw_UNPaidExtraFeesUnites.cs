namespace MOL.EFDAL.Models
{
    using System;

    public partial class Vw_UNPaidExtraFeesUnites
    {
        public int FK_LaborOfficeId { get; set; }
        public long SequenceNumber { get; set; }
        public Nullable<int> PaidExtraFeesUnites { get; set; }
    }
}
