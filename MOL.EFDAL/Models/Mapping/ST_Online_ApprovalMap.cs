namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class ST_Online_ApprovalMap : EntityTypeConfiguration<ST_Online_Approval>
    {
        public ST_Online_ApprovalMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_Online_Approval);

            // Properties
            this.Property(t => t.TimeStamp)
                .HasMaxLength(50);

            this.Property(t => t.Reason)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("ST_Online_Approval");
            this.Property(t => t.p_lab_off).HasColumnName("p_lab_off");
            this.Property(t => t.p_ser_yy).HasColumnName("p_ser_yy");
            this.Property(t => t.p_ser_no).HasColumnName("p_ser_no");
            this.Property(t => t.p_id_no).HasColumnName("p_id_no");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.FK_UserId).HasColumnName("FK_UserId");
            this.Property(t => t.createdon).HasColumnName("createdon");
            this.Property(t => t.PK_Online_Approval).HasColumnName("PK_Online_Approval");
            this.Property(t => t.ST_STATUS).HasColumnName("ST_STATUS");
            this.Property(t => t.Reason).HasColumnName("Reason");
        }
    }
}
