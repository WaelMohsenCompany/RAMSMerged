namespace MOL.EFDAL.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_VwUserEstablishmentsMap : EntityTypeConfiguration<MOL_VwUserEstablishments>
    {
        public MOL_VwUserEstablishmentsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PK_EstablishmentId, t.FK_LaborOfficeId, t.SequenceNumber, t.Name, t.AuthorizedType });

            // Properties
            this.Property(t => t.AuthorizedIdNo)
                .HasMaxLength(15);

            this.Property(t => t.PK_EstablishmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FK_LaborOfficeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SequenceNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.AuthorizedType)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AuthorizedName)
                .HasMaxLength(203);

            // Table & Column Mappings
            this.ToTable("MOL_VwUserEstablishments");
            this.Property(t => t.PK_AuthorizedId).HasColumnName("PK_AuthorizedId");
            this.Property(t => t.AuthorizedIdNo).HasColumnName("AuthorizedIdNo");
            this.Property(t => t.PK_AuthorizationId).HasColumnName("PK_AuthorizationId");
            this.Property(t => t.PK_EstablishmentId).HasColumnName("PK_EstablishmentId");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.AuthorizedType).HasColumnName("AuthorizedType");
            this.Property(t => t.AuthorizedName).HasColumnName("AuthorizedName");
            this.Property(t => t.IsVerified).HasColumnName("IsVerified");
        }
    }
}
