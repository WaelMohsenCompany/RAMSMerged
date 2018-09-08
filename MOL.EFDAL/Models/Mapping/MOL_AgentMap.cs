namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_AgentMap : EntityTypeConfiguration<MOL_Agent>
    {
        public MOL_AgentMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_AgentId);

            // Properties
            this.Property(t => t.AgentName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.IdNo)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.IdSource)
                .IsRequired()
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
                .HasMaxLength(9);

            this.Property(t => t.Telephone2)
                .HasMaxLength(9);

            this.Property(t => t.Fax)
                .HasMaxLength(9);

            // Table & Column Mappings
            this.ToTable("MOL_Agent");
            this.Property(t => t.PK_AgentId).HasColumnName("PK_AgentId");
            this.Property(t => t.AgentName).HasColumnName("AgentName");
            this.Property(t => t.IdNo).HasColumnName("IdNo");
            this.Property(t => t.IdSource).HasColumnName("IdSource");
            this.Property(t => t.IdReleaseDate).HasColumnName("IdReleaseDate");
            this.Property(t => t.FK_CityId).HasColumnName("FK_CityId");
            this.Property(t => t.District).HasColumnName("District");
            this.Property(t => t.Street).HasColumnName("Street");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");
            this.Property(t => t.Telephone1).HasColumnName("Telephone1");
            this.Property(t => t.Telephone2).HasColumnName("Telephone2");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.FK_CurrentLaborOffice).HasColumnName("FK_CurrentLaborOffice");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasRequired(t => t.Lookup_City)
                .WithMany(t => t.MOL_Agent)
                .HasForeignKey(d => d.FK_CityId);
            this.HasOptional(t => t.MOL_LaborOffice)
                .WithMany(t => t.MOL_Agent)
                .HasForeignKey(d => d.FK_CurrentLaborOffice);

        }
    }
}
