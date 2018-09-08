namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VwCEAJobLaborersCountMap : EntityTypeConfiguration<MOL_VwCEAJobLaborersCount>
    {
        public MOL_VwCEAJobLaborersCountMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EstablishmentId, t.JobId, t.Job });

            // Properties
            this.Property(t => t.EstablishmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.JobId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Job)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MOL_VwCEAJobLaborersCount");
            this.Property(t => t.EstablishmentId).HasColumnName("EstablishmentId");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.Job).HasColumnName("Job");
            this.Property(t => t.LaborersCount).HasColumnName("LaborersCount");
        }
    }
}
