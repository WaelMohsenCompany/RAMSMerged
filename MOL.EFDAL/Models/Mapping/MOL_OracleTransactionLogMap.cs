namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_OracleTransactionLogMap : EntityTypeConfiguration<MOL_OracleTransactionLog>
    {
        public MOL_OracleTransactionLogMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_OracleTransactionId);

            // Properties
            this.Property(t => t.RepresentativeIdNo)
                .HasMaxLength(50);

            this.Property(t => t.OracleResult)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_OracleTransactionLog");
            this.Property(t => t.PK_OracleTransactionId).HasColumnName("PK_OracleTransactionId");
            this.Property(t => t.FK_Online_Requests).HasColumnName("FK_Online_Requests");
            this.Property(t => t.FK_ServiceId).HasColumnName("FK_ServiceId");
            this.Property(t => t.FK_UserId).HasColumnName("FK_UserId");
            this.Property(t => t.Lab_Off).HasColumnName("Lab_Off");
            this.Property(t => t.Ser_YY).HasColumnName("Ser_YY");
            this.Property(t => t.Seq_No).HasColumnName("Seq_No");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.RepresentativeIdNo).HasColumnName("RepresentativeIdNo");
            this.Property(t => t.TransactionStatus).HasColumnName("TransactionStatus");
            this.Property(t => t.OracleResult).HasColumnName("OracleResult");
            this.Property(t => t.Error).HasColumnName("Error");
            this.Property(t => t.isManPower).HasColumnName("isManPower");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");

            // Relationships
            this.HasRequired(t => t.Enum_Service)
                .WithMany(t => t.MOL_OracleTransactionLog)
                .HasForeignKey(d => d.FK_ServiceId);
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_OracleTransactionLog)
                .HasForeignKey(d => d.FK_EstablishmentId);
            this.HasRequired(t => t.CJD_Online_Requests)
                .WithMany(t => t.MOL_OracleTransactionLog)
                .HasForeignKey(d => d.FK_Online_Requests);
            this.HasRequired(t => t.ST_Online_Requests)
                .WithMany(t => t.MOL_OracleTransactionLog)
                .HasForeignKey(d => d.FK_Online_Requests);
            this.HasOptional(t => t.MOL_User)
                .WithMany(t => t.MOL_OracleTransactionLog)
                .HasForeignKey(d => d.FK_UserId);
        }
    }
}
