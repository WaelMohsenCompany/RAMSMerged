namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class CJD_Online_RequestsMap : EntityTypeConfiguration<CJD_Online_Requests>
    {
        public CJD_Online_RequestsMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_Online_Requests);

            // Properties
            this.Property(t => t.p_law_name)
                .HasMaxLength(50);

            this.Property(t => t.TimeStamp)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CJD_Online_Requests");
            this.Property(t => t.p_lab_off).HasColumnName("p_lab_off");
            this.Property(t => t.p_nat_flg).HasColumnName("p_nat_flg");
            this.Property(t => t.p_lab_ser).HasColumnName("p_lab_ser");
            this.Property(t => t.p_old_job).HasColumnName("p_old_job");
            this.Property(t => t.p_new_job).HasColumnName("p_new_job");
            this.Property(t => t.p_lab_off_cmpy).HasColumnName("p_lab_off_cmpy");
            this.Property(t => t.p_cmpy_no).HasColumnName("p_cmpy_no");
            this.Property(t => t.p_appl_typ).HasColumnName("p_appl_typ");
            this.Property(t => t.p_agn_ser_no).HasColumnName("p_agn_ser_no");
            this.Property(t => t.p_law_name).HasColumnName("p_law_name");
            this.Property(t => t.p_law_id).HasColumnName("p_law_id");
            this.Property(t => t.FK_ColorId).HasColumnName("FK_ColorId");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.Fk_UserId).HasColumnName("Fk_UserId");
            this.Property(t => t.createdon).HasColumnName("createdon");
            this.Property(t => t.PK_Online_Requests).HasColumnName("PK_Online_Requests");

            // Relationships
            this.HasOptional(t => t.MOL_User)
                .WithMany(t => t.CJD_Online_Requests)
                .HasForeignKey(d => d.Fk_UserId);
        }
    }
}
