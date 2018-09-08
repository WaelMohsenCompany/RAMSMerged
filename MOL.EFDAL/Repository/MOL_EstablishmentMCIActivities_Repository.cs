namespace MOL.EFDAL.Repository
{
    using MOL.EFDAL.Models;

    public class MOL_EstablishmentMCIActivities_Repository : EFRepository<MOL_EstablishmentMCIActivities>
    {
        public MOL_EstablishmentMCIActivities_Repository()
        {

        }

        public MOL_EstablishmentMCIActivities_Repository(MOLEFEntities context) : base(context)
        {

        }
    }
}
