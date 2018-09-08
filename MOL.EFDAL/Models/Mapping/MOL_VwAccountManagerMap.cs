namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VwAccountManagerMap : EntityTypeConfiguration<MOL_VwAccountManager>
    {
        public MOL_VwAccountManagerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AccountManagerTypeName, t.UN_LaborOffice, t.UN_SequenceNumber, t.PK_AccountManagerID, t.IDNO, t.FirstName, t.SecondName, t.ThirdName, t.FourthName, t.FullName, t.BirthDate, t.FK_NationalityID, t.FK_UnifiedNumberId, t.FK_AccountManagerTypeId, t.FK_AttachmentID, t.Role_Id });

            // Properties
            this.Property(t => t.AccountManagerTypeName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UN_LaborOffice)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UN_SequenceNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PK_AccountManagerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IDNO)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SecondName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ThirdName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FourthName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FullName)
                .IsRequired()
                .HasMaxLength(203);

            this.Property(t => t.FK_NationalityID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FK_UnifiedNumberId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FK_AccountManagerTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Role_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.POBox)
                .HasMaxLength(50);

            this.Property(t => t.ZipCode)
                .HasMaxLength(50);

            this.Property(t => t.Fax)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_VwAccountManager");
            this.Property(t => t.AccountManagerTypeName).HasColumnName("AccountManagerTypeName");
            this.Property(t => t.UN_LaborOffice).HasColumnName("UN_LaborOffice");
            this.Property(t => t.UN_SequenceNumber).HasColumnName("UN_SequenceNumber");
            this.Property(t => t.PK_AccountManagerID).HasColumnName("PK_AccountManagerID");
            this.Property(t => t.FK_UserID).HasColumnName("FK_UserID");
            this.Property(t => t.IDNO).HasColumnName("IDNO");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.SecondName).HasColumnName("SecondName");
            this.Property(t => t.ThirdName).HasColumnName("ThirdName");
            this.Property(t => t.FourthName).HasColumnName("FourthName");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.FK_NationalityID).HasColumnName("FK_NationalityID");
            this.Property(t => t.FK_UnifiedNumberId).HasColumnName("FK_UnifiedNumberId");
            this.Property(t => t.FK_AccountManagerTypeId).HasColumnName("FK_AccountManagerTypeId");
            this.Property(t => t.FK_AttachmentID).HasColumnName("FK_AttachmentID");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.Role_Id).HasColumnName("Role_Id");
            this.Property(t => t.IsStopRole).HasColumnName("IsStopRole");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.FK_SecurableEntityId).HasColumnName("FK_SecurableEntityId");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Id_ExpiryDate).HasColumnName("Id_ExpiryDate");
            this.Property(t => t.Iqama_ExpiryDate).HasColumnName("Iqama_ExpiryDate");
            this.Property(t => t.POBox).HasColumnName("POBox");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.IsEmailVerified).HasColumnName("IsEmailVerified");
            this.Property(t => t.EmailVerificationCount).HasColumnName("EmailVerificationCount");
            this.Property(t => t.EmailLastVerificationDate).HasColumnName("EmailLastVerificationDate");
            this.Property(t => t.IsMobileVerified).HasColumnName("IsMobileVerified");
            this.Property(t => t.MobileVerificationCount).HasColumnName("MobileVerificationCount");
            this.Property(t => t.MobileLastVerificationDate).HasColumnName("MobileLastVerificationDate");
            this.Property(t => t.IsDataVerified).HasColumnName("IsDataVerified");
        }
    }
}
