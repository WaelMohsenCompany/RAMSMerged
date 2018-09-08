// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="RunAwayReviewRequestsInfo.cs" company="Tasleem IT for MLSD">
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
    /// Class RunAwayReviewRequestsInfo.
    /// </summary>
    [DataContract]
    [Serializable]
    public class RunAwayReviewRequestsInfo
    {
        //==========================================================
        //RunAway Data
        /// <summary>
        /// Gets or sets the run away request identifier.
        /// </summary>
        /// <value>The run away request identifier.</value>
        [DataMember]
        public int RunAwayRequestId { get; set; }

        /// <summary>
        /// Gets or sets the run away request number.
        /// </summary>
        /// <value>The run away request number.</value>
        [DataMember]
        public string RunAwayRequestNumber { get; set; }

        /// <summary>
        /// Gets or sets the run away request date.
        /// </summary>
        /// <value>The run away request date.</value>
        [DataMember]
        public DateTime RunAwayRequestDate { get; set; }

        /// <summary>
        /// Gets or sets the run away files paths.
        /// </summary>
        /// <value>The run away files paths.</value>
        [DataMember]
        public HashSet<string> RunAwayFilesPaths { get; set; }

        //==========================================================
        //Complaint Data
        /// <summary>
        /// Gets or sets the complaint request identifier.
        /// </summary>
        /// <value>The complaint request identifier.</value>
        [DataMember]
        public int ComplaintRequestId { get; set; }

        /// <summary>
        /// Gets or sets the complaint request date.
        /// </summary>
        /// <value>The complaint request date.</value>
        [DataMember]
        public DateTime ComplaintRequestDate { get; set; }

        /// <summary>
        /// Gets or sets the complaint files paths.
        /// </summary>
        /// <value>The complaint files paths.</value>
        [DataMember]
        public HashSet<string> ComplaintFilesPaths { get; set; }


        //=========================================================
        //Establishment Info
        /// <summary>
        /// Gets or sets the establishment title.
        /// </summary>
        /// <value>The establishment title.</value>
        [DataMember]
        public string EstablishmentTitle { get; set; }

        /// <summary>
        /// Gets or sets the labor office identifier.
        /// </summary>
        /// <value>The labor office identifier.</value>
        [DataMember]
        public int LaborOfficeId { get; set; }

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>The sequence number.</value>
        [DataMember]
        public long SequenceNumber { get; set; }


        //=========================================================
        //Laborer Info
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

        //=========================================================
        //Labor Office Reply
        /// <summary>
        /// Gets or sets the labor office reply details.
        /// </summary>
        /// <value>The labor office reply details.</value>
        [DataMember]
        public string LaborOfficeReplyDetails { get; set; }

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

        /// <summary>
        /// Gets or sets the complaint request status identifier.
        /// </summary>
        /// <value>The complaint request status identifier.</value>
        [DataMember]
        public int ComplaintRequestStatusId { get; set; }

        /// <summary>
        /// Gets or sets the name of the complaint request status.
        /// </summary>
        /// <value>The name of the complaint request status.</value>
        [DataMember]
        public string ComplaintRequestStatusName { get; set; }

        //==========================================================
        //Complaint Request Questions
        /// <summary>
        /// Gets or sets the complaint question1.
        /// </summary>
        /// <value>The complaint question1.</value>
        [DataMember]
        public DateTime? ComplaintQuestion1 { get; set; }

        /// <summary>
        /// Gets or sets the question2.
        /// </summary>
        /// <value>The question2.</value>
        [DataMember]
        public DateTime? ComplaintQuestion2 { get; set; }

        /// <summary>
        /// Gets or sets the question3.
        /// </summary>
        /// <value>The question3.</value>
        [DataMember]
        public DateTime? ComplaintQuestion3 { get; set; }

        /// <summary>
        /// Gets or sets the question4.
        /// </summary>
        /// <value>The question4.</value>
        [DataMember]
        public string ComplaintQuestion4 { get; set; }

        //==========================================================
        //Runaway Creation Request Questions
        /// <summary>
        /// Gets or sets the question1.
        /// </summary>
        /// <value>The question1.</value>
        [DataMember]
        public DateTime? RunAwayQuestion1 { get; set; }

        /// <summary>
        /// Gets or sets the question2.
        /// </summary>
        /// <value>The question2.</value>
        [DataMember]
        public DateTime? RunAwayQuestion2 { get; set; }

        /// <summary>
        /// Gets or sets the question3.
        /// </summary>
        /// <value>The question3.</value>
        [DataMember]
        public DateTime? RunAwayQuestion3 { get; set; }

        /// <summary>
        /// Gets or sets the question4.
        /// </summary>
        /// <value>The question4.</value>
        [DataMember]
        public string RunAwayQuestion4 { get; set; }

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
