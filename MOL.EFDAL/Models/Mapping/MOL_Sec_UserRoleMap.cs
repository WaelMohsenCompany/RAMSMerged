namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Sec_UserRoleMap : EntityTypeConfiguration<MOL_Sec_UserRole>
    {
        public MOL_Sec_UserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // IAuditable
            this.Ignore(t => t.CurrentUserID);
            this.Ignore(t => t.DBTableName);

            // Properties

            // Table & Column Mappings
            this.ToTable("MOL_Sec_UserRole");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.Role_Id).HasColumnName("Role_Id");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IDNO).HasColumnName("IDNO");
            this.Property(t => t.IsStopRole).HasColumnName("IsStopRole");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.FK_SecurableEntityId).HasColumnName("FK_SecurableEntityId");

            // Relationships
            this.HasRequired(t => t.MOL_Sec_Role)
                .WithMany(t => t.MOL_Sec_UserRole)
                .HasForeignKey(d => d.Role_Id);
            this.HasOptional(t => t.MOL_Sec_SecurableEntity)
                .WithMany(t => t.MOL_Sec_UserRole)
                .HasForeignKey(d => d.FK_SecurableEntityId);
            this.HasOptional(t => t.MOL_User)
                .WithMany(t => t.MOL_Sec_UserRole)
                .HasForeignKey(d => d.User_Id);

        }
    }
}
