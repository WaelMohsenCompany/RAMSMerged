// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="MOL_RAMS_RunAway_FilesMap.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    /// <summary>
    /// Class MOL_RAMS_RunAway_FilesMap.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{MOL.EFDAL.Models.MOL_RAMS_RunAway_Files}" />
    public class MOL_RAMS_RunAway_FilesMap : EntityTypeConfiguration<MOL_RAMS_RunAway_Files>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RAMS_RunAway_FilesMap"/> class.
        /// </summary>
        public MOL_RAMS_RunAway_FilesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.Property(t => t.FileName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FilePath)
                .IsRequired()
                .HasMaxLength(250);

            // Relationships
            this.HasRequired(t => t.MOL_LaborerMOIRunaway)
                .WithMany(t => t.MOL_RAMS_RunAway_Files)
                .HasForeignKey(d => d.RunAwayId);

            // Table & Column Mappings
            this.ToTable("MOL_RAMS_RunAway_Files");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RunAwayId).HasColumnName("RunAwayId");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.FilePath).HasColumnName("FilePath");
        }
    }
}
