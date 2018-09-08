namespace MOL.EFDAL.Repository
{
    using MOL.EFDAL.Models;
    using System.Linq;
    public class MOL_ChangeLaborerBranchInMOI_Repository : EFRepository<MOL_ChangeLaborerBranchInMOI>
    {
        public MOL_ChangeLaborerBranchInMOI_Repository()
        {
            Context = new MOLEFEntities();
        }

        public MOL_ChangeLaborerBranchInMOI_Repository(MOLEFEntities context) : base(context)
        {

        }

        public ComplexTypes.CLBInMOILaborerDetails GetLaborerDetails(string idNo)
        {
            return (from l in Context.MOL_Laborer
                    join j in Context.Lookup_Job on l.FK_JobId equals j.Id
                    join ls in Context.Enum_LaborerStatus on l.FK_LaborerStatusId equals ls.Id
                    join e in Context.MOL_Establishment on l.FK_EstablishmentId equals e.PK_EstablishmentId
                    join un in Context.MOL_UnifiedNumber on e.FK_UnifiedNumberId equals un.PK_UnifiedNumberId
                    from owner in Context.MOL_Owner.Where(p => p.PK_OwnerId == un.FK_OwnerId).DefaultIfEmpty()

                    where l.IdNo == idNo

                    select new ComplexTypes.CLBInMOILaborerDetails
                    {
                        EstablishmentLaborOffice = e.FK_LaborOfficeId,
                        EstablishmentSequenceNumber = e.SequenceNumber,
                        LaborerIDNumber = l.IdNo,
                        FirstName = l.FirstName,
                        SecondName = l.SecondName,
                        ThirdName = l.ThirdName,
                        FourthName = l.FourthName,
                        LaborerJob = j.Name,
                        LaborerStatus = ls.Description,
                        IsIndividualEstablishment = un.FK_OwnerId.HasValue,
                        EstablishmentName = e.Name,
                        Establishment700Number = un.SevenHundredNumber,
                        EstablishmentOwnerIDNumber = owner == null ? "" : owner.IdNo
                    }).FirstOrDefault();
        }
    }
}



