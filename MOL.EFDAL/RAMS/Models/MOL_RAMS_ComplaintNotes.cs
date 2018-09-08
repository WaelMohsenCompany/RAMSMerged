// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="MOL_RAMS_ComplaintNotes.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MOL.EFDAL.Models
{
    /// <summary>
    /// Class MOL_RAMS_ComplaintNotes.
    /// </summary>
    public class MOL_RAMS_ComplaintNotes
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the complaint time identifier.
        /// </summary>
        /// <value>The complaint time identifier.</value>
        public int ComplaintTimeId { get; set; }
        /// <summary>
        /// Gets or sets the note type identifier.
        /// </summary>
        /// <value>The note type identifier.</value>
        public int NoteTypeId { get; set; }
        /// <summary>
        /// Gets or sets the note scope identifier.
        /// </summary>
        /// <value>The note scope identifier.</value>
        public int NoteScopeId { get; set; }
        /// <summary>
        /// Gets or sets the note days.
        /// </summary>
        /// <value>The note days.</value>
        public int NoteDays { get; set; }

        ///// <summary>
        ///// Gets or sets the lookup rams complaint times.
        ///// </summary>
        ///// <value>The lookup rams complaint times.</value>
        //public virtual Lookup_RAMS_ComplaintTimes Lookup_RAMS_ComplaintTimes { get; set; }

        ///// <summary>
        ///// Gets or sets the lookup rams note scope.
        ///// </summary>
        ///// <value>The lookup rams note scope.</value>
        //public virtual Enum_NoteApplicability Enum_NoteApplicability { get; set; }

        ///// <summary>
        ///// Gets or sets the type of the lookup rams note.
        ///// </summary>
        ///// <value>The type of the lookup rams note.</value>
        //public virtual Enum_NoteType Enum_NoteType { get; set; }
    }
}
