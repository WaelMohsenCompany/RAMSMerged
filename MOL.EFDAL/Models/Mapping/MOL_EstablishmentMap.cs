namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentMap : EntityTypeConfiguration<MOL_Establishment>
    {
        public MOL_EstablishmentMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EstablishmentId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.ZakatRegisterationNumber)
                .HasMaxLength(14);

            this.Property(t => t.EconomicActivityText)
                .HasMaxLength(4000);

            this.Property(t => t.Notes)
                .HasMaxLength(200);

            this.Property(t => t.CommercialRecordNumber)
                .HasMaxLength(12);

            this.Property(t => t.CommercialRecordSource)
                .HasMaxLength(50);

            this.Property(t => t.CommercialRecordCancellationNo)
                .HasMaxLength(14);

            this.Property(t => t.MunicipalLicenseNumber)
                .HasMaxLength(12);

            this.Property(t => t.MunicipalLicenseSource)
                .HasMaxLength(50);

            this.Property(t => t.MunicipalLicenseCancellationNo)
                .HasMaxLength(14);

            this.Property(t => t.AreaForMunicipalLicense)
                .HasMaxLength(50);

            this.Property(t => t.SocialInsuranceRegisterationNo)
                .HasMaxLength(14);

            this.Property(t => t.ZakatCertificateNumber)
                .HasMaxLength(14);

            this.Property(t => t.District)
                .HasMaxLength(30);

            this.Property(t => t.Street)
                .HasMaxLength(100);

            this.Property(t => t.PostalCode)
                .HasMaxLength(7);

            this.Property(t => t.ZipCode)
                .HasMaxLength(7);

            this.Property(t => t.Telephone1)
                .HasMaxLength(15);

            this.Property(t => t.Telephone2)
                .HasMaxLength(15);

            this.Property(t => t.Fax)
                .HasMaxLength(15);

            this.Property(t => t.email)
                .HasMaxLength(50);

            this.Property(t => t.ManagerName)
                .HasMaxLength(50);

            this.Property(t => t.NationalEnterpriseId)
                .HasMaxLength(20);

            this.Property(t => t.WASELZipCode)
                .HasMaxLength(50);

            this.Property(t => t.WASELPrimary)
                .HasMaxLength(50);

            this.Property(t => t.WASELSecondary)
                .HasMaxLength(50);

            this.Property(t => t.WASELUnitNo)
                .HasMaxLength(50);

            this.Property(t => t.WASELCity)
                .HasMaxLength(50);

            this.Property(t => t.WASELArea)
                .HasMaxLength(50);

            this.Property(t => t.WASELStreet)
                .HasMaxLength(50);

            this.Property(t => t.SevenHundred)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_Establishment");
            this.Property(t => t.PK_EstablishmentId).HasColumnName("PK_EstablishmentId");
            this.Property(t => t.FK_UnifiedNumberId).HasColumnName("FK_UnifiedNumberId");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.InsertDate).HasColumnName("InsertDate");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ZakatRegisterationNumber).HasColumnName("ZakatRegisterationNumber");
            this.Property(t => t.FK_MainEconomicActivityId).HasColumnName("FK_MainEconomicActivityId");
            this.Property(t => t.FK_SubEconomicActivityId).HasColumnName("FK_SubEconomicActivityId");
            this.Property(t => t.EconomicActivityText).HasColumnName("EconomicActivityText");
            this.Property(t => t.RequiredLaborCount).HasColumnName("RequiredLaborCount");
            this.Property(t => t.FK_EstablishmentStatusId).HasColumnName("FK_EstablishmentStatusId");
            this.Property(t => t.StatusModificationDate).HasColumnName("StatusModificationDate");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.LaborCountLastModificationDate).HasColumnName("LaborCountLastModificationDate");
            this.Property(t => t.CommercialRecordNumber).HasColumnName("CommercialRecordNumber");
            this.Property(t => t.CommercialRecordReleaseDate).HasColumnName("CommercialRecordReleaseDate");
            this.Property(t => t.CommercialRecordEndDate).HasColumnName("CommercialRecordEndDate");
            this.Property(t => t.CommercialRecordSource).HasColumnName("CommercialRecordSource");
            this.Property(t => t.CommercialRecordCancellationNo).HasColumnName("CommercialRecordCancellationNo");
            this.Property(t => t.CommercialRecordCancellationDt).HasColumnName("CommercialRecordCancellationDt");
            this.Property(t => t.MunicipalLicenseNumber).HasColumnName("MunicipalLicenseNumber");
            this.Property(t => t.MunicipalLicenseReleaseDate).HasColumnName("MunicipalLicenseReleaseDate");
            this.Property(t => t.MunicipalLicenseEndDate).HasColumnName("MunicipalLicenseEndDate");
            this.Property(t => t.MunicipalLicenseSource).HasColumnName("MunicipalLicenseSource");
            this.Property(t => t.MunicipalLicenseCancellationNo).HasColumnName("MunicipalLicenseCancellationNo");
            this.Property(t => t.MunicipalLicenseCancellationDt).HasColumnName("MunicipalLicenseCancellationDt");
            this.Property(t => t.AreaForMunicipalLicense).HasColumnName("AreaForMunicipalLicense");
            this.Property(t => t.SocialInsuranceRegisterationNo).HasColumnName("SocialInsuranceRegisterationNo");
            this.Property(t => t.SocialInsuranceRegEndDate).HasColumnName("SocialInsuranceRegEndDate");
            this.Property(t => t.ZakatCertificateNumber).HasColumnName("ZakatCertificateNumber");
            this.Property(t => t.ZakatCertificateDate).HasColumnName("ZakatCertificateDate");
            this.Property(t => t.FK_CityId).HasColumnName("FK_CityId");
            this.Property(t => t.District).HasColumnName("District");
            this.Property(t => t.Street).HasColumnName("Street");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");
            this.Property(t => t.Telephone1).HasColumnName("Telephone1");
            this.Property(t => t.Telephone2).HasColumnName("Telephone2");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.ConcessionsCount).HasColumnName("ConcessionsCount");
            this.Property(t => t.DeparturesCount).HasColumnName("DeparturesCount");
            this.Property(t => t.RunnersCount).HasColumnName("RunnersCount");
            this.Property(t => t.IsMainBranch).HasColumnName("IsMainBranch");
            this.Property(t => t.ManagerName).HasColumnName("ManagerName");
            this.Property(t => t.NationalEnterpriseId).HasColumnName("NationalEnterpriseId");
            this.Property(t => t.CommercialRecordConfirmationDate).HasColumnName("CommercialRecordConfirmationDate");
            this.Property(t => t.MunicipalLicenseConfirmationDate).HasColumnName("MunicipalLicenseConfirmationDate");
            this.Property(t => t.SocialInsuranceConfirmationDate).HasColumnName("SocialInsuranceConfirmationDate");
            this.Property(t => t.ZakatCertificateConfirmationDate).HasColumnName("ZakatCertificateConfirmationDate");
            this.Property(t => t.SaudiLaborCountAtRegistration).HasColumnName("SaudiLaborCountAtRegistration");
            this.Property(t => t.NonSaudiLaborCountAtRegistration).HasColumnName("NonSaudiLaborCountAtRegistration");
            this.Property(t => t.FK_MunicipalityId).HasColumnName("FK_MunicipalityId");
            this.Property(t => t.Fk_NewEconomicActivityId).HasColumnName("Fk_NewEconomicActivityId");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.WASELStatus).HasColumnName("WASELStatus");
            this.Property(t => t.WASELZipCode).HasColumnName("WASELZipCode");
            this.Property(t => t.WASELPrimary).HasColumnName("WASELPrimary");
            this.Property(t => t.WASELSecondary).HasColumnName("WASELSecondary");
            this.Property(t => t.WASELUnitNo).HasColumnName("WASELUnitNo");
            this.Property(t => t.WASELCity).HasColumnName("WASELCity");
            this.Property(t => t.WASELArea).HasColumnName("WASELArea");
            this.Property(t => t.WASELStreet).HasColumnName("WASELStreet");
            this.Property(t => t.WASELExpiryDate).HasColumnName("WASELExpiryDate");
            this.Property(t => t.MOCIUpdate).HasColumnName("MOCIUpdate");
            this.Property(t => t.MOCIUpdateTimeStamp).HasColumnName("MOCIUpdateTimeStamp");
            this.Property(t => t.SevenHundred).HasColumnName("SevenHundred");
            this.Property(t => t.FK_CRStatusId).HasColumnName("FK_CRStatusId");
            this.Property(t => t.IsGregorian).HasColumnName("IsGregorian");

            // Relationships
            this.HasOptional(t => t.Enum_EstablishmentStatus)
                .WithMany(t => t.MOL_Establishment)
                .HasForeignKey(d => d.FK_EstablishmentStatusId);
            this.HasOptional(t => t.Lookup_EconomicActivity)
                .WithMany(t => t.MOL_Establishment)
                .HasForeignKey(d => d.FK_SubEconomicActivityId);
            this.HasRequired(t => t.MOL_UnifiedNumber)
                .WithMany(t => t.MOL_Establishment)
                .HasForeignKey(d => d.FK_UnifiedNumberId);

        }
    }
}
