namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_AccountManagerMap : EntityTypeConfiguration<MOL_AccountManager>
    {
        public MOL_AccountManagerMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_AccountManagerID);

            // IAuditable
            this.Ignore(t => t.CurrentUserID);
            this.Ignore(t => t.DBTableName);

            // Properties
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

            // Table & Column Mappings
            this.ToTable("MOL_AccountManager");
            this.Property(t => t.PK_AccountManagerID).HasColumnName("PK_AccountManagerID");
            this.Property(t => t.FK_UserID).HasColumnName("FK_UserID");
            this.Property(t => t.IDNO).HasColumnName("IDNO");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.SecondName).HasColumnName("SecondName");
            this.Property(t => t.ThirdName).HasColumnName("ThirdName");
            this.Property(t => t.FourthName).HasColumnName("FourthName");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.FK_NationalityID).HasColumnName("FK_NationalityID");
            this.Property(t => t.FK_UnifiedNumberId).HasColumnName("FK_UnifiedNumberId");
            this.Property(t => t.FK_AccountManagerTypeId).HasColumnName("FK_AccountManagerTypeId");
            this.Property(t => t.FK_AttachmentID).HasColumnName("FK_AttachmentID");

            // Relationships
            this.HasRequired(t => t.Enum_AccountManagerType)
                .WithMany(t => t.MOL_AccountManager)
                .HasForeignKey(d => d.FK_AccountManagerTypeId);
            this.HasRequired(t => t.Lookup_Nationality)
                .WithMany(t => t.MOL_AccountManager)
                .HasForeignKey(d => d.FK_NationalityID);
            this.HasOptional(t => t.MOL_User)
                .WithMany(t => t.MOL_AccountManager)
                .HasForeignKey(d => d.FK_UserID);

        }
    }
}
