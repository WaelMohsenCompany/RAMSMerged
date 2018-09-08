namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_LaborerMap : EntityTypeConfiguration<MOL_Laborer>
    {
        public MOL_LaborerMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_LaborerId);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SecondName)
                .HasMaxLength(50);

            this.Property(t => t.ThirdName)
                .HasMaxLength(50);

            this.Property(t => t.FourthName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.IdNo)
                .HasMaxLength(15);

            this.Property(t => t.IdSource)
                .HasMaxLength(50);

            this.Property(t => t.PassportNo)
                .HasMaxLength(30);

            this.Property(t => t.PassportSource)
                .HasMaxLength(50);

            this.Property(t => t.BorderNo)
                .HasMaxLength(50);

            this.Property(t => t.EstablishmentName)
                .HasMaxLength(60);

            this.Property(t => t.Mobile)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("MOL_Laborer");
            this.Property(t => t.PK_LaborerId).HasColumnName("PK_LaborerId");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.FK_SaudiFlagId).HasColumnName("FK_SaudiFlagId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.InsertDate).HasColumnName("InsertDate");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.SecondName).HasColumnName("SecondName");
            this.Property(t => t.ThirdName).HasColumnName("ThirdName");
            this.Property(t => t.FourthName).HasColumnName("FourthName");
            this.Property(t => t.FK_AccomodationStatusId).HasColumnName("FK_AccomodationStatusId");
            this.Property(t => t.IdNo).HasColumnName("IdNo");
            this.Property(t => t.IdSource).HasColumnName("IdSource");
            this.Property(t => t.IdReleaseDate).HasColumnName("IdReleaseDate");
            this.Property(t => t.FK_LaborerTypeId).HasColumnName("FK_LaborerTypeId");
            this.Property(t => t.FK_NationalityId).HasColumnName("FK_NationalityId");
            this.Property(t => t.FK_ReligionId).HasColumnName("FK_ReligionId");
            this.Property(t => t.PassportNo).HasColumnName("PassportNo");
            this.Property(t => t.PassportSource).HasColumnName("PassportSource");
            this.Property(t => t.PassportReleaseDate).HasColumnName("PassportReleaseDate");
            this.Property(t => t.VisaExpiryDate).HasColumnName("VisaExpiryDate");
            this.Property(t => t.FK_GenderId).HasColumnName("FK_GenderId");
            this.Property(t => t.YearOfBirth).HasColumnName("YearOfBirth");
            this.Property(t => t.FK_JobId).HasColumnName("FK_JobId");
            this.Property(t => t.FK_EducationalStatusId).HasColumnName("FK_EducationalStatusId");
            this.Property(t => t.FK_QualificationId).HasColumnName("FK_QualificationId");
            this.Property(t => t.KingdomEntryDate).HasColumnName("KingdomEntryDate");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.Salary).HasColumnName("Salary");
            this.Property(t => t.ServiceStartDate).HasColumnName("ServiceStartDate");
            this.Property(t => t.FK_LaborerStatusId).HasColumnName("FK_LaborerStatusId");
            this.Property(t => t.ServiceEndDate).HasColumnName("ServiceEndDate");
            this.Property(t => t.FK_ServiceEndReasonId).HasColumnName("FK_ServiceEndReasonId");
            this.Property(t => t.FK_CurrentLaborOfficeId).HasColumnName("FK_CurrentLaborOfficeId");
            this.Property(t => t.BorderNo).HasColumnName("BorderNo");
            this.Property(t => t.FK_Service_LastServiceStatusId).HasColumnName("FK_Service_LastServiceStatusId");
            this.Property(t => t.FK_WPId).HasColumnName("FK_WPId");
            this.Property(t => t.FK_LastWPId).HasColumnName("FK_LastWPId");
            this.Property(t => t.EstablishmentSequenceNumber).HasColumnName("EstablishmentSequenceNumber");
            this.Property(t => t.EstablishmentName).HasColumnName("EstablishmentName");
            this.Property(t => t.EstablishmentStatusId).HasColumnName("EstablishmentStatusId");
            this.Property(t => t.LastWPStartDate).HasColumnName("LastWPStartDate");
            this.Property(t => t.LastWPExpirationDate).HasColumnName("LastWPExpirationDate");
            this.Property(t => t.UpdateStatus).HasColumnName("UpdateStatus");
            this.Property(t => t.LaborerStatusModificationDate).HasColumnName("LaborerStatusModificationDate");
            this.Property(t => t.ModifiedByMOI).HasColumnName("ModifiedByMOI");
            this.Property(t => t.FK_BatchUserId).HasColumnName("FK_BatchUserId");
            this.Property(t => t.BatchTransactionNumber).HasColumnName("BatchTransactionNumber");
            this.Property(t => t.FK_Service_TransactionId).HasColumnName("FK_Service_TransactionId");
            this.Property(t => t.StatusLastModificationDate).HasColumnName("StatusLastModificationDate");
            this.Property(t => t.isUpdatedToOracle).HasColumnName("isUpdatedToOracle");
            this.Property(t => t.isSpecialExpatriate).HasColumnName("isSpecialExpatriate");
            this.Property(t => t.FK_SpecialExpatriateTypeId).HasColumnName("FK_SpecialExpatriateTypeId");
            this.Property(t => t.CameByCompensationVISA).HasColumnName("CameByCompensationVISA");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.ComplaintDate).HasColumnName("ComplaintDate");
            this.Property(t => t.CreditID).HasColumnName("CreditID");
            this.Property(t => t.CreditType).HasColumnName("CreditType");
            this.Property(t => t.NIC_LastSyncDate).HasColumnName("NIC_LastSyncDate");
            this.Property(t => t.NIC_SyncStatus).HasColumnName("NIC_SyncStatus");

            // Relationships
            this.HasRequired(t => t.Enum_AccomodationStatus)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_AccomodationStatusId);
            this.HasRequired(t => t.Enum_Gender)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_GenderId);
            this.HasOptional(t => t.Enum_LaborerStatus)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_LaborerStatusId);
            this.HasOptional(t => t.Enum_LaborerType)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_LaborerTypeId);
            this.HasRequired(t => t.Enum_SaudiFlag)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_SaudiFlagId);
            this.HasRequired(t => t.Lookup_EducationalStatus)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_EducationalStatusId);
            this.HasRequired(t => t.Lookup_Nationality)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_NationalityId);
            this.HasOptional(t => t.Lookup_Qualification)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_QualificationId);
            this.HasRequired(t => t.Lookup_Religion)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_ReligionId);
            this.HasOptional(t => t.Lookup_ServiceEndReason)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_ServiceEndReasonId);
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_EstablishmentId);
            this.HasRequired(t => t.MOL_LaborOffice)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_CurrentLaborOfficeId);
            this.HasRequired(t => t.MOL_LaborOffice1)
                .WithMany(t => t.MOL_Laborer1)
                .HasForeignKey(d => d.FK_LaborOfficeId);
            this.HasOptional(t => t.MOL_User)
                .WithMany(t => t.MOL_Laborer)
                .HasForeignKey(d => d.FK_BatchUserId);
            this.HasRequired(t => t.Lookup_Job)
                .WithMany()
                .HasForeignKey(t => t.FK_JobId);
        }
    }
}
