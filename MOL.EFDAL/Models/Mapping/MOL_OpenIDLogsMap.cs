namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_OpenIDLogsMap : EntityTypeConfiguration<MOL_OpenIDLogs>
    {
        public MOL_OpenIDLogsMap()
        {
            // Primary Key
            this.HasKey(t => t.OLog_PK);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_OpenIDLogs");
            this.Property(t => t.OLog_PK).HasColumnName("OLog_PK");
            this.Property(t => t.OLog_Message).HasColumnName("OLog_Message");
            this.Property(t => t.OLog_timestamp).HasColumnName("OLog_timestamp");
        }
    }
}
