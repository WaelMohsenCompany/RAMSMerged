// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="MOL_RAMS_Complaint_Files.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MOL.EFDAL.Models
{
    /// <summary>
    /// Class MOL_RAMS_Complaint_Files.
    /// </summary>
    public partial class MOL_RAMS_Complaint_Files
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the complaint identifier.
        /// </summary>
        /// <value>The complaint identifier.</value>
        public int ComplaintId { get; set; }
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the mol run away complaints.
        /// </summary>
        /// <value>The mol run away complaints.</value>
        public virtual MOL_RunAwayComplaints MOL_RunAwayComplaints { get; set; }
    }
}
