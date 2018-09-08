namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_NationalityMap : EntityTypeConfiguration<Lookup_Nationality>
    {
        public Lookup_NationalityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name_EN)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Lookup_Nationality");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Name_EN).HasColumnName("Name_EN");
            this.Property(t => t.IsIncludedForEWV).HasColumnName("IsIncludedForEWV");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsBanForFollowerTransfer).HasColumnName("IsBanForFollowerTransfer");
            this.Property(t => t.NIC_CountryCode).HasColumnName("NIC_CountryCode");
            this.Property(t => t.AllowedForAccountManager).HasColumnName("AllowedForAccountManager");
        }
    }
}
