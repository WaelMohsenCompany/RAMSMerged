namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_SaudiCertificateDirectedToMap : EntityTypeConfiguration<Lookup_SaudiCertificateDirectedTo>
    {
        public Lookup_SaudiCertificateDirectedToMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Lookup_SaudiCertificateDirectedTo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FK_SubDirectedTo).HasColumnName("FK_SubDirectedTo");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasOptional(t => t.Lookup_SaudiCertificateDirectedTo2)
                .WithMany(t => t.Lookup_SaudiCertificateDirectedTo1)
                .HasForeignKey(d => d.FK_SubDirectedTo);

        }
    }
}
