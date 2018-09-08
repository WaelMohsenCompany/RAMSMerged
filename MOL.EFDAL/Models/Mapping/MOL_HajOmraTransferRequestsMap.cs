namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_HajOmraTransferRequestsMap : EntityTypeConfiguration<MOL_HajOmraTransferRequests>
    {
        public MOL_HajOmraTransferRequestsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.BorderNo)
                .HasMaxLength(50);

            this.Property(t => t.Temp1)
                .HasMaxLength(50);

            this.Property(t => t.Temp2)
                .HasMaxLength(50);

            this.Property(t => t.Temp3)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("MOL_HajOmraTransferRequests");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RequesterID).HasColumnName("RequesterID");
            this.Property(t => t.OldKingdomEntryDate).HasColumnName("OldKingdomEntryDate");
            this.Property(t => t.NewKingdomEntryDate).HasColumnName("NewKingdomEntryDate");
            this.Property(t => t.EstablishmentID).HasColumnName("EstablishmentID");
            this.Property(t => t.BorderNo).HasColumnName("BorderNo");
            this.Property(t => t.RequestDate).HasColumnName("RequestDate");
            this.Property(t => t.Temp1).HasColumnName("Temp1");
            this.Property(t => t.Temp2).HasColumnName("Temp2");
            this.Property(t => t.Temp3).HasColumnName("Temp3");
        }
    }
}
