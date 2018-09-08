namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Laborer_MOI_AuditMap : EntityTypeConfiguration<MOL_Laborer_MOI_Audit>
    {
        public MOL_Laborer_MOI_AuditMap()
        {
            // Primary Key
            this.HasKey(t => t.MOLLaborerMOIAuditId);

            // Properties
            this.Property(t => t.UserName)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("MOL_Laborer_MOI_Audit");
            this.Property(t => t.MOLLaborerMOIAuditId).HasColumnName("MOLLaborerMOIAuditId");
            this.Property(t => t.UserIdNumber).HasColumnName("UserIdNumber");
            this.Property(t => t.FK_LaborerId).HasColumnName("FK_LaborerId");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
        }
    }
}
