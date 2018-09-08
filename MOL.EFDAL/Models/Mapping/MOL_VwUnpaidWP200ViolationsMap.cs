namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VwUnpaidWP200ViolationsMap : EntityTypeConfiguration<MOL_VwUnpaidWP200Violations>
    {
        public MOL_VwUnpaidWP200ViolationsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.FK_UnifiedNumberId, t.TotalDueUnits });

            // Properties
            this.Property(t => t.FK_UnifiedNumberId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TotalDueUnits)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MOL_VwUnpaidWP200Violations");
            this.Property(t => t.FK_UnifiedNumberId).HasColumnName("FK_UnifiedNumberId");
            this.Property(t => t.TotalDueUnits).HasColumnName("TotalDueUnits");
        }
    }
}
