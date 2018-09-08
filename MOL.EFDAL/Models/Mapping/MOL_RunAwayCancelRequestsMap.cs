namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_RunAwayCancelRequestsMap : EntityTypeConfiguration<MOL_RunAwayCancelRequests>
    {
        public MOL_RunAwayCancelRequestsMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_RequestID);

            // Properties
            this.Property(t => t.RunAwayID)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.CurrentUserIDNo)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.Reject_Reason_Desc)
                .HasMaxLength(200);

            this.Property(t => t.NIC_ResultCode)
                .HasMaxLength(50);

            this.Property(t => t.NIC_ResultMessage)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("MOL_RunAwayCancelRequests");
            this.Property(t => t.PK_RequestID).HasColumnName("PK_RequestID");
            this.Property(t => t.CurrentUser_ID).HasColumnName("CurrentUser_ID");
            this.Property(t => t.RunAwayID).HasColumnName("RunAwayID");
            this.Property(t => t.CurrentUserIDNo).HasColumnName("CurrentUserIDNo");
            this.Property(t => t.Fk_EstablishmentID).HasColumnName("Fk_EstablishmentID");
            this.Property(t => t.ReqStatus).HasColumnName("ReqStatus");
            this.Property(t => t.Reject_Reason_Desc).HasColumnName("Reject_Reason_Desc");
            this.Property(t => t.NIC_ResultCode).HasColumnName("NIC_ResultCode");
            this.Property(t => t.NIC_ResultMessage).HasColumnName("NIC_ResultMessage");
            this.Property(t => t.RequestDate).HasColumnName("RequestDate");
            this.Property(t => t.DecisionTakenByUser_ID).HasColumnName("DecisionTakenByUser_ID");
        }
    }
}
