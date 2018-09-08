namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_GC_ContractsMap : EntityTypeConfiguration<MOL_GC_Contracts>
    {
        public MOL_GC_ContractsMap()
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
            this.ToTable("MOL_GC_Contracts");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GovEntityID).HasColumnName("GovEntityID");
            this.Property(t => t.TypeID).HasColumnName("TypeID");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.FieldID).HasColumnName("FieldID");
            this.Property(t => t.IsReplacementContract).HasColumnName("IsReplacementContract");
            this.Property(t => t.ReplacementContractID).HasColumnName("ReplacementContractID");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.EndReasonID).HasColumnName("EndReasonID");
            this.Property(t => t.ReplacedByContractID).HasColumnName("ReplacedByContractID");
            this.Property(t => t.ApprovalDoneBy).HasColumnName("ApprovalDoneBy");
            this.Property(t => t.ApprovalDate).HasColumnName("ApprovalDate");
            this.Property(t => t.ApprovalComment).HasColumnName("ApprovalComment");
            this.Property(t => t.VisaCreditDBGroupingReference).HasColumnName("VisaCreditDBGroupingReference");

            // Relationships
            this.HasRequired(t => t.Lookup_GC_ContractFields)
                .WithMany(t => t.MOL_GC_Contracts)
                .HasForeignKey(d => d.FieldID);
            this.HasOptional(t => t.MOL_GC_Contracts2)
                .WithMany(t => t.MOL_GC_Contracts1)
                .HasForeignKey(d => d.ReplacementContractID);
            this.HasOptional(t => t.MOL_GC_Contracts3)
                .WithMany(t => t.MOL_GC_Contracts11)
                .HasForeignKey(d => d.ReplacedByContractID);
        }
    }
}
