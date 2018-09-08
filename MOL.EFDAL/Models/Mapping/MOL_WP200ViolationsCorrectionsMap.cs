namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_WP200ViolationsCorrectionsMap : EntityTypeConfiguration<MOL_WP200ViolationsCorrections>
    {
        public MOL_WP200ViolationsCorrectionsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_WP200ViolationsCorrections");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FK_WP200ViolatedUNId).HasColumnName("FK_WP200ViolatedUNId");
            this.Property(t => t.FK_Service_TransactionId).HasColumnName("FK_Service_TransactionId");
            this.Property(t => t.FK_Service_LastServiceStatusId).HasColumnName("FK_Service_LastServiceStatusId");
        }
    }
}
