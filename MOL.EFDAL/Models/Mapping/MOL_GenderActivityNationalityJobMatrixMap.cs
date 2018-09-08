namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_GenderActivityNationalityJobMatrixMap : EntityTypeConfiguration<MOL_GenderActivityNationalityJobMatrix>
    {
        public MOL_GenderActivityNationalityJobMatrixMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_GenderActivityNationalityJobMatrix");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.NationalityId).HasColumnName("NationalityId");
            this.Property(t => t.GenderId).HasColumnName("GenderId");
            this.Property(t => t.ActivityId).HasColumnName("ActivityId");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.IsValidRule).HasColumnName("IsValidRule");
            this.Property(t => t.ValidForCompensationVisas).HasColumnName("ValidForCompensationVisas");
            this.Property(t => t.ValidForInstantVisas).HasColumnName("ValidForInstantVisas");
            this.Property(t => t.ValidForEServicesSystem).HasColumnName("ValidForEServicesSystem");
            this.Property(t => t.ValidForMPSystem).HasColumnName("ValidForMPSystem");
        }
    }
}
