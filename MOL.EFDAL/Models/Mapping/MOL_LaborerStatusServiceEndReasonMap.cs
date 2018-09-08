namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_LaborerStatusServiceEndReasonMap : EntityTypeConfiguration<MOL_LaborerStatusServiceEndReason>
    {
        public MOL_LaborerStatusServiceEndReasonMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_LaborerStatusServiceEndReasonId);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_LaborerStatusServiceEndReason");
            this.Property(t => t.PK_LaborerStatusServiceEndReasonId).HasColumnName("PK_LaborerStatusServiceEndReasonId");
            this.Property(t => t.FK_LaborerStatusId).HasColumnName("FK_LaborerStatusId");
            this.Property(t => t.FK_ServiceEndReasonId).HasColumnName("FK_ServiceEndReasonId");

            // Relationships
            this.HasRequired(t => t.Enum_LaborerStatus)
                .WithMany(t => t.MOL_LaborerStatusServiceEndReason)
                .HasForeignKey(d => d.FK_LaborerStatusId);
            this.HasRequired(t => t.Lookup_ServiceEndReason)
                .WithMany(t => t.MOL_LaborerStatusServiceEndReason)
                .HasForeignKey(d => d.FK_ServiceEndReasonId);

        }
    }
}
