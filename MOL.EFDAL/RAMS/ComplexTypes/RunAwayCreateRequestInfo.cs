// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-04-2018
// ***********************************************************************
// <copyright file="RunAwayCreateRequestInfo.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MOL.EFDAL.ComplexTypes
{
    /// <summary>
    /// Class definition for input parameters of RunAway Request
    /// </summary>
    [DataContract]
    public class RunAwayCreateRequestInfo
    {
        //==========================================================
        //Data Members
        /// <summary>
        /// Gets or sets the laborer office identifier.
        /// </summary>
        /// <value>The laborer office identifier.</value>
        [DataMember]
        public int LaborerOfficeId { get; set; }

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>The sequence number.</value>
        [DataMember]
        public long SequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the establishment identifier.
        /// </summary>
        /// <value>The establishment identifier.</value>
        [DataMember]
        public string EstablishmentId { get; set; }

        /// <summary>
        /// Gets or sets the establishment title.
        /// </summary>
        /// <value>The establishment title.</value>
        [DataMember]
        public string EstablishmentTitle { get; set; }

        /// <summary>
        /// Gets or sets the laborer identifier number.
        /// </summary>
        /// <value>The laborer identifier number.</value>
        [DataMember]
        public long? LaborerIdNumber { get; set; }

        /// <summary>
        /// Gets or sets the laborer border number.
        /// </summary>
        /// <value>The laborer border number.</value>
        [DataMember]
        public long? LaborerBorderNumber { get; set; }

        /// <summary>
        /// Gets or sets the full name of the laborer.
        /// </summary>
        /// <value>The full name of the laborer.</value>
        [DataMember]
        public string LaborerFullName { get; set; }

        /// <summary>
        /// Gets or sets the files paths.
        /// </summary>
        /// <value>The files paths.</value>
        [DataMember]
        public HashSet<string> FilesPaths { get; set; }
        //==========================================================
        //Request Questions
        /// <summary>
        /// Gets or sets the question1.
        /// </summary>
        /// <value>The question1.</value>
        [DataMember]
        public DateTime Question1 { get; set; }

        /// <summary>
        /// Gets or sets the question2.
        /// </summary>
        /// <value>The question2.</value>
        [DataMember]
        public DateTime Question2 { get; set; }

        /// <summary>
        /// Gets or sets the question3.
        /// </summary>
        /// <value>The question3.</value>
        [DataMember]
        public DateTime Question3 { get; set; }

        /// <summary>
        /// Gets or sets the question4.
        /// </summary>
        /// <value>The question4.</value>
        [DataMember]
        public string Question4 { get; set; }

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
        [DataMember]
        public bool IsRequestByEstablishmentAgent { get; set; }

        /// <summary>
        /// Gets or sets the applicant user identifier.
        /// </summary>
        /// <value>The applicant user identifier.</value>
        [DataMember]
        public long ApplicantUserIdNumber { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [DataMember]
        public long CreatedByIdNumber { get; set; }

    }
}
