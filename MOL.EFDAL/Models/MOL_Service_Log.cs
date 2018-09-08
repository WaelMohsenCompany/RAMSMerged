namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Service_Log
    {
        public MOL_Service_Log()
        {
        }

		[DataMember]
        public int LogID { get; set; }
		[DataMember]
        public int ServiceID { get; set; }
		[DataMember]
        public long? FK_EstablishmentID { get; set; }
		[DataMember]
        public long? FK_LaborerID { get; set; }
		[DataMember]
        public int CreatedByUserID { get; set; }
		[DataMember]
        public System.DateTime CreationDate { get; set; }
		[DataMember]
        public string ReturnMessage { get; set; }
		[DataMember]
        public int? ReturnCode { get; set; }
		[DataMember]
        public string RequesterIDNo { get; set; }
		[DataMember]
        public string ClientIPAddress { get; set; }
        [DataMember]
        public virtual ICollection<MOL_Service_Log_Extension> MOL_Service_Log_Extension { get; set; } = new List<MOL_Service_Log_Extension>();
    }
}
