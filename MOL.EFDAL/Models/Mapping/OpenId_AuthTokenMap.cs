namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class OpenId_AuthTokenMap : EntityTypeConfiguration<OpenId_AuthToken>
    {
        public OpenId_AuthTokenMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TokenId, t.Token, t.TokenSecret, t.ConsumerId, t.UserId, t.State, t.IssueDate });

            // Properties
            this.Property(t => t.TokenId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Token)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.TokenSecret)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ConsumerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.State)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RequestTokenVerifier)
                .HasMaxLength(100);

            this.Property(t => t.RequestTokenCallback)
                .HasMaxLength(100);

            this.Property(t => t.ConsumerVersion)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("OpenId_AuthToken");
            this.Property(t => t.TokenId).HasColumnName("TokenId");
            this.Property(t => t.Token).HasColumnName("Token");
            this.Property(t => t.TokenSecret).HasColumnName("TokenSecret");
            this.Property(t => t.ConsumerId).HasColumnName("ConsumerId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.IssueDate).HasColumnName("IssueDate");
            this.Property(t => t.Scope).HasColumnName("Scope");
            this.Property(t => t.RequestTokenVerifier).HasColumnName("RequestTokenVerifier");
            this.Property(t => t.RequestTokenCallback).HasColumnName("RequestTokenCallback");
            this.Property(t => t.ConsumerVersion).HasColumnName("ConsumerVersion");
        }
    }
}
