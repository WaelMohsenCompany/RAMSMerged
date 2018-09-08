namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class CLB_Online_RequestsMap : EntityTypeConfiguration<CLB_Online_Requests>
    {
        public CLB_Online_RequestsMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_Online_Requests);

            // Properties
            // Table & Column Mappings
            this.ToTable("CLB_Online_Requests");
            this.Property(t => t.p_lab_off).HasColumnName("p_lab_off");
            this.Property(t => t.p_nat_flg).HasColumnName("p_nat_flg");
            this.Property(t => t.p_lab_ser).HasColumnName("p_lab_ser");
            this.Property(t => t.o_lab_off_cmpy).HasColumnName("o_lab_off_cmpy");
            this.Property(t => t.o_cmpy_no).HasColumnName("o_cmpy_no");
            this.Property(t => t.p_lab_off_cmpy).HasColumnName("p_lab_off_cmpy");
            this.Property(t => t.p_cmpy_no).HasColumnName("p_cmpy_no");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.createdon).HasColumnName("createdon");
            this.Property(t => t.PK_Online_Requests).HasColumnName("PK_Online_Requests");
            this.Property(t => t.LaborerIdNo).HasColumnName("LaborerIdNo");
            this.Property(t => t.Filler_3).HasColumnName("Filler_3");
        }
    }
}
