namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_OwnerMap : EntityTypeConfiguration<MOL_Owner>
    {
        public MOL_OwnerMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_OwnerId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.IdNo)
                .HasMaxLength(15);

            this.Property(t => t.IdSource)
                .HasMaxLength(50);

            this.Property(t => t.District)
                .HasMaxLength(30);

            this.Property(t => t.Street)
                .HasMaxLength(30);

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

            this.Property(t => t.MOIName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MOL_Owner");
            this.Property(t => t.PK_OwnerId).HasColumnName("PK_OwnerId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.FK_NationalityId).HasColumnName("FK_NationalityId");
            this.Property(t => t.IdNo).HasColumnName("IdNo");
            this.Property(t => t.IdExpiryDate).HasColumnName("IdExpiryDate");
            this.Property(t => t.IdSource).HasColumnName("IdSource");
            this.Property(t => t.FK_GenderId).HasColumnName("FK_GenderId");
            this.Property(t => t.FK_CityId).HasColumnName("FK_CityId");
            this.Property(t => t.District).HasColumnName("District");
            this.Property(t => t.Street).HasColumnName("Street");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");
            this.Property(t => t.Telephone1).HasColumnName("Telephone1");
            this.Property(t => t.Telephone2).HasColumnName("Telephone2");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.FK_CurrentLaborOfficeId).HasColumnName("FK_CurrentLaborOfficeId");
            this.Property(t => t.UpdatedByMOI).HasColumnName("UpdatedByMOI");
            this.Property(t => t.MOIName).HasColumnName("MOIName");
            this.Property(t => t.IsVerified).HasColumnName("IsVerified");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasOptional(t => t.Enum_Gender)
                .WithMany(t => t.MOL_Owner)
                .HasForeignKey(d => d.FK_GenderId);
            this.HasRequired(t => t.Lookup_City)
                .WithMany(t => t.MOL_Owner)
                .HasForeignKey(d => d.FK_CityId);
            this.HasOptional(t => t.Lookup_Nationality)
                .WithMany(t => t.MOL_Owner)
                .HasForeignKey(d => d.FK_NationalityId);
            this.HasOptional(t => t.MOL_LaborOffice)
                .WithMany(t => t.MOL_Owner)
                .HasForeignKey(d => d.FK_CurrentLaborOfficeId);

        }
    }
}
