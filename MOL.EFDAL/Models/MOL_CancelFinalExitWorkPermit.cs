namespace MOL.EFDAL.Models
{
    using System;

    public class MOL_CancelFinalExitWorkPermit
    {
        public int Id { get; set; }
        public long LaborerId { get; set; }
        public long CanceledWPId { get; set; }
        public long? OldWPId { get; set; }
        public long UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string ClientIP { get; set; }

        public virtual MOL_Laborer MOL_Laborer { get; set; }
        public virtual MOL_User MOL_User { get; set; }

    }
}
