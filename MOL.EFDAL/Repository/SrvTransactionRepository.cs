using MOL.EFDAL.Models;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public partial class MOL_Srv_Transaction_Repository
    {

        public MOL_Srv_Transaction GetLatestWorkPermitTransactionByLaborerID(long laborerId)
        {
            var transaction = (from t in Context.MOL_Srv_Transaction
                               join w in Context.MOL_WorkPermit on t.PK_Service_TransactionId equals w.FK_Service_TransactionId
                               where w.FK_LaborId == laborerId
                               orderby t.TransactionDate descending
                               select t).FirstOrDefault();

            return transaction;
                             
        }
    }
}
