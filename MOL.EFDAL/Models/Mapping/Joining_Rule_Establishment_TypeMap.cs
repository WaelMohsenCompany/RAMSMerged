namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Joining_Rule_Establishment_TypeMap : EntityTypeConfiguration<Joining_Rule_Establishment_Type>
    {
        public Joining_Rule_Establishment_TypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Joining_Rule_Establishment_Type", "FN");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Joining_Rule_Id).HasColumnName("Joining_Rule_Id");
            this.Property(t => t.Establishment_Type_Id).HasColumnName("Establishment_Type_Id");
            this.Property(t => t.Block).HasColumnName("Block");
        }
    }
}
