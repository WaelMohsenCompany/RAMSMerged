namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_CountryMap : EntityTypeConfiguration<Lookup_Country>
    {
        public Lookup_CountryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Local_Name)
                .HasMaxLength(50);

            this.Property(t => t.Nationality)
                .HasMaxLength(50);

            this.Property(t => t.Local_Nationality)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Lookup_Country");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Local_Name).HasColumnName("Local_Name");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Nationality).HasColumnName("Nationality");
            this.Property(t => t.Local_Nationality).HasColumnName("Local_Nationality");
        }
    }
}
