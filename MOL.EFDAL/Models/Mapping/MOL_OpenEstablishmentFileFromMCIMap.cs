
namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    public class MOL_OpenEstablishmentFileFromMCIMap : EntityTypeConfiguration<MOL_OpenEstablishmentFileFromMCI>
    {
        public MOL_OpenEstablishmentFileFromMCIMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Result)
                .HasMaxLength(50);
            this.Property(t => t.MCI_Body)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_OpenEstablishmentFileFromMCI");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FK_EstablishmentID).HasColumnName("FK_EstablishmentID");
            this.Property(t => t.ReferenceNumber).HasColumnName("ReferenceNumber");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.Result).HasColumnName("Result");
            this.Property(t => t.MCI_Body).HasColumnName("MCI_Body");
            this.Property(t => t.MCI_Status).HasColumnName("MCI_Status");

            // Relationships
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_OpenEstablishmentFileFromMCI)
                .HasForeignKey(t => t.FK_EstablishmentID);
        }
    }
}
