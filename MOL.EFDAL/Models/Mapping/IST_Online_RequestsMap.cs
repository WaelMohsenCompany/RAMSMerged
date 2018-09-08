namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class IST_Online_RequestsMap : EntityTypeConfiguration<IST_Online_Requests>
    {
        public IST_Online_RequestsMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_Online_Requests);

            // Properties
            this.Property(t => t.p_SPONNAME)
                .HasMaxLength(50);

            this.Property(t => t.p_law_name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("IST_Online_Requests");
            this.Property(t => t.p_lab_off_cmpy).HasColumnName("p_lab_off_cmpy");
            this.Property(t => t.p_cmpy_no).HasColumnName("p_cmpy_no");
            this.Property(t => t.p_SPONNAME).HasColumnName("p_SPONNAME");
            this.Property(t => t.p_id_no).HasColumnName("p_id_no");
            this.Property(t => t.p_appl_typ).HasColumnName("p_appl_typ");
            this.Property(t => t.p_agn_ser_no).HasColumnName("p_agn_ser_no");
            this.Property(t => t.p_law_name).HasColumnName("p_law_name");
            this.Property(t => t.p_law_id).HasColumnName("p_law_id");
            this.Property(t => t.FK_ColorId).HasColumnName("FK_ColorId");
            this.Property(t => t.FK_UserId).HasColumnName("FK_UserId");
            this.Property(t => t.createdon).HasColumnName("createdon");
            this.Property(t => t.PK_Online_Requests).HasColumnName("PK_Online_Requests");
        }
    }
}
