namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VisaIssuePrivateContractMap : EntityTypeConfiguration<MOL_VisaIssuePrivateContract>
    {
        public MOL_VisaIssuePrivateContractMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_PrivateContractID);

            // Properties
            this.Property(t => t.ContractNumber)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.ContractorName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ContractPlace)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MOL_VisaIssuePrivateContract");
            this.Property(t => t.PK_PrivateContractID).HasColumnName("PK_PrivateContractID");
            this.Property(t => t.FK_VisaRequestID).HasColumnName("FK_VisaRequestID");
            this.Property(t => t.ContractNumber).HasColumnName("ContractNumber");
            this.Property(t => t.ContractorName).HasColumnName("ContractorName");
            this.Property(t => t.ContractPlace).HasColumnName("ContractPlace");
            this.Property(t => t.ContractBudget).HasColumnName("ContractBudget");
            this.Property(t => t.ContractStartDate).HasColumnName("ContractStartDate");
            this.Property(t => t.ContractEndDate).HasColumnName("ContractEndDate");
            this.Property(t => t.CreatedByUserID).HasColumnName("CreatedByUserID");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");

            // Relationships
            this.HasRequired(t => t.MOL_VisaRequests)
                .WithMany(t => t.MOL_VisaIssuePrivateContract)
                .HasForeignKey(d => d.FK_VisaRequestID);

        }
    }
}
