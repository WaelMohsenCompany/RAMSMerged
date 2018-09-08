namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VwEstablishmentCRMComplaintDataMap : EntityTypeConfiguration<MOL_VwEstablishmentCRMComplaintData>
    {
        public MOL_VwEstablishmentCRMComplaintDataMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PK_EstablishmentId });

            // Table & Column Mappings
            this.ToTable("MOL_VwEstablishmentCRMComplaintData");
            this.Property(t => t.PK_EstablishmentId).HasColumnName("PK_EstablishmentId");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.UnifiedNumber).HasColumnName("UnifiedNumber");
            this.Property(t => t.SevenHundredNumberOrOwnerID).HasColumnName("SevenHundredNumberOrOwnerID");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.ZoneID).HasColumnName("ZoneID");
            this.Property(t => t.ZoneName).HasColumnName("ZoneName");
        }
    }
}
