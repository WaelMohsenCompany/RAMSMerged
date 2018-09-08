namespace MOL.EFDAL.Models
{
    public partial class UnifiedNumber_NitaqatActivity_Establishment
    {
        public long Establishment_Id { get; set; }
        public long Pk_EstablishmentId { get; set; }
        public int Fk_laborofficeId { get; set; }
        public long SequenceNumber { get; set; }
        public long Fk_UnifiedNumberId { get; set; }
        public int? FK_SubEconomicActivityId { get; set; }
        public int EconomicActivityId { get; set; }
    }
}
