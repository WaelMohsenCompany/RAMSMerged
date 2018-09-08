namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_ZATNoteConfirmationLogMap : EntityTypeConfiguration<MOL_ZATNoteConfirmationLog>
    {
        public MOL_ZATNoteConfirmationLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties


            // Table & Column Mappings
            this.ToTable("MOL_ZATNoteConfirmationLog");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.InsertDate).HasColumnName("InsertDate");

            // Relationships
        }
    }
}
