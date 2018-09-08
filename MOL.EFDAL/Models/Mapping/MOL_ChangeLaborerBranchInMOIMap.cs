namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class MOL_ChangeLaborerBranchInMOIMap : EntityTypeConfiguration<MOL_ChangeLaborerBranchInMOI>
    {
        public MOL_ChangeLaborerBranchInMOIMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.LaborerId)
                .IsRequired();

            this.Property(t => t.EstablishmentId)
                .IsRequired();

            this.Property(t => t.UserId)
                .IsRequired();

            this.Property(t => t.UserIdNumber)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.CreateDate)
                .IsRequired();

            this.Property(t => t.ClientIP)
                .IsRequired()
                .HasMaxLength(50);



            // Table & Column Mappings
            this.ToTable("MOL_ChangeLaborerBranchInMOI");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.LaborerId).HasColumnName("LaborerId");
            this.Property(t => t.EstablishmentId).HasColumnName("EstablishmentId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.UserIdNumber).HasColumnName("UserIdNumber");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.ClientIP).HasColumnName("ClientIP");

            // Relationships
            this.HasRequired(t => t.MOL_Laborer)
                .WithMany(t => t.MOL_ChangeLaborerBranchInMOI)
                .HasForeignKey(t => t.LaborerId);

            this.HasRequired(t => t.MOL_Establishment)
                .WithMany(t => t.MOL_ChangeLaborerBranchInMOI)
                .HasForeignKey(t => t.EstablishmentId);

            this.HasRequired(t => t.MOL_User)
                .WithMany(t => t.MOL_ChangeLaborerBranchInMOI)
                .HasForeignKey(t => t.UserId);
        }
    }
}
