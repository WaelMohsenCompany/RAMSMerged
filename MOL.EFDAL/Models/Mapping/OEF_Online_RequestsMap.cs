namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class OEF_Online_RequestsMap : EntityTypeConfiguration<OEF_Online_Requests>
    {
        public OEF_Online_RequestsMap()
        {
            // Primary Key
            this.HasKey(t => t.SequenceNumber);

            // Properties
            // Table & Column Mappings
            this.ToTable("OEF_Online_Requests");
            this.Property(t => t.Fk_LaborOfficeId).HasColumnName("Fk_LaborOfficeId");
            this.Property(t => t.HijriYear).HasColumnName("HijriYear");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.Fk_EstablishmentId).HasColumnName("Fk_EstablishmentId");
            this.Property(t => t.Fk_UserId).HasColumnName("Fk_UserId");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.OEF_Online_Requests)
                .HasForeignKey(d => d.Fk_EstablishmentId);
            this.HasRequired(t => t.MOL_User)
                .WithMany(t => t.OEF_Online_Requests)
                .HasForeignKey(d => d.Fk_UserId);
        }
    }
}
