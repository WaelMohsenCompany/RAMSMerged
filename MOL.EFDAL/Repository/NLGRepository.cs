using MOL.EFDAL.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public class NLGRepository
    {
        public static int AddRejectReason(int istikdamBalanceRequestId, int rejectionReasonId)
        {
            using (MOLEFEntities MOLRep = new MOLEFEntities())
            {
                SqlParameter output = new SqlParameter
                {
                    ParameterName = "@IstikdamRequestRejectionReasonId",
                    Direction = ParameterDirection.Output,
                    DbType = DbType.Int32
                };

                if (MOLRep.usp_MOL_IstikdamRequestRejectionReason_Insert(istikdamBalanceRequestId, rejectionReasonId, output) == 1)
                {
                    return (int)output.Value;
                }
                else
                {
                    return -1;
                }
            }
        }

        public List<RejectionReason> GetNLGRequestRejectReasons(long id)
        {
            var dbContext = new MOLEFEntities();

            return (from IR in dbContext.IstikdamRequestRejectionReasons
                    join R in dbContext.RejectionReasons on IR.FK_RejectionReasonId equals R.Id
                    where IR.FK_IstikdamBalanceRequestId == id
                    select R).ToList();
        }
    }
}
