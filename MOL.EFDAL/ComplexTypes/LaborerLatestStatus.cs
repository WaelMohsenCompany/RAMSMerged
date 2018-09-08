namespace MOL.EFDAL
{
    public partial class LaborerLatestStatus
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? FK_LaborerStatusId { get; set; }
        public long? FK_LastWPId { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public System.DateTime StartDate { get; set; }
        public string iqamaStatus { get; set; }
        public string WPStatus { get; set; }
    }
}