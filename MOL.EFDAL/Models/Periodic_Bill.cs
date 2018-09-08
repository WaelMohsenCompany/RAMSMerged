namespace MOL.EFDAL.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Periodic_Bill
    {
        public Periodic_Bill()
        {
        }

        public int Id { get; set; }
        public int? Program_Establishment_Id { get; set; }
        public int? Program_Sequence { get; set; }
        public int? Requested_Saudi_Units { get; set; }
        public int? Calculated_Fees { get; set; }
        public decimal? Bill_Amount { get; set; }
        public decimal? Bill_Number { get; set; }
        public System.DateTime? Issued_On { get; set; }
        public System.DateTime? Expiration_On { get; set; }
        public int? Bill_Status_Id { get; set; }
        public System.DateTime? Status_Modified_On { get; set; }
        public DateTime? Nitaqat_Validity_Start { get; set; }
        public DateTime? Nitaqat_Validity_Expiration { get; set; }
        public virtual Bill_Status Bill_Status { get; set; }
        public virtual ICollection<Periodic_Bill_History> Periodic_Bill_History { get; set; } = new List<Periodic_Bill_History>();
        public virtual Program_Establishment Program_Establishment { get; set; }
    }
}
