namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Sec_UserEntityPrivilegeMap : EntityTypeConfiguration<MOL_Sec_UserEntityPrivilege>
    {
        public MOL_Sec_UserEntityPrivilegeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.User_ID, t.Privilege_Id, t.Securable_Entity_Id });

            // Properties
            this.Property(t => t.User_ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Privilege_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Securable_Entity_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MOL_Sec_UserEntityPrivilege");
            this.Property(t => t.User_ID).HasColumnName("User_ID");
            this.Property(t => t.Privilege_Id).HasColumnName("Privilege_Id");
            this.Property(t => t.Securable_Entity_Id).HasColumnName("Securable_Entity_Id");

            // Relationships
            this.HasRequired(t => t.MOL_Sec_Privilege)
                .WithMany(t => t.MOL_Sec_UserEntityPrivilege)
                .HasForeignKey(d => d.Privilege_Id);
            this.HasRequired(t => t.MOL_Sec_SecurableEntity)
                .WithMany(t => t.MOL_Sec_UserEntityPrivilege)
                .HasForeignKey(d => d.Securable_Entity_Id);
            this.HasRequired(t => t.MOL_User)
                .WithMany(t => t.MOL_Sec_UserEntityPrivilege)
                .HasForeignKey(d => d.User_ID);

        }
    }
}
