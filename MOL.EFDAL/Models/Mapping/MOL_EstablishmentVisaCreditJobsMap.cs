namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentVisaCreditJobsMap : EntityTypeConfiguration<MOL_EstablishmentVisaCreditJobs>
    {
        public MOL_EstablishmentVisaCreditJobsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentVisaCreditJobs");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.VisaCreditID).HasColumnName("VisaCreditID");
            this.Property(t => t.JobID).HasColumnName("JobID");
            this.Property(t => t.GenderID).HasColumnName("GenderID");
            this.Property(t => t.ApprovedCredit).HasColumnName("ApprovedCredit");
            this.Property(t => t.UsedCredit).HasColumnName("UsedCredit");
            this.Property(t => t.AvailableCredit).HasColumnName("AvailableCredit");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");

            // Relationships
            this.HasRequired(t => t.Enum_Gender)
                .WithMany(t => t.MOL_EstablishmentVisaCreditJobs)
                .HasForeignKey(d => d.GenderID);
            this.HasRequired(t => t.Lookup_Job)
                .WithMany(t => t.MOL_EstablishmentVisaCreditJobs)
                .HasForeignKey(d => d.JobID);
            this.HasRequired(t => t.MOL_EstablishmentVisaCredit)
                .WithMany(t => t.MOL_EstablishmentVisaCreditJobs)
                .HasForeignKey(d => d.VisaCreditID);
            this.HasOptional(t => t.MOL_User)
                .WithMany(t => t.MOL_EstablishmentVisaCreditJobs)
                .HasForeignKey(d => d.LastModifiedBy);
            this.HasRequired(t => t.MOL_User1)
                .WithMany(t => t.MOL_EstablishmentVisaCreditJobs1)
                .HasForeignKey(d => d.CreatedBy);

        }
    }
}
