// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 02-20-2018
// ***********************************************************************
// <copyright file="MOL_RunAwayComplaints.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace MOL.EFDAL.Models
{
    /// <summary>
    /// Class MOL_RunAwayComplaints.
    /// </summary>
    public partial class MOL_RunAwayComplaints
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RunAwayComplaints"/> class.
        /// </summary>
        public MOL_RunAwayComplaints()
        {
            this.MOL_RAMS_Complaint_Files = new HashSet<MOL_RAMS_Complaint_Files>();
            this.MOL_RAMS_ComplaintTransactionsLog = new HashSet<MOL_RAMS_ComplaintTransactionsLog>();
        }

        /// <summary>
        /// Gets or sets the complaint identifier.
        /// </summary>
        /// <value>The complaint identifier.</value>
        public int ComplaintID { get; set; }
        /// <summary>
        /// Gets or sets the run away request identifier.
        /// </summary>
        /// <value>The run away request identifier.</value>
        public long? RunAwayRequestId { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public int Status { get; set; }
        /// <summary>
        /// Gets or sets the labor office reply details.
        /// </summary>
        /// <value>The labor office reply details.</value>
        public string LaborOfficeReplyDetails { get; set; }
        /// <summary>
        /// Gets or sets the reject reason.
        /// </summary>
        /// <value>The reject reason.</value>
        public string RejectReason { get; set; }
        /// <summary>
        /// Gets or sets the decision date.
        /// </summary>
        /// <value>The decision date.</value>
        public DateTime? DecisionDate { get; set; }
        /// <summary>
        /// Gets or sets the decided by user identifier.
        /// </summary>
        /// <value>The decided by user identifier.</value>
        public int? DecidedByUserID { get; set; }
        /// <summary>
        /// Gets or sets the is request by laborer.
        /// </summary>
        /// <value>The is request by laborer.</value>
        public bool? IsRequestByLaborer { get; set; }
        /// <summary>
        /// Gets or sets the complaint date.
        /// </summary>
        /// <value>The complaint date.</value>
        public DateTime ComplaintDate { get; set; }
        /// <summary>
        /// Gets or sets the created by user identifier.
        /// </summary>
        /// <value>The created by user identifier.</value>
        public long CreatedByUserIdNumber { get; set; }
        /// <summary>
        /// Gets or sets the applicant user identifier.
        /// </summary>
        /// <value>The applicant user identifier.</value>
        public long? ApplicantUserIdNumber { get; set; }
        /// <summary>Gets or sets the laborer mobile no.</summary>
        /// <value>The laborer mobile no.</value>
        public string LaborerMobileNo { get; set; }
        /// <summary>
        /// Gets or sets the modified on.
        /// </summary>
        /// <value>The modified on.</value>
        public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>The modified by.</value>
        public long? ModifiedByIdNumber { get; set; }
        /// <summary>
        /// Gets or sets the modified by applicant user identifier.
        /// </summary>
        /// <value>The modified by applicant user identifier.</value>
        public long? ModifiedByApplicantUserIdNumber { get; set; }
        /// <summary>
        /// Gets or sets the run away labor identifier.
        /// </summary>
        /// <value>The run away labor identifier.</value>
        public long? RunAwayLaborID { get; set; }
        /// <summary>
        /// Gets or sets the fk establishment identifier.
        /// </summary>
        /// <value>The fk establishment identifier.</value>
        public long? FKEstablishmentID { get; set; }
        /// <summary>
        /// Gets or sets the note end date.
        /// </summary>
        /// <value>The note end date.</value>
        public DateTime? NoteEndDate { get; set; }
        /// <summary>
        /// Gets or sets the complaint sequence.
        /// </summary>
        /// <value>The complaint sequence.</value>
        public int? ComplaintSequence { get; set; }
        /// <summary>
        /// Gets or sets the client ip address.
        /// </summary>
        /// <value>The client ip address.</value>
        public string ClientIPAddress { get; set; }

        //==========================================================
        //Request Questions
        /// <summary>
        /// Gets or sets the question1.
        /// </summary>
        /// <value>The question1.</value>
        public DateTime? ComplaintQuestion1 { get; set; }

        /// <summary>
        /// Gets or sets the question2.
        /// </summary>
        /// <value>The question2.</value>
        public DateTime? ComplaintQuestion2 { get; set; }

        /// <summary>
        /// Gets or sets the question3.
        /// </summary>
        /// <value>The question3.</value>
        public DateTime? ComplaintQuestion3 { get; set; }

        /// <summary>
        /// Gets or sets the question4.
        /// </summary>
        /// <value>The question4.</value>
        public string ComplaintQuestion4 { get; set; }

        /// <summary>
        /// Gets or sets the mol laborer moi runaway.
        /// </summary>
        /// <value>The mol laborer moi runaway.</value>
        public virtual MOL_LaborerMOIRunaway MOL_LaborerMOIRunaway { get; set; }
        /// <summary>
        /// Gets or sets the mol rams complaint files.
        /// </summary>
        /// <value>The mol rams complaint files.</value>
        public virtual ICollection<MOL_RAMS_Complaint_Files> MOL_RAMS_Complaint_Files { get; set; }
        /// <summary>
        /// Gets or sets the mol rams complaint transactions log.
        /// </summary>
        /// <value>The mol rams complaint transactions log.</value>
        public virtual ICollection<MOL_RAMS_ComplaintTransactionsLog> MOL_RAMS_ComplaintTransactionsLog { get; set; }
    }
}
