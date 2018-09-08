namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_NotificationMessageMap : EntityTypeConfiguration<MOL_NotificationMessage>
    {
        public MOL_NotificationMessageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.EmailTxt)
                .HasMaxLength(1024);

            this.Property(t => t.SmsTxt)
                .HasMaxLength(1024);

            this.Property(t => t.UserInterfaceTxt)
                .HasMaxLength(1024);

            this.Property(t => t.LaborerIdNo)
                .HasMaxLength(15);

            this.Property(t => t.LaborerFullName)
                .HasMaxLength(200);

            this.Property(t => t.EstablishmentLicenseNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_NotificationMessage");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EmailTxt).HasColumnName("EmailTxt");
            this.Property(t => t.SmsTxt).HasColumnName("SmsTxt");
            this.Property(t => t.UserInterfaceTxt).HasColumnName("UserInterfaceTxt");
            this.Property(t => t.FK_NotificationMessageCreatorId).HasColumnName("FK_NotificationMessageCreatorId");
            this.Property(t => t.FK_StatusId).HasColumnName("FK_StatusId");
            this.Property(t => t.IsSentSuccessfully).HasColumnName("IsSentSuccessfully");
            this.Property(t => t.SendAttemptDate).HasColumnName("SendAttemptDate");
            this.Property(t => t.SendAttemptCount).HasColumnName("SendAttemptCount");
            this.Property(t => t.FK_EstablishmentID).HasColumnName("FK_EstablishmentID");
            this.Property(t => t.IgnoreIfNotSent).HasColumnName("IgnoreIfNotSent");
            this.Property(t => t.FK_LaborerID).HasColumnName("FK_LaborerID");
            this.Property(t => t.LaborerIdNo).HasColumnName("LaborerIdNo");
            this.Property(t => t.LaborerFullName).HasColumnName("LaborerFullName");
            this.Property(t => t.OperationDate).HasColumnName("OperationDate");
            this.Property(t => t.ShownDate).HasColumnName("ShownDate");
            this.Property(t => t.Agent_EstablishmentAgentId).HasColumnName("Agent_EstablishmentAgentId");
            this.Property(t => t.Agent_AgencyEndDate).HasColumnName("Agent_AgencyEndDate");
            this.Property(t => t.Commissioner_EstablishmentCommissionerId).HasColumnName("Commissioner_EstablishmentCommissionerId");
            this.Property(t => t.Comissioner_CommisionEndDate).HasColumnName("Comissioner_CommisionEndDate");
            this.Property(t => t.EstablishmentLicenseExpirationDate).HasColumnName("EstablishmentLicenseExpirationDate");
            this.Property(t => t.EstablishmentLicenseNumber).HasColumnName("EstablishmentLicenseNumber");
            this.Property(t => t.IsWarning).HasColumnName("IsWarning");

            // Relationships
            this.HasRequired(t => t.Enum_NotificationMessageCreator)
                .WithMany(t => t.MOL_NotificationMessage)
                .HasForeignKey(d => d.FK_NotificationMessageCreatorId);
            this.HasOptional(t => t.Enum_NotificationMessageStatus)
                .WithMany(t => t.MOL_NotificationMessage)
                .HasForeignKey(d => d.FK_StatusId);
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_NotificationMessage)
                .HasForeignKey(d => d.FK_EstablishmentID);

        }
    }
}
