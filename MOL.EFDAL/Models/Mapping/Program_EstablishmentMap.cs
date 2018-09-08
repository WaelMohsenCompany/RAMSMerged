using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    public class Program_EstablishmentMap : EntityTypeConfiguration<Program_Establishment>
    {
        public Program_EstablishmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.User_IP_Address)
                .HasMaxLength(50);

            this.Property(t => t.User_PC_Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Program_Establishment", "FN");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Establishment_Id).HasColumnName("Establishment_Id");
            this.Property(t => t.Requested_Saudi_Units).HasColumnName("Requested_Saudi_Units");
            this.Property(t => t.Calculated_Fees).HasColumnName("Calculated_Fees");
            this.Property(t => t.Joining_On).HasColumnName("Joining_On");
            this.Property(t => t.Deactivation_On).HasColumnName("Deactivation_On");
            this.Property(t => t.Program_Status_Id).HasColumnName("Program_Status_Id");
            this.Property(t => t.Created_On).HasColumnName("Created_On");
            this.Property(t => t.Created_By).HasColumnName("Created_By");
            this.Property(t => t.User_IP_Address).HasColumnName("User_IP_Address");
            this.Property(t => t.User_PC_Name).HasColumnName("User_PC_Name");
            this.Property(t => t.Activation_Date).HasColumnName("Activation_Date");
            // Relationships
            this.HasOptional(t => t.Program_Status)
                .WithMany(t => t.Program_Establishment)
                .HasForeignKey(d => d.Program_Status_Id);

        }
    }
}
