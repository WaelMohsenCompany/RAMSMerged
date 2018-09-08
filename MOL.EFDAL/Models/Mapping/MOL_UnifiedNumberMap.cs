namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_UnifiedNumberMap : EntityTypeConfiguration<MOL_UnifiedNumber>
    {
        public MOL_UnifiedNumberMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_UnifiedNumberId);

            // Properties
            this.Property(t => t.SevenHundredNumber)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("MOL_UnifiedNumber");
            this.Property(t => t.PK_UnifiedNumberId).HasColumnName("PK_UnifiedNumberId");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.FK_EstablishmentTypeId).HasColumnName("FK_EstablishmentTypeId");
            this.Property(t => t.FK_NationalityId).HasColumnName("FK_NationalityId");
            this.Property(t => t.FK_LawRepresentationId).HasColumnName("FK_LawRepresentationId");
            this.Property(t => t.SevenHundredNumber).HasColumnName("SevenHundredNumber");
            this.Property(t => t.FK_OwnerId).HasColumnName("FK_OwnerId");
            this.Property(t => t.CommercialRecordSequenceNumber).HasColumnName("CommercialRecordSequenceNumber");
            this.Property(t => t.FK_FirstEstablishment).HasColumnName("FK_FirstEstablishment");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.MCI700UsageStatus).HasColumnName("MCI700UsageStatus");

            // Relationships
            this.HasOptional(t => t.Enum_EstablishmentType)
                .WithMany(t => t.MOL_UnifiedNumber)
                .HasForeignKey(d => d.FK_EstablishmentTypeId);
            this.HasOptional(t => t.Lookup_LawRepresentation)
                .WithMany(t => t.MOL_UnifiedNumber)
                .HasForeignKey(d => d.FK_LawRepresentationId);
            this.HasRequired(t => t.Lookup_Nationality)
                .WithMany(t => t.MOL_UnifiedNumber)
                .HasForeignKey(d => d.FK_NationalityId);
            this.HasRequired(t => t.MOL_LaborOffice)
                .WithMany(t => t.MOL_UnifiedNumber)
                .HasForeignKey(d => d.FK_LaborOfficeId);
            this.HasOptional(t => t.MOL_Owner)
                .WithMany(t => t.MOL_UnifiedNumber)
                .HasForeignKey(d => d.FK_OwnerId);

        }
    }
}
