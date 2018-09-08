namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_DownloadMap : EntityTypeConfiguration<MOL_Download>
    {
        public MOL_DownloadMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_Download");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DownloadGuid).HasColumnName("DownloadGuid");
            this.Property(t => t.ContentType).HasColumnName("ContentType");
            this.Property(t => t.Filename).HasColumnName("Filename");
            this.Property(t => t.Extension).HasColumnName("Extension");
            this.Property(t => t.Path).HasColumnName("Path");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
        }
    }
}
