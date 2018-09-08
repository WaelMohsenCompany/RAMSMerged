namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_LaborOfficeMap : EntityTypeConfiguration<MOL_LaborOffice>
    {
        public MOL_LaborOfficeMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_LaborOfficeId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(40);

            this.Property(t => t.District)
                .HasMaxLength(30);

            this.Property(t => t.Street)
                .HasMaxLength(30);

            this.Property(t => t.PostalCode)
                .HasMaxLength(7);

            this.Property(t => t.ZipCode)
                .HasMaxLength(7);

            this.Property(t => t.Telephone1)
                .HasMaxLength(9);

            this.Property(t => t.Telephone2)
                .HasMaxLength(9);

            this.Property(t => t.Fax)
                .HasMaxLength(9);

            this.Property(t => t.ManagerName)
                .HasMaxLength(25);

            this.Property(t => t.BenChapterNo)
                .HasMaxLength(3);

            this.Property(t => t.BenBranchNo)
                .HasMaxLength(3);

            this.Property(t => t.BenSectionNo)
                .HasMaxLength(3);

            this.Property(t => t.BenSequenceNo)
                .HasMaxLength(3);

            this.Property(t => t.BenSubDepartmentsCount)
                .HasMaxLength(3);

            this.Property(t => t.BenSubSectionsCount)
                .HasMaxLength(3);

            this.Property(t => t.DepChapterNo)
                .HasMaxLength(3);

            this.Property(t => t.DepBranchNo)
                .HasMaxLength(3);

            this.Property(t => t.DepSectionNo)
                .HasMaxLength(3);

            this.Property(t => t.DepSequenceNo)
                .HasMaxLength(3);

            this.Property(t => t.DepSubDepartmentsCount)
                .HasMaxLength(3);

            this.Property(t => t.DepSubSectionsCount)
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("MOL_LaborOffice");
            this.Property(t => t.PK_LaborOfficeId).HasColumnName("PK_LaborOfficeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.FK_BankId).HasColumnName("FK_BankId");
            this.Property(t => t.AccountNumber).HasColumnName("AccountNumber");
            this.Property(t => t.Balance).HasColumnName("Balance");
            this.Property(t => t.FK_CityId).HasColumnName("FK_CityId");
            this.Property(t => t.District).HasColumnName("District");
            this.Property(t => t.Street).HasColumnName("Street");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");
            this.Property(t => t.Telephone1).HasColumnName("Telephone1");
            this.Property(t => t.Telephone2).HasColumnName("Telephone2");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.ManagerName).HasColumnName("ManagerName");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.FK_ZoneId).HasColumnName("FK_ZoneId");
            this.Property(t => t.BenChapterNo).HasColumnName("BenChapterNo");
            this.Property(t => t.BenBranchNo).HasColumnName("BenBranchNo");
            this.Property(t => t.BenSectionNo).HasColumnName("BenSectionNo");
            this.Property(t => t.BenSequenceNo).HasColumnName("BenSequenceNo");
            this.Property(t => t.BenSubDepartmentsCount).HasColumnName("BenSubDepartmentsCount");
            this.Property(t => t.BenSubSectionsCount).HasColumnName("BenSubSectionsCount");
            this.Property(t => t.DepChapterNo).HasColumnName("DepChapterNo");
            this.Property(t => t.DepBranchNo).HasColumnName("DepBranchNo");
            this.Property(t => t.DepSectionNo).HasColumnName("DepSectionNo");
            this.Property(t => t.DepSequenceNo).HasColumnName("DepSequenceNo");
            this.Property(t => t.DepSubDepartmentsCount).HasColumnName("DepSubDepartmentsCount");
            this.Property(t => t.DepSubSectionsCount).HasColumnName("DepSubSectionsCount");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasOptional(t => t.Lookup_Bank)
                .WithMany(t => t.MOL_LaborOffice)
                .HasForeignKey(d => d.FK_BankId);
            this.HasOptional(t => t.Lookup_City)
                .WithMany(t => t.MOL_LaborOffice)
                .HasForeignKey(d => d.FK_CityId);
            this.HasOptional(t => t.Lookup_Zone)
                .WithMany(t => t.MOL_LaborOffice)
                .HasForeignKey(d => d.FK_ZoneId);

        }
    }
}
