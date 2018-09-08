namespace MOL.EFDAL.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EconomicActivity_Jobs_GenderMap : EntityTypeConfiguration<MOL_EconomicActivity_Jobs_Gender>
    {
        public MOL_EconomicActivity_Jobs_GenderMap()
        {
            // Primary Key
            this.HasKey(t => new { t.FK_EconomicActivityID, t.FK_JobID, t.IsGenderRequired });

            // Properties
            this.Property(t => t.FK_EconomicActivityID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FK_JobID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MOL_EconomicActivity_Jobs_Gender");
            this.Property(t => t.FK_EconomicActivityID).HasColumnName("FK_EconomicActivityID");
            this.Property(t => t.FK_JobID).HasColumnName("FK_JobID");
            this.Property(t => t.IsGenderRequired).HasColumnName("IsGenderRequired");

            // Relationships
            this.HasRequired(t => t.Lookup_EconomicActivity)
                .WithMany(t => t.MOL_EconomicActivity_Jobs_Gender)
                .HasForeignKey(d => d.FK_EconomicActivityID);
        }
    }
}
