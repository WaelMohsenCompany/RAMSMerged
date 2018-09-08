using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    public class UnifiedNumber_NitaqatActivity_EstablishmentMap : EntityTypeConfiguration<UnifiedNumber_NitaqatActivity_Establishment>
    {
        public UnifiedNumber_NitaqatActivity_EstablishmentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Establishment_Id, t.Pk_EstablishmentId, t.Fk_laborofficeId, t.SequenceNumber, t.Fk_UnifiedNumberId, t.EconomicActivityId });

            // Properties
            this.Property(t => t.Establishment_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Pk_EstablishmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Fk_laborofficeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SequenceNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Fk_UnifiedNumberId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EconomicActivityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("UnifiedNumber_NitaqatActivity_Establishment", "FN");
            this.Property(t => t.Establishment_Id).HasColumnName("Establishment_Id");
            this.Property(t => t.Pk_EstablishmentId).HasColumnName("Pk_EstablishmentId");
            this.Property(t => t.Fk_laborofficeId).HasColumnName("Fk_laborofficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.Fk_UnifiedNumberId).HasColumnName("Fk_UnifiedNumberId");
            this.Property(t => t.FK_SubEconomicActivityId).HasColumnName("FK_SubEconomicActivityId");
            this.Property(t => t.EconomicActivityId).HasColumnName("EconomicActivityId");
        }
    }
}
