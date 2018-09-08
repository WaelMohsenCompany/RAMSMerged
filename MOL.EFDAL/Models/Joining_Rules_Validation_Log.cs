namespace MOL.EFDAL.Models
{
    public partial class Joining_Rules_Validation_Log
    {
        public int Id { get; set; }
        public long? Establishment_Id { get; set; }
        public string Requester_IdNo { get; set; }
        public int? Rule_Id { get; set; }
        public System.DateTime? Created_On { get; set; }
        public virtual Joining_Rule Joining_Rule { get; set; }
    }
}
