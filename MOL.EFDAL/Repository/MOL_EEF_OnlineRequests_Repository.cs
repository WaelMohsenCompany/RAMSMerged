using MOL.EFDAL.Models;

namespace MOL.EFDAL.Repository
{
    public class MOL_EEF_OnlineRequests_Repository : EFRepository<MOL_EEF_OnlineRequests>
    {
        public MOL_EEF_OnlineRequests_Repository()
        {

        }

        public MOL_EEF_OnlineRequests_Repository(MOLEFEntities context) : base(context)
        {

        }
    }
}

