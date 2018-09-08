using System;
using System.Runtime.Serialization;

namespace MOL.EFDAL.ComplexTypes
{
    public class RequestContactInfo
    {
        /// <summary>
        /// Gets or sets the request number.
        /// </summary>
        /// <value>The request number.</value>
        [DataMember]
        public string RequestNumber { get; set; }

        /// <summary>Gets or sets the laborer mobile no.</summary>
        /// <value>The laborer mobile no.</value>
        [DataMember]
        public string LaborerMobileNo { get; set; }

        /// <summary>
        /// Gets or sets the applicant user identifier.
        /// </summary>
        /// <value>The applicant user identifier.</value>
        [DataMember]
        public long? RunAwayApplicantUserId { get; set; }

        /// <summary>
        /// Gets or sets the applicant user identifier.
        /// </summary>
        /// <value>The applicant user identifier.</value>
        [DataMember]
        public long? ComplaintApplicantUserId { get; set; }

        /// <summary>
        /// Gets or sets the request number.
        /// </summary>
        /// <value>The request number.</value>
        [DataMember]
        public DateTime CreatedOn { get; set; }
    }
}
