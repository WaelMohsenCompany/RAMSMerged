namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VisaRequestDetailsMap : EntityTypeConfiguration<MOL_VisaRequestDetails>
    {
        public MOL_VisaRequestDetailsMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_VisaRequestDetailID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_VisaRequestDetails");
            this.Property(t => t.PK_VisaRequestDetailID).HasColumnName("PK_VisaRequestDetailID");
            this.Property(t => t.FK_VisaRequestID).HasColumnName("FK_VisaRequestID");
            this.Property(t => t.Fk_JobID).HasColumnName("Fk_JobID");
            this.Property(t => t.FK_GenderID).HasColumnName("FK_GenderID");
            this.Property(t => t.LaborRequestCount).HasColumnName("LaborRequestCount");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.ApprovedRequestCount).HasColumnName("ApprovedRequestCount");

            // Relationships
            this.HasRequired(t => t.MOL_VisaRequests)
                .WithMany(t => t.MOL_VisaRequestDetails)
                .HasForeignKey(d => d.FK_VisaRequestID);

        }
    }
}
