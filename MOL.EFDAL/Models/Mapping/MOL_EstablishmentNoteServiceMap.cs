namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentNoteServiceMap : EntityTypeConfiguration<MOL_EstablishmentNoteService>
    {
        public MOL_EstablishmentNoteServiceMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EstablishmentNoteServiceId);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentNoteService");
            this.Property(t => t.PK_EstablishmentNoteServiceId).HasColumnName("PK_EstablishmentNoteServiceId");
            this.Property(t => t.FK_EstablishmentNoteId).HasColumnName("FK_EstablishmentNoteId");
            this.Property(t => t.FK_ServiceId).HasColumnName("FK_ServiceId");

            // Relationships
            this.HasRequired(t => t.Enum_Service)
                .WithMany(t => t.MOL_EstablishmentNoteService)
                .HasForeignKey(d => d.FK_ServiceId);

        }
    }
}
