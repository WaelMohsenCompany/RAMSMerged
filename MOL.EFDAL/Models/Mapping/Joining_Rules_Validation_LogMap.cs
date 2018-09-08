using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    public class Joining_Rules_Validation_LogMap : EntityTypeConfiguration<Joining_Rules_Validation_Log>
    {
        public Joining_Rules_Validation_LogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Requester_IdNo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Joining_Rules_Validation_Log", "FN");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Establishment_Id).HasColumnName("Establishment_Id");
            this.Property(t => t.Requester_IdNo).HasColumnName("Requester_IdNo");
            this.Property(t => t.Rule_Id).HasColumnName("Rule_Id");
            this.Property(t => t.Created_On).HasColumnName("Created_On");

            // Relationships
            this.HasOptional(t => t.Joining_Rule)
                .WithMany(t => t.Joining_Rules_Validation_Log)
                .HasForeignKey(d => d.Rule_Id);

        }
    }
}
