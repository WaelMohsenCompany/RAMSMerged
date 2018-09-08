namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EstablishmnetEligibleToTakeAppointmentMap : EntityTypeConfiguration<MOL_EstablishmnetEligibleToTakeAppointment>
    {
        public MOL_EstablishmnetEligibleToTakeAppointmentMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_EstablishmentAppointment);

            // Properties
            // Table & Column Mappings
            this.ToTable("MOL_EstablishmnetEligibleToTakeAppointment");
            this.Property(t => t.PK_EstablishmentAppointment).HasColumnName("PK_EstablishmentAppointment");
            this.Property(t => t.FK_EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.EligibleToTakeAppointment).HasColumnName("EligibleToTakeAppointment");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");

            // Relationships
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_EstablishmnetEligibleToTakeAppointment)
                .HasForeignKey(d => d.FK_EstablishmentId);

        }
    }
}
