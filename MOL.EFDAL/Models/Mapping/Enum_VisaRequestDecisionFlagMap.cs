namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class Enum_VisaRequestDecisionFlagMap : EntityTypeConfiguration<Enum_VisaRequestDecisionFlag>
    {
        public Enum_VisaRequestDecisionFlagMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_DecisionFlagID);

            // Properties
            this.Property(t => t.PK_DecisionFlagID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Enum_VisaRequestDecisionFlag");
            this.Property(t => t.PK_DecisionFlagID).HasColumnName("PK_DecisionFlagID");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
