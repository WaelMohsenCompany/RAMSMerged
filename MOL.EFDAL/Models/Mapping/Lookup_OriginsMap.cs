namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_OriginsMap : EntityTypeConfiguration<Lookup_Origins>
    {
        public Lookup_OriginsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Lookup_Origins");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.IsIncludedForEWV).HasColumnName("IsIncludedForEWV");
            this.Property(t => t.FK_NationalityId).HasColumnName("FK_NationalityId");

            // Relationships
            this.HasOptional(t => t.Lookup_Nationality)
                .WithMany(t => t.Lookup_Origins)
                .HasForeignKey(d => d.FK_NationalityId);

        }
    }
}
