namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_MunicipalityMap : EntityTypeConfiguration<Lookup_Municipality>
    {
        public Lookup_MunicipalityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Lookup_Municipality");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");

            // Relationships
            this.HasRequired(t => t.MOL_LaborOffice)
                .WithMany(t => t.Lookup_Municipality)
                .HasForeignKey(d => d.FK_LaborOfficeId);

        }
    }
}
