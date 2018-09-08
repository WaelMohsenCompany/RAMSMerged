using MOL.EFDAL.Models;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public class ELRRep
    {
        MOLEFEntities MOLRep = new MOLEFEntities();

        public MOL_ProgramBEstablishments getProgramBEstablishmentsByID(long ID)
        {
            var Est = MOLRep.MOL_ProgramBEstablishments.Where(x => x.EstablishmentID == ID).FirstOrDefault();
            return Est;
        }
    }
}
