namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_CancelVisaRequestMap : EntityTypeConfiguration<MOL_CancelVisaRequest>
    {
        public MOL_CancelVisaRequestMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_RequestId);

            // Properties
            this.Property(t => t.OOUT_No)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BorderNo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NICResponse)
                .IsRequired();

            this.Property(t => t.RequesterIdNo)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("MOL_CancelVisaRequest");
            this.Property(t => t.PK_RequestId).HasColumnName("PK_RequestId");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.FK_RequesterId).HasColumnName("FK_RequesterId");
            this.Property(t => t.OOUT_No).HasColumnName("OOUT_No");
            this.Property(t => t.BorderNo).HasColumnName("BorderNo");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.NICResponse).HasColumnName("NICResponse");
            this.Property(t => t.isManPower).HasColumnName("isManPower");
            this.Property(t => t.RequesterIdNo).HasColumnName("RequesterIdNo");
            this.Property(t => t.VisaCreditRefundResponce).HasColumnName("VisaCreditRefundResponce");

            // Relationships
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_CancelVisaRequest)
                .HasForeignKey(d => d.FK_EstablishmentId);
            this.HasRequired(t => t.MOL_User)
                .WithMany(t => t.MOL_CancelVisaRequest)
                .HasForeignKey(d => d.FK_RequesterId);

        }
    }
}
