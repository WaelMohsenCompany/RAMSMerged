
namespace MOL.EFDAL.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_MonitoredUsersActivity
    {
        public MOL_MonitoredUsersActivity()
        {
        }

        [DataMember]
        public long ID { get; set; }

        [DataMember]
        public DateTime AuditDate { get; set; }

        [DataMember]
        public string SessionID { get; set; }

        [DataMember]
        public long? UserID { get; set; }

        [DataMember]
        public string UserIDNumber { get; set; }

        [DataMember]
        public string IP { get; set; }

        [DataMember]
        public string CurrentURL { get; set; }

        [DataMember]
        public int? ServiceID { get; set; }

        [DataMember]
        public long? EstablishmentID { get; set; }

    }
}