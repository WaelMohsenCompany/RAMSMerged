using System.Linq;

namespace MOL.EFDAL.Repository
{
    public class LaborerRep
    {
        MOLEFEntities MOLRep = new MOLEFEntities();
        
        /// <summary>
        /// This method gets the previous establishment of a laborer.
        /// </summary>
        /// <param name="laborerId">Laborer Id (PK Identifier)</param>
        /// <returns>Previous establishment information, if no previous establishments returns null.</returns>
        public PreviousEstablishment GetPreviousEstablishment(long laborerId)
        {
            PreviousEstablishment previousEstablishment = null;
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var previousEstablishmentCollection = context.MOL_VwLaborer_Audit_GetEstablishmentsHistory.Where(w => w.PK_LaborerId == laborerId).OrderByDescending(o => o.ServiceStartDate).ToList();

                if (previousEstablishmentCollection.Count > 1)
                {
                    previousEstablishment = new PreviousEstablishment
                    {
                        LaborOfficeId = previousEstablishmentCollection[1].FK_LaborOfficeId,
                        SequenceNumber = previousEstablishmentCollection[1].SequenceNumber,
                        EstablishmentName = previousEstablishmentCollection[1].Name
                    };
                }
            }
            return previousEstablishment;
        }
    }

    public class PreviousEstablishment
    {
        public int LaborOfficeId { get; set; }
        public long SequenceNumber { get; set; }
        public string EstablishmentName { get; set; }
    }
}
