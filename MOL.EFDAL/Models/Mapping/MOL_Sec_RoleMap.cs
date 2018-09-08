namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Sec_RoleMap : EntityTypeConfiguration<MOL_Sec_Role>
    {
        public MOL_Sec_RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(200);

            this.Property(t => t.Local_Name)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("MOL_Sec_Role");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Local_Name).HasColumnName("Local_Name");
            this.Property(t => t.GroupID).HasColumnName("GroupID");
            this.Property(t => t.IsSystem).HasColumnName("IsSystem");

            // Relationships
            this.HasOptional(t => t.MOL_Sec_Group)
                .WithMany(t => t.MOL_Sec_Role)
                .HasForeignKey(d => d.GroupID);

        }
    }
}
