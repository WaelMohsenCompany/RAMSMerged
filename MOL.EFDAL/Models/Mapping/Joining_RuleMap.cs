using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    public class Joining_RuleMap : EntityTypeConfiguration<Joining_Rule>
    {
        public Joining_RuleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Joining_Rule", "FN");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
