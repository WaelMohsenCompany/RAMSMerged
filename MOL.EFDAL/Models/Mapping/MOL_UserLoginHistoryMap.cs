namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_UserLoginHistoryMap : EntityTypeConfiguration<MOL_UserLoginHistory>
    {
        public MOL_UserLoginHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.SessionID)
                .HasMaxLength(200);

            this.Property(t => t.ClientIP)
                .HasMaxLength(100);

            this.Property(t => t.ServerIP)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MOL_UserLoginHistory");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.AuditDate).HasColumnName("AuditDate");
            this.Property(t => t.SessionID).HasColumnName("SessionID");
            this.Property(t => t.ClientIP).HasColumnName("ClientIP");
            this.Property(t => t.LoginSourceID).HasColumnName("LoginSourceID");
            this.Property(t => t.ServerIP).HasColumnName("ServerIP");

            // Relationships
            this.HasRequired(t => t.MOL_User)
                .WithMany(t => t.MOL_UserLoginHistory)
                .HasForeignKey(d => d.UserID);

        }
    }
}

