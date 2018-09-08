namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VisaActivityPeriodMap : EntityTypeConfiguration<MOL_VisaActivityPeriod>
    {
        public MOL_VisaActivityPeriodMap()
        {
            // Primary Key
            this.HasKey(t => t.ActivityID);

            // Properties
            this.Property(t => t.ActivityID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MOL_VisaActivityPeriod");
            this.Property(t => t.ActivityID).HasColumnName("ActivityID");
            this.Property(t => t.ValidityPeriodDays).HasColumnName("ValidityPeriodDays");
            this.Property(t => t.ApprovedRequestWaitingPeriod).HasColumnName("ApprovedRequestWaitingPeriod");
            this.Property(t => t.CanceledRequestWaitingPeriod).HasColumnName("CanceledRequestWaitingPeriod");
            this.Property(t => t.RejectedRequestWaitingPeriod).HasColumnName("RejectedRequestWaitingPeriod");
            this.Property(t => t.AutomaticRejectWaitingPeriod).HasColumnName("AutomaticRejectWaitingPeriod");
        }
    }
}
