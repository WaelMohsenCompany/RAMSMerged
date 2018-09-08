namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentExceptionalWPMap : EntityTypeConfiguration<MOL_EstablishmentExceptionalWP>
    {
        public MOL_EstablishmentExceptionalWPMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FK_UnifiedNumberId)
                .HasMaxLength(256);

            this.Property(t => t.FK_LaborOfficeId)
                .HasMaxLength(256);

            this.Property(t => t.SequenceNumber)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentExceptionalWP");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FK_UnifiedNumberId).HasColumnName("FK_UnifiedNumberId");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
