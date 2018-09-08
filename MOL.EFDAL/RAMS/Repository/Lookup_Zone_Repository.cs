using MOL.EFDAL.ComplexTypes;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public partial class Lookup_Zone_Repository
    {
        /// <summary>Gets zone laborer offices.</summary>
        /// <remarks>Wael Mohsen, 2018-05-03.</remarks>
        /// <param name="userLaborerOffice">The user laborer office.</param>
        /// <returns>The zone laborer offices.</returns>
        public IQueryable<LaborOfficeInfo> GetZoneLaborerOffices(int? userLaborerOffice)
        {
            //======================================================
            // Select Zone Id of current user labor Office
            if (userLaborerOffice.HasValue)
            {
                var zoneId =
                    Context.MOL_LaborOffice.Where(laborOffice => laborOffice.PK_LaborOfficeId == userLaborerOffice)
                        .Select(laborOffice => laborOffice.FK_ZoneId).FirstOrDefault();

                if (!zoneId.HasValue)
                    return null;

                //======================================================
                // Select the list of labor offices that belongs to current Zone
                return
                    Context.MOL_LaborOffice
                        .Where(laborOffice =>
                            laborOffice.FK_ZoneId == zoneId && laborOffice.IsActive == true)

                        .Select(laborOffice =>
                            new LaborOfficeInfo
                            {
                                Id = laborOffice.PK_LaborOfficeId,
                                Name = laborOffice.Name
                            });
            }
            else
            {
                //======================================================
                // Select the list of labor offices that belongs to current Zone
                return
                    Context.MOL_LaborOffice
                        .Where(laborOffice => laborOffice.IsActive == true)

                        .Select(laborOffice =>
                            new LaborOfficeInfo
                            {
                                Id = laborOffice.PK_LaborOfficeId,
                                Name = laborOffice.Name
                            });
            }
        }

    }
}
