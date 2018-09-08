namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Sec_SecurableEntityMap : EntityTypeConfiguration<MOL_Sec_SecurableEntity>
    {
        public MOL_Sec_SecurableEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // IAuditable
            this.Ignore(t => t.CurrentUserID);
            this.Ignore(t => t.DBTableName);

            // Properties
            this.Property(t => t.Securable_Entity_Id)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("MOL_Sec_SecurableEntity");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Securable_Entity_Type_Id).HasColumnName("Securable_Entity_Type_Id");
            this.Property(t => t.Securable_Entity_Id).HasColumnName("Securable_Entity_Id");

            // Relationships
            this.HasRequired(t => t.Lookup_SecurableEntityType)
                .WithMany(t => t.MOL_Sec_SecurableEntity)
                .HasForeignKey(d => d.Securable_Entity_Type_Id);

        }
    }
}
