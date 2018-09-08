namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentStatementMap : EntityTypeConfiguration<MOL_EstablishmentStatement>
    {
        public MOL_EstablishmentStatementMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EstablishmentStatementId);

            // Properties
            this.Property(t => t.StatementNumber)
                .HasMaxLength(30);

            this.Property(t => t.Source)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CancellationNo)
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentStatement");
            this.Property(t => t.PK_EstablishmentStatementId).HasColumnName("PK_EstablishmentStatementId");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.FK_StatementTypeId).HasColumnName("FK_StatementTypeId");
            this.Property(t => t.StatementNumber).HasColumnName("StatementNumber");
            this.Property(t => t.ReleaseDate).HasColumnName("ReleaseDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Source).HasColumnName("Source");
            this.Property(t => t.CancellationNo).HasColumnName("CancellationNo");
            this.Property(t => t.CancellationDate).HasColumnName("CancellationDate");
            this.Property(t => t.ConfirmationDate).HasColumnName("ConfirmationDate");

            // Relationships
            this.HasRequired(t => t.Lookup_StatementsType)
                .WithMany(t => t.MOL_EstablishmentStatement)
                .HasForeignKey(d => d.FK_StatementTypeId);
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_EstablishmentStatement)
                .HasForeignKey(d => d.FK_EstablishmentId);

        }
    }
}
