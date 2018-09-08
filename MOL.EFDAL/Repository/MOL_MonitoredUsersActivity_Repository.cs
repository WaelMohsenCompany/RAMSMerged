using MOL.EFDAL.Models;

namespace MOL.EFDAL.Repository
{
    public partial class MOL_MonitoredUsersActivity_Repository : EFRepository<MOL_MonitoredUsersActivity>
    {
        public MOL_MonitoredUsersActivity_Repository()
        {
            Context = new MOLEFEntities();
        }

        public MOL_MonitoredUsersActivity_Repository(MOLEFEntities context) : base(context)
        {

        }
    }
}
