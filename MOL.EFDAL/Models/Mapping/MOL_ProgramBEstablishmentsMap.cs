namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_ProgramBEstablishmentsMap : EntityTypeConfiguration<MOL_ProgramBEstablishments>
    {
        public MOL_ProgramBEstablishmentsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_ProgramBEstablishments");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.EstablishmentID).HasColumnName("EstablishmentID");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasOptional(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_ProgramBEstablishments)
                .HasForeignKey(d => d.EstablishmentID);

        }
    }
}
