namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class OpenId_NonceMap : EntityTypeConfiguration<OpenId_Nonce>
    {
        public OpenId_NonceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Context, t.Code, t.Issued, t.Expires });

            // Properties
            this.Property(t => t.Context)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("OpenId_Nonce");
            this.Property(t => t.Context).HasColumnName("Context");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Issued).HasColumnName("Issued");
            this.Property(t => t.Expires).HasColumnName("Expires");
        }
    }
}
