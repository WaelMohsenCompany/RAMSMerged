namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentEconomicActivityMap : EntityTypeConfiguration<MOL_EstablishmentEconomicActivity>
    {
        public MOL_EstablishmentEconomicActivityMap()
        {
            // Primary Key
            this.HasKey(t => new { t.FK_EstablishmentId, t.FK_EconomicId });

            // Properties
            this.Property(t => t.FK_EstablishmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FK_EconomicId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentEconomicActivity");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.FK_EconomicId).HasColumnName("FK_EconomicId");
        }
    }
}
