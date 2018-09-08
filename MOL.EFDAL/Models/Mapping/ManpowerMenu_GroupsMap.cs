namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class ManpowerMenu_GroupsMap : EntityTypeConfiguration<ManpowerMenu_Groups>
    {
        public ManpowerMenu_GroupsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ManpowerMenu_Groups", "ManpowerMenu");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Order).HasColumnName("Order");
            this.Property(t => t.SectionID).HasColumnName("SectionID");

            // Relationships
            this.HasOptional(t => t.ManpowerMenu_Sections)
                .WithMany(t => t.ManpowerMenu_Groups)
                .HasForeignKey(d => d.SectionID);

        }
    }
}
