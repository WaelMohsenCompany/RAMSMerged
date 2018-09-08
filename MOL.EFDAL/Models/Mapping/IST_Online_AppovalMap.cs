namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class IST_Online_AppovalMap : EntityTypeConfiguration<IST_Online_Appoval>
    {
        public IST_Online_AppovalMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_IST_Online_Appoval);

            // Properties
            this.Property(t => t.returnParam)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("IST_Online_Appoval");
            this.Property(t => t.p_lab_off).HasColumnName("p_lab_off");
            this.Property(t => t.p_ser_yy).HasColumnName("p_ser_yy");
            this.Property(t => t.p_ser_no).HasColumnName("p_ser_no");
            this.Property(t => t.p_id_no).HasColumnName("p_id_no");
            this.Property(t => t.p_trs_stus).HasColumnName("p_trs_stus");
            this.Property(t => t.FK_UseId).HasColumnName("FK_UseId");
            this.Property(t => t.returnParam).HasColumnName("returnParam");
            this.Property(t => t.createdon).HasColumnName("createdon");
            this.Property(t => t.PK_IST_Online_Appoval).HasColumnName("PK_IST_Online_Appoval");
        }
    }
}
