using MOL.EFDAL.Models;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public partial class MOL_VwEstablishmentCRMComplaintData_Repository : EFRepository<MOL_VwEstablishmentCRMComplaintData>
    {
        public MOL_VwEstablishmentCRMComplaintData_Repository()
        {
            Context = new MOLEFEntities();
        }

        public MOL_VwEstablishmentCRMComplaintData_Repository(MOLEFEntities context) : base(context)
        {

        }

        public MOL_VwEstablishmentCRMComplaintData GetEstablishmentCommonData(long establishmentId)
        {
            return this.Context.MOL_VwEstablishmentCRMComplaintData.FirstOrDefault(p => p.PK_EstablishmentId == establishmentId);
        }
    }
}

