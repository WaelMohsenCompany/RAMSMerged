namespace MOL.EFDAL.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    class MOL_VwLaborer_Audit_GetEstablishmentsHistoryMap : EntityTypeConfiguration<MOL_VwLaborer_Audit_GetEstablishmentsHistory>
    {
        public MOL_VwLaborer_Audit_GetEstablishmentsHistoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.FK_LaborOfficeId, t.SequenceNumber, t.Name });

            // Properties
            this.Property(t => t.FK_LaborOfficeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SequenceNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(60);

            // Table & Column Mappings
            this.ToTable("MOL_VwLaborer_Audit_GetEstablishmentsHistory");
            this.Property(t => t.PK_LaborerId).HasColumnName("PK_LaborerId");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ServiceStartDate).HasColumnName("ServiceStartDate");
        }
    }
}
