namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class IstikdamRequestRejectionReasonMap : EntityTypeConfiguration<IstikdamRequestRejectionReason>
    {
        public IstikdamRequestRejectionReasonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("IstikdamRequestRejectionReason");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FK_IstikdamBalanceRequestId).HasColumnName("FK_IstikdamBalanceRequestId");
            this.Property(t => t.FK_RejectionReasonId).HasColumnName("FK_RejectionReasonId");
        }
    }
}
