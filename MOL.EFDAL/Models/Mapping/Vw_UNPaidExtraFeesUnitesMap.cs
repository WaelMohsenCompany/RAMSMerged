namespace MOL.EFDAL.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class Vw_UNPaidExtraFeesUnitesMap : EntityTypeConfiguration<Vw_UNPaidExtraFeesUnites>
    {
        public Vw_UNPaidExtraFeesUnitesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.FK_LaborOfficeId, t.SequenceNumber });

            // Properties
            this.Property(t => t.FK_LaborOfficeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SequenceNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Vw_UNPaidExtraFeesUnites");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.PaidExtraFeesUnites).HasColumnName("PaidExtraFeesUnites");
        }
    }
}
