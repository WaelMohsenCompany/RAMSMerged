using System;

namespace MOL.EFDAL.Models
{
    public partial class Periodic_Bill_History
    {
        public Periodic_Bill_History()
        {
        }
        public int Id { get; set; }
        public int? Periodic_Bill_Id { get; set; }
        public int? Bill_Status_Id { get; set; }
       
        public System.DateTime? Status_Created_On { get; set; }
        public virtual Bill_Status Bill_Status { get; set; }
        public virtual Periodic_Bill Periodic_Bill { get; set; }
        public DateTime? Nitaqat_Validity_Start { get; set; }
        public DateTime? Nitaqat_Validity_Expiration { get; set; }
    }
}
