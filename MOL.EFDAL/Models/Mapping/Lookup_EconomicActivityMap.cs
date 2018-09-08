namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_EconomicActivityMap : EntityTypeConfiguration<Lookup_EconomicActivity>
    {
        public Lookup_EconomicActivityMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EconomicActivityId);

            // Properties
            this.Property(t => t.PK_EconomicActivityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ActivityName)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Lookup_EconomicActivity");
            this.Property(t => t.PK_EconomicActivityId).HasColumnName("PK_EconomicActivityId");
            this.Property(t => t.ActivityName).HasColumnName("ActivityName");
            this.Property(t => t.FK_MainEconomicActivityId).HasColumnName("FK_MainEconomicActivityId");
            this.Property(t => t.SaudizationPercentage).HasColumnName("SaudizationPercentage");
            this.Property(t => t.IsSocialInsuranceLicenseFree).HasColumnName("IsSocialInsuranceLicenseFree");
            this.Property(t => t.IsZakatLicenseFree).HasColumnName("IsZakatLicenseFree");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsEligibleForIstiqdamImmediateApprove).HasColumnName("IsEligibleForIstiqdamImmediateApprove");

            //RAMS New Mapping
            this.Property(t => t.IsEligibleForRunAway).HasColumnName("IsEligibleForRunAway");

            // Relationships
            this.HasOptional(t => t.Lookup_EconomicActivity2)
                .WithMany(t => t.Lookup_EconomicActivity1)
                .HasForeignKey(d => d.FK_MainEconomicActivityId);

        }
    }
}
