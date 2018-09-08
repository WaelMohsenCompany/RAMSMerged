
namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    public class MOL_EstablishmentMCIActivitiesMap : EntityTypeConfiguration<MOL_EstablishmentMCIActivities>
    {
        public MOL_EstablishmentMCIActivitiesMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentMCIActivities");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FK_EstablishmentID).HasColumnName("FK_EstablishmentID");
            this.Property(t => t.ISEC_Code).HasColumnName("ISEC_Code");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_EstablishmentMCIActivities)
                .HasForeignKey(t => t.FK_EstablishmentID);
        }
    }
}
