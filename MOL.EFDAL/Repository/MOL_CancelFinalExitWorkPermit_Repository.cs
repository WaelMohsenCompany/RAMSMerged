

namespace MOL.EFDAL.Repository
{
    using MOL.EFDAL.Models;
    public class MOL_CancelFinalExitWorkPermit_Repository : EFRepository<MOL_CancelFinalExitWorkPermit>
    {
        public MOL_CancelFinalExitWorkPermit_Repository()
        {
            Context = new MOLEFEntities();
        }

        public MOL_CancelFinalExitWorkPermit_Repository(MOLEFEntities context) : base(context)
        {

        }
    }
}


