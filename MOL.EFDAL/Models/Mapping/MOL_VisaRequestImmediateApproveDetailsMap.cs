namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VisaRequestImmediateApproveDetailsMap : EntityTypeConfiguration<MOL_VisaRequestImmediateApproveDetails>
    {
        public MOL_VisaRequestImmediateApproveDetailsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_VisaRequestImmediateApproveDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FK_VisaRequestID).HasColumnName("FK_VisaRequestID");
            this.Property(t => t.HasNoActiveNote).HasColumnName("HasNoActiveNote");
            this.Property(t => t.HasNoFemaleJob).HasColumnName("HasNoFemaleJob");
            this.Property(t => t.HasNoGovSupportJob).HasColumnName("HasNoGovSupportJob");
            this.Property(t => t.HasValidEstNitaq).HasColumnName("HasValidEstNitaq");
            this.Property(t => t.EstablishmentColorID).HasColumnName("EstablishmentColorID");
            this.Property(t => t.RequestedVISAsCount).HasColumnName("RequestedVISAsCount");
            this.Property(t => t.AllowedNitaqLimit).HasColumnName("AllowedNitaqLimit");
            this.Property(t => t.UnusedVISACredit).HasColumnName("UnusedVISACredit");
            this.Property(t => t.MinimumForeigners).HasColumnName("MinimumForeigners");
            this.Property(t => t.AutoApprovalQuota).HasColumnName("AutoApprovalQuota");
            this.Property(t => t.ExistsInNitaqatHistoryDB).HasColumnName("ExistsInNitaqatHistoryDB");
            this.Property(t => t.WithinAllowedRunawayRequestPecentage).HasColumnName("WithinAllowedRunawayRequestPecentage");
            this.Property(t => t.RunawayRequests).HasColumnName("RunawayRequests");
            this.Property(t => t.ForeignersLaborersCount).HasColumnName("ForeignersLaborersCount");
            this.Property(t => t.RunawayRequestsPercentage).HasColumnName("RunawayRequestsPercentage");
            this.Property(t => t.AllowedRunawayRequestsPercentage).HasColumnName("AllowedRunawayRequestsPercentage");
            this.Property(t => t.WithinAllowedTransferedNewComersPecentage).HasColumnName("WithinAllowedTransferedNewComersPecentage");
            this.Property(t => t.NewComersCount).HasColumnName("NewComersCount");
            this.Property(t => t.TransferedNewComersCount).HasColumnName("TransferedNewComersCount");
            this.Property(t => t.TransferedNewComersPercentage).HasColumnName("TransferedNewComersPercentage");
            this.Property(t => t.AllowedTransferedNewComersPercentage).HasColumnName("AllowedTransferedNewComersPercentage");
            this.Property(t => t.EconomicActivityAllowed).HasColumnName("EconomicActivityAllowed");
        }
    }
}
