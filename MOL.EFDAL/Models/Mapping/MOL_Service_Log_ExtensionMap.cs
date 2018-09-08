namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Service_Log_ExtensionMap : EntityTypeConfiguration<MOL_Service_Log_Extension>
    {
        public MOL_Service_Log_ExtensionMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_LogId);

            // Properties
            this.Property(t => t.LaborerIdNo_BorderNo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Reason)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.ClientComputerName)
               .HasMaxLength(50);

            this.Property(t => t.LaborerName)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("MOL_Service_Log_Extension");
            this.Property(t => t.PK_LogId).HasColumnName("PK_LogId");
            this.Property(t => t.FK_ServiceLogId).HasColumnName("FK_ServiceLogId");
            this.Property(t => t.LaborerIdNo_BorderNo).HasColumnName("LaborerIdNo_BorderNo");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.RunawayDate).HasColumnName("RunawayDate");
            this.Property(t => t.ClientComputerName).HasColumnName("ClientComputerName");
            this.Property(t => t.LaborerName).HasColumnName("LaborerName");

            // Relationships
            this.HasRequired(t => t.MOL_Service_Log)
                .WithMany(t => t.MOL_Service_Log_Extension)
                .HasForeignKey(d => d.FK_ServiceLogId);

        }
    }
}
