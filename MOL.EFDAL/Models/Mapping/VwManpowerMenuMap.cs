namespace MOL.EFDAL.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class VwManpowerMenuMap : EntityTypeConfiguration<VwManpowerMenu>
    {
        public VwManpowerMenuMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GroupID, t.GroupName, t.SecurableEntityTypeID, t.SecurableEntityTypeOrder, t.IsActive, t.PrivilegeID, t.PrivilegeOrder });

            // Properties
            this.Property(t => t.GroupID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GroupName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SecurableEntityTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SecurableEntityTypeName)
                .HasMaxLength(50);

            this.Property(t => t.SecurableEntityTypeOrder)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.URL)
                .HasMaxLength(300);

            this.Property(t => t.PrivilegeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PrivilegeName)
                .HasMaxLength(50);

            this.Property(t => t.PrivilegeOrder)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("VwManpowerMenu", "ManpowerMenu");
            this.Property(t => t.SectionID).HasColumnName("SectionID");
            this.Property(t => t.GroupID).HasColumnName("GroupID");
            this.Property(t => t.GroupName).HasColumnName("GroupName");
            this.Property(t => t.GroupOrder).HasColumnName("GroupOrder");
            this.Property(t => t.SecurableEntityTypeID).HasColumnName("SecurableEntityTypeID");
            this.Property(t => t.SecurableEntityTypeName).HasColumnName("SecurableEntityTypeName");
            this.Property(t => t.SecurableEntityTypeOrder).HasColumnName("SecurableEntityTypeOrder");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.PrivilegeID).HasColumnName("PrivilegeID");
            this.Property(t => t.PrivilegeName).HasColumnName("PrivilegeName");
            this.Property(t => t.PrivilegeOrder).HasColumnName("PrivilegeOrder");
        }
    }
}
