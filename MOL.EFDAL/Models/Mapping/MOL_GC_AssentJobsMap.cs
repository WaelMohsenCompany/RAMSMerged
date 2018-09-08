namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_GC_AssentJobsMap : EntityTypeConfiguration<MOL_GC_AssentJobs>
    {
        public MOL_GC_AssentJobsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_GC_AssentJobs");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AssentID).HasColumnName("AssentID");
            this.Property(t => t.JobID).HasColumnName("JobID");
            this.Property(t => t.RequiredNumber).HasColumnName("RequiredNumber");
            this.Property(t => t.GenderID).HasColumnName("GenderID");

            // Relationships
            this.HasRequired(t => t.MOL_GC_Assents)
                .WithMany(t => t.MOL_GC_AssentJobs)
                .HasForeignKey(d => d.AssentID);
        }
    }
}
