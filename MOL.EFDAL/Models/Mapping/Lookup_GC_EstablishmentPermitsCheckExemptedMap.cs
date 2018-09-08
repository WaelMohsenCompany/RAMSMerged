namespace MOL.EFDAL.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_GC_EstablishmentPermitsCheckExemptedMap : EntityTypeConfiguration<Lookup_GC_EstablishmentPermitsCheckExempted>
    {
        public Lookup_GC_EstablishmentPermitsCheckExemptedMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Lookup_GC_EstablishmentPermitsCheckExempted");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.EstablishmentID).HasColumnName("EstablishmentID");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");

            // Relationships
        }
    }
}
