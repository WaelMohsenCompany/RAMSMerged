namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_EEF_OnlineRequestsMap : EntityTypeConfiguration<MOL_EEF_OnlineRequests>
    {
        public MOL_EEF_OnlineRequestsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Before)
                .HasMaxLength(4000);

            this.Property(t => t.After)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("MOL_EEF_OnlineRequests");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FK_UserId).HasColumnName("FK_UserId");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.FK_EstablishmentID).HasColumnName("FK_EstablishmentID");
            this.Property(t => t.IsManPower).HasColumnName("IsManPower");
            this.Property(t => t.Before).HasColumnName("Before");
            this.Property(t => t.After).HasColumnName("After");

            // Relationships
            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_EEF_OnlineRequests)
                .HasForeignKey(d => d.FK_EstablishmentID);
            this.HasRequired(t => t.MOL_User)
                .WithMany(t => t.MOL_EEF_OnlineRequests)
                .HasForeignKey(d => d.FK_UserId);

        }
    }
}
