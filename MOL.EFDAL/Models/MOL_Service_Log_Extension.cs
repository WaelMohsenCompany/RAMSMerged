namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Service_Log_Extension
    {
        [DataMember]
        public int PK_LogId { get; set; }
        [DataMember]
        public int FK_ServiceLogId { get; set; }
        [DataMember]
        public string LaborerIdNo_BorderNo { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public System.DateTime? RunawayDate { get; set; }
        [DataMember]
        public string ClientComputerName { get; set; }
        [DataMember]
        public string LaborerName { get; set; }
        [DataMember]
        public virtual MOL_Service_Log MOL_Service_Log { get; set; }
    }
}
