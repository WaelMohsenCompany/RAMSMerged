namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_AuditTrailsMap : EntityTypeConfiguration<MOL_AuditTrails>
    {
        public MOL_AuditTrailsMap()
        {
            // Primary Key
            this.HasKey(t => t.AuditId);

            // Properties
            this.Property(t => t.AuditedTableName)
                .HasMaxLength(100);

            this.Property(t => t.FieldName)
                .HasMaxLength(100);

            this.Property(t => t.ObjectName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MOL_AuditTrails");
            this.Property(t => t.AuditId).HasColumnName("AuditId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.FK_AuditActionId).HasColumnName("FK_AuditActionId");
            this.Property(t => t.AuditedTableName).HasColumnName("AuditedTableName");
            this.Property(t => t.FieldName).HasColumnName("FieldName");
            this.Property(t => t.OldValue).HasColumnName("OldValue");
            this.Property(t => t.NewValue).HasColumnName("NewValue");
            this.Property(t => t.AuditDateTime).HasColumnName("AuditDateTime");
            this.Property(t => t.ObjectName).HasColumnName("ObjectName");
            this.Property(t => t.ObjectId).HasColumnName("ObjectId");
        }
    }
}
