namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_CEAReferenceSequenceMap : EntityTypeConfiguration<MOL_CEAReferenceSequence>
    {
        public MOL_CEAReferenceSequenceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Year, t.Month, t.Sequence });

            // Properties
            this.Property(t => t.Year)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Month)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Sequence)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MOL_CEAReferenceSequence");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Month).HasColumnName("Month");
            this.Property(t => t.Sequence).HasColumnName("Sequence");
        }
    }
}
