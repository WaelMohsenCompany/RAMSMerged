// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MOL_Laborer.cs" company="">
//   
// </copyright>
// <summary>
//   The MOL laborer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace MOL.EFDAL.Models
{
    /// <summary>
    /// The Social Development Beneficiary Details.
    /// </summary>
    [DataContract]
    [CLSCompliant(true)]
#pragma warning disable CS3014 // 'SocialDevelopmentBeneficiaryDetails' cannot be marked as CLS-compliant because the assembly does not have a CLSCompliant attribute
    public class SocialDevelopmentBeneficiaryDetails
#pragma warning restore CS3014 // 'SocialDevelopmentBeneficiaryDetails' cannot be marked as CLS-compliant because the assembly does not have a CLSCompliant attribute
    {
        [DataMember]
        public int OwnerId { get; set; }
        [DataMember]
        public string OwnerIdNumber { get; set; }
        [DataMember]
        public string OwnerName { get; set; }
        [DataMember]
        public long? EstablishmentId { get; set; }
        [DataMember]
        public int? EstablishmentLaborOfficeNumber { get; set; }
        [DataMember]
        public long? EstablishmentSequenceNumber { get; set; }
        [DataMember]
        public string EstablishmentName { get; set; }
        [DataMember]
        public bool? EstablishmentIsMainBranch { get; set; }
        [DataMember]
        public long? LaborerId { get; set; }
        [DataMember]
        public string LaborerIdNumber { get; set; }
        [DataMember]
        public string LaborerFirstName { get; set; }
        [DataMember]
        public string LaborerSecondName { get; set; }
        [DataMember]
        public string LaborerThirdName { get; set; }
        [DataMember]
        public string LaborerFourthName { get; set; }
        [DataMember]
        public short? LaborerNationalityId { get; set; }
        [DataMember]
        public string LaborerNationalityName { get; set; }
        [DataMember]
        public int? LaborerJobId { get; set; }
        [DataMember]
        public string LaborerJobName { get; set; }

        /// <summary>
        /// Gets the full name.
        /// Added Property
        /// </summary>
        [DataMember]
        public string LaborerFullName
        {
            get
            {
                var fullName = new System.Text.StringBuilder();

                fullName.Append(LaborerFirstName.Trim());
                fullName.Append(" ");

                if (this.LaborerSecondName != null)
                {
                    fullName.Append(LaborerSecondName.Trim());
                    fullName.Append(" ");
                }

                if (this.LaborerThirdName != null)
                {
                    fullName.Append(LaborerThirdName.Trim());
                    fullName.Append(" ");
                }

                fullName.Append(LaborerFourthName.Trim());

                return fullName.ToString();
            }
        }
    }
}
