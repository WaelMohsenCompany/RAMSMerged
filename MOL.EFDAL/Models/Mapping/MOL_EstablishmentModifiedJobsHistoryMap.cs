namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentModifiedJobsHistoryMap : EntityTypeConfiguration<MOL_EstablishmentModifiedJobsHistory>
    {
        public MOL_EstablishmentModifiedJobsHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentModifiedJobsHistory");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CreditId).HasColumnName("CreditId");
            this.Property(t => t.OldJobId).HasColumnName("OldJobId");
            this.Property(t => t.NewJobId).HasColumnName("NewJobId");
            this.Property(t => t.OldGenderId).HasColumnName("OldGenderId");
            this.Property(t => t.NewGenderId).HasColumnName("NewGenderId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
