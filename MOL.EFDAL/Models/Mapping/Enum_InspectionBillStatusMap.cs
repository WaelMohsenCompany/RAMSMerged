namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class Enum_InspectionBillStatusMap : EntityTypeConfiguration<Enum_InspectionBillStatus>
    {
        public Enum_InspectionBillStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_BillStatusCode);

            // Properties
            this.Property(t => t.PK_BillStatusCode)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.BillStatusDescription)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Enum_InspectionBillStatus");
            this.Property(t => t.PK_BillStatusCode).HasColumnName("PK_BillStatusCode");
            this.Property(t => t.BillStatusDescription).HasColumnName("BillStatusDescription");
        }
    }
}
