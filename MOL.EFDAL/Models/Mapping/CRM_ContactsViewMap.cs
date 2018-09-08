namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class CRM_ContactsViewMap : EntityTypeConfiguration<CRM_ContactsView>
    {
        public CRM_ContactsViewMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.NationalId)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.EstablishmentName)
                .HasMaxLength(100);

            this.Property(t => t.FirstName)
                .HasMaxLength(255);

            this.Property(t => t.SecondName)
                .HasMaxLength(50);

            this.Property(t => t.ThirdName)
                .HasMaxLength(50);

            this.Property(t => t.FourthName)
                .HasMaxLength(50);

            this.Property(t => t.Nationality)
                .HasMaxLength(50);

            this.Property(t => t.NationalIdSource)
                .HasMaxLength(50);

            this.Property(t => t.ContactType)
                .HasMaxLength(50);

            this.Property(t => t.Mobile)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CRM_ContactsView");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.NationalId).HasColumnName("NationalId");
            this.Property(t => t.PK_EstablishmentId).HasColumnName("PK_EstablishmentId");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.EstablishmentName).HasColumnName("EstablishmentName");
            this.Property(t => t.ContactTypeId).HasColumnName("ContactTypeId");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.SecondName).HasColumnName("SecondName");
            this.Property(t => t.ThirdName).HasColumnName("ThirdName");
            this.Property(t => t.FourthName).HasColumnName("FourthName");
            this.Property(t => t.IsVerified).HasColumnName("IsVerified");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.NationalityId).HasColumnName("NationalityId");
            this.Property(t => t.Nationality).HasColumnName("Nationality");
            this.Property(t => t.NationalIdSource).HasColumnName("NationalIdSource");
            this.Property(t => t.ContactType).HasColumnName("ContactType");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Email).HasColumnName("Email");
        }
    }
}
