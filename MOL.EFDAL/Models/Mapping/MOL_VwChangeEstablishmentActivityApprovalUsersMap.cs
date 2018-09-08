namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VwChangeEstablishmentActivityApprovalUsersMap : EntityTypeConfiguration<MOL_VwChangeEstablishmentActivityApprovalUsers>
    {
        public MOL_VwChangeEstablishmentActivityApprovalUsersMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.IsSystem, t.IsEmailVerified, t.EmailVerificationCount, t.IsMobileVerified, t.MobileVerificationCount, t.IsDataVerified });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .HasMaxLength(255);

            this.Property(t => t.First_Name)
                .HasMaxLength(50);

            this.Property(t => t.Second_Name)
                .HasMaxLength(50);

            this.Property(t => t.Third_Name)
                .HasMaxLength(50);

            this.Property(t => t.Fourth_Name)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.PlaceofBirth)
                .HasMaxLength(50);

            this.Property(t => t.MobileNumber)
                .HasMaxLength(50);

            this.Property(t => t.TwitterAccount)
                .HasMaxLength(50);

            this.Property(t => t.POBox)
                .HasMaxLength(50);

            this.Property(t => t.ZipCode)
                .HasMaxLength(50);

            this.Property(t => t.Fax)
                .HasMaxLength(50);

            this.Property(t => t.EmailVerificationCount)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MobileVerificationCount)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MOL_VwChangeEstablishmentActivityApprovalUsers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.First_Name).HasColumnName("First_Name");
            this.Property(t => t.Second_Name).HasColumnName("Second_Name");
            this.Property(t => t.Third_Name).HasColumnName("Third_Name");
            this.Property(t => t.Fourth_Name).HasColumnName("Fourth_Name");
            this.Property(t => t.Nationality).HasColumnName("Nationality");
            this.Property(t => t.Birth_Date).HasColumnName("Birth_Date");
            this.Property(t => t.User_Type_Id).HasColumnName("User_Type_Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.LastLoggedIn).HasColumnName("LastLoggedIn");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.GenderID).HasColumnName("GenderID");
            this.Property(t => t.MaritalStatusID).HasColumnName("MaritalStatusID");
            this.Property(t => t.Id_Number).HasColumnName("Id_Number");
            this.Property(t => t.Id_ExpiryDate).HasColumnName("Id_ExpiryDate");
            this.Property(t => t.Iqama_Number).HasColumnName("Iqama_Number");
            this.Property(t => t.Iqama_ExpiryDate).HasColumnName("Iqama_ExpiryDate");
            this.Property(t => t.EmailLangID).HasColumnName("EmailLangID");
            this.Property(t => t.IsUserDeleted).HasColumnName("IsUserDeleted");
            this.Property(t => t.PlaceofBirth).HasColumnName("PlaceofBirth");
            this.Property(t => t.IsActivated).HasColumnName("IsActivated");
            this.Property(t => t.MobileNumber).HasColumnName("MobileNumber");
            this.Property(t => t.IsSystem).HasColumnName("IsSystem");
            this.Property(t => t.TwitterAccount).HasColumnName("TwitterAccount");
            this.Property(t => t.POBox).HasColumnName("POBox");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.FromHafiz).HasColumnName("FromHafiz");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
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
