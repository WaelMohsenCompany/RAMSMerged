namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class OpenId_AssociationMap : EntityTypeConfiguration<OpenId_Association>
    {
        public OpenId_AssociationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DistinguishingFactor, t.Handle, t.Expires, t.PrivateData });

            // Properties
            this.Property(t => t.DistinguishingFactor)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Handle)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PrivateData)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("OpenId_Association");
            this.Property(t => t.DistinguishingFactor).HasColumnName("DistinguishingFactor");
            this.Property(t => t.Handle).HasColumnName("Handle");
            this.Property(t => t.Expires).HasColumnName("Expires");
            this.Property(t => t.PrivateData).HasColumnName("PrivateData");
        }
    }
}
