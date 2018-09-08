using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    public class Periodic_BillMap : EntityTypeConfiguration<Periodic_Bill>
    {
        public Periodic_BillMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Periodic_Bill", "FN");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Program_Establishment_Id).HasColumnName("Program_Establishment_Id");
            this.Property(t => t.Program_Sequence).HasColumnName("Program_Sequence");
            this.Property(t => t.Requested_Saudi_Units).HasColumnName("Requested_Saudi_Units");
            this.Property(t => t.Calculated_Fees).HasColumnName("Calculated_Fees");
            this.Property(t => t.Bill_Amount).HasColumnName("Bill_Amount");
            this.Property(t => t.Bill_Number).HasColumnName("Bill_Number");
            this.Property(t => t.Issued_On).HasColumnName("Issued_On");
            this.Property(t => t.Expiration_On).HasColumnName("Expiration_On");
            this.Property(t => t.Bill_Status_Id).HasColumnName("Bill_Status_Id");
            this.Property(t => t.Status_Modified_On).HasColumnName("Status_Modified_On");
            this.Property(t => t.Nitaqat_Validity_Start).HasColumnName("Nitaqat_Validity_Start");
            this.Property(t => t.Nitaqat_Validity_Expiration).HasColumnName("Nitaqat_Validity_Expiration");
            // Relationships
            this.HasOptional(t => t.Bill_Status)
                .WithMany(t => t.Periodic_Bill)
                .HasForeignKey(d => d.Bill_Status_Id);
            this.HasOptional(t => t.Program_Establishment)
                .WithMany(t => t.Periodic_Bill)
                .HasForeignKey(d => d.Program_Establishment_Id);

        }
    }
}
