namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_NotificationMessageReceiverMap : EntityTypeConfiguration<MOL_NotificationMessageReceiver>
    {
        public MOL_NotificationMessageReceiverMap()
        {
            // Primary Key
            this.HasKey(t => new { t.FK_UserID, t.FK_NotificationMessageID });

            // Properties
            this.Property(t => t.FK_UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FK_NotificationMessageID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SMSReceiver)
                .HasMaxLength(50);

            this.Property(t => t.EmailTo)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MOL_NotificationMessageReceiver");
            this.Property(t => t.FK_UserID).HasColumnName("FK_UserID");
            this.Property(t => t.FK_NotificationMessageID).HasColumnName("FK_NotificationMessageID");
            this.Property(t => t.SMSReceiver).HasColumnName("SMSReceiver");
            this.Property(t => t.EmailTo).HasColumnName("EmailTo");

            // Relationships
            this.HasRequired(t => t.MOL_NotificationMessage)
                .WithMany(t => t.MOL_NotificationMessageReceiver)
                .HasForeignKey(d => d.FK_NotificationMessageID);

        }
    }
}
