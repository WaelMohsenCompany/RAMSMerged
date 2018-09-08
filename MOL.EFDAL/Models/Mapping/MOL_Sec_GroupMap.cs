namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Sec_GroupMap : EntityTypeConfiguration<MOL_Sec_Group>
    {
        public MOL_Sec_GroupMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Local_name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_Sec_Group");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Local_name).HasColumnName("Local_name");
        }
    }
}
