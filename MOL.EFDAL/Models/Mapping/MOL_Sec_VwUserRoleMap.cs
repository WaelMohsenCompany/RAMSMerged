namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Sec_VwUserRoleMap : EntityTypeConfiguration<MOL_Sec_VwUserRole>
    {
        public MOL_Sec_VwUserRoleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.MOL_Sec_Role_Id, t.UserRole_User_Id, t.UserRole_Role_Id });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .HasMaxLength(255);

            this.Property(t => t.First_Name)
                .HasMaxLength(50);

            this.Property(t => t.Second_Name)
                .HasMaxLength(50);

            this.Property(t => t.Third_Name)
                .HasMaxLength(50);

            this.Property(t => t.Fourth_Name)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.MOL_Sec_Role_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RoleName)
                .HasMaxLength(200);

            this.Property(t => t.Local_Name)
                .HasMaxLength(200);

            this.Property(t => t.UserRole_User_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserRole_Role_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MOL_Sec_VwUserRole");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.First_Name).HasColumnName("First_Name");
            this.Property(t => t.Second_Name).HasColumnName("Second_Name");
            this.Property(t => t.Third_Name).HasColumnName("Third_Name");
            this.Property(t => t.Fourth_Name).HasColumnName("Fourth_Name");
            this.Property(t => t.Nationality).HasColumnName("Nationality");
            this.Property(t => t.Birth_Date).HasColumnName("Birth_Date");
            this.Property(t => t.User_Type_Id).HasColumnName("User_Type_Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.LastLoggedIn).HasColumnName("LastLoggedIn");
            this.Property(t => t.MOL_Sec_Role_Id).HasColumnName("MOL_Sec_Role_Id");
            this.Property(t => t.RoleName).HasColumnName("RoleName");
            this.Property(t => t.Local_Name).HasColumnName("Local_Name");
            this.Property(t => t.UserRole_User_Id).HasColumnName("UserRole_User_Id");
            this.Property(t => t.UserRole_Role_Id).HasColumnName("UserRole_Role_Id");
        }
    }
}
