namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_FakeEmploymentReportMap : EntityTypeConfiguration<MOL_FakeEmploymentReport>
    {
        public MOL_FakeEmploymentReportMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_FakeEmploymentReportId);

            // Properties
            this.Property(t => t.MobileNumber)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.Email)
                .HasMaxLength(254);

            // Table & Column Mappings
            this.ToTable("MOL_FakeEmploymentReport");
            this.Property(t => t.PK_FakeEmploymentReportId).HasColumnName("PK_FakeEmploymentReportId");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.FakeEmploymentReportDate).HasColumnName("FakeEmploymentReportDate");
            this.Property(t => t.FK_FakeEmploymentReportStatusId).HasColumnName("FK_FakeEmploymentReportStatusId");
            this.Property(t => t.FK_LaborerId).HasColumnName("FK_LaborerId");
            this.Property(t => t.MobileNumber).HasColumnName("MobileNumber");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.ReportBody).HasColumnName("ReportBody");
            this.Property(t => t.Fk_LaborOfficeId).HasColumnName("Fk_LaborOfficeId");
            this.Property(t => t.HijriYear).HasColumnName("HijriYear");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");

            // Relationships
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_FakeEmploymentReport)
                .HasForeignKey(d => d.FK_EstablishmentId);
            this.HasRequired(t => t.MOL_FakeEmploymentReportStatus)
                .WithMany(t => t.MOL_FakeEmploymentReport)
                .HasForeignKey(d => d.FK_FakeEmploymentReportStatusId);
            this.HasRequired(t => t.MOL_Laborer)
                .WithMany(t => t.MOL_FakeEmploymentReport)
                .HasForeignKey(d => d.FK_LaborerId);

        }
    }
}
