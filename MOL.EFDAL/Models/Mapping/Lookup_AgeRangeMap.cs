namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_AgeRangeMap : EntityTypeConfiguration<Lookup_AgeRange>
    {
        public Lookup_AgeRangeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Lookup_AgeRange");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.LowerLimit).HasColumnName("LowerLimit");
            this.Property(t => t.UpperLimit).HasColumnName("UpperLimit");
        }
    }
}
