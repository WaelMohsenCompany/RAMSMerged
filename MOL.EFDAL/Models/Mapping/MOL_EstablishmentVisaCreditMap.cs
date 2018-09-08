namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmentVisaCreditMap : EntityTypeConfiguration<MOL_EstablishmentVisaCredit>
    {
        public MOL_EstablishmentVisaCreditMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ReferenceData)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("MOL_EstablishmentVisaCredit");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RequestID).HasColumnName("RequestID");
            this.Property(t => t.TypeID).HasColumnName("TypeID");
            this.Property(t => t.EstablishmentID).HasColumnName("EstablishmentID");
            this.Property(t => t.RequestedCredit).HasColumnName("RequestedCredit");
            this.Property(t => t.ApprovedCredit).HasColumnName("ApprovedCredit");
            this.Property(t => t.UsedCredit).HasColumnName("UsedCredit");
            this.Property(t => t.AvailableCredit).HasColumnName("AvailableCredit");
            this.Property(t => t.ExpirationDate).HasColumnName("ExpirationDate");
            this.Property(t => t.TransferedFromID).HasColumnName("TransferedFromID");
            this.Property(t => t.TerminationDate).HasColumnName("TerminationDate");
            this.Property(t => t.TerminationReasonID).HasColumnName("TerminationReasonID");
            this.Property(t => t.IsTerminated).HasColumnName("IsTerminated");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
            this.Property(t => t.ReferenceData).HasColumnName("ReferenceData");
            this.Property(t => t.GroupingRefrence).HasColumnName("GroupingRefrence");

            // Relationships
            this.HasOptional(t => t.Enum_EstablishmentVisaCreditTerminationReason)
                .WithMany(t => t.MOL_EstablishmentVisaCredit)
                .HasForeignKey(d => d.TerminationReasonID);
            this.HasRequired(t => t.Enum_EstablishmentVisaCreditType)
                .WithMany(t => t.MOL_EstablishmentVisaCredit)
                .HasForeignKey(d => d.TypeID);
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_EstablishmentVisaCredit)
                .HasForeignKey(d => d.EstablishmentID);
            this.HasOptional(t => t.MOL_EstablishmentVisaCredit2)
                .WithMany(t => t.MOL_EstablishmentVisaCredit1)
                .HasForeignKey(d => d.TransferedFromID);
            this.HasRequired(t => t.MOL_User)
                .WithMany(t => t.MOL_EstablishmentVisaCredit)
                .HasForeignKey(d => d.CreatedBy);
            this.HasOptional(t => t.MOL_User1)
                .WithMany(t => t.MOL_EstablishmentVisaCredit1)
                .HasForeignKey(d => d.LastModifiedBy);

        }
    }
}
