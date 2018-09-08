namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentProfileMap : EntityTypeConfiguration<MOL_EstablishmentProfile>
    {
        public MOL_EstablishmentProfileMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EstablishmentProfileId);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.AddressLine1)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.AddressLine2)
                .HasMaxLength(100);

            this.Property(t => t.Website)
                .HasMaxLength(100);

            this.Property(t => t.ActivationStatusChangeReason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentProfile");
            this.Property(t => t.PK_EstablishmentProfileId).HasColumnName("PK_EstablishmentProfileId");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AddressLine1).HasColumnName("AddressLine1");
            this.Property(t => t.AddressLine2).HasColumnName("AddressLine2");
            this.Property(t => t.FK_CityId).HasColumnName("FK_CityId");
            this.Property(t => t.Website).HasColumnName("Website");
            this.Property(t => t.LastModified).HasColumnName("LastModified");
            this.Property(t => t.FK_LastModifiedUser).HasColumnName("FK_LastModifiedUser");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.FK_CreatedBy).HasColumnName("FK_CreatedBy");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.ActivationStatusChangeReason).HasColumnName("ActivationStatusChangeReason");

            // Relationships
            this.HasRequired(t => t.Lookup_City)
                .WithMany(t => t.MOL_EstablishmentProfile)
                .HasForeignKey(d => d.FK_CityId);
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_EstablishmentProfile)
                .HasForeignKey(d => d.FK_EstablishmentId);
            this.HasRequired(t => t.MOL_User)
                .WithMany(t => t.MOL_EstablishmentProfile)
                .HasForeignKey(d => d.FK_LastModifiedUser);
            this.HasRequired(t => t.MOL_User1)
                .WithMany(t => t.MOL_EstablishmentProfile1)
                .HasForeignKey(d => d.FK_CreatedBy);

        }
    }
}
