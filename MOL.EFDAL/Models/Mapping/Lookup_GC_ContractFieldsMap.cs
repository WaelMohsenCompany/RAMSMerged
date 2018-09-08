namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_GC_ContractFieldsMap : EntityTypeConfiguration<Lookup_GC_ContractFields>
    {
        public Lookup_GC_ContractFieldsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Lookup_GC_ContractFields");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LaborCostRatio).HasColumnName("LaborCostRatio");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
        }
    }
}
