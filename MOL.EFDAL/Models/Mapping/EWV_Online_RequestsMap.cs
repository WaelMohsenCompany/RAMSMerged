namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class EWV_Online_RequestsMap : EntityTypeConfiguration<EWV_Online_Requests>
    {
        public EWV_Online_RequestsMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_Online_Requests);

            // Properties
            this.Property(t => t.TransactionNumber)
                .HasMaxLength(50);

            this.Property(t => t.p_lab_off_cmpy)
                .HasMaxLength(50);

            this.Property(t => t.p_cmpy_no)
                .HasMaxLength(50);

            this.Property(t => t.p_appl_typ)
                .HasMaxLength(50);

            this.Property(t => t.p_agn_ser_no)
                .HasMaxLength(50);

            this.Property(t => t.p_tot_labores)
                .HasMaxLength(50);

            this.Property(t => t.p_law_name)
                .HasMaxLength(50);

            this.Property(t => t.p_law_id)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EWV_Online_Requests");
            this.Property(t => t.PK_Online_Requests).HasColumnName("PK_Online_Requests");
            this.Property(t => t.TransactionNumber).HasColumnName("TransactionNumber");
            this.Property(t => t.FK_UserId).HasColumnName("FK_UserId");
            this.Property(t => t.FK_PrivilegeId).HasColumnName("FK_PrivilegeId");
            this.Property(t => t.FK_RequesterTypeId).HasColumnName("FK_RequesterTypeId");
            this.Property(t => t.RequesterIdNo).HasColumnName("RequesterIdNo");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.p_lab_off_cmpy).HasColumnName("p_lab_off_cmpy");
            this.Property(t => t.p_cmpy_no).HasColumnName("p_cmpy_no");
            this.Property(t => t.p_appl_typ).HasColumnName("p_appl_typ");
            this.Property(t => t.p_agn_ser_no).HasColumnName("p_agn_ser_no");
            this.Property(t => t.p_tot_labores).HasColumnName("p_tot_labores");
            this.Property(t => t.p_law_name).HasColumnName("p_law_name");
            this.Property(t => t.p_law_id).HasColumnName("p_law_id");
        }
    }
}
