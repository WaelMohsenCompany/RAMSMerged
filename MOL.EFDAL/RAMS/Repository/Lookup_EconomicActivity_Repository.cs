// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-30-2018
// ***********************************************************************
// <copyright file="Lookup_EconomicActivity_Repository.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;

namespace MOL.EFDAL.Repository
{
    /// <summary>
    /// Class Lookup_EconomicActivity_Repository.
    /// </summary>
    /// <seealso cref="MOL.EFDAL.Repository.EFRepository{MOL.EFDAL.Models.Lookup_EconomicActivity}" />
    public partial class Lookup_EconomicActivity_Repository
    {
        /// <summary>
        /// Function checks if Establishment is Eligible for creating new RunAway Request
        /// RAMS
        /// Code Review (Done)
        /// </summary>
        /// <param name="laborOfficeId">The labor office identifier.</param>
        /// <param name="sequenceNumber">The sequence number.</param>
        /// <returns><c>true</c> if [is eligible for run away request] [the specified labor office identifier]; otherwise, <c>false</c>.</returns>
        public bool IsEligibleForRunAwayRequest(int laborOfficeId, long sequenceNumber)
        {
            var isEligible = true;

            var establishmentInfo = new MOL_Establishment_Repository().
                GetEstablishmentByLaborOfficeAndSequenceNumber(laborOfficeId, sequenceNumber);

            if (establishmentInfo == null)
                return isEligible;

            var economicActivity = Context.Lookup_EconomicActivity.SingleOrDefault(e =>
                e.PK_EconomicActivityId == establishmentInfo.SubEconomicActivityId);

            if (economicActivity != null)
                isEligible = economicActivity.IsEligibleForRunAway;

            return isEligible;
        }

        /// <summary>
        /// Function checks if Establishment is Eligible for creating new RunAway Request
        /// RAMS
        /// Code Review (Done)
        /// </summary>
        /// <param name="economicActivityId">The economic activity identifier.</param>
        /// <returns><c>true</c> if [is eligible for run away request] [the specified economic activity identifier]; otherwise, <c>false</c>.</returns>
        public bool IsEligibleForRunAwayRequest(int economicActivityId)
        {
            var isEligible = true;

            var economicActivity = Context.Lookup_EconomicActivity.SingleOrDefault(e =>
                e.PK_EconomicActivityId == economicActivityId);

            if (economicActivity != null)
            {
                isEligible = economicActivity.IsEligibleForRunAway;
            }

            return isEligible;
        }
    }
}
