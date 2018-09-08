namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_WP200ViolationsCorrections
    {
		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public long? FK_WP200ViolatedUNId { get; set; }
		[DataMember]
        public long? FK_Service_TransactionId { get; set; }
		[DataMember]
        public int? FK_Service_LastServiceStatusId { get; set; }
    }
}
