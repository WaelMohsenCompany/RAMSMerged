namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_LaborerStatus
    {
        public Enum_LaborerStatus()
        {
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public System.DateTime? CreatedOn { get; set; }
        [DataMember]
        public System.DateTime? ModifiedOn { get; set; }
        [DataMember]
        public virtual ICollection<MOL_Laborer> MOL_Laborer { get; set; } = new List<MOL_Laborer>();

        [DataMember]
        public virtual ICollection<MOL_LaborerStatusServiceEndReason> MOL_LaborerStatusServiceEndReason { get; set; } = new List<MOL_LaborerStatusServiceEndReason>();
    }
}
