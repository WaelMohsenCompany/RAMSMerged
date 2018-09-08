namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_CEAUserServiceMap : EntityTypeConfiguration<MOL_CEAUserService>
    {
        public MOL_CEAUserServiceMap()
        {
            // Primary Key
            this.HasKey(t => t.Pk_CEAUserServiceId);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_CEAUserService");
            this.Property(t => t.Pk_CEAUserServiceId).HasColumnName("Pk_CEAUserServiceId");
            this.Property(t => t.Fk_UserId).HasColumnName("Fk_UserId");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.MOL_User)
                .WithMany(t => t.MOL_CEAUserService)
                .HasForeignKey(d => d.Fk_UserId);

        }
    }
}
