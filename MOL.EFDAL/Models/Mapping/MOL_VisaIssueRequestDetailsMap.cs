namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VisaIssueRequestDetailsMap : EntityTypeConfiguration<MOL_VisaIssueRequestDetails>
    {
        public MOL_VisaIssueRequestDetailsMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_VisaIssueRequestDetailID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_VisaIssueRequestDetails");
            this.Property(t => t.PK_VisaIssueRequestDetailID).HasColumnName("PK_VisaIssueRequestDetailID");
            this.Property(t => t.FK_VisaIssueRequestID).HasColumnName("FK_VisaIssueRequestID");
            this.Property(t => t.Fk_JobID).HasColumnName("Fk_JobID");
            this.Property(t => t.FK_NationalityID).HasColumnName("FK_NationalityID");
            this.Property(t => t.FK_OriginID).HasColumnName("FK_OriginID");
            this.Property(t => t.FK_ReligionID).HasColumnName("FK_ReligionID");
            this.Property(t => t.FK_GenderID).HasColumnName("FK_GenderID");
            this.Property(t => t.LaborRequestCount).HasColumnName("LaborRequestCount");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");

            // Relationships
            this.HasRequired(t => t.MOL_VisaIssueRequests)
                .WithMany(t => t.MOL_VisaIssueRequestDetails)
                .HasForeignKey(d => d.FK_VisaIssueRequestID);

        }
    }
}
