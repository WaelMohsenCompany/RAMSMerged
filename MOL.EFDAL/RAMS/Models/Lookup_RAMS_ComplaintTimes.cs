// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="Lookup_RAMS_ComplaintTimes.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace MOL.EFDAL.Models
{
    /// <summary>
    /// Class Lookup_RAMS_ComplaintTimes.
    /// </summary>
    public partial class Lookup_RAMS_ComplaintTimes
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the complaint time.
        /// </summary>
        /// <value>The complaint time.</value>
        public string ComplaintTime { get; set; }
        /// <summary>
        /// Gets or sets the complaint order.
        /// </summary>
        /// <value>The complaint order.</value>
        public int ComplaintOrder { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        ///// <summary>
        ///// Gets or sets the mol rams complaint notes.
        ///// </summary>
        ///// <value>The mol rams complaint notes.</value>
        //public virtual MOL_RAMS_ComplaintNotes MOL_RAMS_ComplaintNotes { get; set; }
    }
}
