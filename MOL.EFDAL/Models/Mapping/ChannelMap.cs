namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class ChannelMap : EntityTypeConfiguration<Channels>
    {
        public ChannelMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Address)
                .HasMaxLength(100);

            this.Property(t => t.Phone)
                .HasMaxLength(15);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Attachment)
                .HasMaxLength(50);

            this.Property(t => t.PrivilegesManagerIDNumber)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Channels", "UM");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ChannelTypeID).HasColumnName("ChannelTypeID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PaymentMethodID).HasColumnName("PaymentMethodID");
            this.Property(t => t.PricePackageID).HasColumnName("PricePackageID");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.ContractStartDate).HasColumnName("ContractStartDate");
            this.Property(t => t.ContractEndDate).HasColumnName("ContractEndDate");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Attachment).HasColumnName("Attachment");
            this.Property(t => t.PrivilegesManagerIDNumber).HasColumnName("PrivilegesManagerIDNumber");
            this.Property(t => t.Gov_Agency_Id).HasColumnName("Gov_Agency_Id");

            // Relationships
            this.HasOptional(t => t.Gov_Agency)
                .WithMany(t => t.Channels)
                .HasForeignKey(d => d.Gov_Agency_Id);
        }
    }
}
