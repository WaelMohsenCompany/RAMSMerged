// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 02-18-2018
// ***********************************************************************
// <copyright file="LaborerInfo.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;

namespace MOL.EFDAL.ComplexTypes
{
    /// <summary>
    /// Class LaborerInfo.
    /// </summary>
    [DataContract]
    public class LaborerInfo
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier number.
        /// </summary>
        /// <value>The identifier number.</value>
        [DataMember]
        public long? IdNumber { get; set; }

        /// <summary>
        /// Gets or sets the border number.
        /// </summary>
        /// <value>The border number.</value>
        [DataMember]
        public long? BorderNumber { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the laborer office identifier.
        /// </summary>
        /// <value>The laborer office identifier.</value>
        [DataMember]
        public int LaborerOfficeId { get; set; }

        /// <summary>
        /// Gets or sets the laborer sequence number.
        /// </summary>
        /// <value>The laborer sequence number.</value>
        [DataMember]
        public long? LaborerSequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the establishment labor office identifier.
        /// </summary>
        /// <value>The establishment labor office identifier.</value>
        [DataMember]
        public int EstablishmentLaborOfficeId { get; set; }

        /// <summary>
        /// Gets or sets the establishment sequence number.
        /// </summary>
        /// <value>The establishment sequence number.</value>
        [DataMember]
        public long? EstablishmentSequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the laborer status identifier.
        /// </summary>
        /// <value>The laborer status identifier.</value>
        [DataMember]
        public int? LaborerStatusId { get; set; }

        /// <summary>
        /// Gets or sets the Mobile Number.
        /// </summary>
        /// <value>The Mobile Number.</value>
        [DataMember]
        public string MobileNumber { get; set; }
    }
}
