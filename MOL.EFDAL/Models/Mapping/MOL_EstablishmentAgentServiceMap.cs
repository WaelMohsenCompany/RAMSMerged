namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentAgentServiceMap : EntityTypeConfiguration<MOL_EstablishmentAgentService>
    {
        public MOL_EstablishmentAgentServiceMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EstablishmentAgentServiceId);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentAgentService");
            this.Property(t => t.PK_EstablishmentAgentServiceId).HasColumnName("PK_EstablishmentAgentServiceId");
            this.Property(t => t.FK_EstablishmentAgentId).HasColumnName("FK_EstablishmentAgentId");
            this.Property(t => t.FK_ServiceId).HasColumnName("FK_ServiceId");

            // Relationships
            this.HasRequired(t => t.Enum_Service)
                .WithMany(t => t.MOL_EstablishmentAgentService)
                .HasForeignKey(d => d.FK_ServiceId);
            this.HasRequired(t => t.MOL_EstablishmentAgent)
                .WithMany(t => t.MOL_EstablishmentAgentService)
                .HasForeignKey(d => d.FK_EstablishmentAgentId);

        }
    }
}
