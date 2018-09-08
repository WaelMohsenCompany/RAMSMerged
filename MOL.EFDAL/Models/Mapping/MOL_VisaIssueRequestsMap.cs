namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VisaIssueRequestsMap : EntityTypeConfiguration<MOL_VisaIssueRequests>
    {
        public MOL_VisaIssueRequestsMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_VisaIssueRequestID);

            // Properties
            this.Property(t => t.NICOutgoingNumber)
                .HasMaxLength(20);

            this.Property(t => t.RequestedByIDNo)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("MOL_VisaIssueRequests");
            this.Property(t => t.PK_VisaIssueRequestID).HasColumnName("PK_VisaIssueRequestID");
            this.Property(t => t.FK_EstablishmentID).HasColumnName("FK_EstablishmentID");
            this.Property(t => t.FK_LaborOfficeID).HasColumnName("FK_LaborOfficeID");
            this.Property(t => t.RequestYear).HasColumnName("RequestYear");
            this.Property(t => t.Sequence).HasColumnName("Sequence");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.RequestType).HasColumnName("RequestType");
            this.Property(t => t.FK_VisaRequestID).HasColumnName("FK_VisaRequestID");
            this.Property(t => t.NICStatus).HasColumnName("NICStatus");
            this.Property(t => t.NICOutgoingNumber).HasColumnName("NICOutgoingNumber");
            this.Property(t => t.NICOutgoingDate).HasColumnName("NICOutgoingDate");
            this.Property(t => t.CreatedByUserID).HasColumnName("CreatedByUserIdNumber");
            this.Property(t => t.RequestedByIDNo).HasColumnName("RequestedByIDNo");
            this.Property(t => t.CurrentQuota).HasColumnName("CurrentQuota");
            this.Property(t => t.CurrentNitaq).HasColumnName("CurrentNitaq");
            this.Property(t => t.TotalLaborRequest).HasColumnName("TotalLaborRequest");
            this.Property(t => t.CurrentVisaRequestBalance).HasColumnName("CurrentVisaRequestBalance");
            this.Property(t => t.NICRejectReasonID).HasColumnName("NICRejectReasonID");
            this.Property(t => t.FK_ExceptionID).HasColumnName("FK_ExceptionID");
        }
    }
}
