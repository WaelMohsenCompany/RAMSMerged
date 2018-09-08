namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class OpenId_UserMap : EntityTypeConfiguration<OpenId_User>
    {
        public OpenId_UserMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.OpenIDClaimedIdentifier });

            // Properties
            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OpenIDClaimedIdentifier)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.OpenIDFriendlyIdentifier)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("OpenId_User");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.OpenIDClaimedIdentifier).HasColumnName("OpenIDClaimedIdentifier");
            this.Property(t => t.OpenIDFriendlyIdentifier).HasColumnName("OpenIDFriendlyIdentifier");
        }
    }
}
