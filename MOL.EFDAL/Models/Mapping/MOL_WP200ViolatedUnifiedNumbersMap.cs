namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_WP200ViolatedUnifiedNumbersMap : EntityTypeConfiguration<MOL_WP200ViolatedUnifiedNumbers>
    {
        public MOL_WP200ViolatedUnifiedNumbersMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_WP200ViolatedUNId);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_WP200ViolatedUnifiedNumbers");
            this.Property(t => t.PK_WP200ViolatedUNId).HasColumnName("PK_WP200ViolatedUNId");
            this.Property(t => t.FK_UnifiedNumberId).HasColumnName("FK_UnifiedNumberId");
            this.Property(t => t.TotalDueUnits).HasColumnName("TotalDueUnits");
        }
    }
}
