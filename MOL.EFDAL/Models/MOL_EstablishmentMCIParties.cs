using System;

namespace MOL.EFDAL.Models
{
    public class MOL_EstablishmentMCIParties
    {
        public int ID { get; set; }
        public string MciPartyID { get; set; }
        public string Name { get; set; }
        public Lookup_MCIPartyRelationType RelationTypeID { get; set; }
        public short? NationalityID { get; set; }
        public DateTime BirthDate { get; set; }
        public  Lookup_Nationality Nationality { get; set; }
        public long EstablishmentID { get; set; }
        public virtual MOL_Establishment MOL_Establishment { get; set; }
    }
}
