using MOL.EFDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public partial class MOL_Sec_UserRevokePrivilege_Repository
    {
        public List<MOL_Sec_UserRevokePrivilege> GetRevokePrivilegesForUser(long userIDNo, long unifiedNumberEntityID)
        {
            return Where(rp => rp.FK_SecurableEntityId == unifiedNumberEntityID && rp.IdNo == userIDNo).ToList<MOL_Sec_UserRevokePrivilege>();
        }
    }
}
