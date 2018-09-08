using MOL.EFDAL.Models;

namespace MOL.EFDAL.Repository
{
    using Mol.Entities;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public partial class MOL_Laborer_Repository : EFRepository<MOL_Laborer>
    {
        public MOL_Laborer_Repository()
        {

        }

        public MOL_Laborer_Repository(MOLEFEntities context) : base(context)
        {

        }

        /// <summary>
        /// Gets the non saudi laborer by id no or border no.
        /// </summary>
        /// <param name="idNo">The identifier no.</param>
        /// <param name="borderNo">The border no.</param>
        /// <returns>The Laborer</returns>
        /// <CreatedOn> 29/11/2015 </CreatedOn>
        /// <CreatedBy> Mohammed Adel ( Mohammed.Adel@Itworx.com ) </CreatedBy>
        public MOL_Laborer GetNonSaudiLaborerByIdNoOrBorder(string idNo, string borderNo)
        {
            return this.SingleOrDefault(w => w.FK_SaudiFlagId == (int)SaudiFlagList.NonSaudi && (w.IdNo == idNo || w.BorderNo == borderNo));
        }

        /// <summary>
        /// Gets the non saudi laborer by id no or border no for establishment identifier.
        /// </summary>
        /// <param name="establishmentId">The establishment identifier.</param>
        /// <param name="idNo">The identifier no.</param>
        /// <param name="borderNo">The border no.</param>
        /// <returns>The Laborer</returns>
        /// <CreatedOn> 29/11/2015 </CreatedOn>
        /// <CreatedBy> Mohammed Adel ( Mohammed.Adel@Itworx.com ) </CreatedBy>
        public MOL_Laborer GetNonSaudiLaborerByIdNoOrBorderForEstablishmentID(long establishmentId, string idNo, string borderNo)
        {
            return this.Where(w => w.FK_EstablishmentId == establishmentId && w.FK_SaudiFlagId == (int)SaudiFlagList.NonSaudi && (w.IdNo == idNo || w.BorderNo == borderNo)).Include("Enum_LaborerStatus").SingleOrDefault();
        }

        /// <summary>
        /// Gets the laborer by number for establishment.
        /// </summary>
        /// <param name="establishmentID">
        /// The establishment ID.
        /// </param>
        /// <param name="laborOfficeID">
        /// The labor office identifier.
        /// </param>
        /// <param name="sequenceNumber">
        /// The sequence Number.
        /// </param>
        /// <returns>
        /// The Laborer
        /// </returns>
        /// <CreatedOn> 29/11/2015 </CreatedOn>
        /// <CreatedBy> Mohammed Adel ( Mohammed.Adel@Itworx.com ) </CreatedBy>
        public MOL_Laborer GetNonSaudiLaborerByNumberForEstablishment(long establishmentID, int laborOfficeID, int sequenceNumber)
        {
            return this.Where(s =>
                s.FK_EstablishmentId == establishmentID &&
                s.FK_LaborOfficeId == laborOfficeID &&
                s.FK_SaudiFlagId == (int)SaudiFlagList.NonSaudi &&
                s.SequenceNumber == sequenceNumber).Include("Enum_LaborerStatus").SingleOrDefault();
        }

        public static int GetUnifiedNumberAllActiveLaborersCount(long unifiedNumberId)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var query = from l in context.MOL_Laborer
                            join e in context.MOL_Establishment
                            on l.FK_EstablishmentId equals e.PK_EstablishmentId
                            where e.FK_UnifiedNumberId == unifiedNumberId && l.FK_LaborerStatusId == 1
                            select l;

                if (query.Any())
                    return query.Count();
                else
                    return 0;
            }
        }

        public static int GetUnifiedNumberRunnersCount(long fkUnifiedNumberId, int runnersImportDays)
        {
            System.DateTime runnersFromDate = System.DateTime.Now.AddDays(-1 * runnersImportDays);
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var query = from l in context.MOL_Laborer
                            join e in context.MOL_Establishment
                            on l.FK_EstablishmentId equals e.PK_EstablishmentId
                            where e.FK_UnifiedNumberId == fkUnifiedNumberId && l.FK_LaborerStatusId == 3
                            && l.FK_SaudiFlagId == 2
                            && l.StatusLastModificationDate > runnersFromDate
                            select l;

                if (query.Any())
                    return query.Count();
                else
                    return 0;
            }
        }

        public static int GetUnifiedNumberRunnersCountForNationality(long fkUnifiedNumberId, int runnersImportDays, long nationalityID)
        {
            System.DateTime runnersFromDate = System.DateTime.Now.AddDays(-1 * runnersImportDays);
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var query = from l in context.MOL_Laborer
                            join e in context.MOL_Establishment
                            on l.FK_EstablishmentId equals e.PK_EstablishmentId
                            where e.FK_UnifiedNumberId == fkUnifiedNumberId && l.FK_LaborerStatusId == 3
                            && l.FK_SaudiFlagId == 2 && l.FK_NationalityId == nationalityID
                            && l.StatusLastModificationDate > runnersFromDate
                            select l;

                if (query.Any())
                    return query.Count();
                else
                    return 0;
            }
        }

        public MOL_Laborer GetNonSaudiLaborerByIdNumber(long idNumber)
        {
            return this.SingleOrDefault(w => w.FK_SaudiFlagId == (int)SaudiFlagList.NonSaudi && (w.IdNo == idNumber.ToString()));
        }

        public MOL_Laborer GetNonSaudiLaborerByBorderNumber(long borderNumber)
        {
            return this.SingleOrDefault(w => w.FK_SaudiFlagId == (int)SaudiFlagList.NonSaudi && (w.BorderNo == borderNumber.ToString()));
        }

        public MOL_Laborer GetNonSaudiLaborerByIdNo(string idNo)
        {
            return (from laborer in this.Context.MOL_Laborer
                    join est in this.Context.MOL_Establishment on laborer.FK_EstablishmentId equals est.PK_EstablishmentId
                    join wp in this.Context.MOL_WorkPermit on laborer.FK_LastWPId equals wp.PK_WPId into wps
                    from p in wps.DefaultIfEmpty()
                    where laborer.IdNo == idNo
                    select laborer).FirstOrDefault<MOL_Laborer>();
        }
        public List<MOL_Laborer> GetLaborersByCreditID(long CreditID, int RequstType, long EstablishmentID)
        {
            return (from laborer in this.Context.MOL_Laborer
                    where laborer.CreditID == CreditID && laborer.CreditType == RequstType && laborer.FK_EstablishmentId == EstablishmentID && laborer.FK_LaborerStatusId != 5
                    select laborer).ToList();
        }
    }
}

