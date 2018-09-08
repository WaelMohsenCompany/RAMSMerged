// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-30-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-30-2018
// ***********************************************************************
// <copyright file="EstablishmentInfo.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.Serialization;

namespace MOL.EFDAL.ComplexTypes
{
    /// <summary>
    /// Class EstablishmentInfo.
    /// </summary>
    [DataContract]
    public class EstablishmentInfo
    {
        /// <summary>
        /// Gets or sets the establishment identifier.
        /// </summary>
        /// <value>The establishment identifier.</value>
        [DataMember]
        public long EstablishmentId { get; set; }

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

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the main economic activity identifier.
        /// </summary>
        /// <value>The main economic activity identifier.</value>
        [DataMember]
        public int? MainEconomicActivityId { get; set; }

        /// <summary>
        /// Gets or sets the sub economic activity identifier.
        /// </summary>
        /// <value>The sub economic activity identifier.</value>
        [DataMember]
        public int? SubEconomicActivityId { get; set; }

        /// <summary>
        /// Gets or sets the establishment status identifier.
        /// </summary>
        /// <value>The establishment status identifier.</value>
        [DataMember]
        public int? EstablishmentStatusId { get; set; }

        /// <summary>
        /// Gets or sets the wasel status.
        /// </summary>
        /// <value>The wasel status.</value>
        [DataMember]
        public int? WASELStatus { get; set; }

        /// <summary>
        /// Gets or sets the wasel expiry date.
        /// </summary>
        /// <value>The wasel expiry date.</value>
        [DataMember]
        public DateTime? WASELExpiryDate { get; set; }
    }
}
