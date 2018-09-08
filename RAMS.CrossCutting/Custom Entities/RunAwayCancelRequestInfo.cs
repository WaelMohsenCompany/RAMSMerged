// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-04-2018
// ***********************************************************************
// <copyright file="RunAwayCancelRequestInfo.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace RAMS.CrossCutting
{
    /// <summary>
    /// Class RunAwayCancelRequestInfo.
    /// </summary>
    public class RunAwayCancelRequestInfo
    {
        //==========================================================
        //Data Members
        /// <summary>
        /// Gets or sets the request number.
        /// </summary>
        /// <value>The request number.</value>
        public string RequestNumber { get; set; }

        /// <summary>
        /// Gets or sets the cancel reason.
        /// </summary>
        /// <value>The cancel reason.</value>
        public string CancelReason { get; set; }

        /// <summary>
        /// Gets or sets the files paths.
        /// </summary>
        /// <value>The files paths.</value>
        public HashSet<string> FilesPaths { get; set; }
        //==========================================================
        //Request Questions
        /// <summary>
        /// Gets or sets the Cancel Question1.
        /// </summary>
        /// <value>The Cancel Question1.</value>
        public DateTime CancelQuestion1 { get; set; }

        //==========================================================
        //Meta-data Members

        /// <summary>
        /// Gets or sets the client IP address.
        /// </summary>
        /// <value>The client IP address.</value>
        public string ClientIPAddress { get; set; }

        /// <summary>
        /// Gets or sets the applicant user identifier.
        /// </summary>
        /// <value>The applicant user identifier.</value>
        public long ApplicantUserIdNumber { get; set; }

        /// <summary>
        /// Gets or sets the created by IdNumber.
        /// </summary>
        /// <value>The created by IdNumber.</value>
        public long CreatedByIdNumber { get; set; }

    }
}
