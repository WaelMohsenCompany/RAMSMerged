namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentAgentMap : EntityTypeConfiguration<MOL_EstablishmentAgent>
    {
        public MOL_EstablishmentAgentMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EstablishmentAgentId);

            // Properties
            this.Property(t => t.AgencyNo)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.AgencySource)
                .HasMaxLength(30);

            this.Property(t => t.AgencyDescription)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.StopAgencyReason)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentAgent");
            this.Property(t => t.PK_EstablishmentAgentId).HasColumnName("PK_EstablishmentAgentId");
            this.Property(t => t.FK_AgentTypeId).HasColumnName("FK_AgentTypeId");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.FK_UnifiedNumberId).HasColumnName("FK_UnifiedNumberId");
            this.Property(t => t.FK_AgentId).HasColumnName("FK_AgentId");
            this.Property(t => t.AgencyNo).HasColumnName("AgencyNo");
            this.Property(t => t.AgencySource).HasColumnName("AgencySource");
            this.Property(t => t.AgencyReleaseDate).HasColumnName("AgencyReleaseDate");
            this.Property(t => t.AgencyEndDate).HasColumnName("AgencyEndDate");
            this.Property(t => t.AgencyDescription).HasColumnName("AgencyDescription");
            this.Property(t => t.StopAgency).HasColumnName("StopAgency");
            this.Property(t => t.StopAgencyDate).HasColumnName("StopAgencyDate");
            this.Property(t => t.StopAgencyReason).HasColumnName("StopAgencyReason");
            this.Property(t => t.IsVerified).HasColumnName("IsVerified");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasRequired(t => t.Enum_AgentType)
                .WithMany(t => t.MOL_EstablishmentAgent)
                .HasForeignKey(d => d.FK_AgentTypeId);
            this.HasRequired(t => t.MOL_Agent)
                .WithMany(t => t.MOL_EstablishmentAgent)
                .HasForeignKey(d => d.FK_AgentId);
            this.HasOptional(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_EstablishmentAgent)
                .HasForeignKey(d => d.FK_EstablishmentId);
            this.HasOptional(t => t.MOL_UnifiedNumber)
                .WithMany(t => t.MOL_EstablishmentAgent)
                .HasForeignKey(d => d.FK_UnifiedNumberId);

        }
    }
}
