namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_SecurableEntityTypeMap : EntityTypeConfiguration<Lookup_SecurableEntityType>
    {
        public Lookup_SecurableEntityTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Local_Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Lookup_SecurableEntityType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Local_Name).HasColumnName("Local_Name");
            this.Property(t => t.IsSystem).HasColumnName("IsSystem");
        }
    }
}
