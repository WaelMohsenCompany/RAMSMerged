namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentSaudiCertificateMap : EntityTypeConfiguration<MOL_EstablishmentSaudiCertificate>
    {
        public MOL_EstablishmentSaudiCertificateMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_SaudiCertificateId);

            // Properties
            this.Property(t => t.CertificateNumber)
                .HasMaxLength(14);

            this.Property(t => t.EstablishmentName)
                .HasMaxLength(60);

            this.Property(t => t.CommercialRecordNumber)
                .HasMaxLength(12);

            this.Property(t => t.CommercialRecordSource)
                .HasMaxLength(50);

            this.Property(t => t.Purpose_Others)
                .HasMaxLength(200);

            this.Property(t => t.EstablishmentState)
                .HasMaxLength(200);

            this.Property(t => t.EstablishmentColor)
                .HasMaxLength(50);

            this.Property(t => t.ProjectName)
                .HasMaxLength(200);

            this.Property(t => t.FK_LaborOfficeId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentSaudiCertificate");
            this.Property(t => t.PK_SaudiCertificateId).HasColumnName("PK_SaudiCertificateId");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.DateOfIssue).HasColumnName("DateOfIssue");
            this.Property(t => t.DateOfExpiry).HasColumnName("DateOfExpiry");
            this.Property(t => t.CertificateNumber).HasColumnName("CertificateNumber");
            this.Property(t => t.FK_DirectedToId).HasColumnName("FK_DirectedToId");
            this.Property(t => t.EstablishmentName).HasColumnName("EstablishmentName");
            this.Property(t => t.CommercialRecordNumber).HasColumnName("CommercialRecordNumber");
            this.Property(t => t.CommercialRecordSource).HasColumnName("CommercialRecordSource");
            this.Property(t => t.FK_PurposeId).HasColumnName("FK_PurposeId");
            this.Property(t => t.Purpose_Others).HasColumnName("Purpose_Others");
            this.Property(t => t.EstablishmentState).HasColumnName("EstablishmentState");
            this.Property(t => t.EstablishmentColor).HasColumnName("EstablishmentColor");
            this.Property(t => t.FK_CertificateApprovalStatusId).HasColumnName("FK_CertificateApprovalStatusId");
            this.Property(t => t.ProjectName).HasColumnName("ProjectName");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");

            // Relationships
            this.HasOptional(t => t.Enum_SaudiCertificateApprovalStatus)
                .WithMany(t => t.MOL_EstablishmentSaudiCertificate)
                .HasForeignKey(d => d.FK_CertificateApprovalStatusId);
            this.HasOptional(t => t.Lookup_SaudiCertificateDirectedTo)
                .WithMany(t => t.MOL_EstablishmentSaudiCertificate)
                .HasForeignKey(d => d.FK_DirectedToId);
            this.HasOptional(t => t.Lookup_SaudiCertificatePurpose)
                .WithMany(t => t.MOL_EstablishmentSaudiCertificate)
                .HasForeignKey(d => d.FK_PurposeId);

        }
    }
}
