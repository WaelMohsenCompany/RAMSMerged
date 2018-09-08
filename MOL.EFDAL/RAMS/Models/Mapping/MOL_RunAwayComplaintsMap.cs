// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 02-20-2018
// ***********************************************************************
// <copyright file="MOL_RunAwayComplaintsMap.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    /// <summary>
    /// Class MOL_RunAwayComplaintsMap.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{MOL.EFDAL.Models.MOL_RunAwayComplaints}" />
    public class MOL_RunAwayComplaintsMap : EntityTypeConfiguration<MOL_RunAwayComplaints>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RunAwayComplaintsMap"/> class.
        /// </summary>
        public MOL_RunAwayComplaintsMap()
        {
            // Primary Key
            this.HasKey(t => t.ComplaintID);

            // Properties
            this.Property(t => t.Status).IsRequired();
            this.Property(t => t.RejectReason).IsOptional().HasMaxLength(2000);
            this.Property(t => t.ComplaintDate)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            this.Property(t => t.DecisionDate).IsOptional();
            this.Property(t => t.DecidedByUserID).IsOptional();
            this.Property(t => t.CreatedByUserIdNumber).IsRequired();
            this.Property(t => t.LaborOfficeReplyDetails).IsOptional().HasMaxLength(2000);
            this.Property(t => t.LaborerMobileNo).IsOptional().HasMaxLength(12);

            this.Property(t => t.ComplaintQuestion1).IsRequired();
            this.Property(t => t.ComplaintQuestion2).IsRequired();
            this.Property(t => t.ComplaintQuestion3).IsRequired();
            this.Property(t => t.ComplaintQuestion4).IsRequired().HasMaxLength(2000);

            this.Property(t => t.IsRequestByLaborer).IsOptional();
            this.Property(t => t.ApplicantUserIdNumber).IsOptional();
            this.Property(t => t.ModifiedOn).IsOptional();
            this.Property(t => t.ModifiedByIdNumber).IsOptional();
            this.Property(t => t.ModifiedByApplicantUserIdNumber).IsOptional();

            //========================================================================
            //Obsolete Fields
            this.Property(t => t.ClientIPAddress)
                .IsOptional()
                .HasMaxLength(50)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            this.Property(t => t.ComplaintSequence)
                .IsOptional()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            this.Property(t => t.NoteEndDate)
                .IsOptional()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            this.Property(t => t.FKEstablishmentID)
                .IsOptional()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            this.Property(t => t.RunAwayLaborID)
                .IsOptional()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            //========================================================================
            // Table & Column Mappings
            this.ToTable("MOL_RunAwayComplaints");
            this.Property(t => t.ComplaintID).HasColumnName("ComplaintID");
            this.Property(t => t.RunAwayRequestId).HasColumnName("RunAwayRequestId");

            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.LaborOfficeReplyDetails).HasColumnName("LaborOfficeReplyDetails");
            this.Property(t => t.RejectReason).HasColumnName("RejectReason");
            this.Property(t => t.DecisionDate).HasColumnName("DecisionDate");
            this.Property(t => t.DecidedByUserID).HasColumnName("DecidedByUserID");
            this.Property(t => t.IsRequestByLaborer).HasColumnName("IsRequestByLaborer");
            this.Property(t => t.ComplaintDate).HasColumnName("ComplaintDate");
            this.Property(t => t.CreatedByUserIdNumber).HasColumnName("CreatedByUserIdNumber");
            this.Property(t => t.ApplicantUserIdNumber).HasColumnName("ApplicantUserIdNumber");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.ModifiedByIdNumber).HasColumnName("ModifiedByIdNumber");
            this.Property(t => t.ModifiedByApplicantUserIdNumber).HasColumnName("ModifiedByApplicantUserIdNumber");
            this.Property(t => t.RunAwayLaborID).HasColumnName("RunAwayLaborID");
            this.Property(t => t.FKEstablishmentID).HasColumnName("FKEstablishmentID");
            this.Property(t => t.NoteEndDate).HasColumnName("NoteEndDate");
            this.Property(t => t.ComplaintSequence).HasColumnName("ComplaintSequence");
            this.Property(t => t.ClientIPAddress).HasColumnName("ClientIPAddress");

            this.Property(t => t.ComplaintQuestion1).HasColumnName("ComplaintQuestion1");
            this.Property(t => t.ComplaintQuestion2).HasColumnName("ComplaintQuestion2");
            this.Property(t => t.ComplaintQuestion3).HasColumnName("ComplaintQuestion3");
            this.Property(t => t.ComplaintQuestion4).HasColumnName("ComplaintQuestion4");
            this.Property(t => t.LaborerMobileNo).HasColumnName("LaborerMobileNo");
            //========================================================================
            // Relationships
            this.HasOptional(t => t.MOL_LaborerMOIRunaway)
                .WithMany(t => t.MOL_RunAwayComplaints)
                .HasForeignKey(d => d.RunAwayRequestId);
        }
    }
}
