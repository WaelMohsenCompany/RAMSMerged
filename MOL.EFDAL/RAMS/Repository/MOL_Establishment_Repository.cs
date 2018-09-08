// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-30-2018
// ***********************************************************************
// <copyright file="MOL_Establishment_Repository.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************

using MOL.EFDAL.ComplexTypes;
using MOL.EFDAL.Models;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    /// <summary>
    /// Class MOL_Establishment_Repository.
    /// </summary>
    /// <seealso cref="MOL.EFDAL.Repository.EFRepository{MOL.EFDAL.Models.MOL_Establishment}" />
    public partial class MOL_Establishment_Repository : EFRepository<MOL_Establishment>
    {
        /// <summary>
        /// Function returns Establishment By LaborOffice And Sequence Number"
        /// </summary>
        /// <param name="laborOfficeId">The labor office identifier.</param>
        /// <param name="sequenceNumber">The sequence number.</param>
        /// <returns>SP_MOL_Establishment_GetByFkLaborOfficeIdSequenceNumber.</returns>
        public EstablishmentInfo GetEstablishmentByLaborOfficeAndSequenceNumber(int laborOfficeId, long sequenceNumber)
        {
            return
                (from establishment in Context.MOL_Establishment
                 where
                     (establishment.FK_LaborOfficeId == laborOfficeId &&
                      establishment.SequenceNumber == sequenceNumber)

                 select new EstablishmentInfo
                 {
                     EstablishmentId = establishment.PK_EstablishmentId,
                     LaborOfficeId = establishment.FK_LaborOfficeId,
                     SequenceNumber = establishment.SequenceNumber,
                     Name = establishment.Name,
                     MainEconomicActivityId = establishment.FK_MainEconomicActivityId,
                     SubEconomicActivityId = establishment.FK_SubEconomicActivityId,
                     EstablishmentStatusId = establishment.FK_EstablishmentStatusId,
                     WASELStatus = establishment.WASELStatus,
                     WASELExpiryDate = establishment.WASELExpiryDate
                 }).SingleOrDefault();
        }
    }
}

