namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EconomicActivityStatementMap : EntityTypeConfiguration<MOL_EconomicActivityStatement>
    {
        public MOL_EconomicActivityStatementMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_EconomicActivityStatement");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FK_EconomicActivityId).HasColumnName("FK_EconomicActivityId");
            this.Property(t => t.FK_StatementsTypeId).HasColumnName("FK_StatementsTypeId");
            this.Property(t => t.IsRequired).HasColumnName("IsRequired");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModificationDate).HasColumnName("ModificationDate");
        }
    }
}
