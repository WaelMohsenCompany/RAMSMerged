// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-04-2018
// ***********************************************************************
// <copyright file="ComplaintRetrieveRequestInfo.cs" company="Tasleem IT for MLSD">
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
    /// Class ComplaintRetrieveRequestInfo.
    /// </summary>
    [DataContract]
    [Serializable]
    public class ComplaintRetrieveRequestInfo
    {
        //==========================================================
        //RunAway Info
        /// <summary>
        /// Gets or sets the run away request identifier.
        /// </summary>
        /// <value>The run away request identifier.</value>
        [DataMember]
        public int RunAwayRequestId { get; set; }

        /// <summary>
        /// Gets or sets the complaint request identifier.
        /// </summary>
        /// <value>The complaint request identifier.</value>
        [DataMember]
        public int? ComplaintRequestId { get; set; }

        /// <summary>
        /// Gets or sets the run away request number.
        /// </summary>
        /// <value>The run away request number.</value>
        [DataMember]
        public string RunAwayRequestNumber { get; set; }

        /// <summary>
        /// Gets or sets the establishment title.
        /// </summary>
        /// <value>The establishment title.</value>
        [DataMember]
        public string EstablishmentTitle { get; set; }

        /// <summary>
        /// Gets or sets the run away request date.
        /// </summary>
        /// <value>The run away request date.</value>
        [DataMember]
        public DateTime RunAwayRequestDate { get; set; }

        /// <summary>
        /// Gets or sets the complaint request date.
        /// </summary>
        /// <value>The complaint request date.</value>
        [DataMember]
        public DateTime? ComplaintRequestDate { get; set; }

        /// <summary>
        /// Gets or sets the files paths.
        /// </summary>
        /// <value>The files paths.</value>
        [DataMember]
        public List<string> FilesPaths { get; set; }
        //==========================================================
        //Request Questions
        /// <summary>
        /// Gets or sets the question1.
        /// </summary>
        /// <value>The question1.</value>
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

        /// <summary>Gets or sets the laborer mobile no.</summary>
        /// <value>The laborer mobile no.</value>
        [DataMember]
        public string LaborerMobileNo { get; set; }
        //=========================================================
        //Final Labor Office Approval Reply
        /// <summary>
        /// Gets or sets the labor office approval reply details.
        /// </summary>
        /// <value>The labor office approval reply details.</value>
        [DataMember]
        public string RejectReason { get; set; }

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
        public int? ComplaintRequestStatusId { get; set; }

        /// <summary>
        /// Gets or sets the name of the complaint request status.
        /// </summary>
        /// <value>The name of the complaint request status.</value>
        [DataMember]
        public string ComplaintRequestStatusName { get; set; }
    }
}

