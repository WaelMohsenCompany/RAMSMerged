// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="MOL_RAMS_RunAwayTransactionsLog.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MOL.EFDAL.Models
{
    /// <summary>
    /// Class MOL_RAMS_RunAwayTransactionsLog.
    /// </summary>
    public partial class MOL_RAMS_RunAwayTransactionsLog
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the run away request identifier.
        /// </summary>
        /// <value>The run away request identifier.</value>
        public long RunAwayRequestId { get; set; }

        /// <summary>
        /// Gets or sets the request status identifier.
        /// </summary>
        /// <value>The request status identifier.</value>
        public int RequestStatusId { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>The created on.</value>
        public System.DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public long CreatedByIdNumber { get; set; }

        /// <summary>
        /// Gets or sets the applicant user identifier.
        /// </summary>
        /// <value>The applicant user identifier.</value>
        public long ApplicantUserIdNumber { get; set; }

        /// <summary>
        /// Gets or sets the client IP address.
        /// </summary>
        /// <value>The client IP address.</value>
        public string ClientIPAddress { get; set; }

        /// <summary>
        /// Gets or sets the mol laborer moi runaway.
        /// </summary>
        /// <value>The mol laborer moi runaway.</value>
        public virtual MOL_LaborerMOIRunaway MOL_LaborerMOIRunaway { get; set; }
    }
}
