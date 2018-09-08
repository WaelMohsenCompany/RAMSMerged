namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VisaBalanceRejectReasonMap : EntityTypeConfiguration<MOL_VisaBalanceRejectReason>
    {
        public MOL_VisaBalanceRejectReasonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ReasonDescription)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("MOL_VisaBalanceRejectReason");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ReasonDescription).HasColumnName("ReasonDescription");
        }
    }
}
