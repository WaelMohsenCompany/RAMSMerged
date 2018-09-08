namespace MOL.EFDAL.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class Mol_VwLaborersHasUnusedWPMap : EntityTypeConfiguration<Mol_VwLaborersHasUnusedWP>
    {
        public Mol_VwLaborersHasUnusedWPMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PK_LaborerId, t.FK_LaborOfficeId, t.FK_SaudiFlagId, t.SequenceNumber, t.StartDate, t.ExpirationDate });

            // Properties
            this.Property(t => t.PK_LaborerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FK_LaborOfficeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FK_SaudiFlagId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SequenceNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdNo)
                .HasMaxLength(15);

            this.Property(t => t.BorderNo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Mol_VwLaborersHasUnusedWP");
            this.Property(t => t.PK_LaborerId).HasColumnName("PK_LaborerId");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.FK_SaudiFlagId).HasColumnName("FK_SaudiFlagId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.IdNo).HasColumnName("IdNo");
            this.Property(t => t.BorderNo).HasColumnName("BorderNo");
            this.Property(t => t.LastWPExpirationDate).HasColumnName("LastWPExpirationDate");
            this.Property(t => t.KingdomEntryDate).HasColumnName("KingdomEntryDate");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.ExpirationDate).HasColumnName("ExpirationDate");
        }
    }
}
