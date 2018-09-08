namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_ZoneMap : EntityTypeConfiguration<Lookup_Zone>
    {
        public Lookup_ZoneMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Lookup_Zone");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
        }
    }
}
