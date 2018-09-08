namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_CancelFinalExitWorkPermitMap : EntityTypeConfiguration<MOL_CancelFinalExitWorkPermit>
    {
        public MOL_CancelFinalExitWorkPermitMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.LaborerId)
                .IsRequired();

            this.Property(t => t.CanceledWPId)
                .IsRequired();

            this.Property(t => t.UserId)
                .IsRequired();

            this.Property(t => t.CreateDate)
                .IsRequired();

            this.Property(t => t.ClientIP)
                .IsRequired()
                .HasMaxLength(50);



            // Table & Column Mappings
            this.ToTable("MOL_CancelFinalExitWorkPermit");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.LaborerId).HasColumnName("LaborerId");
            this.Property(t => t.CanceledWPId).HasColumnName("CanceledWPId");
            this.Property(t => t.OldWPId).HasColumnName("OldWPId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.ClientIP).HasColumnName("ClientIP");

            // Relationships
            this.HasRequired(t => t.MOL_Laborer)
                .WithMany(t => t.MOL_CancelFinalExitWorkPermit)
                .HasForeignKey(t => t.LaborerId);

            this.HasRequired(t => t.MOL_User)
                .WithMany(t => t.MOL_CancelFinalExitWorkPermit)
                .HasForeignKey(t => t.UserId);

        }
    }
}
