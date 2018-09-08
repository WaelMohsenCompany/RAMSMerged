namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentSelectLogMap : EntityTypeConfiguration<MOL_EstablishmentSelectLog>
    {
        public MOL_EstablishmentSelectLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ServerIP)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ClientIP)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SessionID)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentSelectLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ActualUserType).HasColumnName("ActualUserType");
            this.Property(t => t.EstablishmentID).HasColumnName("EstablishmentID");
            this.Property(t => t.LoggedUserID).HasColumnName("LoggedUserID");
            this.Property(t => t.LoggedUserIdNo).HasColumnName("LoggedUserIdNo");
            this.Property(t => t.ImpersonatedUserIdNo).HasColumnName("ImpersonatedUserIdNo");
            this.Property(t => t.ImpersonatedUserType).HasColumnName("ImpersonatedUserType");
            this.Property(t => t.ServerIP).HasColumnName("ServerIP");
            this.Property(t => t.ClientIP).HasColumnName("ClientIP");
            this.Property(t => t.SessionID).HasColumnName("SessionID");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
        }
    }
}
