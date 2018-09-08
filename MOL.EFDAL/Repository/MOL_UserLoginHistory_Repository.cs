using MOL.EFDAL.Models;

namespace MOL.EFDAL.Repository
{
    public partial class MOL_UserLoginHistory_Repository : EFRepository<MOL_UserLoginHistory>
    {
        public MOL_UserLoginHistory_Repository()
        {
            Context = new MOLEFEntities();
        }

        public MOL_UserLoginHistory_Repository(MOLEFEntities context) : base(context)
        {

        }
    }
}

