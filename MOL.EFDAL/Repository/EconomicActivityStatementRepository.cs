using MOL.EFDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public class EconomicActivityStatementRepository
    {
        public static List<int> GetStatementsRequiredForEconomicActivityId(int economicActivityId)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var query = context.MOL_EconomicActivityStatement.Where(x => x.FK_EconomicActivityId == economicActivityId && x.IsRequired == true);
                if (query.Any())
                    return query.Select(x => x.FK_StatementsTypeId.Value).ToList();
                else
                    return null;
            }
        }

        public static List<int> GetEstablishmentActiveStatements(long establishmentId)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var query = context.MOL_EstablishmentStatement.Where(x => x.FK_EstablishmentId == establishmentId && x.EndDate > DateTime.Now);
                if (query.Any())
                    return query.Select(x => (int)x.FK_StatementTypeId).ToList();
                else
                    return new List<int>();
            }
        }

        public static bool SetStatementsRequiredForEconomicActivityId(int economicActivityId, List<int> selectedStatments, int currentUserId)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var query = context.MOL_EconomicActivityStatement.Where(x => x.FK_EconomicActivityId == economicActivityId);
                context.MOL_EconomicActivityStatement.RemoveRange(query);

                foreach (int statmentId in selectedStatments)
                {
                    MOL_EconomicActivityStatement economicActivityStatement = new MOL_EconomicActivityStatement();
                    economicActivityStatement.FK_EconomicActivityId = economicActivityId;
                    economicActivityStatement.FK_StatementsTypeId = statmentId;
                    economicActivityStatement.IsRequired = true;
                    economicActivityStatement.ModifiedBy = currentUserId;

                    context.MOL_EconomicActivityStatement.Add(economicActivityStatement);
                }

                context.SaveChanges();
            }

            return true;
        }
    }
}
