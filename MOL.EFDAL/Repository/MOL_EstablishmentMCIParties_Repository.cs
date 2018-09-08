using MOL.EFDAL.Models;

namespace MOL.EFDAL.Repository
{
    public class MOL_EstablishmentMCIParties_Repository:EFRepository<MOL_EstablishmentMCIParties>
    {
        public MOL_EstablishmentMCIParties_Repository()
        {

        }

        public MOL_EstablishmentMCIParties_Repository(MOLEFEntities context) : base(context)
        {

        }
    }
}
