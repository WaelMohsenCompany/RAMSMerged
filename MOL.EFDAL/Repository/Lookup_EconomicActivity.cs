using System.Linq;

namespace MOL.EFDAL.Repository
{
    public partial class Lookup_EconomicActivity_Repository
    {
        public bool IsEligibleForIstiqdamImmediateApproval(long EstablishmentID)
        {
            bool IsEligible = false;

            var Establishment = Context.MOL_Establishment.FirstOrDefault(e => e.PK_EstablishmentId == EstablishmentID);
            if (Establishment != null)
            {
                var EconomicActivity = Context.Lookup_EconomicActivity.SingleOrDefault(e => e.PK_EconomicActivityId == Establishment.FK_SubEconomicActivityId);
                if (EconomicActivity != null)
                {
                    IsEligible = EconomicActivity.IsEligibleForIstiqdamImmediateApprove;
                }
            }
            return IsEligible;
        }
    }
}
