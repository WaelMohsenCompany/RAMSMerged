namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class Enum_ServiceMap : EntityTypeConfiguration<Enum_Service>
    {
        public Enum_ServiceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Enum_Service");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AuthorizationLevel).HasColumnName("AuthorizationLevel");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsWASALRequired).HasColumnName("IsWASALRequired");
            this.Property(t => t.IsGosiStoppedService).HasColumnName("IsGosiStoppedService");
            this.Property(t => t.FK_ServiceCategoryId).HasColumnName("FK_ServiceCategoryId");
            this.Property(t => t.ValidateLicensesMatrix).HasColumnName("ValidateLicensesMatrix");
            
            
            // Relationships
            this.HasMany(t => t.MOL_Sec_Privilege)
                .WithMany(t => t.Enum_Service)
                .Map(m =>
                    {
                        m.ToTable("MOL_Sec_ServiceRequiredPrivilege");
                        m.MapLeftKey("FK_ServiceId");
                        m.MapRightKey("FK_PrivilegeId");
                    });
        }
    }
}
