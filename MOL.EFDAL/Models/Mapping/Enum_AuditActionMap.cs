namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Enum_AuditActionMap : EntityTypeConfiguration<Enum_AuditAction>
    {
        public Enum_AuditActionMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_AudiActionId);

            // Properties
            this.Property(t => t.AuditAction)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Enum_AuditAction");
            this.Property(t => t.PK_AudiActionId).HasColumnName("PK_AudiActionId");
            this.Property(t => t.AuditAction).HasColumnName("AuditAction");
        }
    }
}
