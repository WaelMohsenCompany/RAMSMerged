namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_CEAInboxMap : EntityTypeConfiguration<MOL_CEAInbox>
    {
        public MOL_CEAInboxMap()
        {
            // Primary Key
            this.HasKey(t => t.Pk_CEAInbox);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_CEAInbox");
            this.Property(t => t.Pk_CEAInbox).HasColumnName("Pk_CEAInbox");
            this.Property(t => t.Fk_ChangeEstablishmentActivityRequestId).HasColumnName("Fk_ChangeEstablishmentActivityRequestId");
            this.Property(t => t.Fk_UserId).HasColumnName("Fk_UserId");
            this.Property(t => t.Fk_ChangeEstablishmentActivityUserActionId).HasColumnName("Fk_ChangeEstablishmentActivityUserActionId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.FK_RejectionReasonId).HasColumnName("FK_RejectionReasonId");

            // Relationships
            this.HasOptional(t => t.Lookup_ChangeEstablishmentActivityRejectionReason)
                .WithMany(t => t.MOL_CEAInbox)
                .HasForeignKey(d => d.FK_RejectionReasonId);

        }
    }
}
