namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Sec_PrivilegeMap : EntityTypeConfiguration<MOL_Sec_Privilege>
    {
        public MOL_Sec_PrivilegeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Local_Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_Sec_Privilege");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Local_Name).HasColumnName("Local_Name");
            this.Property(t => t.Securable_Entity_Type_Id).HasColumnName("Securable_Entity_Type_Id");
            this.Property(t => t.IsSystem).HasColumnName("IsSystem");
            this.Property(t => t.FK_PrivilegeLevelID).HasColumnName("FK_PrivilegeLevelID");

            // Relationships
            this.HasMany(t => t.MOL_User)
                .WithMany(t => t.MOL_Sec_Privilege)
                .Map(m =>
                    {
                        m.ToTable("MOL_Sec_UserTypePrivilege");
                        m.MapLeftKey("Privilege_Id");
                        m.MapRightKey("User_Id");
                    });

            this.HasOptional(t => t.Enum_PrivilegeLevel)
                .WithMany(t => t.MOL_Sec_Privilege)
                .HasForeignKey(d => d.FK_PrivilegeLevelID);
            this.HasOptional(t => t.Lookup_SecurableEntityType)
                .WithMany(t => t.MOL_Sec_Privilege)
                .HasForeignKey(d => d.Securable_Entity_Type_Id);

        }
    }
}
