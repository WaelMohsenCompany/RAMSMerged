namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_WorkPermitMap : EntityTypeConfiguration<MOL_WorkPermit>
    {
        public MOL_WorkPermitMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_WPId);

            // Properties
            this.Property(t => t.FK_WP_ReasonId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_WorkPermit");
            this.Property(t => t.PK_WPId).HasColumnName("PK_WPId");
            this.Property(t => t.FK_Service_TransactionId).HasColumnName("FK_Service_TransactionId");
            this.Property(t => t.FK_LaborId).HasColumnName("FK_LaborId");
            this.Property(t => t.FK_Servcie_ServiceRequestTypeId).HasColumnName("FK_Servcie_ServiceRequestTypeId");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.ExpirationDate).HasColumnName("ExpirationDate");
            this.Property(t => t.FK_WP_ReasonId).HasColumnName("FK_WP_ReasonId");
            this.Property(t => t.Period).HasColumnName("Period");
            this.Property(t => t.LastPrintingDate).HasColumnName("LastPrintingDate");
            this.Property(t => t.FK_PrintedBy).HasColumnName("FK_PrintedBy");
            this.Property(t => t.IsSynchronized).HasColumnName("IsSynchronized");
            this.Property(t => t.NOT_ISSUED_WP).HasColumnName("NOT_ISSUED_WP");
            this.Property(t => t.ExtraFees).HasColumnName("ExtraFees");
            this.Property(t => t.PenalityExtraFees).HasColumnName("PenalityExtraFees");

            // Relationships
            this.HasRequired(t => t.MOL_Laborer)
                .WithMany(t => t.MOL_WorkPermit)
                .HasForeignKey(d => d.FK_LaborId);
            this.HasRequired(t => t.MOL_Laborer1)
                .WithMany(t => t.MOL_WorkPermit1)
                .HasForeignKey(d => d.FK_LaborId);
            this.HasRequired(t => t.MOL_Srv_Transaction)
                .WithMany(t => t.MOL_WorkPermit)
                .HasForeignKey(d => d.FK_Service_TransactionId);
            this.HasRequired(t => t.MOL_Srv_Transaction1)
                .WithMany(t => t.MOL_WorkPermit1)
                .HasForeignKey(d => d.FK_Service_TransactionId);
            this.HasOptional(t => t.MOL_User)
                .WithMany(t => t.MOL_WorkPermit)
                .HasForeignKey(d => d.FK_PrintedBy);

        }
    }
}
