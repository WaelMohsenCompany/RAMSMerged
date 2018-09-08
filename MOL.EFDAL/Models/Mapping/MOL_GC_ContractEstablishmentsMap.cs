namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_GC_ContractEstablishmentsMap : EntityTypeConfiguration<MOL_GC_ContractEstablishments>
    {
        public MOL_GC_ContractEstablishmentsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_GC_ContractEstablishments");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ContractID).HasColumnName("ContractID");
            this.Property(t => t.EstablishmentID).HasColumnName("EstablishmentID");
            this.Property(t => t.IssuedCredit).HasColumnName("IssuedCredit");

            // Relationships
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_GC_ContractEstablishments)
                .HasForeignKey(d => d.EstablishmentID);
            this.HasRequired(t => t.MOL_GC_Contracts)
                .WithMany(t => t.MOL_GC_ContractEstablishments)
                .HasForeignKey(d => d.ContractID);

        }
    }
}
