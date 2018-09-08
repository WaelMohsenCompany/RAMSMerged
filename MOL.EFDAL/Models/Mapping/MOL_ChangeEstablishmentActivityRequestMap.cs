namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_ChangeEstablishmentActivityRequestMap : EntityTypeConfiguration<MOL_ChangeEstablishmentActivityRequest>
    {
        public MOL_ChangeEstablishmentActivityRequestMap()
        {
            // Primary Key
            this.HasKey(t => t.Pk_ChangeEstablishmentActivityRequestId);

            // Properties
            this.Property(t => t.RequestNumber)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("MOL_ChangeEstablishmentActivityRequest");
            this.Property(t => t.Pk_ChangeEstablishmentActivityRequestId).HasColumnName("Pk_ChangeEstablishmentActivityRequestId");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.RequestNumber).HasColumnName("RequestNumber");
            this.Property(t => t.FK_OldMainEconomicActivityId).HasColumnName("FK_OldMainEconomicActivityId");
            this.Property(t => t.Fk_OldSubEconomicActivityId).HasColumnName("Fk_OldSubEconomicActivityId");
            this.Property(t => t.Fk_ChangeEstablishmentActivityRequestStatusId).HasColumnName("Fk_ChangeEstablishmentActivityRequestStatusId");
            this.Property(t => t.FK_NewMainEconomicActivityId).HasColumnName("FK_NewMainEconomicActivityId");
            this.Property(t => t.FK_NewSubEconomicActivityId).HasColumnName("FK_NewSubEconomicActivityId");
            this.Property(t => t.FK_NewEconomicActivityId).HasColumnName("FK_NewEconomicActivityId");
            this.Property(t => t.Fk_ChangeEstablishmentActivityReasonId).HasColumnName("Fk_ChangeEstablishmentActivityReasonId");
            this.Property(t => t.Fk_CreatedBy).HasColumnName("Fk_CreatedBy");
            this.Property(t => t.ApprovalsRequired).HasColumnName("ApprovalsRequired");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.Fk_RejectionReasonId).HasColumnName("Fk_RejectionReasonId");
            this.Property(t => t.Fk_ModifiedBy).HasColumnName("Fk_ModifiedBy");

            // Relationships
            this.HasRequired(t => t.Enum_ChangeEstablishmentActivityRequestStatus)
                .WithMany(t => t.MOL_ChangeEstablishmentActivityRequest)
                .HasForeignKey(d => d.Fk_ChangeEstablishmentActivityRequestStatusId);
            this.HasRequired(t => t.Lookup_ChangeEstablishmentActivityReason)
                .WithMany(t => t.MOL_ChangeEstablishmentActivityRequest)
                .HasForeignKey(d => d.Fk_ChangeEstablishmentActivityReasonId);
            this.HasOptional(t => t.Lookup_ChangeEstablishmentActivityRejectionReason)
                .WithMany(t => t.MOL_ChangeEstablishmentActivityRequest)
                .HasForeignKey(d => d.Fk_RejectionReasonId);
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_ChangeEstablishmentActivityRequest)
                .HasForeignKey(d => d.FK_EstablishmentId);

        }
    }
}
