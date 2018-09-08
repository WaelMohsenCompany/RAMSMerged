namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class ManpowerMenuMap : EntityTypeConfiguration<ManpowerMenu>
    {
        public ManpowerMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.URL)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("ManpowerMenu", "ManpowerMenu");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Order).HasColumnName("Order");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.MOL_Sec_Privilege)
                .WithOptional(t => t.ManpowerMenu);

        }
    }
}
