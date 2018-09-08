namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_FakeEmploymentReportCommentsMap : EntityTypeConfiguration<MOL_FakeEmploymentReportComments>
    {
        public MOL_FakeEmploymentReportCommentsMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_CommentId);

            // Properties
            this.Property(t => t.FK_CreatedUserId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_FakeEmploymentReportComments");
            this.Property(t => t.PK_CommentId).HasColumnName("PK_CommentId");
            this.Property(t => t.FK_CommentOwner).HasColumnName("FK_CommentOwner");
            this.Property(t => t.FK_CreatedUserId).HasColumnName("FK_CreatedUserId");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.ModificationDate).HasColumnName("ModificationDate");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.FK_FakeEmploymentReportId).HasColumnName("FK_FakeEmploymentReportId");
            this.Property(t => t.fk_FakeEmploymentReportStatusId).HasColumnName("fk_FakeEmploymentReportStatusId");

            // Relationships
            this.HasRequired(t => t.MOL_FakeEmploymentReport)
                .WithMany(t => t.MOL_FakeEmploymentReportComments)
                .HasForeignKey(d => d.FK_FakeEmploymentReportId);
            this.HasRequired(t => t.MOL_FakeEmploymentReportCommentOwner)
                .WithMany(t => t.MOL_FakeEmploymentReportComments)
                .HasForeignKey(d => d.FK_CommentOwner);
            this.HasOptional(t => t.MOL_FakeEmploymentReportStatus)
                .WithMany(t => t.MOL_FakeEmploymentReportComments)
                .HasForeignKey(d => d.fk_FakeEmploymentReportStatusId);

        }
    }
}
