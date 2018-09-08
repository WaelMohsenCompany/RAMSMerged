namespace MOL.EFDAL.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class Active_Program_EstablishmentMap : EntityTypeConfiguration<Active_Program_Establishment>
    {
        public Active_Program_EstablishmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Active_Program_Establishment", "FN");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Establishment_Id).HasColumnName("Establishment_Id");
        }
    }
}
