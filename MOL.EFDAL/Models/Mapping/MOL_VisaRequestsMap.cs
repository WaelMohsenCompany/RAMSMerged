namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VisaRequestsMap : EntityTypeConfiguration<MOL_VisaRequests>
    {
        public MOL_VisaRequestsMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_VisaRequestID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_VisaRequests");
            this.Property(t => t.PK_VisaRequestID).HasColumnName("PK_VisaRequestID");
            this.Property(t => t.FK_EstablishmentID).HasColumnName("FK_EstablishmentID");
            this.Property(t => t.FK_LaborOfficeID).HasColumnName("FK_LaborOfficeID");
            this.Property(t => t.RequestYear).HasColumnName("RequestYear");
            this.Property(t => t.Sequence).HasColumnName("Sequence");
            this.Property(t => t.LastStatus).HasColumnName("LastStatus");
            this.Property(t => t.ExpiryDate).HasColumnName("ExpiryDate");
            this.Property(t => t.ValidityMonths).HasColumnName("ValidityMonths");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");
            this.Property(t => t.RequestedVisaTotal).HasColumnName("RequestedVisaTotal");
            this.Property(t => t.ApprovedVisaTotal).HasColumnName("ApprovedVisaTotal");
            this.Property(t => t.RequestType).HasColumnName("RequestType");
            this.Property(t => t.LockedByUserID).HasColumnName("LockedByUserID");
            this.Property(t => t.LockTime).HasColumnName("LockTime");
            this.Property(t => t.DecisionFlag).HasColumnName("DecisionFlag");
            this.Property(t => t.DecisionDate).HasColumnName("DecisionDate");
            this.Property(t => t.ReservedVisaTotal).HasColumnName("ReservedVisaTotal");
            this.Property(t => t.IssuedVisaTotal).HasColumnName("IssuedVisaTotal");
            this.Property(t => t.AssingedToUserID).HasColumnName("AssingedToUserID");
            this.Property(t => t.AssingTime).HasColumnName("AssingTime");
            this.Property(t => t.ReturnToEstCount).HasColumnName("ReturnToEstCount");
            this.Property(t => t.isImmediateCredit).HasColumnName("isImmediateCredit");
        }
    }
}
