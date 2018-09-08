namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Srv_TransactionMap : EntityTypeConfiguration<MOL_Srv_Transaction>
    {
        public MOL_Srv_TransactionMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_Service_TransactionId);

            // Properties
            this.Property(t => t.TransactionNumber)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.OtherRequester)
                .HasMaxLength(100);

            this.Property(t => t.RecieptNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_Srv_Transaction");
            this.Property(t => t.PK_Service_TransactionId).HasColumnName("PK_Service_TransactionId");
            this.Property(t => t.FK_Service_ServiceId).HasColumnName("FK_Service_ServiceId");
            this.Property(t => t.TransactionNumber).HasColumnName("TransactionNumber");
            this.Property(t => t.TransactionDate).HasColumnName("TransactionDate");
            this.Property(t => t.TransactionFees).HasColumnName("TransactionFees");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.FK_LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.FK_RequesterId).HasColumnName("FK_RequesterId");
            this.Property(t => t.Fk_RequesterTypeId).HasColumnName("Fk_RequesterTypeId");
            this.Property(t => t.OtherRequester).HasColumnName("OtherRequester");
            this.Property(t => t.BillNumber).HasColumnName("BillNumber");
            this.Property(t => t.FK_Service_LastServiceStatusId).HasColumnName("FK_Service_LastServiceStatusId");
            this.Property(t => t.StatusLastModificationDate).HasColumnName("StatusLastModificationDate");
            this.Property(t => t.FK_UserID).HasColumnName("FK_UserID");
            this.Property(t => t.FK_PayementTypeID).HasColumnName("FK_PayementTypeID");
            this.Property(t => t.RecieptNumber).HasColumnName("RecieptNumber");
            this.Property(t => t.FK_CreatedByUserId).HasColumnName("FK_CreatedByUserId");

            // Relationships
            this.HasOptional(t => t.Enum_PayementType)
                .WithMany(t => t.MOL_Srv_Transaction)
                .HasForeignKey(d => d.FK_PayementTypeID);
            this.HasOptional(t => t.Enum_RequesterType)
                .WithMany(t => t.MOL_Srv_Transaction)
                .HasForeignKey(d => d.Fk_RequesterTypeId);
            this.HasRequired(t => t.Enum_Service)
                .WithMany(t => t.MOL_Srv_Transaction)
                .HasForeignKey(d => d.FK_Service_ServiceId);
            this.HasOptional(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_Srv_Transaction)
                .HasForeignKey(d => d.FK_EstablishmentId);
            this.HasOptional(t => t.MOL_LaborOffice)
                .WithMany(t => t.MOL_Srv_Transaction)
                .HasForeignKey(d => d.FK_LaborOfficeId);
            this.HasOptional(t => t.MOL_User)
                .WithMany(t => t.MOL_Srv_Transaction)
                .HasForeignKey(d => d.FK_UserID);
            this.HasOptional(t => t.MOL_User1)
                .WithMany(t => t.MOL_Srv_Transaction1)
                .HasForeignKey(d => d.FK_CreatedByUserId);

        }
    }
}
