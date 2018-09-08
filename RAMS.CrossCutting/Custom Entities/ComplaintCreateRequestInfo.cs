// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-04-2018
// ***********************************************************************
// <copyright file="ComplaintCreateRequestInfo.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RAMS.CrossCutting
{
    /// <summary>
    /// Class ComplaintCreateRequestInfo.
    /// </summary>
    [DataContract]
    public class ComplaintCreateRequestInfo
    {
        /// <summary>
        /// Gets or sets the run away request identifier.
        /// </summary>
        /// <value>The run away request identifier.</value>
        [DataMember]
        public int RunAwayRequestId { get; set; }

        /// <summary>
        /// Gets or sets the request number.
        /// </summary>
        /// <value>The request number.</value>
        [DataMember]
        public string RequestNumber { get; set; }

        /// <summary>
        /// Gets or sets the laborer identifier number.
        /// </summary>
        /// <value>The laborer identifier number.</value>
        [DataMember]
        public long? LaborerIdNumber { get; set; }

        /// <summary>
        /// Gets or sets the border number.
        /// </summary>
        /// <value>The border number.</value>
        [DataMember]
        public long? BorderNumber { get; set; }

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
        public DateTime ComplaintQuestion1 { get; set; }

        /// <summary>
        /// Gets or sets the question2.
        /// </summary>
        /// <value>The question2.</value>
        [DataMember]
        public DateTime ComplaintQuestion2 { get; set; }

        /// <summary>
        /// Gets or sets the question3.
        /// </summary>
        /// <value>The question3.</value>
        [DataMember]
        public DateTime ComplaintQuestion3 { get; set; }

        /// <summary>
        /// Gets or sets the question4.
        /// </summary>
        /// <value>The question4.</value>
        [DataMember]
        public string ComplaintQuestion4 { get; set; }

        /// <summary>Gets or sets the laborer mobile no.</summary>
        /// <value>The laborer mobile no.</value>
        [DataMember]
        public string LaborerMobileNo { get; set; }
        //==========================================================
        //Meta-data Members

        /// <summary>
        /// Gets or sets the client IP address.
        /// </summary>
        /// <value>The client IP address.</value>
        public string ClientIPAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is request by laborer.
        /// </summary>
        /// <value><c>true</c> if this instance is request by laborer; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool IsRequestByLaborer { get; set; }

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
