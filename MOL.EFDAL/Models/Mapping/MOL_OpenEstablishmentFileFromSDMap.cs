
namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    public class MOL_OpenEstablishmentFileFromSDMap : EntityTypeConfiguration<MOL_OpenEstablishmentFileFromSD>
    {
        public MOL_OpenEstablishmentFileFromSDMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Result)
                .HasMaxLength(50);
            this.Property(t => t.Body)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_OpenEstablishmentFileFromSD");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FK_EstablishmentID).HasColumnName("FK_EstablishmentID");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.Result).HasColumnName("Result");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.RequesterIdNo).HasColumnName("RequesterIdNo");
            this.Property(t => t.RepresentativeIdNo).HasColumnName("RepresentativeIdNo");

            // Relationships
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_OpenEstablishmentFileFromSD)
                .HasForeignKey(t => t.FK_EstablishmentID);
        }
    }
}
