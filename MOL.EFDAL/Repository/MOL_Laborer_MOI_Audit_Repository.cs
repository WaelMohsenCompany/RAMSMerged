using MOL.EFDAL.Models;

namespace MOL.EFDAL.Repository
{
    public partial class MOL_Laborer_MOI_Audit_Repository : EFRepository<MOL_Laborer_MOI_Audit>
    {
        public MOL_Laborer_MOI_Audit_Repository()
        {
        }

        public MOL_Laborer_MOI_Audit_Repository(MOLEFEntities context) : base(context)
        {
        }
    }
}
