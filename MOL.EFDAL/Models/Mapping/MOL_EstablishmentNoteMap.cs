namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentNoteMap : EntityTypeConfiguration<MOL_EstablishmentNote>
    {
        public MOL_EstablishmentNoteMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EstablishmentNoteId);

            // Properties
            this.Property(t => t.NoteText)
                .HasMaxLength(2000);

            this.Property(t => t.InsertLaborerName)
                .HasMaxLength(50);

            this.Property(t => t.EndLaborerName)
                .HasMaxLength(50);

            this.Property(t => t.EndReason)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentNote");
            this.Property(t => t.PK_EstablishmentNoteId).HasColumnName("PK_EstablishmentNoteId");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.FK_NoteTypeId).HasColumnName("FK_NoteTypeId");
            this.Property(t => t.NoteNumber).HasColumnName("NoteNumber");
            this.Property(t => t.FK_NoteSourceId).HasColumnName("FK_NoteSourceId");
            this.Property(t => t.NoteText).HasColumnName("NoteText");
            this.Property(t => t.FK_NoteStatusId).HasColumnName("FK_NoteStatusId");
            this.Property(t => t.InsertDate).HasColumnName("InsertDate");
            this.Property(t => t.InsertLaborerName).HasColumnName("InsertLaborerName");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.EndLaborerName).HasColumnName("EndLaborerName");
            this.Property(t => t.EndReason).HasColumnName("EndReason");
            this.Property(t => t.FK_NoteApplicabilityId).HasColumnName("FK_NoteApplicabilityId");

            // Relationships
            this.HasOptional(t => t.Enum_NoteApplicability)
                .WithMany(t => t.MOL_EstablishmentNote)
                .HasForeignKey(d => d.FK_NoteApplicabilityId);
            this.HasRequired(t => t.Enum_NoteSource)
                .WithMany(t => t.MOL_EstablishmentNote)
                .HasForeignKey(d => d.FK_NoteSourceId);
            this.HasRequired(t => t.Enum_NoteStatus)
                .WithMany(t => t.MOL_EstablishmentNote)
                .HasForeignKey(d => d.FK_NoteStatusId);
            this.HasOptional(t => t.Enum_NoteType)
                .WithMany(t => t.MOL_EstablishmentNote)
                .HasForeignKey(d => d.FK_NoteTypeId);
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_EstablishmentNote)
                .HasForeignKey(d => d.FK_EstablishmentId);

        }
    }
}
