namespace MOL.EFDAL.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_UserLoginHistory
    {
        public MOL_UserLoginHistory()
        {
        }

        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long UserID { get; set; }
        [DataMember]
        public DateTime AuditDate { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string ClientIP { get; set; }
        [DataMember]
        public int? LoginSourceID { get; set; }
        [DataMember]
        public string ServerIP { get; set; }

        [DataMember]
        public virtual MOL_User MOL_User { get; set; }

    }
}

