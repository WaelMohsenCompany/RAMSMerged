namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VwOEFElectronicInquiriesMap : EntityTypeConfiguration<MOL_VwOEFElectronicInquiries>
    {
        public MOL_VwOEFElectronicInquiriesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.OEFSequenceNumber, t.EstablishmentStatusId, t.EstablishmentStatusName });

            // Properties
            this.Property(t => t.OEFSequenceNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EstablishmentStatusId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EstablishmentStatusName)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MOL_VwOEFElectronicInquiries");
            this.Property(t => t.OEFLaborOfficeId).HasColumnName("OEFLaborOfficeId");
            this.Property(t => t.OEFHijriYear).HasColumnName("OEFHijriYear");
            this.Property(t => t.OEFSequenceNumber).HasColumnName("OEFSequenceNumber");
            this.Property(t => t.OEFEstablishmentId).HasColumnName("OEFEstablishmentId");
            this.Property(t => t.OEFUserId).HasColumnName("OEFUserId");
            this.Property(t => t.OEFCreatedOn).HasColumnName("OEFCreatedOn");
            this.Property(t => t.UserIdNumber).HasColumnName("UserIdNumber");
            this.Property(t => t.EstablishmentStatusId).HasColumnName("EstablishmentStatusId");
            this.Property(t => t.EstablishmentStatusName).HasColumnName("EstablishmentStatusName");
        }
    }
}
