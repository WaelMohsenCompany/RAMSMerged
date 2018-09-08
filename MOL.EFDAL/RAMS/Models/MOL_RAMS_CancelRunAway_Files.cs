// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="MOL_RAMS_CancelRunAway_Files.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MOL.EFDAL.Models
{
    /// <summary>
    /// Class MOL_RAMS_CancelRunAway_Files.
    /// </summary>
    public partial class MOL_RAMS_CancelRunAway_Files
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the run away identifier.
        /// </summary>
        /// <value>The run away identifier.</value>
        public long RunAwayId { get; set; }
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
        /// Gets or sets the mol laborer moi runaway.
        /// </summary>
        /// <value>The mol laborer moi runaway.</value>
        public virtual MOL_LaborerMOIRunaway MOL_LaborerMOIRunaway { get; set; }
    }
}
