namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_GC_AssentTrackingLogMap : EntityTypeConfiguration<MOL_GC_AssentTrackingLog>
    {
        public MOL_GC_AssentTrackingLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.RejectReason)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("MOL_GC_AssentTrackingLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AssentID).HasColumnName("AssentID");
            this.Property(t => t.AssentStatusID).HasColumnName("AssentStatusID");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.AssentEditReasonID).HasColumnName("AssentEditReasonID");
            this.Property(t => t.RejectReason).HasColumnName("RejectReason");

            // Relationships
            this.HasRequired(t => t.MOL_GC_Assents)
                .WithMany(t => t.MOL_GC_AssentTrackingLog)
                .HasForeignKey(d => d.AssentID);
            this.HasRequired(t => t.MOL_User)
                .WithMany(t => t.MOL_GC_AssentTrackingLog)
                .HasForeignKey(d => d.UserID);

        }
    }
}
