// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 02-20-2018
// ***********************************************************************
// <copyright file="MOL_RAMS_ComplaintTransactionsLogMap.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    /// <summary>
    /// Class MOL_RAMS_ComplaintTransactionsLogMap.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{MOL.EFDAL.Models.MOL_RAMS_ComplaintTransactionsLog}" />
    public class MOL_RAMS_ComplaintTransactionsLogMap : EntityTypeConfiguration<MOL_RAMS_ComplaintTransactionsLog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RAMS_ComplaintTransactionsLogMap"/> class.
        /// </summary>
        public MOL_RAMS_ComplaintTransactionsLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.RequestStatusId)
                .IsRequired();

            this.Property(t => t.CreatedByIdNumber)
                .IsRequired();

            this.Property(t => t.ApplicantUserIdNumber)
                .IsRequired();

            this.Property(t => t.ClientIPAddress)
                .IsRequired();

            this.Property(t => t.CreatedOn)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // Table & Column Mappings
            this.ToTable("MOL_RAMS_ComplaintTransactionsLog");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ComplaintRequestId).HasColumnName("ComplaintRequestId");
            this.Property(t => t.RequestStatusId).HasColumnName("RequestStatusId");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.CreatedByIdNumber).HasColumnName("CreatedByIdNumber");
            this.Property(t => t.ApplicantUserIdNumber).HasColumnName("ApplicantUserIdNumber");
            this.Property(t => t.ClientIPAddress).HasColumnName("ClientIPAddress");

            //========================================================================
            // Relationships
            this.HasRequired(t => t.MOL_RunAwayComplaints)
                .WithMany(t => t.MOL_RAMS_ComplaintTransactionsLog)
                .HasForeignKey(d => d.ComplaintRequestId);
        }
    }
}
