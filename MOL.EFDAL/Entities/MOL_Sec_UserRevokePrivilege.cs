using System.ComponentModel.DataAnnotations.Schema;

namespace MOL.EFDAL.Models
{
    public partial class MOL_Sec_UserRevokePrivilege //: IAuditable Currently MOL_Sec_UserRevokePrivilege is not Auditable because, Audit Trail does not support delete.
    {
        [NotMapped()]
        public long CurrentUserID
        {
            get;
            set;
        }

        [NotMapped()]
        public string DBTableName
        {
            get
            {
                return "MOL_Sec_UserRevokePrivilege";
            }
        }
    }
}
