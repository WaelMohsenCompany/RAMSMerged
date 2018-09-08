// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="MOL_LaborerMOIRunaway.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace MOL.EFDAL.Models
{
    /// <summary>
    /// Class MOL_LaborerMOIRunaway.
    /// </summary>
    public partial class MOL_LaborerMOIRunaway
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_LaborerMOIRunaway"/> class.
        /// </summary>
        public MOL_LaborerMOIRunaway()
        {
            MOL_RAMS_CancelRunAway_Files = new HashSet<MOL_RAMS_CancelRunAway_Files>();
            MOL_RAMS_RunAway_Files = new HashSet<MOL_RAMS_RunAway_Files>();
            MOL_RAMS_RunAwayTransactionsLog = new HashSet<MOL_RAMS_RunAwayTransactionsLog>();
            MOL_RunAwayComplaints = new HashSet<MOL_RunAwayComplaints>();
        }

        /// <summary>
        /// Gets or sets the request number.
        /// </summary>
        /// <value>The request number.</value>
        public string RequestNumber { get; set; }
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
        /// Gets or sets the laborer office identifier.
        /// </summary>
        /// <value>The laborer office identifier.</value>
        public int? LaborerOfficeId { get; set; }
        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>The sequence number.</value>
        public long? SequenceNumber { get; set; }
        /// <summary>
        /// Gets or sets the establishment title.
        /// </summary>
        /// <value>The establishment title.</value>
        public string EstablishmentTitle { get; set; }
        /// <summary>
        /// Gets or sets the request status identifier.
        /// </summary>
        /// <value>The request status identifier.</value>
        public int? RequestStatusId { get; set; }
        /// <summary>
        /// Gets or sets the cancel reason.
        /// </summary>
        /// <value>The cancel reason.</value>
        public string CancelReason { get; set; }

        //==========================================================
        //Request Questions
        /// <summary>
        /// Gets or sets the question1.
        /// </summary>
        /// <value>The question1.</value>
        public DateTime? CreationQuestion1 { get; set; }

        /// <summary>
        /// Gets or sets the question2.
        /// </summary>
        /// <value>The question2.</value>
        public DateTime? CreationQuestion2 { get; set; }

        /// <summary>
        /// Gets or sets the question3.
        /// </summary>
        /// <value>The question3.</value>
        public DateTime? CreationQuestion3 { get; set; }

        /// <summary>
        /// Gets or sets the question4.
        /// </summary>
        /// <value>The question4.</value>
        public string CreationQuestion4 { get; set; }

        /// <summary>
        /// Gets or sets the question4.
        /// </summary>
        /// <value>The question4.</value>
        public DateTime? CancelQuestion1 { get; set; }

        /// <summary>
        /// Gets or sets the is request by establishment agent.
        /// </summary>
        /// <value>The is request by establishment agent.</value>
        public bool? IsRequestByEstablishmentAgent { get; set; }

        /// <summary>
        /// Gets or sets the laborer border number.
        /// </summary>
        /// <value>The laborer border number.</value>
        public int? NoteId { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public long? CreatedByIdNumber { get; set; }
        /// <summary>
        /// Gets or sets the applicant user identifier.
        /// </summary>
        /// <value>The applicant user identifier.</value>
        public long? ApplicantUserIdNumber { get; set; }
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
        /// Gets or sets the modified on.
        /// </summary>
        /// <value>The modified on.</value>
        public DateTime? CancellationDate { get; set; }
        /// <summary>
        /// Gets or sets the mol rams cancel run away files.
        /// </summary>
        /// <value>The mol rams cancel run away files.</value>
        public virtual ICollection<MOL_RAMS_CancelRunAway_Files> MOL_RAMS_CancelRunAway_Files { get; set; }
        /// <summary>
        /// Gets or sets the mol rams run away files.
        /// </summary>
        /// <value>The mol rams run away files.</value>
        public virtual ICollection<MOL_RAMS_RunAway_Files> MOL_RAMS_RunAway_Files { get; set; }
        /// <summary>
        /// Gets or sets the mol rams run away transactions log.
        /// </summary>
        /// <value>The mol rams run away transactions log.</value>
        public virtual ICollection<MOL_RAMS_RunAwayTransactionsLog> MOL_RAMS_RunAwayTransactionsLog { get; set; }
        /// <summary>
        /// Gets or sets the mol run away complaints.
        /// </summary>
        /// <value>The mol run away complaints.</value>
        public virtual ICollection<MOL_RunAwayComplaints> MOL_RunAwayComplaints { get; set; }
    }
}
