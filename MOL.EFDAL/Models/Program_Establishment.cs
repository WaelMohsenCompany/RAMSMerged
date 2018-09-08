using System.Collections.Generic;

namespace MOL.EFDAL.Models
{
    public partial class Program_Establishment
    {
        public Program_Establishment()
        {
            this.Periodic_Bill = new List<Periodic_Bill>();
            this.Program_Establishment_History = new List<Program_Establishment_History>();
        }

        public int Id { get; set; }
        public long? Establishment_Id { get; set; }
        public int? Requested_Saudi_Units { get; set; }
        public decimal? Calculated_Fees { get; set; }
        public System.DateTime? Joining_On { get; set; }
        public System.DateTime? Deactivation_On { get; set; }
        public int? Program_Status_Id { get; set; }
        public System.DateTime? Created_On { get; set; }
        public long? Created_By { get; set; }
        public string User_IP_Address { get; set; }
        public string User_PC_Name { get; set; }
        public System.DateTime? Activation_Date { get; set; }
        public virtual ICollection<Periodic_Bill> Periodic_Bill { get; set; }
        public virtual ICollection<Program_Establishment_History> Program_Establishment_History { get; set; }
        public virtual Program_Status Program_Status { get; set; }
    }
}
