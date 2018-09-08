namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Gov_AgencyMap : EntityTypeConfiguration<Gov_Agency>
    {
        public Gov_AgencyMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Recipients)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Gov_Agency", "UM");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Statistics_Report_Enabled).HasColumnName("Statistics_Report_Enabled");
            this.Property(t => t.Recipients).HasColumnName("Recipients");
            this.Property(t => t.Parent_Agency_Id).HasColumnName("Parent_Agency_Id");
        }
    }
}
