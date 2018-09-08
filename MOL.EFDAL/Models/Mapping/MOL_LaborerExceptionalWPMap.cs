namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_LaborerExceptionalWPMap : EntityTypeConfiguration<MOL_LaborerExceptionalWP>
    {
        public MOL_LaborerExceptionalWPMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FK_EstablishmentId)
                .HasMaxLength(256);

            this.Property(t => t.FK_LaborerId)
                .HasMaxLength(256);

            this.Property(t => t.IdNo)
                .HasMaxLength(256);

            this.Property(t => t.IdNo_Dec)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_LaborerExceptionalWP");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.FK_LaborerId).HasColumnName("FK_LaborerId");
            this.Property(t => t.IdNo).HasColumnName("IdNo");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.IdNo_Dec).HasColumnName("IdNo_Dec");
        }
    }
}
