namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentCommissionerMap : EntityTypeConfiguration<MOL_EstablishmentCommissioner>
    {
        public MOL_EstablishmentCommissionerMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EstablishmentCommissionerId);

            // Properties
            this.Property(t => t.AuthorizationNumber)
                .HasMaxLength(8);

            this.Property(t => t.Source)
                .HasMaxLength(50);

            this.Property(t => t.CommissionReason)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.StopCommissionReason)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentCommissioner");
            this.Property(t => t.PK_EstablishmentCommissionerId).HasColumnName("PK_EstablishmentCommissionerId");
            this.Property(t => t.FK_CommissionerTypeId).HasColumnName("FK_CommissionerTypeId");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.FK_LaborerId).HasColumnName("FK_LaborerId");
            this.Property(t => t.FK_ServiceOfficeId).HasColumnName("FK_ServiceOfficeId");
            this.Property(t => t.AuthorizationNumber).HasColumnName("AuthorizationNumber");
            this.Property(t => t.Source).HasColumnName("Source");
            this.Property(t => t.ReleaseDate).HasColumnName("ReleaseDate");
            this.Property(t => t.CommissionStartDate).HasColumnName("CommissionStartDate");
            this.Property(t => t.CommissionEndDate).HasColumnName("CommissionEndDate");
            this.Property(t => t.CommissionReason).HasColumnName("CommissionReason");
            this.Property(t => t.StopCommission).HasColumnName("StopCommission");
            this.Property(t => t.StopCommissionDate).HasColumnName("StopCommissionDate");
            this.Property(t => t.StopCommissionReason).HasColumnName("StopCommissionReason");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.IsVerified).HasColumnName("IsVerified");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasRequired(t => t.Enum_CommissionerType)
                .WithMany(t => t.MOL_EstablishmentCommissioner)
                .HasForeignKey(d => d.FK_CommissionerTypeId);
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_EstablishmentCommissioner)
                .HasForeignKey(d => d.FK_EstablishmentId);
            this.HasOptional(t => t.MOL_Laborer)
                .WithMany(t => t.MOL_EstablishmentCommissioner)
                .HasForeignKey(d => d.FK_LaborerId);
        }
    }
}
