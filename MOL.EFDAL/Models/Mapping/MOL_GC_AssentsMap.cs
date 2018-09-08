namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_GC_AssentsMap : EntityTypeConfiguration<MOL_GC_Assents>
    {
        public MOL_GC_AssentsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Number)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ApprovalComment)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("MOL_GC_Assents");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GovEntityID).HasColumnName("GovEntityID");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.EstablishmentID).HasColumnName("EstablishmentID");
            this.Property(t => t.IssuedCredit).HasColumnName("IssuedCredit");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.EndReasonID).HasColumnName("EndReasonID");
            this.Property(t => t.ApprovalDoneBy).HasColumnName("ApprovalDoneBy");
            this.Property(t => t.ApprovalDate).HasColumnName("ApprovalDate");
            this.Property(t => t.ApprovalComment).HasColumnName("ApprovalComment");
            this.Property(t => t.VisaCreditDBGroupingReference).HasColumnName("VisaCreditDBGroupingReference");

            // Relationships
            this.HasRequired(t => t.Channels)
                .WithMany(t => t.MOL_GC_Assents)
                .HasForeignKey(t => t.GovEntityID);
        }
    }
}
