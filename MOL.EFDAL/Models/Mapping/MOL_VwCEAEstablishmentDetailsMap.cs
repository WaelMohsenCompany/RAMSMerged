namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VwCEAEstablishmentDetailsMap : EntityTypeConfiguration<MOL_VwCEAEstablishmentDetails>
    {
        public MOL_VwCEAEstablishmentDetailsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PK_EstablishmentId, t.FK_LaborOfficeId, t.SequenceNumber, t.EstablishmentName, t.MainEconomicActivity, t.SubEconomicActivity });

            // Properties
            this.Property(t => t.PK_EstablishmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FK_LaborOfficeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SequenceNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EstablishmentName)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.MainEconomicActivity)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.SubEconomicActivity)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.EconomicActivityText)
                .HasMaxLength(4000);

            this.Property(t => t.CommercialRecordNumber)
                .HasMaxLength(12);

            this.Property(t => t.CommercialRecordSource)
                .HasMaxLength(50);

            this.Property(t => t.CommercialRecordCancellationNo)
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("MOL_VwCEAEstablishmentDetails");
            this.Property(t => t.PK_EstablishmentId).HasColumnName("PK_EstablishmentId");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.EstablishmentName).HasColumnName("EstablishmentName");
            this.Property(t => t.MainEconomicActivityId).HasColumnName("MainEconomicActivityId");
            this.Property(t => t.MainEconomicActivity).HasColumnName("MainEconomicActivity");
            this.Property(t => t.SubEconomicActivityId).HasColumnName("SubEconomicActivityId");
            this.Property(t => t.SubEconomicActivity).HasColumnName("SubEconomicActivity");
            this.Property(t => t.PendingRequestsCount).HasColumnName("PendingRequestsCount");
            this.Property(t => t.ApprovedRequestsCount).HasColumnName("ApprovedRequestsCount");
            this.Property(t => t.EconomicActivityText).HasColumnName("EconomicActivityText");
            this.Property(t => t.CommercialRecordNumber).HasColumnName("CommercialRecordNumber");
            this.Property(t => t.CommercialRecordReleaseDate).HasColumnName("CommercialRecordReleaseDate");
            this.Property(t => t.CommercialRecordEndDate).HasColumnName("CommercialRecordEndDate");
            this.Property(t => t.CommercialRecordSource).HasColumnName("CommercialRecordSource");
            this.Property(t => t.CommercialRecordCancellationNo).HasColumnName("CommercialRecordCancellationNo");
            this.Property(t => t.CommercialRecordCancellationDt).HasColumnName("CommercialRecordCancellationDt");
            this.Property(t => t.CommercialRecordConfirmationDate).HasColumnName("CommercialRecordConfirmationDate");
        }
    }
}
