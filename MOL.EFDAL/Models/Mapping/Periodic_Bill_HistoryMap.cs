using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    public class Periodic_Bill_HistoryMap : EntityTypeConfiguration<Periodic_Bill_History>
    {
        public Periodic_Bill_HistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Periodic_Bill_History", "FN");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Periodic_Bill_Id).HasColumnName("Periodic_Bill_Id");
            this.Property(t => t.Bill_Status_Id).HasColumnName("Bill_Status_Id");
            this.Property(t => t.Status_Created_On).HasColumnName("Status_Created_On");
            this.Property(t => t.Nitaqat_Validity_Start).HasColumnName("Nitaqat_Validity_Start");
            this.Property(t => t.Nitaqat_Validity_Expiration).HasColumnName("Nitaqat_Validity_Expiration");

            // Relationships
            this.HasOptional(t => t.Bill_Status)
                .WithMany(t => t.Periodic_Bill_History)
                .HasForeignKey(d => d.Bill_Status_Id);
            this.HasOptional(t => t.Periodic_Bill)
                .WithMany(t => t.Periodic_Bill_History)
                .HasForeignKey(d => d.Periodic_Bill_Id);

        }
    }
}
