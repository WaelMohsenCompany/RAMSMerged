// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="Lookup_EconomicActivity.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MOL.EFDAL.Models
{
    /// <summary>
    /// Class Lookup_EconomicActivity.
    /// </summary>
    public partial class Lookup_EconomicActivity
    {

        /// <summary>
        /// Get or Set Eligibility to make a Runaway Request - RAMS Modification
        /// </summary>
        /// <value><c>true</c> if this instance is eligible for run away; otherwise, <c>false</c>.</value>
        public bool IsEligibleForRunAway { get; set; }

    }
}