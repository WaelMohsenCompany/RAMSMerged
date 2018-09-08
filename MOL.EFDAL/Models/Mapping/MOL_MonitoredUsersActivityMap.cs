namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_MonitoredUsersActivityMap : EntityTypeConfiguration<MOL_MonitoredUsersActivity>
    {
        public MOL_MonitoredUsersActivityMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.SessionID)
                .HasMaxLength(200);

            this.Property(t => t.UserIDNumber)
                .HasMaxLength(10);

            this.Property(t => t.IP)
                .HasMaxLength(100);


            // Table & Column Mappings
            this.ToTable("MOL_MonitoredUsersActivity");

            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AuditDate).HasColumnName("AuditDate");
            this.Property(t => t.SessionID).HasColumnName("SessionID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserIDNumber).HasColumnName("UserIDNumber");
            this.Property(t => t.IP).HasColumnName("IP");
            this.Property(t => t.CurrentURL).HasColumnName("CurrentURL");
            this.Property(t => t.ServiceID).HasColumnName("ServiceID");
            this.Property(t => t.EstablishmentID).HasColumnName("EstablishmentID");

            // Relationships
        }
    }
}

