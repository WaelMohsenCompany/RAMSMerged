using MOL.EFDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public partial class MOL_Sec_Privilege_Repository
    {
        public List<MOL_Sec_Privilege> GetPrivilegeByRoleID(long roleID)
        {
            List<MOL_Sec_Privilege> lstPrivileges = null;

            lstPrivileges = (from privilege in Context.MOL_Sec_Privilege
                             join rolePrivilege in Context.MOL_Sec_RolePrivilege on privilege.Id equals rolePrivilege.Privilege_Id
                             where rolePrivilege.Role_Id == roleID
                             select privilege
                             ).OrderBy<MOL_Sec_Privilege, string>(p => p.Name).ToList<MOL_Sec_Privilege>();


            return lstPrivileges;
        }

        public List<MOL.EFDAL.SP_CUST_MOL_Sec_Privilege_GetAuthorizedUserServices_Result> GetAuthorizedServicesForUser(long userID, long establishmentID, int? serviceID)
        {
            
            return this.Context.SP_CUST_MOL_Sec_Privilege_GetAuthorizedUserServices(userID, establishmentID, serviceID, null, null).ToList<MOL.EFDAL.SP_CUST_MOL_Sec_Privilege_GetAuthorizedUserServices_Result>();
        }
        
    }
}
