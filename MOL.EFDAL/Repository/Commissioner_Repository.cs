using MOL.EFDAL.Models;
using System;

namespace MOL.EFDAL.Repository
{
    /// <summary>
    /// The MOL_EstablishmentCommissioner_Repository.
    /// </summary>
    public partial class MOL_EstablishmentCommissioner_Repository : EFRepository<MOL_EstablishmentCommissioner>
    {
        /// <summary>
        /// Gets the establishment commissioner by identifier no.
        /// </summary>
        /// <param name="establishmentId">The establishment identifier.</param>
        /// <param name="commissionerIdNo">The commissioner identifier no.</param>
        /// <returns>Establishment Commissioner</returns>
        /// <CreatedOn> 23/12/2015 </CreatedOn>
        /// <CreatedBy> Mohammed Adel ( Mohammed.Adel@Itworx.com ) </CreatedBy>
        public MOL_EstablishmentCommissioner GetEstablishmentCommissionerByIdNo(long establishmentId, string commissionerIdNo)
        {
            return this.SingleOrDefault(s =>
            s.MOL_Laborer.IdNo == commissionerIdNo &&
            s.CommissionEndDate >= DateTime.Today &&
            s.IsVerified == true &&
            s.FK_EstablishmentId == establishmentId &&
            (!s.StopCommission.HasValue || !s.StopCommission.Value || s.StopCommissionDate > DateTime.Now));
        }

        public MOL_EstablishmentCommissioner GetEstablishmentCommissionerByIdNoAndUnifiedNumberID(long unififedNumberID, long commissionerIdNo)
        {
            return this.SingleOrDefault(com => com.MOL_Laborer.IdNo == commissionerIdNo.ToString() && com.MOL_Establishment.FK_UnifiedNumberId == unififedNumberID && (!com.StopCommission.HasValue || !com.StopCommission.Value || com.StopCommissionDate <= DateTime.Now));
        }
    }
}
