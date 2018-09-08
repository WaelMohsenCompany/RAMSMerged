namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_Service_LogMap : EntityTypeConfiguration<MOL_Service_Log>
    {
        public MOL_Service_LogMap()
        {
            // Primary Key
            this.HasKey(t => t.LogID);

            // Properties
            this.Property(t => t.ReturnMessage)
                .HasMaxLength(200);

            this.Property(t => t.RequesterIDNo)
                .HasMaxLength(15);

            this.Property(t => t.ClientIPAddress)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_Service_Log");
            this.Property(t => t.LogID).HasColumnName("LogID");
            this.Property(t => t.ServiceID).HasColumnName("ServiceID");
            this.Property(t => t.FK_EstablishmentID).HasColumnName("FK_EstablishmentID");
            this.Property(t => t.FK_LaborerID).HasColumnName("FK_LaborerID");
            this.Property(t => t.CreatedByUserID).HasColumnName("CreatedByUserID");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.ReturnMessage).HasColumnName("ReturnMessage");
            this.Property(t => t.ReturnCode).HasColumnName("ReturnCode");
            this.Property(t => t.RequesterIDNo).HasColumnName("RequesterIDNo");
            this.Property(t => t.ClientIPAddress).HasColumnName("ClientIPAddress");
        }
    }
}
