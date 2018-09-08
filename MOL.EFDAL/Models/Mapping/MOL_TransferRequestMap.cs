namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_TransferRequestMap : EntityTypeConfiguration<MOL_TransferRequest>
    {
        public MOL_TransferRequestMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_TransferRequestId);

            // Properties
            this.Property(t => t.TransferReason)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MOL_TransferRequest");
            this.Property(t => t.PK_TransferRequestId).HasColumnName("PK_TransferRequestId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.FK_LaborerId).HasColumnName("FK_LaborerId");
            this.Property(t => t.FK_SourceLaborOfficeId).HasColumnName("FK_SourceLaborOfficeId");
            this.Property(t => t.FK_DestinationLaborOfficeId).HasColumnName("FK_DestinationLaborOfficeId");
            this.Property(t => t.TransferReason).HasColumnName("TransferReason");
            this.Property(t => t.TransferDate).HasColumnName("TransferDate");

            // Relationships
            this.HasRequired(t => t.MOL_Laborer)
                .WithMany(t => t.MOL_TransferRequest)
                .HasForeignKey(d => d.FK_LaborerId);
            this.HasRequired(t => t.MOL_LaborOffice)
                .WithMany(t => t.MOL_TransferRequest)
                .HasForeignKey(d => d.FK_DestinationLaborOfficeId);
            this.HasRequired(t => t.MOL_LaborOffice1)
                .WithMany(t => t.MOL_TransferRequest1)
                .HasForeignKey(d => d.FK_SourceLaborOfficeId);

        }
    }
}
