namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class ManpowerMenu_Groups_EntityTypesMap : EntityTypeConfiguration<ManpowerMenu_Groups_EntityTypes>
    {
        public ManpowerMenu_Groups_EntityTypesMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ManpowerMenu_Groups_EntityTypes", "ManpowerMenu");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ManpowerGroupID).HasColumnName("ManpowerGroupID");
            this.Property(t => t.SecurableEntityTypeID).HasColumnName("SecurableEntityTypeID");
            this.Property(t => t.Order).HasColumnName("Order");

            // Relationships
            this.HasRequired(t => t.Lookup_SecurableEntityType)
                .WithMany(t => t.ManpowerMenu_Groups_EntityTypes)
                .HasForeignKey(d => d.SecurableEntityTypeID);
            this.HasRequired(t => t.ManpowerMenu_Groups)
                .WithMany(t => t.ManpowerMenu_Groups_EntityTypes)
                .HasForeignKey(d => d.ManpowerGroupID);

        }
    }
}
