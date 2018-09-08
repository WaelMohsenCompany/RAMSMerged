// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="RunAwayCreateRequestInfo.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace RAMS.CrossCutting
{
    /// <summary>
    /// Class definition for input parameters of RunAway Request
    /// </summary>
    public class RunAwayCreateRequestInfo
    {
        //==========================================================
        //Data Members
        /// <summary>
        /// Gets or sets the laborer office identifier.
        /// </summary>
        /// <value>The laborer office identifier.</value>
        public int LaborerOfficeId { get; set; }

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>The sequence number.</value>
        public long SequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the establishment identifier.
        /// </summary>
        /// <value>The establishment identifier.</value>
        public string EstablishmentId { get; set; }

        /// <summary>
        /// Gets or sets the establishment title.
        /// </summary>
        /// <value>The establishment title.</value>
        public string EstablishmentTitle { get; set; }

        /// <summary>
        /// Gets or sets the laborer identifier number.
        /// </summary>
        /// <value>The laborer identifier number.</value>
        public long? LaborerIdNumber { get; set; }

        /// <summary>
        /// Gets or sets the laborer border number.
        /// </summary>
        /// <value>The laborer border number.</value>
        public long? LaborerBorderNumber { get; set; }

        /// <summary>
        /// Gets or sets the full name of the laborer.
        /// </summary>
        /// <value>The full name of the laborer.</value>
        public string LaborerFullName { get; set; }

        /// <summary>
        /// Gets or sets the files paths.
        /// </summary>
        /// <value>The files paths.</value>
        public HashSet<string> FilesPaths { get; set; }
        //==========================================================
        //Request Questions
        /// <summary>
        /// Gets or sets the question1.
        /// </summary>
        /// <value>The question1.</value>
        public DateTime CreationQuestion1 { get; set; }

        /// <summary>
        /// Gets or sets the question2.
        /// </summary>
        /// <value>The question2.</value>
        public DateTime CreationQuestion2 { get; set; }

        /// <summary>
        /// Gets or sets the question3.
        /// </summary>
        /// <value>The question3.</value>
        public DateTime CreationQuestion3 { get; set; }

        /// <summary>
        /// Gets or sets the question4.
        /// </summary>
        /// <value>The question4.</value>
        public string CreationQuestion4 { get; set; }

        //==========================================================
        //Meta-data Members

        /// <summary>
        /// Gets or sets the client IP address.
        /// </summary>
        /// <value>The client IP address.</value>
        public string ClientIPAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is request by establishment agent.
        /// </summary>
        /// <value><c>true</c> if this instance is request by establishment agent; otherwise, <c>false</c>.</value>
        public bool IsRequestByEstablishmentAgent { get; set; }

        /// <summary>
        /// Gets or sets the applicant user identifier.
        /// </summary>
        /// <value>The applicant user identifier.</value>
        public long ApplicantUserIdNumber { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public long CreatedByIdNumber { get; set; }

    }
}
