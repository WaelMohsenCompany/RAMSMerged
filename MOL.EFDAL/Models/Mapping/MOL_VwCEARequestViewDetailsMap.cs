namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VwCEARequestViewDetailsMap : EntityTypeConfiguration<MOL_VwCEARequestViewDetails>
    {
        public MOL_VwCEARequestViewDetailsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.RequestNumber, t.FK_LaborOfficeId, t.SequenceNumber, t.EstablishmentName, t.DateCreated, t.DateModified, t.Fk_CreatedBy, t.EmployeeFullName, t.CreatedByFullName, t.RequestStatus, t.RequestStatusId, t.Pk_ChangeEstablishmentActivityRequestId, t.PK_EstablishmentId, t.NewEconomicActivityId, t.NewEconomicActivity, t.ChangeReasonId, t.ChangeReason });

            // Properties
            this.Property(t => t.RequestNumber)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.FK_LaborOfficeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SequenceNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EstablishmentName)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.Fk_CreatedBy)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EmployeeFullName)
                .IsRequired()
                .HasMaxLength(203);

            this.Property(t => t.CreatedByFullName)
                .IsRequired()
                .HasMaxLength(203);

            this.Property(t => t.RequestStatus)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.RequestStatusId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Pk_ChangeEstablishmentActivityRequestId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PK_EstablishmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NewEconomicActivityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NewEconomicActivity)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.OldMainEconomicActivity)
                .HasMaxLength(200);

            this.Property(t => t.OldSubEconomicActivity)
                .HasMaxLength(200);

            this.Property(t => t.NewMainEconomicActivity)
                .HasMaxLength(200);

            this.Property(t => t.NewSubEconomicActivity)
                .HasMaxLength(200);

            this.Property(t => t.RequestRejectionReason)
                .HasMaxLength(255);

            this.Property(t => t.ChangeReasonId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ChangeReason)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.CommercialRecordNumber)
                .HasMaxLength(12);

            this.Property(t => t.CommercialRecordSource)
                .HasMaxLength(50);

            this.Property(t => t.CommercialRecordCancellationNo)
                .HasMaxLength(14);

            this.Property(t => t.EconomicActivityText)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("MOL_VwCEARequestViewDetails");
            this.Property(t => t.RequestNumber).HasColumnName("RequestNumber");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.EstablishmentName).HasColumnName("EstablishmentName");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.Fk_CreatedBy).HasColumnName("Fk_CreatedBy");
            this.Property(t => t.EmployeeFullName).HasColumnName("EmployeeFullName");
            this.Property(t => t.CreatedByFullName).HasColumnName("CreatedByFullName");
            this.Property(t => t.User_Type_Id).HasColumnName("User_Type_Id");
            this.Property(t => t.RequestStatus).HasColumnName("RequestStatus");
            this.Property(t => t.RequestStatusId).HasColumnName("RequestStatusId");
            this.Property(t => t.Pk_ChangeEstablishmentActivityRequestId).HasColumnName("Pk_ChangeEstablishmentActivityRequestId");
            this.Property(t => t.PK_EstablishmentId).HasColumnName("PK_EstablishmentId");
            this.Property(t => t.NewEconomicActivityId).HasColumnName("NewEconomicActivityId");
            this.Property(t => t.NewEconomicActivity).HasColumnName("NewEconomicActivity");
            this.Property(t => t.OldMainEconomicActivityId).HasColumnName("OldMainEconomicActivityId");
            this.Property(t => t.OldMainEconomicActivity).HasColumnName("OldMainEconomicActivity");
            this.Property(t => t.OldSubEconomicActivityId).HasColumnName("OldSubEconomicActivityId");
            this.Property(t => t.OldSubEconomicActivity).HasColumnName("OldSubEconomicActivity");
            this.Property(t => t.NewMainEconomicActivityId).HasColumnName("NewMainEconomicActivityId");
            this.Property(t => t.NewMainEconomicActivity).HasColumnName("NewMainEconomicActivity");
            this.Property(t => t.NewSubEconomicActivityId).HasColumnName("NewSubEconomicActivityId");
            this.Property(t => t.NewSubEconomicActivity).HasColumnName("NewSubEconomicActivity");
            this.Property(t => t.RequestRejectionReasonId).HasColumnName("RequestRejectionReasonId");
            this.Property(t => t.RequestRejectionReason).HasColumnName("RequestRejectionReason");
            this.Property(t => t.ChangeReasonId).HasColumnName("ChangeReasonId");
            this.Property(t => t.ChangeReason).HasColumnName("ChangeReason");
            this.Property(t => t.CommercialRecordNumber).HasColumnName("CommercialRecordNumber");
            this.Property(t => t.CommercialRecordReleaseDate).HasColumnName("CommercialRecordReleaseDate");
            this.Property(t => t.CommercialRecordEndDate).HasColumnName("CommercialRecordEndDate");
            this.Property(t => t.CommercialRecordSource).HasColumnName("CommercialRecordSource");
            this.Property(t => t.CommercialRecordCancellationNo).HasColumnName("CommercialRecordCancellationNo");
            this.Property(t => t.CommercialRecordCancellationDt).HasColumnName("CommercialRecordCancellationDt");
            this.Property(t => t.EconomicActivityText).HasColumnName("EconomicActivityText");
            this.Property(t => t.CommercialRecordConfirmationDate).HasColumnName("CommercialRecordConfirmationDate");
        }
    }
}
