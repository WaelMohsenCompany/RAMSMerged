namespace MOL.EFDAL.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class Overdue_EstablishmentMap : EntityTypeConfiguration<Overdue_Establishment>
    {
        public Overdue_EstablishmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Overdue_Establishment", "FN");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Establishment_Id).HasColumnName("Establishment_Id");
        }
    }
}
