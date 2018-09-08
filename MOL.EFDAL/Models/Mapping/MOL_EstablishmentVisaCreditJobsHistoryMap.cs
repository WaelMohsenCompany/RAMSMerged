using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    public class MOL_EstablishmentVisaCreditJobsHistoryMap : EntityTypeConfiguration<MOL_EstablishmentVisaCreditJobsHistory>
    {
        public MOL_EstablishmentVisaCreditJobsHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentVisaCreditJobsHistory");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ConsumerID).HasColumnName("ConsumerID");
            this.Property(t => t.OperationVisaCreditID).HasColumnName("OperationVisaCreditID");
            this.Property(t => t.VisaCreditJobID).HasColumnName("VisaCreditJobID");
            this.Property(t => t.JobID).HasColumnName("JobID");
            this.Property(t => t.GenderID).HasColumnName("GenderID");
            this.Property(t => t.ApprovedCredit).HasColumnName("ApprovedCredit");
            this.Property(t => t.UsedCredit).HasColumnName("UsedCredit");
            this.Property(t => t.AvailableCredit).HasColumnName("AvailableCredit");
            this.Property(t => t.OperationTypeID).HasColumnName("OperationTypeID");
            this.Property(t => t.OperationValue).HasColumnName("OperationValue");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.TransactionLogID).HasColumnName("TransactionLogID");

            // Relationships
            this.HasRequired(t => t.Enum_EstablishmentVisaCreditJobOperationType)
                .WithMany(t => t.MOL_EstablishmentVisaCreditJobsHistory)
                .HasForeignKey(d => d.OperationTypeID);
            this.HasRequired(t => t.Enum_Gender)
                .WithMany(t => t.MOL_EstablishmentVisaCreditJobsHistory)
                .HasForeignKey(d => d.GenderID);
            this.HasRequired(t => t.Lookup_EstablishmentVisaCreditServiceConsumers)
                .WithMany(t => t.MOL_EstablishmentVisaCreditJobsHistory)
                .HasForeignKey(d => d.ConsumerID);
            this.HasRequired(t => t.Lookup_Job)
                .WithMany(t => t.MOL_EstablishmentVisaCreditJobsHistory)
                .HasForeignKey(d => d.JobID);
            this.HasRequired(t => t.MOL_EstablishmentVisaCreditJobs)
                .WithMany(t => t.MOL_EstablishmentVisaCreditJobsHistory)
                .HasForeignKey(d => d.VisaCreditJobID);
            this.HasRequired(t => t.MOL_User)
                .WithMany(t => t.MOL_EstablishmentVisaCreditJobsHistory)
                .HasForeignKey(d => d.CreatedBy);

        }
    }
}
