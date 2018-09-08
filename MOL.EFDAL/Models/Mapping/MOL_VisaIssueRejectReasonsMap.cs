namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VisaIssueRejectReasonsMap : EntityTypeConfiguration<MOL_VisaIssueRejectReasons>
    {
        public MOL_VisaIssueRejectReasonsMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_ReasonID);

            // Properties
            this.Property(t => t.PK_ReasonID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ReasonDescription)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("MOL_VisaIssueRejectReasons");
            this.Property(t => t.PK_ReasonID).HasColumnName("PK_ReasonID");
            this.Property(t => t.ReasonDescription).HasColumnName("ReasonDescription");
        }
    }
}
