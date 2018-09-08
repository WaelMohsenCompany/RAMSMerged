namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VisaRequestImmediateApproveInfoMap : EntityTypeConfiguration<MOL_VisaRequestImmediateApproveInfo>
    {
        public MOL_VisaRequestImmediateApproveInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ImmediateApproveCondition)
                .HasMaxLength(100);

            this.Property(t => t.ImmediateApproveValue)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_VisaRequestImmediateApproveInfo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FK_VisaRequestID).HasColumnName("FK_VisaRequestID");
            this.Property(t => t.ImmediateApproveCondition).HasColumnName("ImmediateApproveCondition");
            this.Property(t => t.ImmediateApproveValue).HasColumnName("ImmediateApproveValue");
        }
    }
}
