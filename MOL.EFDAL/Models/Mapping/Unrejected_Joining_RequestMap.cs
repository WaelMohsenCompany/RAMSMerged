namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Unrejected_Joining_RequestMap : EntityTypeConfiguration<Unrejected_Joining_Request>
    {
        public Unrejected_Joining_RequestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Unrejected_Joining_Request", "FN");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Request_No).HasColumnName("Request_No");
            this.Property(t => t.Establishment_Id).HasColumnName("Establishment_Id");
        }
    }
}
