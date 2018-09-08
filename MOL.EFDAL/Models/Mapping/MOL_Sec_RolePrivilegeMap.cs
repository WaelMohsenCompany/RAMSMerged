namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Sec_RolePrivilegeMap : EntityTypeConfiguration<MOL_Sec_RolePrivilege>
    {
        public MOL_Sec_RolePrivilegeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_Sec_RolePrivilege");
            this.Property(t => t.Role_Id).HasColumnName("Role_Id");
            this.Property(t => t.Privilege_Id).HasColumnName("Privilege_Id");
            this.Property(t => t.Id).HasColumnName("Id");

            // Relationships
            this.HasRequired(t => t.MOL_Sec_Privilege)
                .WithMany(t => t.MOL_Sec_RolePrivilege)
                .HasForeignKey(d => d.Privilege_Id);
            this.HasRequired(t => t.MOL_Sec_Role)
                .WithMany(t => t.MOL_Sec_RolePrivilege)
                .HasForeignKey(d => d.Role_Id);

        }
    }
}
