namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Sec_UserRevokePrivilegeMap : EntityTypeConfiguration<MOL_Sec_UserRevokePrivilege>
    {
        public MOL_Sec_UserRevokePrivilegeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_Sec_UserRevokePrivilege");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdNo).HasColumnName("IdNo");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.Privilege_Id).HasColumnName("Privilege_Id");
            this.Property(t => t.FK_SecurableEntityId).HasColumnName("FK_SecurableEntityId");

            // Relationships
            this.HasRequired(t => t.MOL_Sec_Privilege)
                .WithMany(t => t.MOL_Sec_UserRevokePrivilege)
                .HasForeignKey(d => d.Privilege_Id);
            this.HasRequired(t => t.MOL_Sec_SecurableEntity)
                .WithMany(t => t.MOL_Sec_UserRevokePrivilege)
                .HasForeignKey(d => d.FK_SecurableEntityId);
            this.HasOptional(t => t.MOL_User)
                .WithMany(t => t.MOL_Sec_UserRevokePrivilege)
                .HasForeignKey(d => d.User_Id);

        }
    }
}
