// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="MOL_RAMS_Complaint_FilesMap.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    /// <summary>
    /// Class MOL_RAMS_Complaint_FilesMap.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{MOL.EFDAL.Models.MOL_RAMS_Complaint_Files}" />
    class MOL_RAMS_Complaint_FilesMap : EntityTypeConfiguration<MOL_RAMS_Complaint_Files>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RAMS_Complaint_FilesMap"/> class.
        /// </summary>
        public MOL_RAMS_Complaint_FilesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ComplaintId)
                .IsRequired();

            this.Property(t => t.FileName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FilePath)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("MOL_RAMS_Complaint_Files");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ComplaintId).HasColumnName("ComplaintId");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.FilePath).HasColumnName("FilePath");
        }
    }
}
