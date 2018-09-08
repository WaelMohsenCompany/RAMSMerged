namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_IssuedVisasMap : EntityTypeConfiguration<MOL_IssuedVisas>
    {
        public MOL_IssuedVisasMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_VisaID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_IssuedVisas");
            this.Property(t => t.PK_VisaID).HasColumnName("PK_VisaID");
            this.Property(t => t.FK_VisaIssueRequestID).HasColumnName("FK_VisaIssueRequestID");
            this.Property(t => t.BorderNumber).HasColumnName("BorderNumber");
            this.Property(t => t.Fk_JobID).HasColumnName("Fk_JobID");
            this.Property(t => t.FK_NationalityID).HasColumnName("FK_NationalityID");
            this.Property(t => t.FK_OriginID).HasColumnName("FK_OriginID");
            this.Property(t => t.FK_ReligionID).HasColumnName("FK_ReligionID");
            this.Property(t => t.FK_GenderID).HasColumnName("FK_GenderID");
            this.Property(t => t.VisaStatus).HasColumnName("VisaStatus");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.CreditID).HasColumnName("CreditID");
            this.Property(t => t.CreditType).HasColumnName("CreditType");
            this.Property(t => t.IsRefunded).HasColumnName("IsRefunded");

            // Relationships
            this.HasRequired(t => t.MOL_VisaIssueRequests)
                .WithMany(t => t.MOL_IssuedVisas)
                .HasForeignKey(d => d.FK_VisaIssueRequestID);

        }
    }
}
