using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    public class MOL_EstablishmentMCIPartiesMap : EntityTypeConfiguration<MOL_EstablishmentMCIParties>
    {
        public MOL_EstablishmentMCIPartiesMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.MciPartyID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentMCIParties", "dbo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.MciPartyID).HasColumnName("MciPartyID");
            this.Property(t => t.NationalityID).HasColumnName("NationalityID");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            
            // Relationships
            this.HasOptional(t => t.Nationality)
                .WithMany(t => t.MOL_EstablishmentMCIParties)
                .HasForeignKey(t => t.NationalityID);
            
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_EstablishmentMCIParties)
                .HasForeignKey(t => t.EstablishmentID);

        }
    }
}
