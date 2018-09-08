namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class VW_EstablishmentActivityCorrectionMap : EntityTypeConfiguration<VW_EstablishmentActivityCorrection>
    {
        public VW_EstablishmentActivityCorrectionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PK_EstablishmentActivityCorrection, t.Name, t.EconomicActivityText, t.ActivityName, t.PK_EstablishmentId });

            // Properties
            this.Property(t => t.PK_EstablishmentActivityCorrection)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.EconomicActivityText)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ActivityName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.AuthorizedIdNo)
                .HasMaxLength(15);

            this.Property(t => t.PK_EstablishmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("VW_EstablishmentActivityCorrection");
            this.Property(t => t.PK_EstablishmentActivityCorrection).HasColumnName("PK_EstablishmentActivityCorrection");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.EconomicActivityText).HasColumnName("EconomicActivityText");
            this.Property(t => t.FK_MainEconomicActivityId).HasColumnName("FK_MainEconomicActivityId");
            this.Property(t => t.FK_SubEconomicActivityId).HasColumnName("FK_SubEconomicActivityId");
            this.Property(t => t.ActivityName).HasColumnName("ActivityName");
            this.Property(t => t.OrgMainEconomicActivityId).HasColumnName("OrgMainEconomicActivityId");
            this.Property(t => t.OrgSubEconomicActivityId).HasColumnName("OrgSubEconomicActivityId");
            this.Property(t => t.AuthorizedIdNo).HasColumnName("AuthorizedIdNo");
            this.Property(t => t.ExpDate).HasColumnName("ExpDate");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.PK_EstablishmentId).HasColumnName("PK_EstablishmentId");
        }
    }
}
