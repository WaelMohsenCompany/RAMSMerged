namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_EstablishmentMCIActivities
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public long FK_EstablishmentID { get; set; }
        [DataMember]
        public int ISEC_Code { get; set; }
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
    }
}
