namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Mol_EstablishmentActivityCorrectionMap : EntityTypeConfiguration<Mol_EstablishmentActivityCorrection>
    {
        public Mol_EstablishmentActivityCorrectionMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EstablishmentActivityCorrection);

            // Properties
            this.Property(t => t.FK_CreatedUserId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Mol_EstablishmentActivityCorrection");
            this.Property(t => t.PK_EstablishmentActivityCorrection).HasColumnName("PK_EstablishmentActivityCorrection");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.EconomicActivityText).HasColumnName("EconomicActivityText");
            this.Property(t => t.FK_MainEconomicActivityId).HasColumnName("FK_MainEconomicActivityId");
            this.Property(t => t.FK_SubEconomicActivityId).HasColumnName("FK_SubEconomicActivityId");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.ExpDate).HasColumnName("ExpDate");
            this.Property(t => t.FK_CreatedUserId).HasColumnName("FK_CreatedUserId");
            this.Property(t => t.ModificationDate).HasColumnName("ModificationDate");
        }
    }
}
