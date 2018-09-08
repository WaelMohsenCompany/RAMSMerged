namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentChangeStatusMap : EntityTypeConfiguration<MOL_EstablishmentChangeStatus>
    {
        public MOL_EstablishmentChangeStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EstablishmentChangeStatus);

            // Properties
            this.Property(t => t.Reason)
                .HasMaxLength(130);

            this.Property(t => t.Notes)
                .HasMaxLength(130);

            this.Property(t => t.CommercialRecordCancellationNumber)
                .HasMaxLength(12);

            this.Property(t => t.MunicipalLicenseCancellationNumber)
                .HasMaxLength(12);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentChangeStatus");
            this.Property(t => t.PK_EstablishmentChangeStatus).HasColumnName("PK_EstablishmentChangeStatus");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.CommercialRecordCancellationNumber).HasColumnName("CommercialRecordCancellationNumber");
            this.Property(t => t.CommercialRecordCancellationDate).HasColumnName("CommercialRecordCancellationDate");
            this.Property(t => t.MunicipalLicenseCancellationNumber).HasColumnName("MunicipalLicenseCancellationNumber");
            this.Property(t => t.MunicipalLicenseCancellationDate).HasColumnName("MunicipalLicenseCancellationDate");
            this.Property(t => t.FK_EstablishmentID).HasColumnName("FK_EstablishmentID");
            this.Property(t => t.FK_EstablishmentStatusId).HasColumnName("FK_EstablishmentStatusId");
            this.Property(t => t.UserID).HasColumnName("UserID");

            // Relationships
            this.HasRequired(t => t.Enum_EstablishmentStatus)
                .WithMany(t => t.MOL_EstablishmentChangeStatus)
                .HasForeignKey(d => d.FK_EstablishmentStatusId);
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_EstablishmentChangeStatus)
                .HasForeignKey(d => d.FK_EstablishmentID);

        }
    }
}
