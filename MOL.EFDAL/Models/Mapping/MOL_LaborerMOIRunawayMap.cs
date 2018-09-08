namespace MOL.EFDAL.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class MOL_LaborerMOIRunawayMap : EntityTypeConfiguration<MOL_LaborerMOIRunaway>
    {
        public MOL_LaborerMOIRunawayMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.IDNumber).IsOptional();

            //=========================================================================
            #region " New Properties added by RAMS"

            // Properties
            this.Property(t => t.RequestNumber).HasMaxLength(15);
            this.Property(t => t.LaborerBorderNumber).IsOptional();
            this.Property(t => t.LaborerFullName).HasMaxLength(150);
            this.Property(t => t.LaborerOfficeId).IsOptional();
            this.Property(t => t.SequenceNumber).IsOptional();
            this.Property(t => t.EstablishmentTitle).HasMaxLength(250);
            this.Property(t => t.RequestStatusId).IsOptional();
            this.Property(t => t.CancelReason).HasMaxLength(2000);
            this.Property(t => t.IsRequestByEstablishmentAgent).IsOptional();
            this.Property(t => t.NoteId).IsOptional();
            this.Property(t => t.CreatedByIdNumber).IsOptional();
            this.Property(t => t.ApplicantUserIdNumber).IsOptional();
            this.Property(t => t.ModifiedOn).IsOptional();
            this.Property(t => t.ModifiedByIdNumber).IsOptional();
            this.Property(t => t.ModifiedByApplicantUserIdNumber).IsOptional();
            this.Property(t => t.CancellationDate).IsOptional();

            this.Property(t => t.CreationQuestion1).IsRequired();
            this.Property(t => t.CreationQuestion2).IsRequired();
            this.Property(t => t.CreationQuestion3).IsRequired();
            this.Property(t => t.CreationQuestion4).IsRequired().HasMaxLength(2000);
            this.Property(t => t.CancelQuestion1);

            this.Property(t => t.CreatedOn).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            #endregion
            //============================================================================================

            // Table & Column Mappings
            this.ToTable("MOL_LaborerMOIRunaway");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.LaborerId).HasColumnName("LaborerId");
            this.Property(t => t.EstablishmentId).HasColumnName("EstablishmentId");
            this.Property(t => t.IDNumber).HasColumnName("IDNumber");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.IsCancelRunaway).HasColumnName("IsCancelRunaway");

            //============================================================================================
            #region " New Column added by RAMS"

            this.Property(t => t.RequestNumber).HasColumnName("RequestNumber ");
            this.Property(t => t.LaborerBorderNumber).HasColumnName("LaborerBorderNumber");
            this.Property(t => t.LaborerFullName).HasColumnName("LaborerFullName");
            this.Property(t => t.LaborerOfficeId).HasColumnName("LaborerOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.EstablishmentTitle).HasColumnName("EstablishmentTitle");
            this.Property(t => t.RequestStatusId).HasColumnName("RequestStatusId");
            this.Property(t => t.CancelReason).HasColumnName("CancelReason");
            this.Property(t => t.IsRequestByEstablishmentAgent).HasColumnName("IsRequestByEstablishmentAgent");
            this.Property(t => t.NoteId).HasColumnName("NoteId");
            this.Property(t => t.CreatedByIdNumber).HasColumnName("CreatedByIdNumber");
            this.Property(t => t.ApplicantUserIdNumber).HasColumnName("ApplicantUserIdNumber");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.ModifiedByIdNumber).HasColumnName("ModifiedByIdNumber");
            this.Property(t => t.ModifiedByApplicantUserIdNumber).HasColumnName("ModifiedByApplicantUserIdNumber");
            this.Property(t => t.CancellationDate).HasColumnName("CancellationDate");

            this.Property(t => t.CreationQuestion1).HasColumnName("CreationQuestion1");
            this.Property(t => t.CreationQuestion2).HasColumnName("CreationQuestion2");
            this.Property(t => t.CreationQuestion3).HasColumnName("CreationQuestion3");
            this.Property(t => t.CreationQuestion4).HasColumnName("CreationQuestion4");
            this.Property(t => t.CancelQuestion1).HasColumnName("CancelQuestion1");

            #endregion
            //============================================================================================
        }
    }
}
