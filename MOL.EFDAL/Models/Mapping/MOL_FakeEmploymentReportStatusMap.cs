namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_FakeEmploymentReportStatusMap : EntityTypeConfiguration<MOL_FakeEmploymentReportStatus>
    {
        public MOL_FakeEmploymentReportStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_FakeEmploymentReportStatusId);

            // Properties
            this.Property(t => t.PK_FakeEmploymentReportStatusId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StatusDescription)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_FakeEmploymentReportStatus");
            this.Property(t => t.PK_FakeEmploymentReportStatusId).HasColumnName("PK_FakeEmploymentReportStatusId");
            this.Property(t => t.StatusDescription).HasColumnName("StatusDescription");
        }
    }
}
