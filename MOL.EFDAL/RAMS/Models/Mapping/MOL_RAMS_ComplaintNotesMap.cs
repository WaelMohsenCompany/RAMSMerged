// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="MOL_RAMS_ComplaintNotesMap.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    /// <summary>
    /// Class MOL_RAMS_ComplaintNotesMap.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{MOL.EFDAL.Models.MOL_RAMS_ComplaintNotes}" />
    public class MOL_RAMS_ComplaintNotesMap : EntityTypeConfiguration<MOL_RAMS_ComplaintNotes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RAMS_ComplaintNotesMap"/> class.
        /// </summary>
        public MOL_RAMS_ComplaintNotesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.NoteDays)
                .IsRequired();

            this.Property(t => t.ComplaintTimeId)
                .IsRequired();

            this.Property(t => t.NoteScopeId)
                .IsRequired();

            this.Property(t => t.NoteTypeId)
               .IsRequired();

            // Table & Column Mappings
            this.ToTable("MOL_RAMS_ComplaintNotes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.NoteScopeId).HasColumnName("NoteScopeId");
            this.Property(t => t.NoteTypeId).HasColumnName("NoteTypeId");
            this.Property(t => t.ComplaintTimeId).HasColumnName("ComplaintTimeId");
            this.Property(t => t.NoteDays).HasColumnName("NoteDays");
        }
    }
}
