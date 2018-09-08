namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_FakeEmploymentReportCommentOwnerMap : EntityTypeConfiguration<MOL_FakeEmploymentReportCommentOwner>
    {
        public MOL_FakeEmploymentReportCommentOwnerMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_FakeEmploymentReportCommentOwnerId);

            // Properties
            this.Property(t => t.OwnerType)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("MOL_FakeEmploymentReportCommentOwner");
            this.Property(t => t.PK_FakeEmploymentReportCommentOwnerId).HasColumnName("PK_FakeEmploymentReportCommentOwnerId");
            this.Property(t => t.OwnerType).HasColumnName("OwnerType");
        }
    }
}
