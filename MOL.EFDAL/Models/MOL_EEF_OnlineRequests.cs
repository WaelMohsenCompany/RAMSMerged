namespace MOL.EFDAL.Models
{
    public partial class MOL_EEF_OnlineRequests
    {
        public int ID { get; set; }
        public long FK_UserId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public long FK_EstablishmentID { get; set; }
        public bool IsManPower { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
        public virtual MOL_Establishment MOL_Establishment { get; set; }
        public virtual MOL_User MOL_User { get; set; }
    }
}
