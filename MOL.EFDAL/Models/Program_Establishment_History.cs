namespace MOL.EFDAL.Models
{
    public partial class Program_Establishment_History
    {
        public int Id { get; set; }
        public int Program_Establishment_Id { get; set; }
        public int? Requested_Saudi_Units { get; set; }
        public decimal? Calculated_Fees { get; set; }
        public int? Program_Status_Id { get; set; }
        public System.DateTime? Created_On { get; set; }
        public long? Created_By { get; set; }
        public string User_IP_Address { get; set; }
        public string User_PC_Name { get; set; }
        public System.DateTime? Activation_Date { get; set; }
        public virtual Program_Establishment Program_Establishment { get; set; }
        public virtual Program_Status Program_Status { get; set; }
    }
}
