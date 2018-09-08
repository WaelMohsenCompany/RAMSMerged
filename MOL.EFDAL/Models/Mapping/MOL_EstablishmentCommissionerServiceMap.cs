namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentCommissionerServiceMap : EntityTypeConfiguration<MOL_EstablishmentCommissionerService>
    {
        public MOL_EstablishmentCommissionerServiceMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EstablishmentCommissionerServiceId);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentCommissionerService");
            this.Property(t => t.PK_EstablishmentCommissionerServiceId).HasColumnName("PK_EstablishmentCommissionerServiceId");
            this.Property(t => t.FK_EstablishmentCommissionerId).HasColumnName("FK_EstablishmentCommissionerId");
            this.Property(t => t.FK_ServiceId).HasColumnName("FK_ServiceId");

            // Relationships
            this.HasRequired(t => t.Enum_Service)
                .WithMany(t => t.MOL_EstablishmentCommissionerService)
                .HasForeignKey(d => d.FK_ServiceId);
            this.HasRequired(t => t.MOL_EstablishmentCommissioner)
                .WithMany(t => t.MOL_EstablishmentCommissionerService)
                .HasForeignKey(d => d.FK_EstablishmentCommissionerId);

        }
    }
}
