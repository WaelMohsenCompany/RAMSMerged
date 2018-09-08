namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_JobMap : EntityTypeConfiguration<Lookup_Job>
    {
        public Lookup_JobMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.JobCode)
                .HasMaxLength(100);

            this.Property(t => t.QsimCode)
                .HasMaxLength(3);

            this.Property(t => t.JzaCode)
                .HasMaxLength(3);

            this.Property(t => t.BabCode)
                .HasMaxLength(3);

            this.Property(t => t.FslCode)
                .HasMaxLength(3);

            this.Property(t => t.MhnCode)
                .HasMaxLength(3);

            this.Property(t => t.MstCode)
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("Lookup_Job");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.IsForSaudiOnly).HasColumnName("IsForSaudiOnly");
            this.Property(t => t.JobCode).HasColumnName("JobCode");
            this.Property(t => t.IsIncludedForEWV).HasColumnName("IsIncludedForEWV");
            this.Property(t => t.QsimCode).HasColumnName("QsimCode");
            this.Property(t => t.JzaCode).HasColumnName("JzaCode");
            this.Property(t => t.BabCode).HasColumnName("BabCode");
            this.Property(t => t.FslCode).HasColumnName("FslCode");
            this.Property(t => t.MhnCode).HasColumnName("MhnCode");
            this.Property(t => t.MstCode).HasColumnName("MstCode");
            this.Property(t => t.CanChangeOnline).HasColumnName("CanChangeOnline");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsValidWPJob).HasColumnName("IsValidWPJob");
            this.Property(t => t.isGovSupportEWV).HasColumnName("isGovSupportEWV");
            this.Property(t => t.IsEngineeringJob).HasColumnName("IsEngineeringJob");
            this.Property(t => t.IsValid1_5ForIstiqdam).HasColumnName("IsValid1_5ForIstiqdam");
            this.Property(t => t.IsHomeJob).HasColumnName("IsHomeJob");
            this.Property(t => t.IsBlockedForSeasonalVisas).HasColumnName("IsBlockedForSeasonalVisas");
            this.Property(t => t.IsMedicalJob).HasColumnName("IsMedicalJob");
        }
    }
}
