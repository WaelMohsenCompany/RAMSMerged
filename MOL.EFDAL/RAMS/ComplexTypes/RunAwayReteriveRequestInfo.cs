// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-04-2018
// ***********************************************************************
// <copyright file="RunAwayReteriveRequestInfo.cs" company="MOL">
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
    /// Class RunAwayRetrieveRequestInfo.
    /// </summary>
    [DataContract]
    public class RunAwayRetrieveRequestInfo
    {
        //==========================================================
        //Data Members
        /// <summary>
        /// Gets or sets the request identifier.
        /// </summary>
        /// <value>The request identifier.</value>
        [DataMember]
        public long RequestId { get; set; }

        /// <summary>
        /// Gets or sets the complaint request identifier.
        /// </summary>
        /// <value>The complaint request identifier.</value>
        [DataMember]
        public int? ComplaintRequestId { get; set; }

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
        /// Gets or sets the establishment title.
        /// </summary>
        /// <value>The establishment title.</value>
        [DataMember]
        public string EstablishmentTitle { get; set; }

        /// <summary>
        /// Gets or sets the establishment identifier.
        /// </summary>
        /// <value>The establishment identifier.</value>
        [DataMember]
        public long EstablishmentId { get; set; }

        /// <summary>
        /// Gets or sets the request date.
        /// </summary>
        /// <value>The request date.</value>
        [DataMember]
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// Gets or sets the files paths.
        /// </summary>
        /// <value>The files paths.</value>
        [DataMember]
        public List<string> FilesPaths { get; set; }

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
        //==========================================================
        //Request Questions
        /// <summary>
        /// Gets or sets the question1.
        /// </summary>
        /// <value>The question1.</value>
        [DataMember]
        public DateTime? CreationQuestion1 { get; set; }

        /// <summary>
        /// Gets or sets the question2.
        /// </summary>
        /// <value>The question2.</value>
        [DataMember]
        public DateTime? CreationQuestion2 { get; set; }

        /// <summary>
        /// Gets or sets the question3.
        /// </summary>
        /// <value>The question3.</value>
        [DataMember]
        public DateTime? CreationQuestion3 { get; set; }

        /// <summary>
        /// Gets or sets the question4.
        /// </summary>
        /// <value>The question4.</value>
        [DataMember]
        public string CreationQuestion4 { get; set; }

        //==========================================================
        //Status Members
        /// <summary>
        /// Gets or sets the run away request status identifier.
        /// </summary>
        /// <value>The run away request status identifier.</value>
        [DataMember]
        public int RunAwayRequestStatusId { get; set; }

        /// <summary>
        /// Gets or sets the name of the run away request status.
        /// </summary>
        /// <value>The name of the run away request status.</value>
        [DataMember]
        public string RunAwayRequestStatusName { get; set; }

        //==========================================================
        //Rows Count
        /// <summary>
        /// Gets or sets the total rows count.
        /// </summary>
        /// <value>The total rows count.</value>
        [DataMember]
        public int TotalRowsCount { get; set; }

    }
}
