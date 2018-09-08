namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VwUserEstablishmentsNotesMap : EntityTypeConfiguration<MOL_VwUserEstablishmentsNotes>
    {
        public MOL_VwUserEstablishmentsNotesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.NoteSource, t.EstablishmentName, t.PK_EstablishmentNoteId, t.EstablishmentId });

            // Properties
            this.Property(t => t.NoteSource)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.EstablishmentName)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.PK_EstablishmentNoteId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EstablishmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MOL_VwUserEstablishmentsNotes");
            this.Property(t => t.FK_UserId).HasColumnName("FK_UserId");
            this.Property(t => t.NoteNumber).HasColumnName("NoteNumber");
            this.Property(t => t.NoteSource).HasColumnName("NoteSource");
            this.Property(t => t.InsertDate).HasColumnName("InsertDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.EstablishmentName).HasColumnName("EstablishmentName");
            this.Property(t => t.PK_EstablishmentNoteId).HasColumnName("PK_EstablishmentNoteId");
            this.Property(t => t.EstablishmentId).HasColumnName("EstablishmentId");
        }
    }
}
