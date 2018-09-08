namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_OpenId_ConsumerMap : EntityTypeConfiguration<Lookup_OpenId_Consumer>
    {
        public Lookup_OpenId_ConsumerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ConsumerKey, t.Secret, t.ConsumerId, t.VerificationCodeFormat });

            // Properties
            this.Property(t => t.ConsumerKey)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Secret)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Callback)
                .HasMaxLength(200);

            this.Property(t => t.ConsumerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.VerificationCodeFormat)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.VerificationCodeLength)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Lookup_OpenId_Consumer");
            this.Property(t => t.ConsumerKey).HasColumnName("ConsumerKey");
            this.Property(t => t.Secret).HasColumnName("Secret");
            this.Property(t => t.Callback).HasColumnName("Callback");
            this.Property(t => t.ConsumerId).HasColumnName("ConsumerId");
            this.Property(t => t.VerificationCodeFormat).HasColumnName("VerificationCodeFormat");
            this.Property(t => t.VerificationCodeLength).HasColumnName("VerificationCodeLength");
        }
    }
}
