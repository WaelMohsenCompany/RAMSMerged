namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VisaPrerequisitesDocsMap : EntityTypeConfiguration<MOL_VisaPrerequisitesDocs>
    {
        public MOL_VisaPrerequisitesDocsMap()
        {
            // Primary Key
            this.HasKey(t => t.PreRequisitID);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("MOL_VisaPrerequisitesDocs");
            this.Property(t => t.PreRequisitID).HasColumnName("PreRequisitID");
            this.Property(t => t.Sequence).HasColumnName("Sequence");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.FK_ServiceID).HasColumnName("FK_ServiceID");
        }
    }
}
